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
    public class TestingPool : SeleniumTestInitialize
    {
        [TestInitialize]
        public void Setup()
        {
            SeleniumSetup();
            WriteTestResultsExcel.setTestClassStart("Test the Demo site of testingpool", dateTime);
        }

        [TestCleanup]
        public void tearDown()
        {
            SeleniumQuit();
            WriteTestResultsExcel.setTestClassFinish("Test the Demo site testingpool");
        }

        [TestCategory("UnitTest")]
        [TestMethod]
        public void TC1_RegisterDetails()
        {
           
            WriteTestResultsExcel.setTestCaseStart("Register the details", "Register the details");
            try
            {
                //Test step 1
                {
                    WriteTestResultsExcel.setTestStepStart("Enter the First and Last Name", "Enter the First and Last Name");

                    String firstNameId = getDictionaryValue(Test_Objects.FIRST_NAME, "id");
                    String lastNameId = getDictionaryValue(Test_Objects.LAST_NAME, "id");                                      
                    operateOnWebDriverElement.InsertInToFieldById(firstNameId, TestData.firstName);
                    operateOnWebDriverElement.InsertInToFieldById(lastNameId, TestData.lastName);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 2
                {
                    WriteTestResultsExcel.setTestStepStart("Select the Gender", "Select the Gender");

                    String genderId = getDictionaryValue(Test_Objects.GENDER_RADIO, "id");                    
                    operateOnWebDriverElement.ClickAnElementById(genderId);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 3
                {
                    WriteTestResultsExcel.setTestStepStart("Select the Day", "Select the Day from the list");

                    String weekdayName = getDictionaryValue(Test_Objects.SELECT_DAY, "name");
                    incaFunction.clickButtonUsingNameAndOption(weekdayName, TestData.weekDay);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                //Test step 4
                {
                    WriteTestResultsExcel.setTestStepStart("Select the option from Drop Down", "Select the option from Drop Down");

                    String dropDownName = getDictionaryValue(Test_Objects.SELECT_FROM_DROPDOWN, "name");
                    incaFunction.clickButtonUsingNameAndOption(dropDownName, TestData.number);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }               

                //Test step 5
                {
                    WriteTestResultsExcel.setTestStepStart("Click the Submit button", "Click the Submit button");

                    String submitBtn = getDictionaryValue(Test_Objects.SUBMIT_BUTTON, "id");
                    operateOnWebDriverElement.ClickAnElementById(submitBtn);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);

                }

                // Test step 6
                {
                    WriteTestResultsExcel.setTestStepStart("Click Ok on the pop up window", "Click Ok on the pop up window");

                    IAlert submitAlert = driver.SwitchTo().Alert();
                    submitAlert.Accept();

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                // Test step 7
                {
                    WriteTestResultsExcel.setTestStepStart("Click the link on the page", "Click the link on the page and navigate to new window");
                    driver.FindElementByLinkText("Learn Selenium!!").Click();
                    driver = FindWebDriverElement.SwitchWindowByTitle(driver, "Selenium IDE part 1 - Testingpool");
                    String title = driver.Title;
                    
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

        