using Exercise.Driver;
using Exercise.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace Exercise;

public class Tests
{
    LoginPage loginPage;
    InventoryPage inventoryPage;
    CartPage cartPage;
    CheckoutPageOne checkoutPageOne;
    CheckoutPageTwo checkoutPageTwo;

    [SetUp]
    public void Setup()
    {
        Webdrivers.Initialize();
        loginPage = new LoginPage();
        inventoryPage = new InventoryPage();
        cartPage = new CartPage();
        checkoutPageOne = new CheckoutPageOne();
        checkoutPageTwo = new CheckoutPageTwo();

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

        Assert.That(loginPage.UserNotLogin.Displayed);
    }

    [Test]
    public void TC003_WrongPassword_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("standard_user", "secret_sauce212");

        Assert.That(loginPage.UserNotLogin.Displayed);
    }

    [Test]
    public void TC004_WithoutData_ShouldBeErrorMessageButtonIsDispalyed()
    {
        loginPage.Login("", "");

        Assert.That(loginPage.UserNotLogin.Displayed);
    }

    [Test]
    public void TC_05AddThreeItems_ShouldBeadded()
    {
        loginPage.Login("standard_user", "secret_sauce");
        inventoryPage.AddOnesie.Click();
        inventoryPage.AddBikeLight.Click();
        inventoryPage.AddBlackT_Shirt.Click();
        inventoryPage.SelectOption("Name (A to Z)");

        Assert.That("3", Is.EqualTo(inventoryPage.ShoppingCardClick.Text));

    }

    [Test]
    public void TC_06AddTwoItemsRemoveAndBackToShopping_ShouldBeBack()
    {
        loginPage.Login("standard_user", "secret_sauce");
        inventoryPage.AddOnesie.Click();
        inventoryPage.AddBikeLight.Click();
        inventoryPage.Cart.Click();
        cartPage.RemoveOnesie.Click();
        cartPage.RemoveBikelight.Click();
        cartPage.ContinueShopping.Click();
        
        Assert.That("", Is.EqualTo(inventoryPage.ShoppingCardClick.Text));
    }

    [Test]
    public void TC_07CheckItemTotal_ShouldBeDisplayed()
    {
        loginPage.Login("standard_user", "secret_sauce");
        inventoryPage.AddOnesie.Click();
        inventoryPage.AddBikeLight.Click();
        inventoryPage.AddBlackT_Shirt.Click();
        inventoryPage.Cart.Click();
        cartPage.ButtonCheckout.Click();
        checkoutPageOne.FirstName.SendKeys("Spale");
        checkoutPageOne.LastName.SendKeys("Spaleti");
        checkoutPageOne.ZipCode.SendKeys("11000");
        checkoutPageOne.ButtonContinue.Submit();
        
        

        Assert.That("Item total: $33.97", Is.EqualTo(checkoutPageTwo.ItemTotal.Text));
    }

    [Test]
    public void TC_08CheckTotal_ShouldBeDisplayed()
    {
        loginPage.Login("standard_user", "secret_sauce");
        inventoryPage.AddOnesie.Click();
        inventoryPage.AddBikeLight.Click();
        inventoryPage.AddBlackT_Shirt.Click();
        inventoryPage.Cart.Click();
        cartPage.ButtonCheckout.Click();
        checkoutPageOne.FirstName.SendKeys("Spale");
        checkoutPageOne.LastName.SendKeys("Spaleti");
        checkoutPageOne.ZipCode.SendKeys("11000");
        checkoutPageOne.ButtonContinue.Submit();



        Assert.That("Total: $36.69", Is.EqualTo(checkoutPageTwo.Total.Text));
    }

    [Test]
    public void TC_09FinishBuy_ShouldBeDisplayed()
    {
        loginPage.Login("standard_user", "secret_sauce");
        inventoryPage.AddOnesie.Click();
        inventoryPage.AddBikeLight.Click();
        inventoryPage.AddBlackT_Shirt.Click();
        inventoryPage.Cart.Click();
        cartPage.ButtonCheckout.Click();
        checkoutPageOne.FirstName.SendKeys("Spale");
        checkoutPageOne.LastName.SendKeys("Spaleti");
        checkoutPageOne.ZipCode.SendKeys("11000");
        checkoutPageOne.ButtonContinue.Submit();
        checkoutPageTwo.ButtonFinish.Click();



        Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(checkoutPageTwo.OrderFinished.Text));
    }
}
