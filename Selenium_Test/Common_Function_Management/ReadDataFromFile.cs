//using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using SAFINCA.ParameterAndUserDataMgn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;

namespace SAFINCA.CommonFuncMgn
{
    class ReadDataFromFile
    {
        //static string DYNAMIC_TEST_DATA = "Dynamic_Test_Data_";
        //static string USER_DATA_XLSX = "User_Data.xlsx";
        static string TEST_DATA_XLSX = "Test_Data.xlsx";
        private static string UD = "UD_";
        private static string TD = "TD_";
        private static string DTD = "DTD_";
        



        ///// <summary>
        ///// Read value from excel sheet based on rowName and columnName. Note the column name start with TD_, 
        ///// indicating the file name Test_Data.xlsx or UD_ indicating User_Data.xlsx
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        public static string readInputDataByRowAndColumnName(string key, string value)
        {
            //string pathToDir = CommonUtilities.GetProjectDirectory() + "ParameterAndUserDataMgn\\";
            //string pathToDir = Environment.CurrentDirectory + "\\Test_Data.xlsx";
            string pathToDir = ConfigurationManager.AppSettings["TEST_DATA_PATH"];

            string fileName = getFileName(key, value);

            if (!fileName.Contains(TEST_DATA_XLSX))
            {
                pathToDir = @ConfigParameters.PATH_DYNAMIC_TEST_DATA;
                if (!Directory.Exists(pathToDir))
                {
                    Directory.CreateDirectory(pathToDir);
                }

                if (!File.Exists(pathToDir + fileName))
                {
                    return ParameterAndUserDataMgn.Parameters.DELETED;

                }
                return readValueFromTextFileForGivenKey(pathToDir, fileName, key);
            }
            else
            {
                string cellValue = SAFINCA.ParameterAndUserDataMgn.Parameters.NULL_CHAR;
                Excel.Application xlApp = new Excel.Application(); 
                
                try
                {
                    cellValue = getCell(pathToDir, fileName, key, value, xlApp).Value.ToString();
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                }
                catch (Exception e)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Application.Quit();
                    ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                }
                return cellValue;
            }
        }

