using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using Autofac;

namespace EEPlusTest
{
    class Program
    {
        private static IContainer container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            builder.RegisterType<SayHi>().As<IOutputHello>();
            container = builder.Build();
            WriteDate();
        }

        private static void WriteDate()
        {
            // create the scope, resolve your IDateWriter.
            // use it, then dispose of the scope.
            using (var scope = container.BeginLifetimeScope())
            {
                var say = scope.Resolve<IOutputHello>();
                say.SayHello();

                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

        private static void SetExcelStyle(ExcelPackage package)
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
            picture = sheet.Drawings.AddPicture("Logo", Image.FromFile(@"firstbg.jpg"), new ExcelHyperLink("http://www.cnblogs.com", UriKind.Relative));

            // add Hyperlink for cell
            sheet.Cells[1, 1].Hyperlink = new ExcelHyperLink("Http://www.cnblogs.com", UriKind.Relative);

            // hide sheet
            sheet.Hidden = eWorkSheetHidden.Hidden;
            sheet.Column(1).Hidden = true;
            sheet.Row(1).Hidden = true;
        }

        private static void SetExcelChartDemo(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("test");

            worksheet.Cells.Style.WrapText = true;
            worksheet.View.ShowGridLines = false;//去掉sheet的网格线

            worksheet.Cells[1, 1].Value = "名称";
            worksheet.Cells[1, 2].Value = "价格";
            worksheet.Cells[1, 3].Value = "销量";

            worksheet.Cells[2, 1].Value = "大米";
            worksheet.Cells[2, 2].Value = 56;
            worksheet.Cells[2, 3].Value = 100;

            worksheet.Cells[3, 1].Value = "玉米";
            worksheet.Cells[3, 2].Value = 45;
            worksheet.Cells[3, 3].Value = 150;

            worksheet.Cells[4, 1].Value = "小米";
            worksheet.Cells[4, 2].Value = 38;
            worksheet.Cells[4, 3].Value = 130;

            worksheet.Cells[5, 1].Value = "糯米";
            worksheet.Cells[5, 2].Value = 22;
            worksheet.Cells[5, 3].Value = 200;

            using (ExcelRange range = worksheet.Cells[1, 1, 5, 3])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            using (ExcelRange range = worksheet.Cells[1, 1, 1, 3])
            {
                range.Style.Font.Bold = true;
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Name = "微软雅黑";
                range.Style.Font.Size = 12;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
            }

            worksheet.Cells[1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));

            worksheet.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));

            worksheet.Cells[3, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[3, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[3, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));

            worksheet.Cells[4, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[4, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[4, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));

            worksheet.Cells[5, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[5, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));
            worksheet.Cells[5, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(191, 191, 191));

            ExcelChart chart = worksheet.Drawings.AddChart("chart", eChartType.ColumnClustered);

            ExcelChartSerie serie = chart.Series.Add(worksheet.Cells[2, 3, 5, 3], worksheet.Cells[2, 1, 5, 1]);
            serie.HeaderAddress = worksheet.Cells[1, 3];

            chart.SetPosition(150, 10);
            chart.SetSize(500, 300);
            chart.Title.Text = "销量走势";
            chart.Title.Font.Color = Color.FromArgb(89, 89, 89);
            chart.Title.Font.Size = 15;
            chart.Title.Font.Bold = true;
            chart.Style = eChartStyle.Style15;
            chart.Legend.Border.LineStyle = eLineStyle.Solid;
            chart.Legend.Border.Fill.Color = Color.FromArgb(217, 217, 217);

            package.Save();
        }
        
        private static void SetExcelChart(ExcelPackage package)
        {
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("chart");
            // eChartType define chart type.
            ExcelChart chart = sheet.Drawings.AddChart("chart", eChartType.ColumnClustered);
            // set xAxis and yAxis
            ExcelChartSerie serie = chart.Series.Add(sheet.Cells[2, 3, 5, 3], sheet.Cells[2, 1, 5, 1]);
            // set legend for chart
            serie.HeaderAddress = sheet.Cells[1, 3];
            // set style for chart
            chart.SetPosition(150, 10);
            chart.SetSize(500, 300);
            chart.Title.Text = "Chart Title";
            chart.Title.Font.Color = Color.FromArgb(89, 89, 89);
            chart.Title.Font.Bold = true;
            chart.Title.Font.Size = 15;
            chart.Style = eChartStyle.Style15;
            chart.Legend.Border.LineStyle = eLineStyle.Solid;
            chart.Legend.Border.Fill.Color = Color.FromArgb(217, 217, 217);
        }

        private static void SetVBAScript(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("chart");
            // add vba scripts
            worksheet.CodeModule.Name = "sheet";
            worksheet.CodeModule.Code = File.ReadAllText(@"", Encoding.Default);

            // protected and lock
            worksheet.Protection.IsProtected = true;
            worksheet.Protection.SetPassword("pwd");
            // set right
            worksheet.Protection.AllowAutoFilter = false;
            worksheet.Protection.AllowDeleteColumns = false;
            worksheet.Protection.AllowDeleteRows = false;
            worksheet.Protection.AllowEditScenarios = false;
            worksheet.Protection.AllowEditObject = false;
            worksheet.Protection.AllowFormatCells = false;
            worksheet.Protection.AllowFormatColumns = false;
            worksheet.Protection.AllowFormatRows = false;
            worksheet.Protection.AllowInsertColumns = false;
            worksheet.Protection.AllowInsertHyperlinks = false;
            worksheet.Protection.AllowInsertRows = false;
            worksheet.Protection.AllowPivotTables = false;
            worksheet.Protection.AllowSelectLockedCells = false;
            worksheet.Protection.AllowSelectUnlockedCells = false;
            worksheet.Protection.AllowSort = false;

            // set property
            package.Workbook.Properties.Title = "Excel Title";
            package.Workbook.Properties.Author = "Autor";
            package.Workbook.Properties.Comments = "This is a test comment";
            package.Workbook.Properties.Company = "Company";
            package.Workbook.Properties.Created = DateTime.Now;
            package.Workbook.Properties.Modified = DateTime.Now;

            // set dropdown list
            // method 1
            var ddl = worksheet.DataValidations.AddListValidation(worksheet.Cells[7, 8].Address); // set dropdown list data range
            ddl.Formula.ExcelFormula = "=parameter";
            ddl.Prompt = "Alter";
            ddl.ShowInputMessage = true;

            // method 2
            ExcelRange range = worksheet.Cells[1, 100];
            ddl = worksheet.DataValidations.AddListValidation(range.Address);
            string strData = "A;B;C;D;E";
            string[] data = strData.Split(';');
            for (int i = 0; i < data.Length; i++)
            {
                ddl.Formula.Values.Add(data[i]);
            }
        }
    }
}
