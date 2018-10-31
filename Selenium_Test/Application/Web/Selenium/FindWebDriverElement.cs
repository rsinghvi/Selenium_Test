using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using SAFINCA.LogMgn;
using System.Threading;
using SAFINCA.CommonFuncMgn;

namespace SAFINCA.Application.Web.Selenium
{
    /// <summary>
    /// Manage and retrieve the web element on a driver
    /// </summary>
    public class FindWebDriverElement 
    {
        JavaScriptCalls javaScriptCalls;

        internal JavaScriptCalls JavaScriptCalls
        {
            get { return javaScriptCalls; }
            set { javaScriptCalls = value; }
        }

        static bool waitForAjax = true;
        public RemoteWebDriver driver;

        public RemoteWebDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by class name
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByClassName(string pageNameToSwitchTo, string frameNameToSwitchTo, string classForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.ClassName(classForElementToFind));
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by class name and value using xPath
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classForElementToFind"></param>
        /// <param name="valueForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByClassNameAndValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string classForElementToFind, string valueForElementToFind)
        {
            //String xPath = "//" + tag + "[contains(@id,'" + startPartOfIdm + "') and contains(@id,'" + endPartOfId + "')]";
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.XPath("//*[@class='" + classForElementToFind + "' and @value='" + valueForElementToFind + "']"));
        }

     
        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by name
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByName(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.Name(nameForElementToFind));
            
        }

        

        
        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by name and tag name
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToFind"></param>
        /// <param name="tagNameForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByNameAndTagName(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToFind, string tagNameForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.Name(nameForElementToFind), By.TagName(tagNameForElementToFind));
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by id
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="iDForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementById(string pageNameToSwitchTo, string frameNameToSwitchTo, string iDForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.Id(iDForElementToFind));
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by xPath
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="XPathForElementToFind"></param>
        /// <returns></returns>
        public IWebElement WaitForElementByXPath(string pageNameToSwitchTo, string frameNameToSwitchTo, string XPathForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.XPath(XPathForElementToFind));
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by link text
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="linkTextForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByLinkText(string pageNameToSwitchTo, string frameNameToSwitchTo, string linkTextForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.LinkText(linkTextForElementToFind));
        }

        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by tag name
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="tagNameForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByTagName(string pageNameToSwitchTo, string frameNameToSwitchTo, string tagNameForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.TagName(tagNameForElementToFind));
        }

        public IWebElement waitForElementByText(string pageNameToSwitchTo, string frameNameToSwitchTo, string textForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.CssSelector(textForElementToFind));
        }


        /// <summary>
        /// IWebElement, wait and return an element.
        /// The web element is identified by name and an index/order number of the element, considered from the tag element 
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToFind"></param>
        /// <param name="indexForElementToFind"></param>
        /// <returns></returns>
        public IWebElement waitForElementByNameAndIndex(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToFind, string indexForElementToFind)
        {
            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.Name(nameForElementToFind), By.XPath("#" + indexForElementToFind + "##"));
        }

        /// <summary>
        /// Get the web element according to a given page name, frame name and location(identification method for the element)
        /// 
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        private IWebElement waitAndGetElement(string pageNameToSwitchTo, string frameNameToSwitchTo, params By[] by)
        {
            Exception exception = null;
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            String errorMessage = "No Element Was Found by: " + by[0] + "\n EXCEPTION THROWN: ";
            IWebElement webElement = null;
            if (waitForAjax)
            {
                //Check the status of the page by executing the javascipt, document.status, to see if the page is fully loaded
                //This check makes the system slower but minimize the risk of failure
                javaScriptCalls.WaitForAjaxCallToFinish();
            }
            //Max time to wait for an element
            long maxTimeToWait = CommonUtilities.GetCurrentTimeMillis() + CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC;
            while (webElement == null && maxTimeToWait > CommonUtilities.GetCurrentTimeMillis())
            {
                try
                {
                    //Modify the diver by switching page and frame if needed
                   // driver = SwitchToFrameOrWindowByName(driver, pageNameToSwitchTo, frameNameToSwitchTo);
                   
                    if (by.Length == 1)
                    {
                        var webElementList = driver.FindElements(by[0]);
                        int nrOfFoundElements = webElementList.Count;
                        if (nrOfFoundElements > 1)
                        {
                            foreach (IWebElement webElementFromList in webElementList)
                            {
                                SAFINCALog.Warning("Tag name element: " + webElementFromList.TagName);
                                SAFINCALog.Warning("Text element: " + webElementFromList.Text);
                            }

                            errorMessage = "TOO MANY Elements Was Found by: " + by + "\n EXCEPTION THROWN: ";
                            //throw new Exception();
                        }
                        //Create a WebDriver wait to wait for the element to show on the page
                        var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(CommonUtilities.GLOBAL_TIMEOUT_TIME_IN_MSEC / 1000), TimeSpan.FromMilliseconds(500));
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(by[0]));
                    }
                    else
                    {
                        var webElementList = driver.FindElements(by[0]);
                        string byLocator = by[1].ToString().ToLower().Replace(" ", "");

                        if (byLocator.Contains("by.tagname"))
                        {
                                foreach (IWebElement webElementFromList in webElementList)
                                {
                                    string webElementTagName = "by.tagname:" + webElementFromList.TagName.ToLower().Replace(" ", "");
                                    SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "webElementTagName: " + webElementTagName, "byLocator: " + byLocator);
                                    if (byLocator.Contains(webElementTagName))
                                    {
                                        webElement= webElementFromList;
                                        break;
                                    }                          
                                }
                        }
                        else if (byLocator.Contains("##"))
                        {
                            int startIndex = by[1].ToString().IndexOf("#")+1;
                            int endIndex=by[1].ToString().IndexOf("##")-startIndex;
                            string s = by[1].ToString().Substring(startIndex, endIndex);
                            int elementIndex=int.Parse(by[1].ToString().Substring(startIndex,endIndex));
                            webElement = webElementList[elementIndex];
                        }

                    }
                }


                catch (Exception e)
                {
                    exception = e;
                    Thread.Sleep(500);
                }
            }
        
            if (webElement == null)
            {               
                throw new DriverServiceNotFoundException(errorMessage + (exception==null? "":exception.ToString()));
            }
            return webElement;
        }

        // Find By Class and Data-Field
        public IWebElement waitForElementByClassNameAndDataField(string pageNameToSwitchTo, string frameNameToSwitchTo, string classForElementToFind, string dataFieldForElementToFind)
        {
            //String xPath = "//" + tag + "[contains(@id,'" + startPartOfIdm + "') and contains(@id,'" + endPartOfId + "')]";

            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.XPath("//*[@class='" + classForElementToFind + "' and @data-field='" + dataFieldForElementToFind + "']"));

        }

        // Find By Class and Data-Value
        public IWebElement waitForElementByClassNameAndDataValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string classForElementToFind, string dataValueForElementToFind)
        { 
            //String xPath = "//" + tag + "[contains(@id,'" + startPartOfIdm + "') and contains(@id,'" + endPartOfId + "')]";

            return waitAndGetElement(pageNameToSwitchTo, frameNameToSwitchTo, By.XPath("//*[@class='" + classForElementToFind + "' and @data-value='" + dataValueForElementToFind + "']"));

        }

        
        
        /// <summary>
        /// Modify the driver if needed, by switching page or frame
        /// The switching is needed incase the element is placed in a different frame or page than the defualt ones.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <returns></returns>
        public static RemoteWebDriver SwitchToFrameOrWindowByName(RemoteWebDriver driver, string pageNameToSwitchTo, string frameNameToSwitchTo) 
        {
            //Go back to default page and frame
            if (frameNameToSwitchTo == null && pageNameToSwitchTo == null)
            {
                try
                {
                    driver.SwitchTo().DefaultContent();
                }
                catch
                {
                    //DONOTHING TODO
                }
            }
            //only frame switch
            else if (frameNameToSwitchTo != null && pageNameToSwitchTo == null)
            {
                try
                {
                    driver.SwitchTo().DefaultContent();
                }
                catch
                {
                    //DONOTHING TODO
                }
                driver.SwitchTo().Frame(frameNameToSwitchTo);
            }
            //Only Window Switch
            else if (frameNameToSwitchTo == null && pageNameToSwitchTo != null)
            {                
                driver = SwitchWindowByTitle(driver, pageNameToSwitchTo);
               /// driver.SwitchTo().DefaultContent();
            }
            //Both frame and window Switch
            else if (frameNameToSwitchTo != null && pageNameToSwitchTo != null)
            {               
                driver = SwitchWindowByTitle(driver, pageNameToSwitchTo);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(frameNameToSwitchTo);
            }
            
            return driver;
        }


        /// <summary>
        /// Switch window
        /// The new window is identified by name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="pageNameToSwitchTo"></param>
        /// <returns></returns>
        public static RemoteWebDriver SwitchWindowByTitle(RemoteWebDriver driver, string pageNameToSwitchTo)
        {
            IReadOnlyCollection<string> windowList = driver.WindowHandles;
            foreach (string pageName in windowList)
            {
                string title = driver.SwitchTo().Window(pageName).Title;
                if (title.Replace(" ", "").ToLower().Equals(pageNameToSwitchTo.Replace(" ", "").ToLower()))
                {
                    break;
                }
            }
            return driver;
        }
        public static bool WaitForAjax
        {
            get { return waitForAjax; }
            set { waitForAjax = value; }
        }

        //Displayed
        public bool IsElementDisplayed(By element)
        {
            try
            {

                IWebElement elementDisplayed = waitAndGetElement(null, null, element);

                if (elementDisplayed != null && elementDisplayed.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                return false;
            }

        }

        //Enabled
        public bool IsElementEnabled(By element)
        {

            try
            {

                IWebElement elementEnabled = waitAndGetElement(null, null, element);

                if (elementEnabled != null && elementEnabled.Enabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch (Exception e)
            {
                return false;
            }

        
        }

        public bool IsSpanElementExists(IWebElement element)

        {
            try
            {
                element.FindElement(By.TagName("span"));
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            return true;
        }

        public bool IsChildElementExists(IWebElement parentElement, String ChildTagName)
        {
            try
            {
                parentElement.FindElement(By.TagName(ChildTagName));
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            return true;
        }

        //Present
        public bool IsElementPresent(By element)
        {
            try
            {

                IWebElement elementDisplayed = driver.FindElement(element);

                if (elementDisplayed != null && elementDisplayed.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                return false;
            }

        }


    }
}
