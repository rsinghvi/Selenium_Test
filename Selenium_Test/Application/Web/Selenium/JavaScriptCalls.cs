using SAFINCA.LogMgn;
using SAFINCA.CommonFuncMgn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace SAFINCA.Application.Web.Selenium
{
    public class JavaScriptCalls
    {
        private RemoteWebDriver driver;

        public RemoteWebDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        /**Execute the java script, scriptToExecute, on the site driver, e.g. to simulate an action that cannot be achieved by a webdriver action.
	     * Such actions could be as forcing the browser to show hidden elements, get browser information, etc.
	     * The java script execution should be used with caution since it not an exact simulation of the user behavior. 
	     * @param scriptToExecute
	     * @return an object
	     */
        public Object ExecuteJavaScript(string pageNameToSwitchTo, string frameNameToSwitchTo, string scriptToExecute, params IWebElement[] args)
        {
            SAFINCALog.Debug("scriptToExecute: " + scriptToExecute);
            Object obj = null;
            long maxTimeToWait = CommonUtilities.GetCurrentTimeMillis() + CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC;
            while (obj == null && maxTimeToWait > CommonUtilities.GetCurrentTimeMillis())
            {
                try
                {
                    //driver = FindWebDriverElement.SwitchToFrameOrWindowByName(this.driver, pageNameToSwitchTo, frameNameToSwitchTo);
                    IJavaScriptExecutor iJavaScriptExecutor = (IJavaScriptExecutor)driver;

                    {
                        if (args!=null && args.Length > 0)
                        {
                            obj = (Object)iJavaScriptExecutor.ExecuteScript(scriptToExecute, args[0]);
                            SAFINCALog.Debug("object: " + obj);
                            return obj;
                        }
                        else
                        {
                            obj = (Object)iJavaScriptExecutor.ExecuteScript(scriptToExecute);
                            SAFINCALog.Debug("object: " + obj);
                            return obj;
                        }
                        
                    }
                }
                catch(Exception e)
                {

                }
            }
            return obj;
        }
        
        /// <summary>
        /// Return a list of web element using the javascript to find element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="scriptToExecute"></param>
        /// <returns></returns>
        public ReadOnlyCollection<IWebElement> ExecuteJavaScriptIWebElementList(string pageNameToSwitchTo, string frameNameToSwitchTo, string scriptToExecute)
        {
            SAFINCALog.Debug("scriptToExecute: " + scriptToExecute);
            driver = FindWebDriverElement.SwitchToFrameOrWindowByName(this.driver, pageNameToSwitchTo, frameNameToSwitchTo);
            IJavaScriptExecutor iJavaScriptExecutor = (IJavaScriptExecutor)driver;
            ReadOnlyCollection<IWebElement> iWebElementList = (ReadOnlyCollection<IWebElement>)iJavaScriptExecutor.ExecuteScript(scriptToExecute);
            SAFINCALog.Debug("iWebElementList: " + iWebElementList);
            return iWebElementList;
        }

        /// <summary>
        /// Same as {@methodref executeJavaScript} but with a WaitForAjaxCallToFinish before executing the java script
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="scriptToExecute"></param>
        /// <returns></returns>
        public Object executeJavaScriptWithWaitForAjaxCallToFinish(string pageNameToSwitchTo, string frameNameToSwitchTo, string scriptToExecute)
        {
            SAFINCALog.Debug("scriptToExecute: " + scriptToExecute);
            WaitForAjaxCallToFinish();
            Object obj = ExecuteJavaScript(pageNameToSwitchTo, frameNameToSwitchTo, scriptToExecute);
            WaitForAjaxCallToFinish();
            return obj;
        }

        /// <summary>
        /// Used Only wiht JQuery based web runningApplication 
        /// </summary>
        public void WaitForAjaxCallToFinish()
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            try
            {
                AjaxCallToFinish();
            }
            catch
            {
                SAFINCALog.Info(CommonUtilities.GetClassAndMethodName(), "CALLING THE JAVA SCRIPT THE FIST TIME FAILED. TRYING THE ONE MORE TIME");
                AjaxCallToFinish();
            }
        }

        /// <summary>
        /// Wait for a page to loaded on the screen
        /// </summary>
        private void AjaxCallToFinish()
        {
            string documentReadyState = "";
            string documentReadyStateStripped = "";
            long maxTimeToWait = CommonUtilities.GetCurrentTimeMillis() + CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC;
            while (!documentReadyStateStripped.Equals("complete") && maxTimeToWait > CommonUtilities.GetCurrentTimeMillis())
            {
                try
                {
                    SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
                    String scriptToExecute = "return document.readyState";
                    documentReadyState = (string)driver.ExecuteScript(scriptToExecute);
                    documentReadyStateStripped = documentReadyState.Trim().ToLower();
                }
                catch
                {
                    SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "JAVASCRIPT NOT READY YET");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
