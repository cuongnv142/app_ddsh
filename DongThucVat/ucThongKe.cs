using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace DongThucVat
{
    public partial class ucThongKe : UserControl
    {
        SqlConnection conn;
        string sql = "";

        public ucThongKe()
        {
            InitializeComponent();
            groupBox1.ForeColor = Color.FromArgb(255, 0, 127, 24);
            groupBox2.ForeColor = Color.FromArgb(255, 0, 127, 24);
        }

        public void exportTongQuan(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Hiển thị hộp thoại lưu tệp
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    FileName = "ThongKeTongSoLoai.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(saveFileDialog.FileName, SpreadsheetDocumentType.Workbook))
                    {
                        WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                        workbookPart.Workbook = new Workbook();

                        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                        SheetData sheetData = new SheetData();
                        worksheetPart.Worksheet = new Worksheet(sheetData);

                        Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                        Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "DanhSachLoai" };
                        sheets.Append(sheet);

                        // Thêm tiêu đề cho cột
                        Row headerRow = new Row();
                        string[] headerColumns = { "Ngành", "Lớp", "Bộ", "Họ", "Tổng Số Loài" };
                        foreach (var headerColumn in headerColumns)
                        {
                            Cell headerCell = new Cell(new InlineString(new Text(headerColumn)))
                            {
                                DataType = CellValues.InlineString
                            };
                            headerRow.AppendChild(headerCell);
                        }
                        sheetData.AppendChild(headerRow);

                        // Kết nối đến cơ sở dữ liệu
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        // Truy vấn cơ sở dữ liệu

                        using (SqlCommand cmd = new SqlCommand("ThongKe", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@StartDate", fromDate);
                            cmd.Parameters.AddWithValue("@EndDate", toDate);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Row row = new Row();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Cell cell = new Cell(new InlineString(new Text(reader[i].ToString())))
                                        {
                                            DataType = CellValues.InlineString
                                        };
                                        row.AppendChild(cell);
                                    }
                                    sheetData.AppendChild(row);
                                }
                            }
                        }
                    }

                    MessageBox.Show($"Xuất dữ liệu thành công. Tệp đã được lưu tại: {saveFileDialog.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            string query = "SELECT COUNT(*) AS TongSoLoai FROM Loai";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int tongSoLoai = (int)cmd.ExecuteScalar();

                lbThongBao.Text = "Tổng có " + tongSoLoai + " loài động thực vật trong CSDL.";
            }
        }

        private void btExportChiTiet_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            // Thay đổi truy vấn để lấy dữ liệu phù hợp với yêu cầu của bạn
            sql = "SELECT Loai.name AS Ten, Loai.name_latinh AS TenLatinh, " +
                      "CASE WHEN Loai.loai = 0 THEN N'Động vật' ELSE N'Thực vật' END AS Loai, " +
                      "Ho.name AS Ho, Bo.name AS Bo, Lop.name AS Lop, Nganh.name AS Nganh " +
                      "FROM Loai " +
                      "JOIN Ho ON Loai.id_dtv_ho = Ho.id " +
                      "JOIN Bo ON Ho.id_dtv_bo = Bo.id " +
                      "JOIN Lop ON Bo.id_dtv_lop = Lop.id " +
                      "JOIN Nganh ON Lop.id_dtv_nganh = Nganh.id";

            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Hiển thị hộp thoại lưu tệp
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx|All Files|*.*",
                        FileName = "ThongKeChiTietLoai.xlsx",
                        Title = "Choose a location to save the Excel file"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputPath = saveFileDialog.FileName;

                        // Tạo một tệp Excel mới
                        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(outputPath, SpreadsheetDocumentType.Workbook))
                        {
                            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                            workbookPart.Workbook = new Workbook();

                            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                            SheetData sheetData = new SheetData();
                            worksheetPart.Worksheet = new Worksheet(sheetData);

                            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

                            Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet 1" };
                            sheets.Append(sheet);

                            // Thêm header mới
                            Row headerRow = new Row();
                            string[] headerColumns = { "Tên tiếng Việt", "Tên Latinh", "Loài", "Họ", "Bộ", "Lớp", "Ngành" };
                            foreach (var headerColumn in headerColumns)
                            {
                                Cell headerCell = new Cell(new InlineString(new Text(headerColumn)))
                                {
                                    DataType = CellValues.InlineString
                                };
                                headerRow.AppendChild(headerCell);
                            }
                            sheetData.AppendChild(headerRow);

                            // Đọc dữ liệu từ CSDL và thêm vào tệp Excel
                            while (reader.Read())
                            {
                                Row row = new Row();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Cell cell;
                                    if (reader.GetName(i) == "Loai")
                                    {
                                        cell = new Cell(new InlineString(new Text(reader[i].ToString())))
                                        {
                                            DataType = CellValues.InlineString
                                        };
                                    }
                                    else
                                    {
                                        cell = new Cell(new CellValue(reader[i].ToString()))
                                        {
                                            DataType = CellValues.String
                                        };
                                    }
                                    row.AppendChild(cell);
                                }
                                sheetData.AppendChild(row);
                            }
                        }

                        MessageBox.Show($"Xuất dữ liệu thành công. Tệp đã được lưu tại: {outputPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btExportTongQuan_Click_1(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerFrom.Value;
            DateTime toDate = dateTimePickerTo.Value;
            exportTongQuan(fromDate, toDate);
        }
    }
}
