using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Drivers
{
    public class Driver : IDisposable
    {
        private Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = CraetePageInstance();
        }
        public IPage page => _page.Result;
        private async Task<IPage> CraetePageInstance()
        {
            var playWright = await Playwright.CreateAsync();
            _browser = await playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 120000
            }); ;


            return await _browser.NewPageAsync();
        }

        void IDisposable.Dispose()
        {
            _browser?.CloseAsync();
        }
    }
}
