using System;
using Exercise.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise.Page
{
	public class InventoryPage
	{
        private IWebDriver driver = Webdrivers.Instance;

        public IWebElement AddBikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement AddBlackT_Shirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement AddOnesie => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        public IWebElement Cart => driver.FindElement(By.CssSelector("#shopping_cart_container .shopping_cart_badge"));
        public IWebElement SortByName => driver.FindElement(By.ClassName("product_sort_container"));
        public IWebElement ShoppingCardClick => driver.FindElement(By.Id("shopping_cart_container"));

        public void SelectOption(string Text)
        {
            SelectElement element = new SelectElement(SortByName);
            element.SelectByText(Text);
        }

    }
}

