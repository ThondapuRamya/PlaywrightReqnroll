using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoProject.Configurations;
using PlaywrightDemoProject.Helpers;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Pages
{
    public class LoginPage : PageTest
    {
        ScenarioContext scenarioContext;

        public LoginPage(ScenarioContext ScenarioContext)
        {
            this.scenarioContext = ScenarioContext;

        }
        private IPage page = PlaywrightSettings.Page;

        //locators
        private ILocator txtUserName => page.Locator("#user-name");
        private ILocator txtPassword => page.Locator("#password");
        private ILocator btnLogin => page.Locator("#login-button");
        private ILocator productsText => page.Locator("text=Products");

        //methods
        public async void NavigateToURL()
        {
            await page.GotoAsync(ConfigurationProvider.uiDetails.URL);
        }

        public async void EnterUserName()
        {
            await txtUserName.FillAsync(ConfigurationProvider.uiDetails.UserID);
        }

        public async void EnterPassword()
        {
            await txtPassword.FillAsync(ConfigurationProvider.uiDetails.Password);
        }

        public async void ClickOnLoginButton()
        {
            await btnLogin.ClickAsync();
        }

        public void ValidateTitleOfPage(string expectedTitle)
        {
            Expect(page).ToHaveTitleAsync(expectedTitle);
        }

        public async Task<bool> IsProductsTextExist()
        {
            return await productsText.IsVisibleAsync();
        }

    }
}
