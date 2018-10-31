using SAFINCA.LogMgn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFINCA.ParameterAndUserDataMgn
{
    public class ConfigParameters
    {
        //ENVIRONMENT
        public static string ENVIRONMENT = ConfigurationManager.AppSettings["ENVIRONMENT"];
        public static string APPLICATION_VERSION = ConfigurationManager.AppSettings["APPLICATION_VERSION"];
        public static bool IS_TEST_RUNNING_THROUGH_JENKINS = bool.Parse(ConfigurationManager.AppSettings["IS_TEST_RUNNING_THROUGH_JENKINS"]);
        
        public static string MAIN_WINDOW_APPLICATION = ConfigurationManager.AppSettings["MAIN_WINDOW_APPLICATION"];
        public static string PATH_APPLICATION_TO_LAUNCH = ConfigurationManager.AppSettings["PATH_APPLICATION_TO_LAUNCH"];
        public static string PATH_APPLICATION_TO_LAUNCH_EXTENTION = (ConfigurationManager.AppSettings["PATH_APPLICATION_TO_LAUNCH_EXTENTION"]);
       

        //WINDOWS/DESKTOP APPLICATION
        public static string APPLICATION_PROCESS_NAME = ConfigurationManager.AppSettings["APPLICATION_PROCESS_NAME"];
        public static bool START_DESKTOP_APPLICATION = bool.Parse(ConfigurationManager.AppSettings["START_DESCTOP_APPLICATION"]);
       
   
        //WEB APPLICATION
        public static string WEB_BROWSER_TO_RUN = ConfigurationManager.AppSettings["WEB_BROWSER_TO_RUN"];
        public static string WEB_APPLICATION_URL = ConfigurationManager.AppSettings["WEB_APPLICATION_URL_"+ ENVIRONMENT];
        public static bool WEB_APPLICATION_CLEAR_IE_CACHE = bool.Parse(ConfigurationManager.AppSettings["WEB_APPLICATION_CLEAR_IE_CACHE"]);
 
        public static string WEB_APPLICATION_PROCESS_NAME = ConfigurationManager.AppSettings["WEB_APPLICATION_PROCESS_NAME"];    
            //WEB AND DESKOP APPLICATION PROCESSES TO KILL
        public static bool KILL_APPLICATION_PROCCESS = bool.Parse(ConfigurationManager.AppSettings["KILL_APPLICATION_PROCCESS"]);

        
        public static string APPLICATION_PROCESS_NAMES_TO_KILL = ConfigurationManager.AppSettings["APPLICATION_PROCESS_NAMES_TO_KILL"];

        //TIME OUT PARAMETERS FOR WEB AND DESKTOP APPLICATIONS
        public static int GLOBAL_TIMEOUT_TIME_IN_MSEC = int.Parse(ConfigurationManager.AppSettings["GLOBAL_TIMEOUT_TIME_IN_MSEC"]);
        public static int GLOBAL_TIMEOUT_TIME_IN_MSEC_WITHOUT_FAILING = int.Parse(ConfigurationManager.AppSettings["GLOBAL_TIMEOUT_TIME_IN_MSEC_WITHOUT_FAILING"]);
        public static int START_APPLICATION_TIMEOUT_TIME_IN_MSEC = int.Parse(ConfigurationManager.AppSettings["START_APPLICATION_TIMEOUT_TIME_IN_MSEC"]);

        //WHITE INERNAL TIMEOUT CONFIGURATION
        public static int WHITE_BUSY_TIMEOUT = int.Parse(ConfigurationManager.AppSettings["WHITE_BUSY_TIMEOUT"]);
        public static int WHITE_UI_AUTOMATION_ZERO_WINDOW_BUG_TIMEOUT = int.Parse(ConfigurationManager.AppSettings["WHITE_UI_AUTOMATION_ZERO_WINDOW_BUG_TIMEOUT"]);
        public static int GENERAL_DELAY_FOR_EACH_TEST_STEP = int.Parse(ConfigurationManager.AppSettings["GENERAL_DELAY_FOR_EACH_TEST_STEP"]);

         //RERUN FAILED TEST CASES
        public static string PATH_NUNIT_PACKAGE_CONSOLE_EXE = ConfigurationManager.AppSettings["PATH_NUNIT_PACKAGE_CONSOLE_EXE"];
        public static string PATH_SAF_DLL_BIN_DEBUG = ConfigurationManager.AppSettings["PATH_SAF_DLL_BIN_DEBUG"];
        public static string PATH_RERUN_FAILED_TEST_CASES_FOLDER = ConfigurationManager.AppSettings["PATH_RERUN_FAILED_TEST_CASES_FOLDER"];  
        
        
        static Hashtable windowHashtable;
        static Hashtable modalWindowHashtable;
        public static string PATH_TO_ORIGINAL_FILE = ConfigurationManager.AppSettings["PATH_TO_ORIGINAL_FILE"];
        public static string PATH_TO_FILE_TO_COMPARE_WITH = ConfigurationManager.AppSettings["PATH_TO_FILE_TO_COMPARE_WITH"];
        public static string STRINGS_TO_IGNORE_COMMA_SPERATED = ConfigurationManager.AppSettings["STRINGS_TO_IGNORE_COMMA_SPERATED"];
        public static string PATH_DYNAMIC_TEST_DATA = ConfigurationManager.AppSettings["PATH_DYNAMIC_TEST_DATA"];


        
       public ConfigParameters()
        {
            //MAIN_WINDOW_CATIA_V5_VPM_ROD = ConfigurationManager.AppSettings["MAIN_WINDOW_CATIA_V5_VPM_ROD" + CATIA_VERSION];
            //PATH_APPLICATION_TO_LAUNCH_CATIA_5 = ConfigurationManager.AppSettings["PATH_APPLICATION_TO_LAUNCH_CATIA_5" + CATIA_VERSION];
            //PATH_APPLICATION_TO_LAUNCH_CATIA_5_EXTENTION = (ConfigurationManager.AppSettings["PATH_APPLICATION_TO_LAUNCH_CATIA_5_EXTENTION" + CATIA_VERSION]).Replace("ENV_VARIABLE_TO_REPLACE", ENVIRONMENT);
            //SAFINCALog.Info("MAIN_WINDOW_CATIA_V5_VPM_ROD: " + MAIN_WINDOW_CATIA_V5_VPM_ROD);
        }

        public static Hashtable WindowHashtable
        {
            get { return ConfigParameters.windowHashtable; }
            set { ConfigParameters.windowHashtable = value; }
        } 

        public static Hashtable GetWindowHashtable()
        {
           return windowHashtable;
        }


        public static Hashtable ModalWindowHashtable
        {
            get { return ConfigParameters.modalWindowHashtable; }
            set { ConfigParameters.modalWindowHashtable = value; }
        }

        public static Hashtable GetModalWindowHashtable()
        {
            return modalWindowHashtable;
        }

    }
}
