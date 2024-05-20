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
    public class CheckoutPage : PageTest
    {
        CustomScenarioContext scenarioContext;

        public CheckoutPage(CustomScenarioContext customScenarioContext)
        {
            this.scenarioContext = customScenarioContext;
        }
        private IPage page = PlaywrightSettings.Page;

        //locators
        private ILocator txtFirstName => page.Locator("#first-name");
        private ILocator txtLastName => page.Locator("#last-name");
        private ILocator txtPinCode => page.Locator("#postal-code");
        private ILocator btnContinue => page.Locator("#continue");
        private ILocator btnFinish => page.Locator("#finish");


        //methods
        public async void ProvideFirstName(string firstName)
        {
            await txtFirstName.FillAsync(firstName);
        }

        public async void ProvideLastName(string lastName)
        {
            await txtLastName.FillAsync(lastName);
        }

        public async void ProvidePincode(string pincode)
        {
            await txtPinCode.FillAsync(pincode);
        }

        public async void ClcikOnContinue()
        {
            await btnContinue.ClickAsync();
        }

        public async void ValidateItemPriceIsDisplayedSameAsProductsPage()
        {
            await Expect(page.Locator(".summary_subtotal_label")).ToHaveTextAsync(scenarioContext.itemPrice);
        }


        public async void ClickOnFinishButton()
        {
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads\\playwrightdemo.jpg")
            });
            await btnFinish.ClickAsync();
        }
    }
}
