    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;
    using SAFINCA.Application.Web.Selenium;    
    using NUnit.Framework;
    using SAFINCA.LogMgn;
    using System.Data;
    using System.Data.SqlClient;
    using SAFINCA.Common_Function_Management;
    using SAFINCA.CommonFuncMgn;
    using SAFINCA.Common_Function_Management;
using SAFINCA.ParameterAndUserDataMgn;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using System.Globalization;


namespace SAFINCA.Common_Function_Management

    {

    public class IframeSwitcher : SeleniumTestInitialize
    {
        public bool switchFlag = false;
        public string src = "Default";

        //Switch Iframes
        public void iframeswitch(String iframeTextSrc)
        {
            IReadOnlyCollection<IWebElement> iframelist = driver.FindElements(By.TagName("iframe"));

            String value = null;

            SAFINCALog.Info("Count of IFrames: " + iframelist.Count());
              //Iterate over the td list
            foreach (IWebElement iframe in iframelist)
            {
                value = iframe.GetAttribute("src");

                SAFINCALog.Info("Src of IFrames: " + value);

                if (value != null && value != "")
                {
                    if (value.Contains(iframeTextSrc))
                    {
                        driver.SwitchTo().Frame(iframe);
                        findWebDriverElement.Driver = driver;
                        javaScriptCalls.Driver = driver;
                        operateOnWebDriverElement.FindWebDriverElement = findWebDriverElement;
                        operateOnWebDriverElement.JavaScriptCalls = javaScriptCalls;
                        switchFlag = true;
                        src = value;
                        SAFINCALog.Info("Iframe Match for " + iframeTextSrc);
                        break;
                    }
                }
            }
                   
        }

        //Switch Back
        public void iframeswitchback()
        {

            driver.SwitchTo().DefaultContent();
            findWebDriverElement.Driver = driver;
            javaScriptCalls.Driver = driver;
            operateOnWebDriverElement.FindWebDriverElement = findWebDriverElement;
            operateOnWebDriverElement.JavaScriptCalls = javaScriptCalls;
        }

      }
    }



