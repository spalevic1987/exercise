using Exercise.Driver;
using Exercise.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace Exercise;

public class Tests
{
    LoginPage loginPage;
    InventoryPage inventoryPage;
    string errorMessageOne = "Epic sadface: Username and password do not match any user in this service";
    string errorMessageTwo = "Epic sadface: Username is required";
    string errorMessageThree = "Epic sadface: Password is required";

    [SetUp]
    public void Setup()
    {
        Webdrivers.Initialize();
        loginPage = new LoginPage();
        inventoryPage = new InventoryPage();
    }

    [TearDown]
    public void ClosePage()
    {
        Webdrivers.CleanUp();
    }

    [Test]
    public void TC001_SuccessLogin_ShouldBeLoggedIn()
    {
        loginPage.Login("standard_user", "secret_sauce");

        Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(Webdrivers.Instance.Url));
    }

    [Test]
    public void TC002_WrongUser_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("standard_user212", "secret_sauce");

        Assert.That(errorMessageOne, Is.EqualTo (loginPage.UserNotLogin.Text));
    }

    [Test]
    public void TC003_WrongPassword_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("standard_user", "secret_sauce212");

        Assert.That(errorMessageOne, Is.EqualTo(loginPage.UserNotLogin.Text));
    }

    [Test]
    public void TC004_WithoutData_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("", "");

        Assert.That(errorMessageTwo, Is.EqualTo(loginPage.UserNotLogin.Text));
    }

    [Test]
    public void TC005_WithoutUserName_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("", "secret_sauce");

        Assert.That(errorMessageTwo, Is.EqualTo(loginPage.UserNotLogin.Text));
    }

    [Test]
    public void TC006_WithoutPassword_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("standard_user", "");

        Assert.That(errorMessageThree, Is.EqualTo(loginPage.UserNotLogin.Text));
    }
}