        // Function added by Rahul
        public static string readExcelDataByRowAndColumnName(string key, string value)
        {
            //string pathToDir = CommonUtilities.GetProjectDirectory() + "ParameterAndUserDataMgn\\";
            //string pathToDir = Environment.CurrentDirectory + "\\Test_Data.xlsx";
            string pathToDir = ConfigurationManager.AppSettings["TEST_DATA_PATH"];

            string fileName = "Test_Data.xlsx";          
                string cellValue = SAFINCA.ParameterAndUserDataMgn.Parameters.NULL_CHAR;
                Excel.Application xlApp = new Excel.Application();

                try
                {
                    cellValue = getCell(pathToDir, fileName, key, value, xlApp).Value.ToString();
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                }
                catch (Exception e)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Application.Quit();
                    ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                }
                return cellValue;
            
        }

        /// <summary>
        /// Read a value from a text file given the key.
        /// Note the text line in the file should be in the key=value
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string readValueFromTextFileForGivenKey(string pathToFile, string fileName, string key)
        {
            string value = null;
            String[] linesOfFile;
            string filePathFull = pathToFile + fileName;
            try
            {
                linesOfFile = File.ReadAllLines(filePathFull);
            }
            catch
            {
                throw new Exception("The file, " + filePathFull + " is empty or not found");
            }
            for (int l = 0; l < linesOfFile.Length; l++)
            {
                int startIndex = linesOfFile[l].IndexOf("=");
                if (linesOfFile[l].Substring(0, startIndex).Equals(key))
                {
                    value = linesOfFile[l].Substring(startIndex + 1);
                    return value;
                }
            }
            if (value == null)
            {
                throw new Exception("The value for the following key: " + key + " was not found in the file: " + filePathFull);
            }
            return value;
        }

        /// <summary>
        /// Return the cell object in the excel sheet, given the row name and column name
        /// </summary>
        /// <param name="rowName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private static Excel.Range getCell(string pathToDir, string fileName, string rowName, string columnName, Excel.Application xlApp)
        {

            Excel.Range cell;
            String errorMessage = "The value was not found in the Excel sheet. Looking for row name '" + rowName + "' and column '" + columnName + "'.";
            String errorMessageRow = "The row was not found in the Excel sheet. Looking for row name '" + rowName + "' and column '" + columnName + "'.";
            String errorMessageColumn = "The column was not found in the Excel sheet. Looking for row name '" + rowName + "' and column '" + columnName + "'.";


            //Excel.Application xlApp = new Excel.Application();
            // "Test_Data.xlsx"; //Default Excel file name.
            //String SHEET_NAME = getSheetName(rowName, columnName); //Rahul
            String SHEET_NAME = "USER_DATA_TEST";
            Excel.Workbook workbook = xlApp.Workbooks.Open(pathToDir + fileName);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[SHEET_NAME];
            Excel.Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            int columnNameIndex = 0;
            int rowNameIndex = 0;
            try
            {
                for (int c = 1; c <= colCount; c++)
                {
                    string columnNameForCell = range.Cells[1, c].Value.ToString();
                    if (columnNameForCell.ToLower().Replace(" ", "").Equals(columnName.ToLower().Replace(" ", "")))
                    {
                        columnNameIndex = c;
                        break;
                    }
                }
                if (columnNameIndex == 0)
                {
                    xlApp.Workbooks.Close();
                    throw new Exception(errorMessageColumn);
                }
                for (int r = 1; r <= rowCount; r++)
                {
                    string rowNameForCell = range.Cells[r, 1].Value.ToString();
                    if (rowNameForCell.ToLower().Replace(" ", "").Equals(rowName.ToLower().Replace(" ", "")))
                    {
                        rowNameIndex = r;
                        break;
                    }
                }
                //if (rowNameIndex == 0)
                //{
                //    xlApp.Workbooks.Close();
                //    throw new Exception(errorMessageRow);
                //}
                cell = range.Cells[rowNameIndex, columnNameIndex];
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return cell;
        }

        /// <summary>
        /// Write to an excel file.
        /// If the KEY (column) is found in any row. The row will be deleted and the new value with the same key with new value will be added at the end of the file
        /// If now key is found, the new Key and the new value will be added at the end of the file
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void writeDataInToFileByKeyAndValue(string key, string value)
        {
            //string pathToDir = CommonUtilities.GetProjectDirectory() + "ParameterAndUserDataMgn\\";
            string pathToDir = ConfigurationManager.AppSettings["TEST_DATA_PATH"];
            String fileName = getFileName(key, value);

            if (!fileName.Contains(TEST_DATA_XLSX))
            {
                pathToDir = @ConfigParameters.PATH_DYNAMIC_TEST_DATA;
                writeDataToTextFileKeyValue(pathToDir, fileName, key, value);
            }
            else
            {

                writeDataToExcelFileKeyValue(pathToDir, fileName, key, value);
            }
        }

        public static void writeDataInToExcelFileByKeyAndValue(string key, string value)
        {
            
            //string pathToDir = CommonUtilities.GetProjectDirectory() + "ParameterAndUserDataMgn\\";
            string pathToDir = ConfigurationManager.AppSettings["TEST_DATA_PATH"];
            String fileName = "Test_Data.xlsx";
            writeDataToExcelFile(pathToDir, fileName, key, value);

        }

        /// <summary>
        /// Write to a text file in poperty manner, key=value, line by line
        /// If a key word exist on a line, then the old value is replaced by the new value
        /// </summary>
        /// <param name="pathToDir"></param>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void writeDataToTextFileKeyValue(string pathToDir, string fileName, string key, string value)
        {
            if (!Directory.Exists(pathToDir))
            {
                Directory.CreateDirectory(pathToDir);
            }

            string pathToFile = pathToDir + fileName;
            if (File.Exists(pathToDir + fileName))
            {
                String[] linesOfFile = File.ReadAllLines(pathToFile);
                List<string> tempListLinesOfFile = new List<string>();
                bool addNewKeyValue = true;
                for (int l = 0; l < linesOfFile.Length; l++)
                {
                    int startIndex = linesOfFile[l].IndexOf("=");
                    if (!linesOfFile[l].Substring(0, startIndex).Equals(key))
                    {
                        tempListLinesOfFile.Add(linesOfFile[l]);
                    }
                    else
                    {
                        tempListLinesOfFile.Add(key.Trim() + "=" + value.Trim());
                        addNewKeyValue = false;
                    }
                }
                if (addNewKeyValue)
                {
                    tempListLinesOfFile.Add(key.Trim() + "=" + value.Trim());
                }

                File.WriteAllLines(pathToFile, tempListLinesOfFile);
            }
            else
            {
                File.WriteAllLines(pathToFile, new String[] { key.Trim() + "=" + value.Trim() });
            }
        }


        public static void writeDataToExcelFileKeyValue(string pathToDir, string fileName, string key, string value)
        {
            Excel.Workbook workbook;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                String SHEET_NAME = getSheetName(key, value);
                workbook = xlApp.Workbooks.Open(pathToDir + fileName);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[SHEET_NAME];
                Excel.Range range = worksheet.UsedRange;
                int rowCount = range.Rows.Count;
                int rowNameIndex = 0;
                for (int r = 1; r <= rowCount; r++)
                {
                    string rowNameForCell = range.Cells[r, 1].Value.ToString();
                    if (rowNameForCell.Equals(key))
                    {
                        rowNameIndex = r;
                        break;
                    }
                }
                if (rowNameIndex == 0)
                {
                    range.Cells[rowCount + 1, 1] = key;
                    range.Cells[rowCount + 1, 2] = value;
                }
                else
                {
                    range.Rows[rowNameIndex].EntireRow.Delete();
                    range.Cells[rowCount, 1] = key;
                    range.Cells[rowCount, 2] = value;
                }
                xlApp.DisplayAlerts = false;
                long maxTimeToWait = CommonUtilities.GetCurrentTimeMillis() + CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC;
                xlApp.Workbooks.Application.ActiveWorkbook.Save();
                while (!xlApp.Workbooks.Application.ActiveWorkbook.Saved && maxTimeToWait > CommonUtilities.GetCurrentTimeMillis())
                {

                    xlApp.Workbooks.Application.ActiveWorkbook.Save();
                }
                xlApp.Workbooks.Close();
                xlApp.Quit();
                ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);

            }
            catch (Exception e)
            {
                xlApp.DisplayAlerts = false;
                xlApp.Workbooks.Close();
                xlApp.Quit();
                ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                throw new Exception(e.ToString());
            }
        }

        // Function added by Rahul
        public static void writeDataToExcelFile(string pathToDir, string fileName, string key, string value)
        {
            Excel.Workbook workbook;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                //String SHEET_NAME = getSheetName(key, value);
                String SHEET_NAME = "USER_DATA_TEST";
                workbook = xlApp.Workbooks.Open(pathToDir + fileName);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[SHEET_NAME] ;
                Excel.Range range = worksheet.UsedRange;
                int rowCount = range.Rows.Count;
                int rowNameIndex = 0;
                for (int r = 1; r <= rowCount; r++)
                {
                    string rowNameForCell = range.Cells[r, 1].Value.ToString();
                    if (rowNameForCell.Equals(key))
                    {
                        rowNameIndex = r;
                        break;
                    }
                }
                if (rowNameIndex == 0)
                {
                    range.Cells[rowCount + 1, 1] = key;
                    range.Cells[rowCount + 1, 2] = value;
                }
                else
                {
                    range.Rows[rowNameIndex].EntireRow.Delete();
                    range.Cells[rowCount, 1] = key;
                    range.Cells[rowCount, 2] = value;
                }
                xlApp.DisplayAlerts = false;
                long maxTimeToWait = CommonUtilities.GetCurrentTimeMillis() + CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC;
                xlApp.Workbooks.Application.ActiveWorkbook.Save();
                while (!xlApp.Workbooks.Application.ActiveWorkbook.Saved && maxTimeToWait > CommonUtilities.GetCurrentTimeMillis())
                {

                    xlApp.Workbooks.Application.ActiveWorkbook.Save();
                }
                xlApp.Workbooks.Close();
                xlApp.Quit();
                ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);

            }
            catch (Exception e)
            {
                xlApp.DisplayAlerts = false;
                xlApp.Workbooks.Close();
                xlApp.Quit();
                ProcessMgn.killProcessByNames(SAFINCA.ParameterAndUserDataMgn.Parameters.EXCEL_PROCESS_NAME);
                throw new Exception(e.ToString());
            }
        }


        /// <summary>
        /// Return the name of the file, depending on the given prefix
        /// prefix UD_ = User_Data.xlsx
        /// prefix TD_ = Test_Data.xlsx
        /// No prefix = Dynamic_Test_Data.xlsx
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private static string getFileName(string rowName, string columnName)
        {
            String fileName = null; //Default Excel file name.

            if (columnName.Length > 2 && columnName.Substring(0, 3).Equals(UD)) //If given column name starts with UD
            {
                fileName = TEST_DATA_XLSX;
            }

            else if (columnName.Length > 2 && columnName.Substring(0, 3).Equals(TD)) //If given column name starts with UD
            {
                fileName = TEST_DATA_XLSX;
            }
            //else if (columnName.Length > 3 && rowName.Substring(0, 4).Equals("DTD_"))
            else if (rowName.Substring(0, 4).Equals(DTD)) //sometimes columnName.Length can be Null too
            {
                string testCaseFullName = TestContext.CurrentContext.Test.FullName;
                int endIndex = testCaseFullName.LastIndexOf(".");
                string testClassFullName = testCaseFullName.Substring(0, endIndex);
                int startIndex = testClassFullName.LastIndexOf(".");

                string testClassName = testClassFullName.Substring(startIndex + 1);

                int indexSufix = testClassName.IndexOf("_");
                if (indexSufix == -1)
                {
                    fileName = TEST_DATA_XLSX + ConfigParameters.ENVIRONMENT + ".txt";
                }
                else
                {
                    string sufix = testClassName.Substring(indexSufix);
                    fileName = TEST_DATA_XLSX + sufix + "_" + ConfigParameters.ENVIRONMENT + ".txt";
                }
            }
            return fileName;
        }

        /// <summary>
        /// Return the name of a sheet depending on the given prefix/name
        /// No prefix/name = "DYNAMIC_TEST_DATA_" + ConfigParameters.ENVIRONMENT.ToUpper();
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string getSheetName(string rowName, string columnName)
        {
            string SHEET_NAME = null;
            if (columnName.Length > 3 && columnName.Substring(0, 3).Equals(UD)) //If given column name starts with UD
            {
                SHEET_NAME = "USER_DATA_" + ConfigParameters.ENVIRONMENT.ToUpper();//ConfigurationManager.AppSettings["USER_DATA_SHEET_NAME"];
            }
            else if (columnName.Length > 8 && columnName.Substring(0, 3).Equals(TD))
            {
                SHEET_NAME = "TEST_DATA_" + ConfigParameters.ENVIRONMENT.ToUpper(); // ConfigurationManager.AppSettings["TD_226_00_DEV"];
            }
            //else if (columnName.Length > 8 && columnName.Substring(0, 9).Equals("TD_226_31"))
            //{
            //    SHEET_NAME = ConfigurationManager.AppSettings["TD_226_31_DEV"];
            //}
            //else if (columnName.Length > 8 && columnName.Substring(0, 9).Equals("TD_226_20"))
            //{
            //    SHEET_NAME = ConfigurationManager.AppSettings["TD_226_20_DEV"];
            //}
            //else if (columnName.Length > 5 && columnName.Substring(0, 6).Equals("TD_GEN"))
            //{
            //    SHEET_NAME = ConfigurationManager.AppSettings["TD_GEN_DEV"];
            //}
            //else if (columnName.Length > 4 && columnName.Substring(0, 5).Equals("TD_SV"))
            //{
            //    SHEET_NAME = ConfigurationManager.AppSettings["TD_SV_DEV"];
            //}

            else if (rowName.Substring(0, 4).Equals("DTD_"))
            {
                SHEET_NAME = TEST_DATA_XLSX + ConfigParameters.ENVIRONMENT.ToUpper();
            }
            return SHEET_NAME;
        }

        /// <summary>
        /// check if the value is aimed to be read from excel or not
        /// Prefix TD_(Test Data), UD_(User Data) and _ (dynamic test data)
        /// </summary>
        /// <param name="rowNameAndColumnName"></param>
        /// <returns></returns>
        public static string readInputDataByRowAndColumnName(params string[] rowNameAndColumnName)
        {
            string commaSeperateString = "";
            if (rowNameAndColumnName.Length > 1 && (rowNameAndColumnName[1].Contains("TD_") || rowNameAndColumnName[1].Contains("UD_") || rowNameAndColumnName[0].Contains("DTD_")))
            {
                return readInputDataByRowAndColumnName(rowNameAndColumnName[0], rowNameAndColumnName[1]);
            }
            else if (rowNameAndColumnName.Length > 0)
            {

                commaSeperateString = rowNameAndColumnName[0];
                for (int i = 1; i < rowNameAndColumnName.Length; i++)
                {
                    commaSeperateString = commaSeperateString + "," + rowNameAndColumnName[i];
                }
                return commaSeperateString;
            }

            return commaSeperateString;
        }
    }
}
