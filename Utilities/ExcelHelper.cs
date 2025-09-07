using ClosedXML.Excel;
using System.Data;

namespace CArch_V1.Utilities
{
    public static class ExcelHelper
    {
        public static byte[] ExportToExcel<T>(List<T> data, string sheetName = "Sheet1")
        {
            var periode = DateTime.Now;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);

                //title
                var props = typeof(T).GetProperties();
                int lastCol = props.Length; // hitung kolom sesuai jumlah properti

                // ===== Title (Row 1) =====
                worksheet.Cell(1, 1).Value = Constanta.titleReportUser;
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, lastCol).Merge()
                         .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // ===== Periode (Row 2) =====
                worksheet.Cell(2, 1).Value = $"Periode: {periode}";
                worksheet.Cell(2, 1).Style.Font.Italic = true;
                worksheet.Cell(2, 1).Style.Font.FontSize = 12;
                worksheet.Range(2, 1, 2, lastCol).Merge()
                         .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // ===== Tanggal Download (Row 3) =====
                worksheet.Cell(3, 1).Value = $"Tanggal Download: {DateTime.Now:dd MMM yyyy HH:mm}";
                worksheet.Cell(3, 1).Style.Font.Italic = true;
                worksheet.Cell(3, 1).Style.Font.FontSize = 12;
                worksheet.Range(3, 1, 3, lastCol).Merge()
                         .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);


                // Konversi List<T> ke DataTable
                var dt = ToDataTable(data);
                var table = worksheet.Cell(5, 1).InsertTable(dt);

                table.Theme = XLTableTheme.None;
                table.ShowHeaderRow = true;
                table.HeadersRow().Style.Font.Bold = true;

                // Auto adjust lebar kolom
                worksheet.Columns().AdjustToContents();

                // Simpan ke memory stream
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray(); // hasilkan byte[] untuk download
                }
            }
        }

        private static DataTable ToDataTable<T>(List<T> items)
        {
            var dt = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties();

            // Tambahkan kolom
            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Tambahkan data
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}
