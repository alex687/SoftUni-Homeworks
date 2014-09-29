using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace LINQtoExcel
{
    class ExcelGenerator
    {
        private string filePath;
        private string fileTitle;
        private string[] headerItems;
        private List<Student> list;

        public ExcelGenerator(string filePath, string fileTitle, string[] headerItems, List<Student> list)
        {
            this.filePath = filePath;
            this.fileTitle = fileTitle;
            this.headerItems = headerItems;
            this.list = list;
        }

        public void Generate()
        {
            FileInfo newFile = new FileInfo(this.filePath);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(this.filePath);
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(this.fileTitle);
                for (int i = 0; i < this.headerItems.Length; i++)
                {
                    int col = i + 1;
                    worksheet.Cells[1,  col].Value = this.headerItems[i];
                }
                
                var properties = typeof (Student).GetProperties();
                for (int i = 0; i < this.list.Count; i++)
                {
                    int row = i + 2;
                    int col = 1;
                    foreach (var property in properties)
                    {
                        worksheet.Cells[row, col].Value = property.GetValue(list[i]);
                        col++;
                    }
                }
                using (var range = worksheet.Cells[1, 1, 1, 13])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Brown);
                    range.Style.Font.Color.SetColor(Color.White);
                }

                package.Workbook.Properties.Title = this.fileTitle;
                package.Save();
            }
        }
    }
}
