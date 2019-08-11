using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace EEPlusTest
{
    public class EEPlus
    {
        public void CreateXlsx(string fileName)
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                // Craete a workSheet
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Test");
                package.Save();
            }
        }

        public void CreateXlsx(string fileName, Action<ExcelPackage> actionHandle)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                fileInfo = new FileInfo(fileName);
            }
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                if (actionHandle != null)
                {
                    actionHandle.Invoke(package);
                }
                package.Save();
            }
        }
    }
}
