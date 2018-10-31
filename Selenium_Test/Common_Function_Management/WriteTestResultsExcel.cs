using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.Threading;
using System.Drawing;
using System.Configuration;
using System.IO;

using System.Diagnostics;
using SAFINCA.Application.Web.Selenium;
using SAFINCA.LogMgn;
using SAFINCA.CommonFuncMgn;
using OfficeOpenXml.Style.XmlAccess;

namespace SAFINCA.Common_Function_Management
{

    public static class WriteTestResultsExcel
    {

        public static ExcelPackage excelPackage = null;
        public static ExcelWorksheet testCaseWorkSheet = null;
        public static ExcelWorksheet testStepWorkSheet = null;
        public static FileInfo testTemplate = null;
        public static FileInfo testResultFile = null;
        public static String testResultFilePath = null;
        public static String errorTestResultFilePath = null;

        public static String currentTestname = null;
        public static int currentTestId;

        //Report Results Path
        public static string templatePath = Environment.CurrentDirectory + "\\Test_Results_Template.xlsx";
        
        public static string resultFolderPath = ConfigurationManager.AppSettings["AUTOMATION_TEST_RESULTS_PATH"];

        //Test Case & Test Step Counter
        public static int testCaseIDCounter = 1;
        public static int testStepIDCounter = 1;

        //Row Index for both worksheets
        public static int tc_RowIndex = 7;
        public static int ts_RowIndex = 7;

        //Common Column Index for both Sheets
        public static int testCaseId_ColIndex = 5;
        public static int testCaseName_ColIndex = 6;

        //Columns for Test Case Results worksheet
        public static int tc_testCaseDesc_ColIndex = 7;
        public static int tc_testCaseResult_ColIndex = 8;

        //Columns for Test Step Results worksheet
        public static int ts_testStepId_ColIndex = 7;
        public static int ts_testStepName_ColIndex = 8;
        public static int ts_testStepDesc_ColIndex = 9;
        public static int ts_testStepResult_ColIndex = 10;
        public static int ts_testStepError_ColIndex = 11;
        public static int ts_testStepScreenShot_ColIndex = 12;
        public static bool currentTestExecutionFlag = false;
        public static bool subTestFailure = false;
        public static MemoryStream holdingStream;

        //Named Style
        public static ExcelNamedStyleXml namedStyle = null;

        public static int tc_Hierachy_Counter = 0;



        public static void setTestClassStart(String testClassName,String dateTime)
        {
            try
            {
                SAFINCALog.Info("Executing Test Cases for Class Started for Class : " + testClassName);

                errorTestResultFilePath = null;

                //For Directory
                if (!Directory.Exists(resultFolderPath))
                {
                    resultFolderPath = resultFolderPath + "_" + dateTime;
                    Directory.CreateDirectory(resultFolderPath);
                    System.IO.File.Copy(@Environment.CurrentDirectory + "\\Test_Results_Template.xlsx", resultFolderPath + "\\Test_Results" + "_" + dateTime + ".xlsx");
                }

                testResultFilePath = resultFolderPath + "\\Test_Results" + "_" + dateTime + ".xlsx";

                testResultFile = new FileInfo(testResultFilePath);

                excelPackage = new ExcelPackage(testResultFile);

                testCaseWorkSheet = excelPackage.Workbook.Worksheets.First();

                testStepWorkSheet = excelPackage.Workbook.Worksheets.Last();

            }

            catch (Exception e)
            {
                SAFINCALog.TestCaseErrorMessage(e);
            }

        }

        public static void setTestClassFinish(String testClassName)
        {
            try
           
            {
                SAFINCALog.Info("Executing Test Cases Finished for Class  : " + testClassName);

                excelPackage.SaveAs(testResultFile);

                excelPackage.Dispose();

               // excelPackage.Load(holdingStream);

               SAFINCALog.Info("Saving Test Results for Class : "+testClassName+" in path -> "+testResultFilePath);
            }
            catch (Exception e)
            {
                SAFINCALog.TestCaseErrorMessage(e);
            }
            finally
            {
                //tc_RowIndex = 7; ts_RowIndex = 7; testCaseIDCounter = 1;
                testStepIDCounter = 1;
            }
        }

        public static void setTestCaseErrorMessage(Exception e)
        {
            SAFINCALog.TestCaseErrorMessage(e);

        }

        public static void setTestCaseStart(String testCaseName, String testCaseDescription)
        {
            if (tc_Hierachy_Counter==0 &&!currentTestExecutionFlag)
            {
                //set Current Test Case Name
                currentTestname = testCaseName;

                //set Current Test Id
                currentTestId = testCaseIDCounter;

                //Set Test Case ID
                testCaseWorkSheet.Cells[tc_RowIndex, testCaseId_ColIndex].Value = testCaseIDCounter;

                //Set Test Case Name
                testCaseWorkSheet.Cells[tc_RowIndex, testCaseName_ColIndex].Value = testCaseName;

                //set Test Case Desc
                testCaseWorkSheet.Cells[tc_RowIndex, tc_testCaseDesc_ColIndex].Value = testCaseDescription;

                //Increment the counter
                testCaseIDCounter++;
                
                currentTestExecutionFlag = true;
            }

            else
            {
                tc_Hierachy_Counter++;

                currentTestExecutionFlag = false;
            }
        }

