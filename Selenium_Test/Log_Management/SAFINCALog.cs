using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAFINCA.ParameterAndUserDataMgn;
using log4net;
using System.Diagnostics;
using System.IO;
using log4net.Config;
using SAFINCA.CommonFuncMgn;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace SAFINCA.LogMgn
{
    public class SAFINCALog : ConfigParameters
    {
        public static readonly ILog logger = LogManager.GetLogger(typeof(SAFINCALog));

        static int numberOfFailedTests;
        static int numberOfExecutedTests;
        static int numberOfSucceededTests;
        static bool isPreviousTestCaseFailed;

        public static bool IsPreviousTestCaseSucceeded
        {
            get { return SAFINCALog.isPreviousTestCaseFailed; }
            set { SAFINCALog.isPreviousTestCaseFailed = value; }
        }

        public static int NumberOfSucceededTests
        {
            get { return SAFINCALog.numberOfSucceededTests; }
            set { SAFINCALog.numberOfSucceededTests = value; }
        }

        public static int NumberOfExecutedTests
        {
            get { return SAFINCALog.numberOfExecutedTests; }
            set { SAFINCALog.numberOfExecutedTests = value; }
        }
        static int totalNumberOfTestToRun;

        public static int TotalNumberOfTestsToRun
        {
            get { return totalNumberOfTestToRun; }
            set { totalNumberOfTestToRun = value; }
        }
        public static void Debug(String classAndMethodName, params String[] debugMessageToLog)
        {
            logger.Debug(ArrayToStringMessage(classAndMethodName,debugMessageToLog));
        }

        public static void Info(String classAndMethodName, params String[] infoMessageToLog)
        {
            logger.Info(ArrayToStringMessage(classAndMethodName, infoMessageToLog));
        }

        public static void Error(String classAndMethodName, params String[] errorMessageToLog)
        {
            logger.Error(ArrayToStringMessage(classAndMethodName, errorMessageToLog));
        }

        public static String TestStep(String classAndMethodName, params String[] testStepMessageToLog)
        {

            Thread.Sleep(ConfigParameters.GENERAL_DELAY_FOR_EACH_TEST_STEP);
            string readValueFromFile="";
            if (testStepMessageToLog.Length > 1 && (testStepMessageToLog[1].Contains("TD_") || testStepMessageToLog[1].Contains("UD_") || testStepMessageToLog[0].Contains("DTD_")))
            {
                //readValueFromFile = ReadDataFromFile.readInputDataByRowAndColumnName(testStepMessageToLog);
                //logger.Info(ArrayToStringMessage(classAndMethodName, readValueFromFile, testStepMessageToLog));
            }
            else
            { 
                logger.Info(ArrayToStringMessage(classAndMethodName, testStepMessageToLog));
                readValueFromFile = (testStepMessageToLog.Length>0) ? testStepMessageToLog[0]: "" ;
            }
            return readValueFromFile;
        }

        public static void Warning(String classAndMethodName,params String[] warningMessageToLog)
        {
            logger.Warn(ArrayToStringMessage(classAndMethodName, warningMessageToLog));

        }

        private static String ArrayToStringMessage(String classAndMethodName, params String[] str)
        {
            String messageToLog = "";
            for (int i = 0; i < str.Length; i++)
            {
                messageToLog = " :" + str[i];
            }
            return classAndMethodName + messageToLog;
        }

        private static String ArrayToStringMessage(String classAndMethodName, string readValueFromFile, params String[] str)
        {
            String messageToLog = "";
            for (int i = 0; i < str.Length; i++)
            {
                messageToLog = " :" + str[i];
            }
            //readValueFromFile = (readValueFromFile !="") ? ": "+ readValueFromFile : readValueFromFile;
            return classAndMethodName + messageToLog + readValueFromFile;
        }

        public static void TestClassStart(TestContext testContext)
        {
            SAFINCALog.IsPreviousTestCaseSucceeded = true;
            logger.Info("\n###################################################\n" +
                        "##\n" +
                        "####TEST CLASS " + testContext.TestName + " STARTS" +
                        "\n##\n" +
                        "####################################################\n");
        }

        public static void TestClassEnd(TestContext testContext)
        {
            logger.Info("###################################################\n" +
                    "##\n" +
                    "####TEST CLASS " + testContext.TestName + " ENDS###" +
                    "\n##\n" +
                    "#######################################################\n");
        }

        public static void TestCaseStart(TestContext testContext)
        {
            logger.Info("\n****************************************************************\n" +
                        "**************TEST CASE, " + testContext.TestName + ", STARTS**************" +
                "\n***********************************************************\n");
        }

        public static void TestCaseFinish(TestContext testContext)
        {
            logger.Info("\n****************************************************************\n" +
                        "**************TEST CASE, " + testContext.TestName + ", FINISHED**************" +
                "\n***********************************************************\n");
        }

        public static void TestCaseFailed(TestContext testContext)
        {
            logger.Info("****************************************************************\n" +
                        "**************TEST CASE, " + testContext.TestName + " FAILED**************" +
                        "\n***********************************************************\n");
        }


        public static void TestCaseEnd(TestResult result)
        {
            string testResult="SUCCEEDED";
            ++numberOfSucceededTests;
            string message = "";
            if (result.ResultState == ResultState.Error || result.ResultState == ResultState.Failure)
            {
                --numberOfSucceededTests;
                ++numberOfFailedTests;
                testResult= "FAILED";
                message = "\n*************************ERROR MESSAGE *************************\n" + result.Message;
            }
            logger.Info("\n*****************************"+testResult+"***********************************" +
                        "\n************ Total number of executed tests : " + ++numberOfExecutedTests + "("+totalNumberOfTestToRun+") *********"+
                        "\n************ Total number of failed tests: " + numberOfFailedTests + " ***********" +
                        "\n**************TEST CASE, " + result.Name.ToUpper() + ", ENDS**************" +
                        message + 
                        "\n***********************************************************\n");
        }


        public static void TestCaseErrorMessage(Exception e)
        {
            logger.Info("\n--------------ERROR MESSGE:--------------\n" + e.Message +
                    "\n--------------STACK TRACE:--------------\n");
            //StringWriter  stringWriter = new StringWriter(); 
            //StreamReader streamReader = new StreamReader();
            logger.Info(e.StackTrace);

        }

        public static void TestClassPostConditionStarts()
        {
            logger.Info("-------------TEST CLASS POSTCONDITION STARTS--------------\n");
        }
        public static void TestCasePostConditionStarts()
        {
            logger.Info("-------------TEST CASE POSTCONDITION STARTS--------------\n");
        }

        public static void TestCasePreConditionEnds()
        {
            logger.Info("-------------TEST CASE PRECONDITION ENDS--------------\n");
        }

        public static void TestCasePreConditionStarts()
        {
            logger.Info("-------------TEST CASE PRECONDITION STARTS--------------\n");
        }

        public static void PrintApplicationConfigurations()
        {
                logger.Info("######### WINDOWS/DESKTOP APPLICATION	###########");		
                //logger.Info("PATH_APPLICATION_TO_LAUNCH_CATIA_5".PadRight(60) + ConfigParameters.PATH_APPLICATION_TO_LAUNCH	+"");
                //logger.Info("PATH_APPLICATION_TO_LAUNCH_CATIA_5_EXTENTION".PadRight(60) + ConfigParameters.PATH_APPLICATION_TO_LAUNCH_EXTENTION + "");
                //logger.Info(" APPLICATION_PROCESS_NAME".PadRight(60) + ConfigParameters.APPLICATION_PROCESS + "");
                //logger.Info(" MAIN_MENU_APPLICATION_DEFAULT_SUB_MENU_NAMES".PadRight(60) + ConfigParameters.MAIN_MENU_APPLICATION_DEFAULT_SUB_MENU_NAMES + "");
                logger.Info(" APPLICATION_TO_LAUNCH_CATIA_5_PASSWORD".PadRight(60) + "*****");
                logger.Info("\n\n######### WEB APPLICATION	###########");
                logger.Info(" WEB_BROWSER_TO_RUN".PadRight(60) + ConfigParameters.WEB_BROWSER_TO_RUN	+"");
                logger.Info(" WEB_APPLICATION_URL".PadRight(60) + ConfigParameters.WEB_APPLICATION_URL	+"");
                logger.Info("WEB_APPLICATION_ENOVIA_PORTAL_PASSWORD*****   ");
                logger.Info("\n\n######### WEB AND DESKOP APPLICATION PROCESSES TO KILL ###########");
                logger.Info(" KILL_APPLICATION_PROCCESS".PadRight(60) + ConfigParameters.KILL_APPLICATION_PROCCESS	+"");
                logger.Info(" APPLICATION_PROCESS_NAMES_TO_KILL".PadRight(60) + ConfigParameters.APPLICATION_PROCESS_NAMES_TO_KILL	+"");
                logger.Info("\n\n######### TIME OUT PARAMETERS FOR WEB AND DESKTOP APPLICATIONS	###########");
                logger.Info(" GLOBAL_TIMEOUT_TIME_IN_MSEC".PadRight(60) + ConfigParameters.GLOBAL_TIMEOUT_TIME_IN_MSEC	+"");
                logger.Info(" START_APPLICATION_TIMEOUT_TIME_IN_MSEC".PadRight(60) + ConfigParameters.START_APPLICATION_TIMEOUT_TIME_IN_MSEC	+"");
        }

        public static String LogStackTrace(Exception e)
        {
            logger.Info(e.Message);
            StringWriter stringWriter = new StringWriter();
            //PrintWriter printWriter = new PrintWriter(stringWriter);
            //e.printStackTrace(printWriter);
            return e.Message;
        }



    }
}