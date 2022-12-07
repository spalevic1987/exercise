using System;
using Exercise.Driver;
using OpenQA.Selenium;

namespace Exercise.Page
{
	public class CheckoutPageTwo
	{
        private IWebDriver driver = Webdrivers.Instance;

        public IWebElement ItemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement Total => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement ButtonFinish => driver.FindElement(By.Id("finish"));
        public IWebElement OrderFinished => driver.FindElement(By.CssSelector("#checkout_complete_container .complete-header"));

    }
}

