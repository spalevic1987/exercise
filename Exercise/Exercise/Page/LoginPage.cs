using System;
using Exercise.Driver;
using OpenQA.Selenium;

namespace Exercise.Page
{
    public class LoginPage
    {
        private IWebDriver driver = Webdrivers.Instance;

        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement ButtonLogin => driver.FindElement(By.Id("login-button"));
        public IWebElement UserNotLogin => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));

        public void Login(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            ButtonLogin.Submit();
        }
    }
}

