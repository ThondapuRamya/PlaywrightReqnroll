using BoDi;
using Microsoft.Playwright;
using PlaywrightDemoProject.Drivers;
using PlaywrightDemoProject.Helpers;
using Reqnroll;

//[assembly: Parallelizable(ParallelScope.Fixtures)] -- for parallel execution

namespace PlaywrightDemoProject.Hooks
{
    [Binding]

    public class TestHooks
    {
        [BeforeScenario]
        public void SetupPage(IObjectContainer objectContainer)
        {
            Driver driver = new Driver();
            PlaywrightSettings.Page = driver.page;

            objectContainer.RegisterInstanceAs(PlaywrightSettings.Page);
        }

        [AfterScenario]
        public async Task AfterScenario(IObjectContainer objectContainer)
        {
            var page = objectContainer.Resolve<IPage>();
            await page.CloseAsync();
        }
    }
}
