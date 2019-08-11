using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Drawing;

namespace EEPlusTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Wrold!");
            EEPlusTest.EEPlus ep = new EEPlus();
            ep.CreateXlsx("C:/1.xlsx", package =>
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("test");
                sheet.Cells[1, 1].Value = "Project Name";
                sheet.Cells[1, 2].Value = "Project Price";
                sheet.Cells[1, 3].Value = "Sale Percent";

                sheet.Cells[2, 1].Value = "Rice";
                sheet.Cells[2, 2].Value = 65;
                sheet.Cells[2, 3].Value = 100;
                sheet.Cells["D2:D2"].Formula = "B2*C2";

                sheet.Cells[3, 1].Value = "玉米";
                sheet.Cells[3, 2].Value = 45;
                sheet.Cells[3, 3].Value = 150;
                sheet.Cells["D3:D3"].Formula = "B3*C3";

                sheet.Cells[4, 1].Value = "小米";
                sheet.Cells[4, 2].Value = 38;
                sheet.Cells[4, 3].Value = 130;
                sheet.Cells["D4:D4"].Formula = "B4*C4";

                sheet.Cells[5, 1].Value = "糯米";
                sheet.Cells[5, 2].Value = 22;
                sheet.Cells[5, 3].Value = 200;
                sheet.Cells["D5:D5"].Formula = "B5*C5";

                // auto sum
                //sheet.Cells[6, 2, 6, 4].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(2, 2, 5, 2).Address);
                // set cell formula, and keep two decimals.
                sheet.Cells[5, 3].Style.Numberformat.Format = "#,##0.00";
                sheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells[1, 4, 1, 5].Merge = true; // merge cell
                sheet.Cells.Style.WrapText = true; // auto new line

                // set backgroud
                sheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));

                // set border
                sheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
                sheet.Cells[1, 1].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheet.Cells[1, 1].Style.Border.Bottom.Color.SetColor(Color.FromArgb(191, 191, 191));
            
                // set cell row height and column width
                sheet.Cells.Style.ShrinkToFit = true;// auto adapter
                sheet.Row(1).Height = 15;// set row height
                sheet.Row(1).CustomHeight = true;// auto adapter row height
                sheet.Column(1).Width = 15;// set column width.

                // set sheet background
                sheet.View.ShowGridLines = false;// remove grid line
                sheet.Cells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray); // set backgroud color
                sheet.BackgroundImage.Image = Image.FromFile(@"firstbg.jpg");// set backgroud image

                // insert image
                ExcelPicture picture = sheet.Drawings.AddPicture("Logo", Image.FromFile(@"firstbg.jpg"));
                picture.SetPosition(100, 100);// set picture position
                picture.SetSize(100, 100);

                // insert shape
                ExcelShape shape = sheet.Drawings.AddShape("shape", eShapeStyle.Rect);
                shape.Font.Color = Color.Red;
                shape.Font.Size = 15;
                shape.Font.Bold = true;
                shape.Fill.Style = eFillStyle.NoFill;
                shape.Border.Fill.Style = eFillStyle.NoFill;
                shape.SetPosition(200, 300);
                shape.SetSize(80, 30);
                shape.Text = "Text";

                // add Hyperlink for image
                ExcelPicture picture = sheet.Drawings.AddPicture("Logo", Image.FromFile(@"firstbg.jpg"), new ExcelHyperLink("http://www.cnblogs.com", UriKind.Relative));

                // add Hyperlink for cell
                sheet.Cells[1, 1].Hyperlink = new ExcelHyperLink("Http://www.cnblogs.com", UriKind.Relative);

                // hide sheet
                sheet.Hidden = eWorkSheetHidden.Hidden;
                sheet.Column(1).Hidden = true;
                sheet.Row(1).Hidden = true;
            });
        }
    }
}
