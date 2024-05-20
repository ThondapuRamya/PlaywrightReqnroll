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
    public class ProductsPage : PageTest
    {
        CustomScenarioContext scenarioContext;
        public ProductsPage(CustomScenarioContext customScenarioContext)
        {
            this.scenarioContext = customScenarioContext;
        }
        private IPage page = PlaywrightSettings.Page;

        private ILocator btnAddToCart => page.Locator("#add-to-cart");
        private ILocator btnCartImage => page.Locator(".shopping_cart_link");


        //methods
        public async void ClickOnFirstDispalyedProduct()
        {
            scenarioContext.itemPrice = await page.Locator("div.inventory_item_price").First.InnerTextAsync();
            await page.Locator("//div[@class='inventory_item_description']//a").First.ClickAsync();
        }

        public async void ValidatePriceOnProductDeatilsPageIsSameAsProductsPage()
        {
            await Expect(page.Locator("div.inventory_details_price")).ToHaveTextAsync(scenarioContext.itemPrice);
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
