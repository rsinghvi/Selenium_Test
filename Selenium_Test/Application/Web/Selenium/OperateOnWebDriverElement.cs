using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


using SAFINCA.LogMgn;
using SAFINCA.CommonFuncMgn;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using System.Windows;


namespace SAFINCA.Application.Web.Selenium
{
    /// <summary>
    /// Actions that can be used to interact with a web application
    /// </summary>
    public class OperateOnWebDriverElement
    {
        FindWebDriverElement findWebDriverElement;

        internal FindWebDriverElement FindWebDriverElement
        {
            get { return findWebDriverElement; }
            set { findWebDriverElement = value; }
        }
        public JavaScriptCalls javaScriptCalls;

        internal JavaScriptCalls JavaScriptCalls
        {
            get { return javaScriptCalls; }
            set { javaScriptCalls = value; }
        }

        public OperateOnWebDriverElement()
        {
        }


        ///////////////////////////INSERT INTO FIELD///////////////////////

        /// <summary>
        /// Insert into a text field. Without frame or window switch
        /// The text field is identified by the element class name.
        /// </summary>
        /// <param name="elementClassName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassName(string elementClassName, string textToInsert)
        {
            InsertInToFieldByClassName(null, elementClassName, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassName(string frameNameToSwitchTo, string elementClassName, string textToInsert)
        {
            InsertInToFieldByClassName(null, frameNameToSwitchTo, elementClassName, textToInsert);
        }


        /// <summary>
        ///  Insert into a text field. including frame switch, and window switch
        /// The text field is identified by the element class name
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassName(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementClassName, string textToInsert)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(pageNameToSwitchTo, frameNameToSwitchTo, elementClassName);
            //webelement.Clear();
            webelement.SendKeys(textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and value
        /// </summary>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassNameAndValue(string elementClassName, string elementValue, string textToInsert)
        {
            InsertInToFieldByClassNameAndValue(null, elementClassName, elementValue, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and value
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassNameAndValue(string frameNameToSwitchTo, string elementClassName, string elementValue, string textToInsert)
        {
            InsertInToFieldByClassNameAndValue(null, frameNameToSwitchTo, elementClassName, elementValue, textToInsert);
        }

        /// <summary>/// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and value
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassNameAndValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementClassName, string elementValue, string textToInsert)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndValue(pageNameToSwitchTo, frameNameToSwitchTo, elementClassName, elementValue);
            webelement.Clear();
            webelement.SendKeys(textToInsert);
        }

        // Edit Starts for Insert By Kabilan //

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and data field
        /// </summary>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassAndDataField(string elementClassName, string datafield, string textToInsert)
        {
            InsertInToFieldByClassAndDataField(null, elementClassName, datafield, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and data field
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassAndDataField(string frameNameToSwitchTo, string elementClassName, string datafield, string textToInsert)
        {
            InsertInToFieldByClassAndDataField(null, frameNameToSwitchTo, elementClassName, datafield, textToInsert);
        }

        /// <summary>/// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and data field
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassAndDataField(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementClassName, string datafield, string textToInsert)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndDataField(pageNameToSwitchTo, frameNameToSwitchTo, elementClassName, datafield);
            webelement.Clear();
            webelement.SendKeys(textToInsert);
            
        }

        /// <summary>
        /// Insert into a text field. 
        /// The text field is identified by the element class name.
        /// </summary>
        /// <param name="elementClassName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByClassName(IWebElement inputElement, string textToInsert)
        {
            inputElement.SendKeys(textToInsert);
        }

        public void GetTextByClassAndDataField(string elementClassName, string datafield)
        {
            GetTextByClassAndDataField(null, elementClassName, datafield);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and data field
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void GetTextByClassAndDataField(string frameNameToSwitchTo, string elementClassName, string datafield)
        {
            GetTextByClassAndDataField(null, frameNameToSwitchTo, elementClassName, datafield);
        }

        /// <summary>/// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element class name and data field
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementClassName"></param>
        /// <param name="elementValue"></param>
        /// <param name="textToInsert"></param>
        public void GetTextByClassAndDataField(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementClassName, string datafield)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndDataField(pageNameToSwitchTo, frameNameToSwitchTo, elementClassName, datafield);
            webelement.FindElement(By.CssSelector("div[data-field = 'datafield']")).GetAttribute("Text");

        }

        // Edit Ends for Insert //


        /// <summary>
        /// Insert into a text field. Without frame or window switch
        /// The text field is identified by the element name.
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldById(string elementId, string textToInsert)
        {
            InsertInToFieldById(null, elementId, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element name
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementId"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldById(string frameNameToSwitchTo, string elementId, string textToInsert)
        {
            InsertInToFieldById(null, frameNameToSwitchTo, elementId, textToInsert);
        }


        /// Insert into a text field. including frame switch, and window switch
        /// The text field is identified by the element name
        public void InsertInToFieldById(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementId, string textToInsert)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, elementId);
            webelement.Clear();
            webelement.SendKeys(textToInsert);
        }

        /// <summary>
        /// Insert into a text field. Without frame or window switch
        /// The text field is identified by the element name.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByName(string elementName, string textToInsert)
        {
            InsertInToFieldByName(null, elementName, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the element name
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByName(string frameNameToSwitchTo, string elementName, string textToInsert)
        {
            InsertInToFieldByName(null, frameNameToSwitchTo, elementName, textToInsert);
        }


        /// Insert into a text field. including frame switch, and window switch
        /// The text field is identified by the element name
        public void InsertInToFieldByName(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementName, string textToInsert)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, elementName);
            webelement.Clear();
            webelement.SendKeys(textToInsert);
        }

        /// <summary>
        /// Insert into a text field. no frame switch, no window switch
        /// The text field is identified by the xPath of the element 
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByXPath(string elementName, string textToInsert)
        {
            InsertInToFieldByXPath(null, elementName, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, no window switch
        /// The text field is identified by the xPath of the element 
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByXPath(string frameNameToSwitchTo, string elementName, string textToInsert)
        {
            InsertInToFieldByXPath(null, frameNameToSwitchTo, elementName, textToInsert);
        }

        /// <summary>
        /// Insert into a text field. including frame switch, and window switch
        /// The text field is identified by the xPath of the element 
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementName"></param>
        /// <param name="textToInsert"></param>
        public void InsertInToFieldByXPath(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementName, string textToInsert)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(pageNameToSwitchTo, frameNameToSwitchTo, elementName);
            webelement.Clear();
            webelement.SendKeys(textToInsert);
            webelement.SendKeys(Keys.Return);
            
        }


        ///////////////////////////////CLICK AN ELEMENT/////////////////


        ///////////////////////////////CLICK AN ELEMENT/////////////////



        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class aame of the element 
        /// </summary>
        /// <param name="classNameForElementToClick"></param>
        public void ClickAnElementByClassName(String classNameForElementToClick)
        {
            ClickAnElementByClassName(null, classNameForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, no window switch
        /// The element is identified by the class name of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        public void ClickAnElementByClassName(string frameNameToSwitchTo, String classNameForElementToClick)
        {
            ClickAnElementByClassName(null, frameNameToSwitchTo, classNameForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, and window switch
        /// The element is identified by the class name of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        public void ClickAnElementByClassName(string pageNameToSwitchTo, string frameNameToSwitchTo, String classNameForElementToClick)
        {            
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick);
            try
            {
                webelement.Click();
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.waitForElementByClassName(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick);
                webelement.Click();
            }
        }



        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="elementValue"></param>
        public void ClickAnElementByClassNameAndValue(String classNameForElementToClick, string elementValue)
        {
            ClickAnElementByClassNameAndValue(null, classNameForElementToClick, elementValue);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="elementValue"></param>
        public void ClickAnElementByClassNameAndValue(string frameNameToSwitchTo, String classNameForElementToClick, string elementValue)
        {
            ClickAnElementByClassNameAndValue(null, frameNameToSwitchTo, classNameForElementToClick, elementValue);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="elementValue"></param>
        public void ClickAnElementByClassNameAndValue(string pageNameToSwitchTo, string frameNameToSwitchTo, String classNameForElementToClick, string elementValue)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndValue(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, elementValue);
            try
            {
                webelement.Click();
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.waitForElementByClassNameAndValue(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, elementValue);
                webelement.Click();
            }
        }

        //Edit Start for Click //

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataField(String classNameForElementToClick, string dataField)
        {
            ClickAnElementByClassAndDataField(null, classNameForElementToClick, dataField);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataField(string frameNameToSwitchTo, String classNameForElementToClick, string dataField)
        {
            ClickAnElementByClassAndDataField(null, frameNameToSwitchTo, classNameForElementToClick, dataField);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataField(string pageNameToSwitchTo, string frameNameToSwitchTo, String classNameForElementToClick, string dataField)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndDataField(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, dataField);
            try
            {
                webelement.Click();
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.waitForElementByClassNameAndDataField(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, dataField);
                webelement.Click();
            }
        }

        // Edit ends //

        //Edit Start for Click by Class and Data Value//

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataValue(String classNameForElementToClick, string dataField)
        {
            ClickAnElementByClassAndDataValue(null, classNameForElementToClick, dataField);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataValue(string frameNameToSwitchTo, String classNameForElementToClick, string dataField)
        {
            ClickAnElementByClassAndDataValue(null, frameNameToSwitchTo, classNameForElementToClick, dataField);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the class name and value of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="classNameForElementToClick"></param>
        /// <param name="dataField"></param>
        public void ClickAnElementByClassAndDataValue(string pageNameToSwitchTo, string frameNameToSwitchTo, String classNameForElementToClick, string dataField)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassNameAndDataValue(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, dataField);
            try
            {
                webelement.Click();
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.waitForElementByClassNameAndDataField(pageNameToSwitchTo, frameNameToSwitchTo, classNameForElementToClick, dataField);
                webelement.Click();
            }
        }

        // Edit ends //


        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the Id of the element 
        /// </summary>
        /// <param name="idForElementToClick"></param>
        public void ClickAnElementById(String idForElementToClick)
        {
            ClickAnElementById(null, idForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, no window switch
        /// The element is identified by the Id of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForElementToClick"></param>
        public void ClickAnElementById(string frameNameToSwitchTo, String idForElementToClick)
        {
            ClickAnElementById(null, frameNameToSwitchTo, idForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, and window switch
        /// The element is identified by the Id of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForElementToClick"></param>
        public void ClickAnElementById(string pageNameToSwitchTo, string frameNameToSwitchTo, String idForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, idForElementToClick);
            try
            {
                webelement.Click();
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, idForElementToClick);
                webelement.Click();
            }
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the xPath of the element
        /// </summary>
        /// <param name="xPathForElementToClick"></param>
        public void ClickAnElementByXPath(String xPathForElementToClick)
        {
            ClickAnElementByXPath(null, xPathForElementToClick);
        }

        /// <summary>
        /// Click an element. Includes frame switch, no window switch
        /// The element is identified by the xPath of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="xPathForElementToClick"></param>
        public void ClickAnElementByXPath(string frameNameToSwitchTo, String xPathForElementToClick)
        {
            ClickAnElementByXPath(null, frameNameToSwitchTo, xPathForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, and window switch
        /// The element is identified by the xpath of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="xPathForElementToClick"></param>
        public void ClickAnElementByXPath(string pageNameToSwitchTo, string frameNameToSwitchTo, String xPathForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(pageNameToSwitchTo, frameNameToSwitchTo, xPathForElementToClick);
            try
            {
                webelement.Click();
                // int xPos=webelement.Location.X;
                // int yPos = webelement.Location.Y;
                //Mouse.Instance.Click(new Point(2951, 184));
                
            }
            catch
            {
                SAFINCALog.Info("FAILED TO CLICK THE FIRST TIME. MAKE A SECOND TRY");
                webelement = findWebDriverElement.WaitForElementByXPath(pageNameToSwitchTo, frameNameToSwitchTo, xPathForElementToClick);
                webelement.Click();
            }
        }

        /// <summary>
        /// Click an element. Includes frame switch, no window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="nameForElementToClick"></param>
        public void ClickAnElementByName(string nameForElementToClick)
        {
            ClickAnElementByName(null, nameForElementToClick);
        }

        /*public void ClickAnElementByValue(string valueForElementToClick)
        {
            ClickAnElementByValue(null, valueForElementToClick);
        }*/

        public void ClickAnElementByText(string textForElementToClick)
        {
            ClickAnElementByText(null, textForElementToClick);
        }
        /// <summary>
        /// Click an element. includes frame switch, no window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        public void ClickAnElementByName(string frameNameToSwitchTo, string nameForElementToClick)
        {
            ClickAnElementByName(null, frameNameToSwitchTo, nameForElementToClick);
        }

/*        public void ClickAnElementByValue(string frameNameToSwitchTo, string valueForElementToClick)
        {
            ClickAnElementByValue(null, frameNameToSwitchTo, valueForElementToClick);
        }
*/
        public void ClickAnElementByText(string frameNameToSwitchTo, string textForElementToClick)
        {
            ClickAnElementByText(null, frameNameToSwitchTo, textForElementToClick);
        }
        /// <summary>
        /// Click an element. includes frame switch, and window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        public void ClickAnElementByName(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, nameForElementToClick);
            webelement.Click();
        }

 /*       public void ClickAnElementByValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string valueForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement(pageNameToSwitchTo, frameNameToSwitchTo, valueForElementToClick);
            webelement.Click();
        }
 */
        public void ClickAnElementByText(string pageNameToSwitchTo, string frameNameToSwitchTo, string textForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, textForElementToClick);
            webelement.Click();
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the tag name and name of the element
        /// This method is used when element with the same name exists on the page
        /// </summary>
        /// <param name="nameForElementToClick"></param>
        /// <param name="tagNameForElementToClick"></param>
        public void ClickAnElementByNameAndTagName(string nameForElementToClick, string tagNameForElementToClick)
        {
            ClickAnElementByNameAndTagName(null, nameForElementToClick, tagNameForElementToClick);
        }

        /// <summary>
        /// Click an element. no frame switch, no window switch
        /// The element is identified by the tag name and name of the element
        /// This method is used when element with the same name exists on the page
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        /// <param name="tagNameForElementToClick"></param>
        public void ClickAnElementByNameAndTagName(string frameNameToSwitchTo, string nameForElementToClick, string tagNameForElementToClick)
        {
            ClickAnElementByNameAndTagName(null, frameNameToSwitchTo, nameForElementToClick, tagNameForElementToClick);
        }

        /// <summary>
        /// Click an element. includes frame switch, and window switch
        /// The element is identified by the tag name and name of the element
        /// This method is used when element with the same name exists on the page
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        /// <param name="tagNameForElementToClick"></param>
        public void ClickAnElementByNameAndTagName(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToClick, string tagNameForElementToClick)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByNameAndTagName(pageNameToSwitchTo, frameNameToSwitchTo, nameForElementToClick, tagNameForElementToClick);
            webelement.Click();
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the Id of the element
        /// </summary>
        /// <param name="idForElementToClick"></param>
        public void clickAnElementByIdUsingJavaScript(string idForElementToClick)
        {
            clickAnElementByIdUsingJavaScript(null, idForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// Includes frame switch, no window switch
        /// The element is identified by the Id of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForElementToClick"></param>
        public void clickAnElementByIdUsingJavaScript(string frameNameToSwitchTo, string idForElementToClick)
        {
            clickAnElementByIdUsingJavaScript(null, frameNameToSwitchTo, idForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// Includes frame switch, and window switch
        /// The element is identified by the Id of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForElementToClick"></param>
        public void clickAnElementByIdUsingJavaScript(string pageNameToSwitchTo, string frameNameToSwitchTo, string idForElementToClick)
        {
            String scriptToExecute = "document.getElementById('" + idForElementToClick + "').click()";
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "clickAWebElementByIdUsingJavaScript, scriptToExecute: " + scriptToExecute);
            javaScriptCalls.executeJavaScriptWithWaitForAjaxCallToFinish(pageNameToSwitchTo, frameNameToSwitchTo, scriptToExecute);
        }


        //The xpath functionalities such asa evaluate are not implemented in IE
        //public void clickAnElementByXPathUsingJavaScript(string pageNameToSwitchTo, string frameNameToSwitchTo, string xPathForElementToClick)
        //{
        //    String scriptToExecute = "document.evaluate(\"" + xPathForElementToClick +"\",document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()";
        //    SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "clickAWebElementByIdUsingJavaScript, scriptToExecute: " + scriptToExecute);
        //    javaScriptCalls.executeJavaScriptWithWaitForAjaxCallToFinish(pageNameToSwitchTo, frameNameToSwitchTo, scriptToExecute);
        //}

//       private getElementByXpath (string path) {
//        return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
//}


        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="nameForElementToClick"></param>
        public void clickAnElementByNameUsingJavaScript(string nameForElementToClick)
        {
            clickAnElementByNameUsingJavaScript(null, nameForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        public void clickAnElementByNameUsingJavaScript(string frameNameToSwitchTo, string nameForElementToClick)
        {
            clickAnElementByIdUsingJavaScript(null, frameNameToSwitchTo, nameForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the name of the element
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        public void clickAnElementByNameUsingJavaScript(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToClick)
        {
            String scriptToExecute = "document.getElementsByName('" + nameForElementToClick + "')[0].click()";
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "clickAWebElementNameIdUsingJavaScript, scriptToExecute: " + scriptToExecute);
            javaScriptCalls.executeJavaScriptWithWaitForAjaxCallToFinish(pageNameToSwitchTo, frameNameToSwitchTo, scriptToExecute);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the name of the element and an index.
        /// The mehod is used when several element exists on a page. The index of the element is idenified as the order of the element where it appears on the page from top
        /// </summary>
        /// <param name="nameForElementToClick"></param>
        /// <param name="indexForElementToClick"></param>
        public void ClickAnElementByNameAndIndexUsingJavaScript(string nameForElementToClick, string indexForElementToClick)
        {
            ClickAnElementByNameAndIndexUsingJavaScript(null, nameForElementToClick, indexForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// No frame switch, no window switch
        /// The element is identified by the name of the element and an index.
        /// The mehod is used when several element exists on a page. The index of the element is idenified as the order of the element where it appears on the page from top
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        /// <param name="indexForElementToClick"></param>
        public void ClickAnElementByNameAndIndexUsingJavaScript(string frameNameToSwitchTo, string nameForElementToClick, string indexForElementToClick)
        {
            ClickAnElementByNameAndIndexUsingJavaScript(null, frameNameToSwitchTo, nameForElementToClick, indexForElementToClick);
        }

        /// <summary>
        /// Click en element using JavaScrip if IE specially version 9 do not react on click
        /// Includes frame switch, and window switch
        /// The element is identified by the name of the element and an index.
        /// The mehod is used when several element exists on a page. The index of the element is idenified as the order of the element where it appears on the page from top
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForElementToClick"></param>
        /// <param name="indexForElementToClick"></param>
        public void ClickAnElementByNameAndIndexUsingJavaScript(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForElementToClick, string indexForElementToClick)
        {
            String scriptToExecute = "document.getElementsByName('" + nameForElementToClick + "')[" + int.Parse(indexForElementToClick) + "].click()";
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), "clickAWebElementNameIdUsingJavaScript, scriptToExecute: " + scriptToExecute);
            javaScriptCalls.executeJavaScriptWithWaitForAjaxCallToFinish(pageNameToSwitchTo, frameNameToSwitchTo, scriptToExecute);
        }

        /// <summary>
        /// Select a checkbox if not selected.
        /// the element is identified by the ID
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementId"></param>
        internal void SelectCheckBoxElementById(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementId)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, elementId);
            if (!webelement.Selected)
            {
                webelement.Click();
            } 

        }

        /// <summary>
        /// Select a value in a dropdown list, based on a value
        /// </summary>
        /// <param name="nameForComboBoxToFind">Name of the combobox a top level element</param>
        /// <param name="indexForElementToFind">Index of the web element within the combobox</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndIndexAndValue(string nameForComboBoxToFind, string indexForElementToFind, string textValue)
        {
            SelectTypeValueComboBoxByNameAndIndexAndValue(null, null, nameForComboBoxToFind, indexForElementToFind, textValue);
        }

        /// <summary>
        /// Select a value in a dropdown list, based on a value
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForComboBoxToFind">Name of the combobox a top level element</param>
        /// <param name="indexForElementToFind">Index of the web element within the combobox</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndIndexAndValue(string frameNameToSwitchTo, string nameForComboBoxToFind, string indexForElementToFind, string textValue)
        {
            SelectTypeValueComboBoxByNameAndIndexAndValue(null, frameNameToSwitchTo, nameForComboBoxToFind, indexForElementToFind, textValue);
        }

        /// <summary>
        /// Select a value in a dropdown list, based on a value
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForComboBoxToFind">Name of the combobox a top level element</param>
        /// <param name="indexForElementToFind">Index of the web element within the combobox</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndIndexAndValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForComboBoxToFind, string indexForElementToFind, string textValue)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByNameAndIndex(pageNameToSwitchTo, frameNameToSwitchTo, nameForComboBoxToFind, indexForElementToFind);
            //webelement.Click();
            IReadOnlyCollection<IWebElement> elementTrList = webelement.FindElements(By.TagName("tr"));
            bool isValueFound=false;
            foreach (IWebElement elementTr in elementTrList)
            {
                IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                foreach (IWebElement elementTd in elementTdList)
                {
                    string elementText = elementTd.Text.Replace(" ", "").ToLower();
                    if (elementText.Contains(textValue.Replace(" ", "").ToLower()))
                    {
                            elementTd.Click();
                            return;
                    }
                }
            }
            if (!isValueFound)
            {
                throw new Exception("Value: " + textValue + " wsa not found");
            }
        }



        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndValue(string nameForComboBoxToFind, string textValue)
        {
            SelectTypeValueComboBoxByNameAndValue(null, null, nameForComboBoxToFind, textValue);
        }
        
        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndValue(string frameNameToSwitchTo, string nameForComboBoxToFind, string textValue)
        {
            SelectTypeValueComboBoxByNameAndValue(null, frameNameToSwitchTo, nameForComboBoxToFind, textValue);
        }
        
        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="nameForComboBoxToFind"> Name of the combobox a top level element</param>
        /// <param name="textValue">The value in the dropdown list to be selected</param>
        public void SelectTypeValueComboBoxByNameAndValue(string pageNameToSwitchTo, string frameNameToSwitchTo, string nameForComboBoxToFind, string textValue)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, nameForComboBoxToFind);
            //webelement.Click();
            IReadOnlyCollection<IWebElement> elementTrList = webelement.FindElements(By.TagName("tr"));
            bool isValueFound = false;
            foreach (IWebElement elementTr in elementTrList)
            {
                IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                foreach (IWebElement elementTd in elementTdList)
                {
                    string elementText = elementTd.Text.Replace(" ", "").ToLower();
                    if (elementText.Equals(textValue.Replace(" ", "").ToLower()))
                    {
                        elementTd.Click();
                        return;
                    }
                }
            }
            if (!isValueFound)
            {
                throw new Exception("Value: " + textValue + " wsa not found");
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dropDownValue"></param>
        //public void SelectTypeValueComboBoxByName(string dropDownValue)
        //{
        //    SelectTypeValueComboBoxByName(null, dropDownValue);
        //}       

        //public void SelectTypeValueComboBoxByName(string frameNameToSwitchTo, string dropDownValue)
        //{
        //    SelectTypeValueComboBoxByName(null, frameNameToSwitchTo, dropDownValue);
        //}

        //public void SelectTypeValueComboBoxByName(string pageNameToSwitchTo, string frameNameToSwitchTo, string dropDownValue)
        //{
        //    SAFINCALog.Debug(CommonWindowsAndPages.GetClassAndMethodName());
        //    IWebElement webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, dropDownValue);
        //    webelement.Click();
        //}


        /// <summary>
        /// Select from a table based on the table ID and a text string in the table
        /// </summary>
        /// <param name="idForTable">Id for the table</param>
        /// <param name="textToIdentifyAndSelect"></param>
        public void SelectFromTableByIdAndText(string idForTable, string textToIdentifyAndSelect)
        {
            SelectFromTableByIdAndText(null, idForTable, textToIdentifyAndSelect);
        }

        /// <summary>
        /// Select from a table based on the table ID and a text string in the table
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForTable">Id for the table</param>
        /// <param name="textToIdentifyAndSelect"></param>
        public void SelectFromTableByIdAndText(string frameNameToSwitchTo, string idForTable, string textToIdentifyAndSelect)
        {
            SelectFromTableByIdAndText(null, frameNameToSwitchTo, idForTable, textToIdentifyAndSelect);
        }

        /// <summary>
        /// Select from a table based on the table ID and a text string in the table
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForTable">Id for the table</param>
        /// <param name="textToIdentifyAndSelect"></param>
        public void SelectFromTableByIdAndText(string pageNameToSwitchTo, string frameNameToSwitchTo, string idForTable, params string[] textToIdentifyAndSelect)
        {
            int numberOfTextCriteria = textToIdentifyAndSelect.Length;
            int numberOfhits=0;
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, idForTable);
            IReadOnlyCollection<IWebElement> elementTrList = webelement.FindElements(By.TagName("tr"));

            foreach (IWebElement elementTr in elementTrList)
            {
                IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                foreach (IWebElement elementTd in elementTdList)
                {
                    string elementText = elementTd.Text.Replace(" ", "").ToLower();
                    if (elementText.Contains(textToIdentifyAndSelect[0].Replace(" ", "").ToLower()))
                    {
                        ++numberOfhits;
                        if (numberOfhits == numberOfTextCriteria)
                        {
                            elementTd.Click();                           
                            return;
                        }

                    }                    
                }
                numberOfhits=0; //Restart with a new row
            }
        }

        public void SelectFromTableByIdAndTextAndRightClickSelectByText(string idForTable, string rightCLickMenyElementName, string textToIdentifyAndSelect)
        {
            SelectFromTableByIdAndTextAndRightClickSelectByText(null, idForTable,rightCLickMenyElementName, textToIdentifyAndSelect);
        }


        public void SelectFromTableByIdAndTextAndRightClickSelectByText(string frameNameToSwitchTo, string idForTable, string rightCLickMenyElementName, string textToIdentifyAndSelect)
        {
            SelectFromTableByIdAndTextAndRightClickSelectByText(null, frameNameToSwitchTo, idForTable, rightCLickMenyElementName, textToIdentifyAndSelect);
        }

        /// <summary>
        /// Rightclick on text in a table. Select from the right click menu based on the given text string, textToIdentifyAndSelect
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="idForTable"></param>
        /// <param name="rightCLickMenyElementName"></param>
        /// <param name="textToIdentifyAndSelect"></param>
        public void SelectFromTableByIdAndTextAndRightClickSelectByText(string pageNameToSwitchTo, string frameNameToSwitchTo, string idForTable, string rightCLickMenyElementName, params string[] textToIdentifyAndSelect)
        {
            int numberOfTextCriteria = textToIdentifyAndSelect.Length;
            int numberOfhits = 0;
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo, idForTable);
            IReadOnlyCollection<IWebElement> elementTrList = webelement.FindElements(By.TagName("tr"));
            bool isElementFound = false;
            foreach (IWebElement elementTr in elementTrList)
            {
                IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                foreach (IWebElement elementTd in elementTdList)
                {
                    string elementText = elementTd.Text.Replace(" ", "").ToLower();
                    if (elementText.Contains(textToIdentifyAndSelect[0].Replace(" ", "").ToLower()))
                    {
                        ++numberOfhits;
                        if (numberOfhits == numberOfTextCriteria)
                        {
                            elementTd.Click();
                            Actions actions = new Actions(findWebDriverElement.Driver);
                            actions.MoveToElement(elementTd);
                            //RightClick on element on table
                            actions.ContextClick(elementTd).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
                            isElementFound = true;
                            break;
                                                  
                        }
                    }  
                }
                if (isElementFound)
                { 
                    break; 
                }
                numberOfhits = 0; //Restart with a new row
            }
            //Fetch the element from the popup menu
            webelement = findWebDriverElement.waitForElementByName(pageNameToSwitchTo, frameNameToSwitchTo, rightCLickMenyElementName);
            webelement.Click();     
        }

        //Select Methods
       public void SelectAnElementByNameAndValue(IWebElement element, String Value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(Value);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

       public void SelectAnElementByNameAndText(IWebElement element, String Text)
       {
           var selectElement = new SelectElement(element);
           selectElement.SelectByText(Text);
       }

        public void SelectAnElementByNameAndValue(String nameOFElementToClick, String Value)
        {
            IWebElement element = findWebDriverElement.waitForElementByName(null, null, nameOFElementToClick);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(Value);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

        public void SelectAnElementByNameAndText(String nameOFElementToClick, String Text)
        {
            IWebElement element = findWebDriverElement.waitForElementByName(null, null, nameOFElementToClick);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(Text);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

        public void SelectAnElementByClassAndText(String classOFElementToClick, String Text)
        {
            IWebElement element = findWebDriverElement.waitForElementByClassName(null, null, classOFElementToClick);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(Text);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

        public void SelectAnElementByXPathAndOption(String xPathForElementToClick, String option)
        {
            IWebElement element = findWebDriverElement.WaitForElementByXPath(null, null, xPathForElementToClick);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(option);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

        public void SelectAnElementByXPathAndIndex(String xPathForElementToClick, int index)
        {
            IWebElement element = findWebDriverElement.WaitForElementByXPath(null, null, xPathForElementToClick);
            var selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
            //new Org.openqa.selenium.support.ui.Select(element).selectByValue(option);
        }

        /// <summary>
        /// Return the text ofn an element, given page name, frame name, element ID 
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public string GetTextOnElementByID(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementId)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.waitForElementById(pageNameToSwitchTo, frameNameToSwitchTo,elementId);
            string textOnelement=webelement.Text;
            return textOnelement;
        }

        /// <summary>
        /// Return the text of an element, given element XPath 
        /// </summary>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public string GetTextOnElementByXPath( string elementXPath)
        {
            return GetTextOnElementByXPath(null, null, elementXPath);
        }

        /// <summary>
        /// Return the text of an element, given frame name, element XPath 
        /// </summary>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public string GetTextOnElementByXPath(string frameNameToSwitchTo, string elementXPath)
        {
            return GetTextOnElementByXPath(null, frameNameToSwitchTo, elementXPath);
        }

        /// <summary>
        /// Return the text ofn an element, given page name, frame name, element XPath 
        /// </summary>
        /// <param name="pageNameToSwitchTo"></param>
        /// <param name="frameNameToSwitchTo"></param>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public string GetTextOnElementByXPath(string pageNameToSwitchTo, string frameNameToSwitchTo, string elementXPath)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(pageNameToSwitchTo, frameNameToSwitchTo, elementXPath);
            string textOnelement = webelement.Text;
            return textOnelement;
        }

        // Check if element is displayed
        public bool IsElementDisplayed(By element)
        {
            return findWebDriverElement.IsElementDisplayed(element);
        }

        // Check if element is disabled
        public bool IsElementDisabled(By element)
        {
            return findWebDriverElement.IsElementEnabled(element);
        }

        // Check if Span element Exists
        public bool IsSpanElementExists(IWebElement element)
        {
            return findWebDriverElement.IsSpanElementExists(element);
        }

        //Check if Child Element exists
        public bool IsChildElementExists(IWebElement parentElement,String ChildTagName)
        {
            return findWebDriverElement.IsChildElementExists(parentElement, ChildTagName);
        }

        // Check if element is present
        public bool IsElementPresent(By element)
        {
            return findWebDriverElement.IsElementPresent(element);
        }

    }
}
