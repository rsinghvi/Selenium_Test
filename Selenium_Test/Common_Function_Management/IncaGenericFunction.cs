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

    public class IncaGenericFunction : SeleniumTestInitialize
    {

        //Click button using Id and option
        public void clickButtonUsingIdAndOption(String id, String buttontext)
        {
            IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
            IReadOnlyCollection<IWebElement> elementButtonList = webelement.FindElements(By.TagName("option"));

            foreach (IWebElement elementButton in elementButtonList)
            {
                if (elementButton.Text == buttontext)
                {
                    elementButton.Click();
                    break;
                }

            }

        }

        //Click button using Name and option - Selenium Session
        public void clickButtonUsingNameAndOption(String name, String buttontext)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByName(null, null, name);
            IReadOnlyCollection<IWebElement> elementButtonList = webelement.FindElements(By.TagName("option"));

            foreach (IWebElement elementButton in elementButtonList)
            {
                if (elementButton.Text == buttontext)
                {
                    elementButton.Click();
                    break;
                }

            }

        }

        //Click button using Id and option
        public void clickOptionUsingId(String id, String buttontext)
        {
            IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
            IReadOnlyCollection<IWebElement> elementButtonList = webelement.FindElements(By.TagName("option"));

            foreach (IWebElement elementButton in elementButtonList)
            {
                if (elementButton.Text.Contains(buttontext))
                {
                    elementButton.Click();
                    break;
                }

            }

        }

        //Verify Table row Div data
        public bool verifyTableRowDivData(String className, String text)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                        foreach (IWebElement elementTd in elementTdList)
                        {


                            if (elementTd.Text == text)
                            {
                                SAFINCALog.Info("Status is " + text + " and as expected");
                                //break;
                                return flag;
                            }
                        }

                       // if (flag) { break; }
                    }
                   // if (flag) { break; }

                } return flag;

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
            return flag;
        }

        // Click the menu from the left side of the panel
        public void clickLeftPanelMenu(String id, String param)
        {

            IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementLiList = webelement.FindElements(By.TagName("li"));
            try
            {
                foreach (IWebElement elementLi in elementLiList)
                {
                    IReadOnlyCollection<IWebElement> elementUlList = elementLi.FindElements(By.TagName("ul"));

                    foreach (IWebElement elementUl in elementUlList)
                    {
                        IReadOnlyCollection<IWebElement> elementList = elementLi.FindElements(By.TagName("li"));

                        foreach (IWebElement subelementList in elementList)
                        {
                            IReadOnlyCollection<IWebElement> anchorElementList = subelementList.FindElements(By.TagName("a"));

                            foreach (IWebElement anchorElement in anchorElementList)
                            {
                                if (anchorElement.Text == param)
                                {
                                    anchorElement.Click();
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag) { break; }

                        }
                        if (flag) { break; }
                    }
                    if (flag) { break; }
                }
            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Click the table on the main panel using class
        public void clickTableRowUsingClass(String className, String text)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                        foreach (IWebElement elementTd in elementTdList)
                        {
                            if (elementTd.GetAttribute("innerHTML").Contains(text))
                            {
                                elementTd.Click();
                                flag = true;
                                break;
                            }

                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Click the table on the main panel using class
        public void clickTableRowUsingClassAndInput(String className, String text)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                        foreach (IWebElement elementTd in elementTdList)
                        {
                            IReadOnlyCollection<IWebElement> elementInputList = elementTr.FindElements(By.TagName("input"));
                            foreach (IWebElement elementInput in elementInputList)
                            {
                                if (elementInput.GetAttribute("value") == text)
                                {
                                    elementInput.Click();
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag) { break; }
                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Click the table on the main panel using class
        public void clickTableHeaderUsingClass(String className, String text)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("thead"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("th"));
                        foreach (IWebElement elementTd in elementTdList)
                        {

                            if (elementTd.GetAttribute("innerHTML").Contains(""))
                            {
                                elementTd.Click();
                                flag = true;
                                break;
                            }

                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Verify the table row data on the main panel
        public bool verifyTableRowData(String className, String text)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                        foreach (IWebElement elementTd in elementTdList)
                        {

                            if (elementTd.GetAttribute("innerHTML").Contains(text))
                            {
                                SAFINCALog.Info("Verified and passed");
                                flag = true;
                                return flag; 
                            }

                        }

                       // if (flag) { break; }
                    }
                   // if (flag) { break; }

                }
                return flag;

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
            return flag;
        }

        //Click the table row using class with condition on the main panel
        public void clickTableRowUsingClassWithCondition(String className, String verifyText, String clickText)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        if (elementTr.GetAttribute("innerHTML").Contains(verifyText))
                        {
                            IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                            foreach (IWebElement elementTd in elementTdList)
                            {
                                if (elementTd.GetAttribute("innerHTML").Contains(clickText))
                                {
                                    elementTd.Click();
                                    flag = true;
                                    break;
                                }

                            }
                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Click the table on the main panel using class
        public void clickTableRowUsingXpath(String xpath, String text)
        {
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(null, null, xpath);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            //Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                        foreach (IWebElement elementTd in elementTdList)
                        {

                            if (elementTd.GetAttribute("innerHTML").Contains(text))
                            {
                                elementTd.Click();
                                flag = true;
                                break;
                            }

                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        //Click the table row using xpath with condition on the main panel
        public void clickTableRowUsingXpathWithCondition(String xpath, String verifyText, String clickText)
        {
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(null, null, xpath);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        if (elementTr.GetAttribute("innerHTML").Contains(verifyText))
                        {
                            IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                            foreach (IWebElement elementTd in elementTdList)
                            {
                                if (elementTd.GetAttribute("innerHTML").Contains(clickText))
                                {
                                    elementTd.Click();
                                    flag = true;
                                    break;
                                }
                            }
                        }

                        if (flag) { break; }
                    }
                    if (flag) { break; }

                }

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
        }

        

        //Verify the table row data using Class with condition to verify on the main panel
        public bool verifyTableRowDataUsingClassWithCondition(String className, String verifyText, String clickText)
        {
            IWebElement webelement = findWebDriverElement.waitForElementByClassName(null, null, className);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        if (elementTr.GetAttribute("innerHTML").Contains(verifyText))
                        {
                            IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                            foreach (IWebElement elementTd in elementTdList)
                            {
                                if (elementTd.GetAttribute("innerHTML").Contains(clickText))
                                {
                                    SAFINCALog.Info("Status is " + clickText + " which is as expected");
                                    flag = true;
                                    return flag;
                                    //break;
                                }

                            }
                        }

                        //if (flag) { break; }
                    }
                   // if (flag) { break; }

                } return flag;

            }
            catch (Exception e)
            {
                SAFINCALog.TestCaseErrorMessage(e);
            }
            return flag;
        }

        //Verify the table row using xpath with condition on the main panel
        public bool verifyTableRowDataUsingXpathWithCondition(String xpath, String verifyText, String clickText)
        {
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(null, null, xpath);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {
                        if (elementTr.GetAttribute("innerHTML").Contains(verifyText))
                        {
                            IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                            foreach (IWebElement elementTd in elementTdList)
                            {
                                if (elementTd.GetAttribute("innerHTML").Contains(clickText))
                                {
                                    SAFINCALog.Info("Status is " + clickText + " which is as expected");
                                    flag = true;
                                    //break;
                                    return flag;
                                }
                            }
                        }

                        //if (flag) { break; }
                    }
                    //if (flag) { break; }

                } return flag;

            }
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
            return flag;
        }

        //Verify the table row div data(column as index) using xpath on the main panel
        public bool verifyTableDivDataUsingXpath(String xpath, int index, String verifyText)
        {
            IWebElement webelement = findWebDriverElement.WaitForElementByXPath(null, null, xpath);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementDivList = webelement.FindElements(By.TagName("tbody"));

            Dictionary<String, String> attributeList = new Dictionary<string, string>();

            try
            {

                foreach (IWebElement elementTable in elementDivList)
                {

                    IReadOnlyCollection<IWebElement> elementTrList = elementTable.FindElements(By.TagName("tr"));
                    foreach (IWebElement elementTr in elementTrList)
                    {                        
                            IReadOnlyCollection<IWebElement> elementTdList = elementTr.FindElements(By.TagName("td"));
                            int counter = 0;
                            foreach (IWebElement elementTd in elementTdList)
                            {
                            if (counter == index)
                            {
                                if (elementTd.Text == verifyText)
                                {
                                    SAFINCALog.Info("Results are not expected");
                                    flag = true;
                                    return flag;                                  
                                    //break;
                                }
                                
                            }
                            counter++;
                            }
                        

                        //if (flag) { break; }
                    }
                    //if (flag) { break; }

                }
                return flag;
            } 
            catch (Exception e) { SAFINCALog.TestCaseErrorMessage(e); }
            return flag;
        } 
    }

}



