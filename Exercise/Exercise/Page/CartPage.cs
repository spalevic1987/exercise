using System;
using Exercise.Driver;
using OpenQA.Selenium;

namespace Exercise.Page
{
	public class CartPage
	{
        private IWebDriver driver = Webdrivers.Instance;

        public IWebElement RemoveBikelight => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement RemoveOnesie => driver.FindElement(By.Id("remove-sauce-labs-onesie"));
        public IWebElement ContinueShopping => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement ButtonCheckout => driver.FindElement(By.Id("checkout"));

    }
}

