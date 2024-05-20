using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoProject.Helpers;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Pages
{
    public class ProductsPage : PageTest
    {
        ScenarioContext scenarioContext;
        public ProductsPage(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
        private IPage page = PlaywrightSettings.Page;

        private ILocator btnAddToCart => page.Locator("#add-to-cart");
        private ILocator btnCartImage => page.Locator(".shopping_cart_link");


        //methods
        public async void ClickOnFirstDisplayedProduct()
        {
            string itemPrice = await page.Locator("div.inventory_item_price").First.InnerTextAsync();
            scenarioContext["firstDisplayedItemPrice"] = itemPrice;

            await page.Locator("//div[@class='inventory_item_description']//a").First.ClickAsync();
        }

        public async void ValidatePriceOnProductDetailsPageIsSameAsProductsPage()
        {
            await Expect(page.Locator("div.inventory_details_price")).ToHaveTextAsync(scenarioContext["firstDisplayedItemPrice"].ToString());
        }

        public async void ClickOnAddToCartButton()
        {
            await btnAddToCart.ClickAsync();
        }

        public async void ClickOnCartImage()
        {
            await btnCartImage.ClickAsync();
        }
    }
}
