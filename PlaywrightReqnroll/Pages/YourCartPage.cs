using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoProject.Helpers;
using Reqnroll;

namespace PlaywrightDemoProject.Pages
{
    public class YourCartPage : PageTest
    {
        ScenarioContext scenarioContext;
        public YourCartPage(ScenarioContext ScenarioContext)
        {
            this.scenarioContext = ScenarioContext;
        }
        private IPage page = PlaywrightSettings.Page;

        //locators
        private ILocator btnCheckout => page.Locator("#checkout");

        //methods
        public async void ValidatePriceOnCartPageIsSameAsProductsPage()
        {
            await Expect(page.Locator(".inventory_item_price")).ToHaveTextAsync(scenarioContext["firstDisplayedItemPrice"].ToString());
        }

        public async void ClickOnCheckoutButton()
        {
            await btnCheckout.ClickAsync();
        }
    }
}
