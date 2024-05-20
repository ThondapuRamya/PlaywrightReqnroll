using PlaywrightDemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoProject.Configurations
{
    public class ConfigurationProvider : Core.Configurations.ConfigurationProvider
    {
        public static readonly string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestSettings.json");

        public static UIDetails uiDetails => Load<UIDetails>(settingsFilePath, "UIDetails");

    }
}