        public static void setTestCaseFinish(String status)
        {

            if (currentTestExecutionFlag && tc_Hierachy_Counter==0)
            {
                //set Test Case Result
                testCaseWorkSheet.Cells[tc_RowIndex, tc_testCaseResult_ColIndex].Value = status;

                //Increment the Row Counter
                tc_RowIndex++;

                //Reset Step Counter
                testStepIDCounter = 1;

                currentTestExecutionFlag = false;

                //holdingStream.SetLength(0);
                //excelPackage.Stream.Position = 0;
               // excelPackage.Stream.CopyTo(holdingStream);
            }

            else
            {
                tc_Hierachy_Counter--;
                currentTestExecutionFlag = true;
            }
        }

        public static void setTestStepStart(String testStepName, String testStepDescription)
        {
            //Set Test Case ID
            testStepWorkSheet.Cells[ts_RowIndex, testCaseId_ColIndex].Value = currentTestId;

            //Set Test Case Name
            testStepWorkSheet.Cells[ts_RowIndex, testCaseName_ColIndex].Value = currentTestname;

            //Set Test Step ID
            testStepWorkSheet.Cells[ts_RowIndex, ts_testStepId_ColIndex].Value = testStepIDCounter;

            //Set Test Step Name
            testStepWorkSheet.Cells[ts_RowIndex, ts_testStepName_ColIndex].Value = testStepName;

            //Set Test Step Desc
            testStepWorkSheet.Cells[ts_RowIndex, ts_testStepDesc_ColIndex].Value = testStepDescription;

            //Set WrapText
            testStepWorkSheet.Cells[ts_RowIndex, testCaseName_ColIndex].Style.WrapText = true;
            testStepWorkSheet.Cells[ts_RowIndex, ts_testStepName_ColIndex].Style.WrapText = true;
            testStepWorkSheet.Cells[ts_RowIndex, ts_testStepDesc_ColIndex].Style.WrapText = true;


            //Increment the Test Step Counter
            testStepIDCounter++;
        }

        public static void setTestStepFinish(String status, Exception e)
        {

           
            try
            {
                // Test Step Error & ScreenShot Style
                testStepWorkSheet.Cells[ts_RowIndex, ts_testStepError_ColIndex].Style.WrapText = true;
                testStepWorkSheet.Cells[ts_RowIndex, ts_testStepScreenShot_ColIndex].Style.WrapText = true;

                if (status.Equals("Pass"))
                {
                    //Set Test Step Result to Pass
                    testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Value = status;

                    testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);

                    //set Test Step Error to NA
                    testStepWorkSheet.Cells[ts_RowIndex, ts_testStepError_ColIndex].Value = "NA";

                    //set Test Step Screenshot location to NA
                    testStepWorkSheet.Cells[ts_RowIndex, ts_testStepScreenShot_ColIndex].Value = "NA";

                    if (tc_Hierachy_Counter > 0) { subTestFailure = false; }
                }

                else
                {
                    // Check for sub test case failure
                    if (!subTestFailure)
                    {
                        //Set Test Step Result to Fail
                        testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Value = status;

                        //Set the color of the status
                        testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        testStepWorkSheet.Cells[ts_RowIndex, ts_testStepResult_ColIndex].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);



                        //Write Error Message in Excel
                        testStepWorkSheet.Cells[ts_RowIndex, ts_testStepError_ColIndex].Value = e.Message;

                        //set the width of the error column
                        testStepWorkSheet.Column(ts_testStepError_ColIndex).Width = 50;
                        testStepWorkSheet.Cells[ts_RowIndex, ts_testStepError_ColIndex].Style.WrapText = true;
                        testStepWorkSheet.Row(ts_RowIndex).Height = 50;
                        //testStepWorkSheet.Column(ts_testStepError_ColIndex).AutoFit();

                        CommonUtilities.CreateAndSaveScreenShot(resultFolderPath + "\\" + currentTestname + ".png");

                        Thread.Sleep(3 * 1000);

                        var uri = new Uri(resultFolderPath + "\\" + currentTestname + ".png");

                        errorTestResultFilePath = resultFolderPath + "\\" + currentTestname + ".png";

                        var cell = testStepWorkSheet.Cells[ts_RowIndex, ts_testStepScreenShot_ColIndex];

                        //cell.Hyperlink = new Uri(Environment.CurrentDirectory + "\\" + currentTestname + ".png"); 

                        // cell.Hyperlink = new Uri(Environment.CurrentDirectory + "\\" + currentTestname + ".png");

                        if (!(namedStyle != null))
                        {
                            namedStyle = testStepWorkSheet.Workbook.Styles.CreateNamedStyle("HyperLink");
                            namedStyle.Style.Font.UnderLine = true;
                            namedStyle.Style.Font.Color.SetColor(Color.Blue);
                        }

                        cell.Hyperlink = new ExcelHyperLink(uri.AbsoluteUri.ToString());

                        cell.StyleName = "HyperLink";
                        cell.Value = currentTestname + ".png";
                        if (tc_Hierachy_Counter > 0) { subTestFailure = true; }
                    }

                }

                //Increment the Row Counter
                ts_RowIndex++;
            }
            catch (Exception ex)
            {
                SAFINCALog.Info("Error Writing data to excel "+ex);
            }

        }




    }
}
