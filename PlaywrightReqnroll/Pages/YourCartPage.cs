using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Pages
{
    public class YourCartPage : PageTest
    {
        CustomScenarioContext scenarioContext;
        public YourCartPage(CustomScenarioContext customScenarioContext)
        {
            this.scenarioContext = customScenarioContext;
        }
        private IPage page = PlaywrightSettings.Page;

        //locators
        private ILocator btnCheckout => page.Locator("#checkout");

        //methods
        public async void ValidatePriceOnCartPageIsSameAsProductsPage()
        {
            await Expect(page.Locator(".inventory_item_price")).ToHaveTextAsync(scenarioContext.itemPrice);
        }

        public async void ClickOnCheckoutButton()
        {
            await btnCheckout.ClickAsync();
        }
    }
}
