    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;


namespace Com.Sogeti.Tests.SeleniumTest.Object_Repository
{

        public class Test_Objects
    {

        //Test Case 1
        public static readonly Dictionary<string, string> FIRST_NAME = new Dictionary<string, string> { { "id", "firstname" } };
        public static readonly Dictionary<string, string> LAST_NAME = new Dictionary<string, string> { { "id", "lastname" } };
        public static readonly Dictionary<string, string> GENDER_RADIO = new Dictionary<string, string> { { "id", "male" } };
        public static readonly Dictionary<string, string> SELECT_DAY = new Dictionary<string, string> { { "name", "Week" } };
        public static readonly Dictionary<string, string> SELECT_FROM_DROPDOWN = new Dictionary<string, string> { { "name", "number" } };
        public static readonly Dictionary<string, string> SELECT_COLOR_CHECKBOX = new Dictionary<string, string> { { "name", "color" } };
        public static readonly Dictionary<string, string> SUBMIT_BUTTON = new Dictionary<string, string> { { "id", "bttn" } };

        //Test Case 2
        public static readonly Dictionary<string, string> PRODUCT_LINK = new Dictionary<string, string> { { "link", "T-SHIRTS" } };
        public static readonly Dictionary<string, string> PRODUCT_NAME = new Dictionary<string, string> { { "link", "Faded Short Sleeve T-shirts" } };
        public static readonly Dictionary<string, string> ADDTOCART_BUTTON = new Dictionary<string, string> { { "id", "add_to_cart" } };
        public static readonly Dictionary<string, string> PROCEEDTOCHECKOUT_BUTTON = new Dictionary<string, string> { { "link", "Proceed to checkout" } };

    }
}



