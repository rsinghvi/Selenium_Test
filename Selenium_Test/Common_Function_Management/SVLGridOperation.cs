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
using SAFINCA.ParameterAndUserDataMgn;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using System.Globalization;
using OpenQA.Selenium.Support.UI;


namespace SAFINCA.Common_Function_Management
{

    public class SVLGridOperation : SeleniumTestInitialize
    {
        public bool clickFlag = false;
        public bool insertFlag = false;


        /*
         * ////////////////////////////////////////////////////////////////////////////////////
         * /////////////////////////////////////////////////////////////////////////////////////
         * ///////////////////////////CORE SVL GRID METHODS/////////////////////////////////////
         * /////////////////////////////////////////////////////////////////////////////////////
         * /////////////////////////////////////////////////////////////////////////////////////
         * */


        /*
       * //////////////////////////////////////////////////////////////////////////////////////
       * ///////////////////////////CLICK OR SELECT RECORD IN DYNAMIC GRID /////////////////////
       * //////////////////////////////////////////////////////////////////////////////////////
       * */
        #region Click/Select Records
        /*
        * Method used to select record in svl grid based on grid position , field
        *Parameter Usage
        *gridPosition : gridPosition of the dynamic grid in the page
        *field : data-field attribute of the column to select
        *data : data based on which the record should be selected
        * */
        public void selectRecordSVLGrid(int gridPosition, string field, string data)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> elementTdList = null;
            clickFlag = false;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                //get all the td list for a particular tr
                elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + field + "']"));

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                //Iterate over the td list
                foreach (IWebElement td in elementTdList)
                {

                    Boolean isPresent = operateOnWebDriverElement.IsChildElementExists(td, "span");

                    if (isPresent)
                    {
                        IWebElement span = td.FindElement(By.TagName("span"));

                        String value = span.GetAttribute("innerHTML");

                        if (value.Contains(data))
                        {
                            span.Click();
                            clickFlag = true;
                            break;
                        }
                    }
                }

            }

            catch (Exception e)
            {
                clickFlag = false;
                throw e;
            }

        }

        //Select a record in dynamic grid based on data-field and row number
        /*Parameter Usage
         * gridPosition : gridPosition of the dynamic grid in the page
         * field : data-field attribute of the column to select
         * row : row value can be 'first' or 'last' or actual number like '1','2' etc.
         **/
        public bool selectRecordInDynamicGridBasedOnRowNumber(int gridPosition, string field, String row)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> tdListCollection = null; List<IWebElement> tdList = null; bool selectedFlag = false;
            int rowCount = 0;
            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]//td[@data-field='" + field + "']"));

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + field + "']"));
                }

                tdList = new List<IWebElement>(tdListCollection);

                //Iterate over the input list
                for (int i = 0; i < tdList.Count; i++)
                {
                    if (row.Equals("first") && i == 0) { tdList[i].Click(); break; }

                    if (row.Equals("last") && i == tdList.Count - 1) { tdList[i].Click(); break; }

                    else if (int.TryParse(row, out rowCount) && i == rowCount) { tdList[i].Click(); break; }


                } // end of for each

                if (!selectedFlag) { SAFINCALog.Info("Record Not Found"); throw new NotFoundException("Record Not Found with row:" + row); }

                return selectedFlag;
            }

            catch (Exception e)
            {
                selectedFlag = false;
                return selectedFlag;
                throw e;
            }

        }

        //Double Click a record in dynamic grid based on data-field and row number
        /*Parameter Usage
         * gridPosition : gridPosition of the dynamic grid in the page
         * field : data-field attribute of the column to select
         * row : row value can be 'first' or 'last' or actual number like '1','2' etc.
         * tag : tag on which the action should be performed
         **/
        public bool doubleClickRecordInDynamicGridBasedOnRowNumber(int gridPosition, string field, String row, String tag)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> tdListCollection = null; List<IWebElement> tdList = null; bool selectedFlag = false;
            int rowCount = 0;
            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]//tr[@data-field='" + field + "']"));

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + field + "']"));
                }

                tdList = new List<IWebElement>(tdListCollection);

                //Iterate over the input list
                for (int i = 0; i < tdList.Count; i++)
                {
                    if (row.Equals("first") && i == 0) { new Actions(driver).DoubleClick(tdList[i].FindElement(By.TagName(tag))).Perform(); break; }

                    if (row.Equals("last") && i == tdList.Count - 1) { new Actions(driver).DoubleClick(tdList[i].FindElement(By.TagName(tag))).Perform(); break; }

                    else if (int.TryParse(row, out rowCount) && i == rowCount) { new Actions(driver).DoubleClick(tdList[i].FindElement(By.TagName(tag))).Perform(); break; }


                } // end of for each

                if (!selectedFlag) { SAFINCALog.Info("Record Not Found"); throw new NotFoundException("Record Not Found with row:" + row); }

                return selectedFlag;
            }

            catch (Exception e)
            {
                selectedFlag = false;
                return selectedFlag;
                throw e;
            }

        }

        //Select a record in dynamic grid based on data-field and row number
        /*Parameter Usage
         * gridPosition : gridPosition of the dynamic grid in the page
         * field : data-field attribute of the column to select
         * row : row value can be 'first' or 'last' or actual number like '1','2' etc.
         **/
        public bool selectRecordTRInDynamicGridBasedOnRowNumber(int gridPosition, string field, String row)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> trListCollection = null; List<IWebElement> trList = null; bool selectedFlag = false;
            int rowCount = 0;
            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                trListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]//td[@data-field='" + field + "']/ancestor::tr"));

                if (trListCollection.Count == 0)
                {
                    trListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']/ancestor::tr"));
                }

                if (trListCollection.Count == 0)
                {
                    trListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + field + "']/ancestor::tr"));
                }

                trList = new List<IWebElement>(trListCollection);

                //Iterate over the input list
                for (int i = 0; i < trList.Count; i++)
                {
                    if (row.Equals("first") && i == 0) { trList[i].Click(); selectedFlag = true; break; }

                    if (row.Equals("last") && i == trList.Count - 1) { trList[i].Click(); selectedFlag = true; break; }

                    else if (int.TryParse(row, out rowCount) && i == rowCount) { trList[i].Click(); selectedFlag = true; break; }


                } // end of for each

               // if (!selectedFlag) { SAFINCALog.Info("Record Not Found"); throw new NotFoundException("Record Not Found with row:" + row); }

                return selectedFlag;
            }

            catch (Exception e)
            {
                selectedFlag = false;
                return selectedFlag;
                throw e;
            }

        }

        #endregion Click/Select Records

        /*
        * //////////////////////////////////////////////////////////////////////////////////////
        * ///////////////////////////SEARCH / SELECT RECORD IN DYNAMIC GRID/////////////////////
        * //////////////////////////////////////////////////////////////////////////////////////
        * */
        #region Search Records
        //Method used to Search and Select Record

        public void searchAndSelectSVLGrid(int gridPosition, string field, string textToSearch)
        {

            searchDataByFieldSVLGrid(gridPosition, field, textToSearch);

            timeOuts(2);

            operateOnWebDriverElement.ClickAnElementByClassName("vpBody");

            selectRecordSVLGrid(gridPosition, field, textToSearch);
        }

        //Method used to search data using the filter in SVl Grid

        public void searchDataByFieldSVLGrid(int gridPosition, string field, string textToSearch)
        {

            IWebElement pageElement = null; IWebElement inputTD = null;

            try
            {
                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                inputTD = pageElement.FindElement(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@class,'HeadF')]/td[@data-field='" + field + "']//input"));

                if (!inputTD.Enabled) { timeOuts(5); }
                inputTD.SendKeys(textToSearch);
                inputTD.SendKeys(Keys.Enter);

            }

            catch (Exception e)
            {

                throw e;
            }


        }

        #endregion Search Records

        /*
        * //////////////////////////////////////////////////////////////////////////////////////
        * ///////////////////////////RETURN RECORD FROM DYNAMIC GRID ROWS/////////////////////
        * //////////////////////////////////////////////////////////////////////////////////////
        * */
        #region Return Records

        //Method to return any data corresponding to the seach field
        public string ReturnDataByDataFieldSVLGrid(int gridPosition, string inputField, String inputData, String outputField, String tag)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> elementTrList = null;
            clickFlag = false;
            string dataToReturn = "";

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                //(//div[contains(@class,'DynamicGrid')])[2]//tr[contains(@data-key,'==')]/td[@data-field='planningarea']//span[contains(text(),'Floor Left')]/ancestor::tr
                elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + inputField + "']//span[contains(text(),'" + inputData + "')]/ancestor::tr"));

                if (elementTrList.Count == 0)
                {
                    elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + inputField + "']//span[contains(text(),'" + inputData + "')]/ancestor::tr"));
                }

                //pageElement.get
                //Iterate over the td list
                foreach (IWebElement tr in elementTrList)
                {
                    IWebElement td = tr.FindElement(By.XPath("td[@data-field='" + outputField + "']"));

                    dataToReturn = td.FindElement(By.TagName(tag)).GetAttribute("innerHTML");

                    if (!dataToReturn.Equals(""))
                    {
                        return dataToReturn;
                    }
                }

                return dataToReturn;
            }

            catch (Exception e)
            {
                return dataToReturn;
                throw e;
            }

        }


        //Return record value in dynamic grid based on data-field and row number
        /*Parameter Usage
         * gridPosition : gridPosition of the dynamic grid in the page
         * field : data-field attribute of the column to select
         * row : row value can be 'first' or 'last' or actual number like '1','2' etc.
         * tag : tag from which the data should be retreived
         **/
        public String ReturnRecordInDynamicGridBasedOnRowNumber(int gridPosition, string field, String row, String tag, String Attribute)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> tdListCollection = null; List<IWebElement> tdList = null;
            String dataReturn = "";

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]//td[@data-field='" + field + "']"));

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + field + "']"));
                }

                tdList = new List<IWebElement>(tdListCollection);
                int rowCount = 0;
                //Iterate over the input list
                for (int i = 0; i < tdList.Count; i++)
                {
                    if (row.Equals("first") && i == 0) { dataReturn = tdList[i].FindElement(By.TagName(tag)).GetAttribute(Attribute); break; }

                    if (row.Equals("last") && i == tdList.Count - 1) { dataReturn = tdList[i].FindElement(By.TagName(tag)).GetAttribute(Attribute); break; }

                    else if (int.TryParse(row, out rowCount) && i == rowCount) { dataReturn = tdList[i].FindElement(By.TagName(tag)).GetAttribute(Attribute); break; }

                } // end of for each

                //if (!returnFlag) { SAFINCALog.Info("No Record returned"); throw new NotFoundException("No Record returned with row:" + row+" and Tag : "+tag); }

                return dataReturn;
            }

            catch (Exception e)
            {
                return dataReturn;
                throw e;
            }

        }


        //Return record count in dynamic grid
        /*Parameter Usage
         * gridPosition : gridPosition of the dynamic grid in the page
         **/
        public int ReturnRecordCountOfDynamicGrid(int gridPosition)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> tdListCollection = null;
            int recordCount = 0;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]"));

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]"));
                }

                if (tdListCollection.Count == 0)
                {
                    tdListCollection = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]"));
                }

                recordCount = tdListCollection.Count();


                return recordCount;
            }

            catch (Exception e)
            {
                return recordCount;
                throw e;
            }

        }
        #endregion Return Records

        /*
        * //////////////////////////////////////////////////////////////////////////////////////
        * ///////////////////////////PERFORM ACTION ON DYNAMIC GRID ROWS/////////////////////
        * //////////////////////////////////////////////////////////////////////////////////////
        * */
        #region Perform Action

        //Method to perform any action like click/select based on input data
        /*Parameter Usage
         * gridPosition - dynamic grid position on the page
         * inputfield - data field of the input field which is used as a search input
         * inputData - input data used to locate the row in the dynamic grid
         * outputField - data field of the output field which will be used as a output
         * outputData - output data if anything on which action will be performed
         * Action - action indicates either click / select / other actions
         * valueOrText - Value or Text based on which Select operation will be performed
         */
        public bool PerformActionSVLGrid(int gridPosition, string inputField, String inputData, String outputField, String outputData, String Action, String valueOrText)
        {
            IWebElement pageElement = null; bool actionFlag = false;
            IReadOnlyCollection<IWebElement> elementTrList = null; IWebElement actionElement = null;

            try
            {
                timeOuts(2);
                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                //(//div[contains(@class,'DynamicGrid')])[2]//tr[contains(@data-key,'==')]/td[@data-field='planningarea']//span[contains(text(),'Floor Left')]/ancestor::tr
                elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + inputField + "']//span[contains(text(),'" + inputData + "')]/ancestor::tr"));

                if (elementTrList.Count == 0)
                {
                    elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + inputField + "']//span[contains(text(),'" + inputData + "')]/ancestor::tr"));
                }

                if (elementTrList.Count == 0)
                {
                    elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + inputField + "']//span[contains(text(),'" + inputData + "')]/ancestor::tr"));
                }

                //Iterate over the td list
                foreach (IWebElement tr in elementTrList)
                {
                    IWebElement td = tr.FindElement(By.XPath("td[@data-field='" + outputField + "']"));

                    if (Action.Equals("click"))
                    {
                        actionElement = td.FindElement(By.TagName("button"));
                        actionElement.Click();
                        actionFlag = true;
                    }
                    else if (Action.Equals("select"))
                    {
                        actionElement = td.FindElement(By.TagName("select"));

                        if (valueOrText.Equals("Value"))
                            operateOnWebDriverElement.SelectAnElementByNameAndValue(actionElement, outputData);
                        else
                            operateOnWebDriverElement.SelectAnElementByNameAndText(actionElement, outputData);

                        actionFlag = true;
                    }
                    else if (Action.Equals("insert"))
                    {
                        actionElement = td.FindElement(By.TagName("input"));

                        for (int i = 0; i < 10; i++)
                        {
                            actionElement.SendKeys(Keys.Backspace);
                        }

                        actionElement.SendKeys(outputData);
                        timeOuts(1);
                        actionElement.SendKeys(Keys.Tab);

                        actionFlag = true;
                    }

                    else
                    {

                    }

                }

                return actionFlag;
            }

            catch (Exception e)
            {
                return actionFlag;
                throw e;
            }

        }

        // Method to Insert into Dynamic Grid based on Grid Position , Data Field , Row Number and Data
        public void insertData_InputField_DynamicGrid(int gridPosition, string field, int row, string data)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> elementTdList = null;
            insertFlag = false; int count = 1;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + field + "']"));

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                //Iterate over the td list
                foreach (IWebElement td in elementTdList)
                {
                    Boolean isPresent = operateOnWebDriverElement.IsChildElementExists(td, "input");

                    if (isPresent && count == row)
                    {
                        IWebElement input = td.FindElement(By.TagName("input"));

                        for (int i = 0; i < 10; i++)
                        {
                            input.SendKeys(Keys.Backspace);
                        }
                        timeOuts(1);

                        input.SendKeys(data);

                        timeOuts(1);

                        input.SendKeys(Keys.Tab);

                        insertFlag = true;
                        break;
                    }

                    count++;
                }
            }

            catch (Exception e)
            {
                clickFlag = false;
                throw e;
            }

        }


        // select data from combo box in Dynamic Grid based on Grid Position , Data Field , Row Number and Data
        public bool PerformActionBasedOnRowNumberSVLGrid(int gridPosition,int row, string field, String outputData, String Action, String valueOrText)
        {
            IWebElement pageElement = null; bool actionFlag = false;
            IReadOnlyCollection<IWebElement> elementTdList = null; IWebElement actionElement = null;
            bool performFlag = false; int counter = 0;
            try
            {
                timeOuts(2);
                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                //(//div[contains(@class,'DynamicGrid')])[2]//tr[contains(@data-key,'==')]/td[@data-field='planningarea']//span[contains(text(),'Floor Left')]/ancestor::tr
                elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + field + "']"));

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + field + "']"));
                }

                //Iterate over the td list
                foreach (IWebElement td in elementTdList)
                {

                    if (row == counter) { performFlag = true; }

                    if (performFlag)
                    {
                        if (Action.Equals("click"))
                        {
                            actionElement = td.FindElement(By.TagName("button"));
                            actionElement.Click();
                            actionFlag = true;
                        }
                        else if (Action.Equals("select"))
                        {
                            actionElement = td.FindElement(By.TagName("select"));

                            if (valueOrText.Equals("Value"))
                                operateOnWebDriverElement.SelectAnElementByNameAndValue(actionElement, outputData);
                            else
                                operateOnWebDriverElement.SelectAnElementByNameAndText(actionElement, outputData);

                            actionFlag = true;
                        }
                        else if (Action.Equals("insert"))
                        {
                            actionElement = td.FindElement(By.TagName("input"));

                            for (int i = 0; i < 10; i++)
                            {
                                actionElement.SendKeys(Keys.Backspace);
                            }

                            actionElement.SendKeys(outputData);
                            timeOuts(1);
                            actionElement.SendKeys(Keys.Tab);

                            actionFlag = true;
                        }

                        else
                        {
                            //Other actions
                        }
                        break;
                    }

                    counter++;

                }

                return actionFlag;
            }

            catch (Exception e)
            {
                return actionFlag;
                throw e;
            }

        }



        //Method to perform any action like click/select based on input data
        /*Parameter Usage
         * gridPosition - dynamic grid position on the page
         * inputfield - data field of the input field which is used as a search input
         * inputData - input data used to locate the row in the dynamic grid
         * outputField - data field of the output field which will be used as a output
         * outputData - output data if anything on which action will be performed
         * Action - action indicates either click / select / other actions
         * valueOrText - Value or Text based on which Select operation will be performed
         */
        public bool PerformActionBasedOnInputTagSVLGrid(int gridPosition, string inputField, String inputData, String outputField, String outputData, String Action, String valueOrText)
        {
            IWebElement pageElement = null; bool actionFlag = false;
            IReadOnlyCollection<IWebElement> elementTrList = null; IWebElement actionElement = null;

            try
            {
                timeOuts(2);
                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                //(//div[contains(@class,'DynamicGrid')])[2]//tr[contains(@data-key,'==')]/td[@data-field='planningarea']//span[contains(text(),'Floor Left')]/ancestor::tr
                elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + inputField + "']//input[contains(@value,'" + inputData + "')]/ancestor::tr"));

                if (elementTrList.Count == 0)
                {
                    elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + inputField + "']//input[contains(@value,'" + inputData + "')]/ancestor::tr"));
                }

                if (elementTrList.Count == 0)
                {
                    elementTrList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'=')]/td[@data-field='" + inputField + "']//input[contains(@value,'" + inputData + "')]/ancestor::tr"));
                }

                //Iterate over the td list
                foreach (IWebElement tr in elementTrList)
                {
                    IWebElement td = tr.FindElement(By.XPath("td[@data-field='" + outputField + "']"));

                    if (Action.Equals("click"))
                    {
                        actionElement = td.FindElement(By.TagName("button"));
                        actionElement.Click();
                        actionFlag = true;
                        break;
                    }
                    else if (Action.Equals("select"))
                    {
                        actionElement = td.FindElement(By.TagName("select"));

                        if (valueOrText.Equals("Value"))
                            operateOnWebDriverElement.SelectAnElementByNameAndValue(actionElement, outputData);
                        else
                            operateOnWebDriverElement.SelectAnElementByNameAndText(actionElement, outputData);

                        actionFlag = true;
                        break;
                    }
                    else if (Action.Equals("insert"))
                    {
                        actionElement = td.FindElement(By.TagName("input"));

                        for (int i = 0; i < 10; i++)
                        {
                            actionElement.SendKeys(Keys.Backspace);
                        }

                        actionElement.SendKeys(outputData);
                        timeOuts(1);
                        actionElement.SendKeys(Keys.Tab);

                        actionFlag = true;
                        break;
                    }

                    else
                    {
                        //other actions
                    }

                }

                return actionFlag;
            }

            catch (Exception e)
            {
                return actionFlag;
                throw e;
            }

        }

        #endregion Perform Action
        /*
        * //////////////////////////////////////////////////////////////////////////////////////
        * ///////////////////////////IS RECORD PRESENT IN DYNAMIC GRID/////////////////////
        * //////////////////////////////////////////////////////////////////////////////////////
        * */
        #region Is Record Present
        //Method used to check record is present in svl grid based on grid position , field
        public bool isRecordPresentSVLGrid(int gridPosition, string field, String[] data)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> elementTdList = null;
            bool isPresentFlag = false; String dataOfField = null; int count = 0;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + field + "']"));

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                //Iterate over the td list
                foreach (IWebElement td in elementTdList)
                {
                    IWebElement span = td.FindElement(By.TagName("span"));

                    dataOfField = span.GetAttribute("innerHTML");

                    if (!dataOfField.Equals(""))
                    {
                        if (Array.Exists(data, element => element == dataOfField)) { isPresentFlag = true; break; }
                        else { isPresentFlag = false; }
                    }

                } // end of for each

                SAFINCALog.Info("Td count" + count);

                return isPresentFlag;
            }

            catch (Exception e)
            {
                isPresentFlag = false;
                return isPresentFlag;
                throw e;
            }

        }

        public bool isAllRecordsPresentSVLGrid(int gridPosition, string field, String[] data)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> elementTdList = null;
            bool isPresentFlag = false; String dataOfField = null; int count = 0;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]/td[@data-field='" + field + "']"));

                if (elementTdList.Count == 0)
                {
                    elementTdList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]/td[@data-field='" + field + "']"));
                }

                //Iterate over the td list
                foreach (IWebElement td in elementTdList)
                {
                    IWebElement span = td.FindElement(By.TagName("span"));

                    dataOfField = span.GetAttribute("innerHTML");

                    if (!dataOfField.Equals(""))
                    {
                        if (Array.Exists(data, element => element == dataOfField)) { isPresentFlag = true; count++; }
                        else { isPresentFlag = false; }
                    }

                } // end of for each

                SAFINCALog.Info("Td count" + count);

                if (data.Length == count) { SAFINCALog.Info("Record count match"); } else { new NotFoundException("All records didn't match correctly"); }

                return isPresentFlag;
            }

            catch (Exception e)
            {
                isPresentFlag = false;
                return isPresentFlag;
                throw e;
            }

        }


        //Method to search if a record is present in the dynamic grid or not
        public bool isRecordPresent_InputField_DynamicGrid(int gridPosition, string field, String data)
        {
            IWebElement pageElement = null;
            IReadOnlyCollection<IWebElement> TdInputList = null; bool isPresentFlag = false;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                TdInputList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@data-key,'==')]//input[@data-field='" + field + "']"));

                if (TdInputList.Count == 0)
                {
                    TdInputList = pageElement.FindElements(By.XPath("(//div[contains(@class,'DynamicGrid')])[" + gridPosition + "]//tr[contains(@external-value,'==')]//input[@data-field='" + field + "']"));
                }


                //Iterate over the input list
                foreach (IWebElement input in TdInputList)
                {
                    if (input.GetAttribute("value") != null && input.GetAttribute("value").Equals(data)) { isPresentFlag = true; break; }
                    else { }

                } // end of for each

                if (!isPresentFlag) { SAFINCALog.Info("Record Not Found"); throw new NotFoundException(); }

                return isPresentFlag;
            }

            catch (Exception e)
            {
                isPresentFlag = false;
                return isPresentFlag;
                throw e;
            }

        }

        #endregion Is Record Present
        /*
        * //////////////////////////////////////////////////////////////////////////////////////
        * ///////////////////////////NAVIGATE THROUGH DYNAMIC GRID/////////////////////
        * //////////////////////////////////////////////////////////////////////////////////////
        * */
        #region Navigate Methods
        //Method used to navigate SVL grid front and back

        //flag can be 1.) first 2.) prev 3.) next 4.)last
        public bool navigatePagesSVLGrid(int gridPosition, string flag)
        {
            IWebElement SVLGridElement = null; IWebElement pageElement = null; IWebElement toolBoxElement = null;
            IWebElement navButton = null; bool navigateFlag = false;

            try
            {

                //Find the Page Element
                pageElement = findWebDriverElement.waitForElementById(null, null, "Portal");

                IReadOnlyCollection<IWebElement> dynamicGridCollectionList = pageElement.FindElements(By.ClassName("DynamicGrid"));

                List<IWebElement> dynamicGridList = new List<IWebElement>(dynamicGridCollectionList);

                if (dynamicGridList.Count != 0)
                {
                    SVLGridElement = dynamicGridList[gridPosition - 1];

                    toolBoxElement = SVLGridElement.FindElement(By.ClassName("Toolbox"));

                    navButton = SVLGridElement.FindElement(By.ClassName(flag));

                    if (navButton.Enabled)
                    {
                        navigateFlag = true;
                        navButton.Click();
                    }

                    else
                    {
                        new NotFoundException();
                    }
                }

            }

            catch (Exception e)
            {
                navigateFlag = false;
                throw e;
            }
            return navigateFlag;
        }


        // Method used to Navigate and Search a Record and Return True or False
        public bool navigateAndSearchSVLGrid(int gridPosition, String field, String data, String navigateFlag)
        {
            bool navigationFlag = false;
            try
            {
                String[] dataArray = new String[] { data };

                while (!navigationFlag)
                {

                    if (isRecordPresentSVLGrid(gridPosition, field, dataArray)) { navigationFlag = true; break; }

                    else
                    {
                        if (navigatePagesSVLGrid(gridPosition, navigateFlag)) { timeOuts(1); }
                        else { navigationFlag = true; throw new NotFoundException(); }

                    }
                }

            }

            catch (Exception e)
            {
                throw e;
            }

            return navigationFlag;
        }

        // Method used to Navigate and Select a Record and Return True or False
        public bool navigateAndSelectSVLGrid(int gridPosition, String field, String data, String navigateFlag)
        {
            bool navigationFlag = false;
            try
            {

                while (!navigationFlag)
                {

                    selectRecordSVLGrid(gridPosition, field, data);
                    if (clickFlag) { navigationFlag = true; break; }

                    else
                    {
                        if (navigatePagesSVLGrid(gridPosition, navigateFlag)) { timeOuts(1); }
                        else { navigationFlag = true; throw new NotFoundException(); }

                    }
                }

            }

            catch (Exception e)
            {
                throw e;
            }

            return navigationFlag;
        }

        #endregion Navigate Methods

    }
}



