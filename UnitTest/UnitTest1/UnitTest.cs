using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UnitTest
{
    [TestFixture]
    public class TestInvalidEmail
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheInvalidEmailTest()
        {
            driver.Navigate().GoToUrl("http://localhost:59251/");
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Name("_contact_email")).Click();
            driver.FindElement(By.Name("_contact_email")).Clear();
            driver.FindElement(By.Name("_contact_email")).SendKeys("testWrongEmail");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        [Test]
        public void TheInvalidPhoneTest()
        {
            driver.Navigate().GoToUrl("http://localhost:59251/Sale/AddInfo");
            driver.FindElement(By.Name("_contact_no")).Click();
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("qwerttyu");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        [Test]
        public void TheInvalidYearTest()
        {
            driver.Navigate().GoToUrl("http://localhost:59251/Sale/AddInfo");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='AddInfo'])[1]/following::div[2]")).Click();
            driver.FindElement(By.Name("_car_year")).Click();
            driver.FindElement(By.Name("_car_year")).Clear();
            driver.FindElement(By.Name("_car_year")).SendKeys("2020");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
