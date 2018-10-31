using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using SAFINCA.Application.Web.Selenium;
using Com.Sogeti.Tests.SeleniumTest.Object_Repository;
using Com.Sogeti.Tests.SeleniumTest.Test_Cases;
using NUnit.Framework;
using SAFINCA.LogMgn;
using Com.Sogeti.Tests.SeleniumTest.Test_Data;
using SAFINCA.Common_Function_Management;
using System.Data;
using System.Data.SqlClient;
using SAFINCA.ParameterAndUserDataMgn;
using System.Threading;
using SAFINCA.Common_Function_Management;
using SAFINCA.CommonFuncMgn;
using OpenQA.Selenium.Interactions;

namespace Com.Sogeti.Tests.SeleniumTest.Test_Cases
{

    [TestClass]
    public class AutomationPractice : SeleniumTestInitialize
    {
        [TestInitialize]
        public void Setup()
        {
            SeleniumSetup();
            WriteTestResultsExcel.setTestClassStart("Test the Demo site automationpractice", dateTime);
        }

        [TestCleanup]
        public void tearDown()
        {
            SeleniumQuit();
            WriteTestResultsExcel.setTestClassFinish("Test the Demo site automationpractice");
        }

        [TestMethod]
        public void TC2_AddToCart()
        {
           
            WriteTestResultsExcel.setTestCaseStart("Add the item to cart", "Add the item to cart");
            try
            {
                //Test step 1
                {
                    WriteTestResultsExcel.setTestStepStart("Click the T-Shirt section", "Click the T-Shirt section");

                    String productLink = getDictionaryValue(Test_Objects.PRODUCT_LINK, "link");
                    IWebElement webelement = findWebDriverElement.waitForElementByLinkText(null,null, productLink);
                    webelement.Click();

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 2
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Faded Short Sleeve T-shirt", "Click on Faded Short Sleeve T-shirt");

                    String productName= getDictionaryValue(Test_Objects.PRODUCT_NAME, "link");
                    IWebElement webelement = findWebDriverElement.waitForElementByLinkText(null, null, productName);
                    webelement.Click();

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 3
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Add to Cart", "Click on Add to Cart");

                    String addToCart = getDictionaryValue(Test_Objects.ADDTOCART_BUTTON, "id");
                    operateOnWebDriverElement.ClickAnElementById(addToCart);
                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 4
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Proceed to Checkout", "Click on Proceed to Checkout");

                    String checkoutLink = getDictionaryValue(Test_Objects.PROCEEDTOCHECKOUT_BUTTON, "link");
                    IWebElement webelement = findWebDriverElement.waitForElementByLinkText(null, null, checkoutLink);

                    webelement.Click();

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 5
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Proceed to Checkout", "Click on Proceed to Checkout");

                    String checkoutLink = getDictionaryValue(Test_Objects.PROCEEDTOCHECKOUT_BUTTON, "link");
                    IWebElement webelement = findWebDriverElement.waitForElementByLinkText(null, null, checkoutLink);
                    webelement.Click();

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }




            }
            catch (Exception e)
            {
                WriteTestResultsExcel.setTestStepFinish("Fail", e);
                WriteTestResultsExcel.setTestCaseFinish("Fail");
                throw e;
            }
        }

     
        
    }
}

        