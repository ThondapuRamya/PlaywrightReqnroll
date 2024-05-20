using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Helpers
{
    public class PlaywrightSettings
    {
        public static IBrowser Browser { get; set; }
        public static IPage Page { get; set; }

    }
}
