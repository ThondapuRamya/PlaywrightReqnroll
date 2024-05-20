using Microsoft.Playwright.NUnit;
using PlaywrightDemoProject.Pages;
using Reqnroll;

namespace PlaywrightDemoProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : PageTest
    {
        ScenarioContext scenarioContext;
        LoginPage loginPage;
        ProductsPage productsPage;
        YourCartPage yourCartPage;
        CheckoutPage checkoutPage;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            loginPage = new LoginPage(scenarioContext);
            productsPage = new ProductsPage(scenarioContext);
            yourCartPage = new YourCartPage(scenarioContext);
            checkoutPage = new CheckoutPage(scenarioContext);
        }
        [Given(@"Launch the url")]
        public void GivenLaunchTheUrl()
        {
            loginPage.NavigateToURL();

        }

        [When(@"Enter valid username and password")]
        public void WhenEnterValidLoginNameAndPassword()
        {
            loginPage.EnterUserName();
            loginPage.EnterPassword();
        }

        [When(@"Click on Login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.ClickOnLoginButton();
        }

        [Then(@"Validate page title as (.*)")]
        public void ThenValidatePageTitleAsInventory(string title)
        {
            loginPage.ValidateTitleOfPage(title);
            // Assert.IsTrue(await loginPage.IsProductsTextExist());
        }

        [When(@"Select any item from list of products displayed")]
        public void WhenSelectAnyItemFromListOfProductsDisplayed()
        {
            productsPage.ClickOnFirstDisplayedProduct();
        }

        [Then(@"Validate price is dispalyed same as products page")]
        public void ThenValidatePriceIsDispalyedSameAsProductsPage()
        {
            productsPage.ValidatePriceOnProductDetailsPageIsSameAsProductsPage();
        }


        [When(@"Click on Add to cart button")]
        public void WhenClcikOnAddToCartButton()
        {
            productsPage.ClickOnAddToCartButton();
        }

        [When(@"Click on cart image")]
        public void WhenClickOnCartImage()
        {
            productsPage.ClickOnCartImage();
        }

        [Then(@"Navigate to cart page and verify same price is displayed or not")]
        public void ThenNavigateToCartPageAndVerifySamePriceIsDisplayedOrNot()
        {
            yourCartPage.ValidatePriceOnCartPageIsSameAsProductsPage();
        }

        [When(@"click on checkout button")]
        public void WhenClickOnCheckoutButton()
        {
            yourCartPage.ClickOnCheckoutButton();
        }

        [Then(@"Provide firstname as (.*)")]
        public void ThenProvideFirstname(string firstname)
        {
            checkoutPage.ProvideFirstName(firstname);
        }

        [Then(@"Provide lastname as (.*)")]
        public void ThenProvideLastname(string lastname)
        {
            checkoutPage.ProvideLastName(lastname);
        }

        [Then(@"Provide zipcode as (.*)")]
        public void ThenProvideZipcode(string zipcode)
        {
            checkoutPage.ProvidePincode(zipcode);
        }

        [When(@"Click on continue button")]
        public void WhenClickOnContinueButton()
        {
            checkoutPage.ClcikOnContinue();
        }

        [Then(@"Validate item price is displayed same as checkout page")]
        public void ThenValidateItemPriceIsDisplayedSameAsCheckoutPage()
        {
            checkoutPage.ValidateItemPriceIsDisplayedSameAsProductsPage();
        }

        [Then(@"Click on Finish button")]
        public void ThenClickOnFinishButton()
        {
            checkoutPage.ClickOnFinishButton();
        }
    }
}
