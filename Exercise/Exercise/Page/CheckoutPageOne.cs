using System;
using Exercise.Driver;
using OpenQA.Selenium;

namespace Exercise.Page
{
	public class CheckoutPageOne
	{
        private IWebDriver driver = Webdrivers.Instance;

        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement ZipCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement ButtonContinue => driver.FindElement(By.Id("continue"));


    }
}

