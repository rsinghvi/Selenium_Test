    using System;
    using System.Text;
    using System.Threading;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Remote;
    using SAFINCA.LogMgn;
    using SAFINCA.CommonFuncMgn;
    using SAFINCA.ParameterAndUserDataMgn;
using SAFINCA.Common_Function_Management;
using System.Configuration;



    namespace SAFINCA.Application.Web.Selenium

    {
        [DeploymentItem(@"Resources\IEDriverServer.exe")]
        [DeploymentItem(@"Resources\chromedriver.exe")]
        [DeploymentItem(@"Resources\Test_Results_Template.xlsx")]
        public class SeleniumTestInitialize
        {
            private TestContext testContextInstance;

            public TestContext TestContext
            {
                get { return testContextInstance; }
                set { testContextInstance = value; }
            }

            public static bool SeleniumExecutionTerminateFlag = false;

            public static FindWebDriverElement findWebDriverElement;
            public static JavaScriptCalls javaScriptCalls;
            public static OperateOnWebDriverElement operateOnWebDriverElement;
            public static RemoteWebDriver driver;
            public static IframeSwitcher switcher;
            public static IncaGenericFunction incaFunction;
            public static String dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

            public static SVLGridOperation SVLGridOperation;

            public static SAFINCALog safeebbalog;
            

        enum DOMAttributes
            {
                id,
                css_class,
                xpath,
                name
            };

            public string baseURL;

            public void SeleniumSetup()
            {
                try
                {

                    Console.WriteLine("Starting Driver...........");

                  String browser = ConfigurationManager.AppSettings["WEB_BROWSER_TO_RUN"];
                 
                var options = new InternetExplorerOptions
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    EnsureCleanSession = true,
                    //ForceCreateProcessApi=true
                    EnableNativeEvents = false,
                    RequireWindowFocus = false,
                    IgnoreZoomLevel = true
                };

                ChromeOptions chromeOptions = new ChromeOptions();

                    chromeOptions.AddArgument("--test-type");
                    chromeOptions.AddArguments("chrome.switches", "--disable-extensions");

                chromeOptions.AddArgument("start-maximized");
                chromeOptions.AddArgument("--enable-automation");
                chromeOptions.AddArgument("test-type=browser");
                chromeOptions.AddArgument("disable-infobars");

                if (browser.Contains("Internet"))
                    driver = new InternetExplorerDriver(TestContext.DeploymentDirectory, options);
                else if (browser.Contains("Chrome"))
                    driver = new ChromeDriver(chromeOptions);
                
                   // driver = new ChromeDriver();
                else
                    driver = null;


                if (driver != null)
                {
                    // Javascript Class
                    javaScriptCalls = new JavaScriptCalls();
                    javaScriptCalls.Driver = driver;

                        //Find Web Driver
                        findWebDriverElement = new FindWebDriverElement();
                        findWebDriverElement.Driver = driver;
                        findWebDriverElement.JavaScriptCalls = javaScriptCalls;

                        //Operate Web Element
                        operateOnWebDriverElement = new OperateOnWebDriverElement();
                        operateOnWebDriverElement.FindWebDriverElement = findWebDriverElement;
                        operateOnWebDriverElement.JavaScriptCalls = javaScriptCalls;

                        SVLGridOperation = new SVLGridOperation();
                        safeebbalog = new SAFINCALog();
                        switcher = new IframeSwitcher();
                        incaFunction = new IncaGenericFunction();

                        GoToSite(ConfigParameters.WEB_APPLICATION_URL);
                       // driver.Manage().Window.Maximize();
                  //  }
                   // else
                  //  {
                       // SAFINCALog.Debug("Browser type not specified in the config file...........");
                  //  }


                }
            }
            catch (Exception e)
                {
                    SAFINCALog.Debug("Error Starting Web Driver...........");
                    Console.WriteLine(e.StackTrace);
                }

            }

            public void SeleniumQuit()
            {
                Console.WriteLine("Quitting Driver...........");
                try
                {
                    if (driver != null)
                    {
                        driver.Quit();
                        driver = null;
                    }

                    SAFINCALog.Info("Closing Web Driver...........");
                    ProcessMgn.killProcessByNames("IEDriverServer");//Make sure the process is killed

                    //Try to add the link to the Result file and screenshots if necessary
                    this.TestContext.AddResultFile(WriteTestResultsExcel.testResultFilePath);
                    if (WriteTestResultsExcel.errorTestResultFilePath != null) 
                    { 
                        this.TestContext.AddResultFile(WriteTestResultsExcel.errorTestResultFilePath);                   
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            public void GoToSite(string urlToOpen)
            {
                driver.Navigate().GoToUrl(urlToOpen);               
            }


            //Method Usage example as give below
            //getDictionaryValue(Login_Objects.LOGIN_APRISO_USERNAME, DOMAttributes.css_class.ToString());

            public String getDictionaryValue(Dictionary<String, String> dictionary, String Key)
            {
                try
                {
                    String value = null;
                    if (dictionary != null)
                    {
                        if (dictionary.ContainsKey(Key))
                        {
                            value = dictionary[Key];
                            return value;
                        }
                        else
                            return value;

                    }
                    else
                        return value;
                }
                catch (Exception e)
                {
                    SAFINCALog.LogStackTrace(e);
                    return null;
                }

            }

            // Method to add timeout of x seconds.

            public void timeOuts(int seconds)
            {
                Thread.Sleep(seconds*1000);
            }
        }

    }



