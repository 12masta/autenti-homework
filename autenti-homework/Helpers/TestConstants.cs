using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using PlaywrightSharp;

namespace autenti_homework.Helpers
{
    public static class TestConstants
    {
        private const string BaseUrl = "https://account.autenti.com";
        private const string ChromiumProduct = "CHROMIUM";

        public static string Product => string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PRODUCT"))
            ? ChromiumProduct
            : Environment.GetEnvironmentVariable("PRODUCT");

        public static string Url => string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BASEURL"))
            ? BaseUrl
            : Environment.GetEnvironmentVariable("BASEURL");

        public static LaunchOptions GetDefaultBrowserOptions()
            => new LaunchOptions
            {
                SlowMo = Convert.ToInt32(Environment.GetEnvironmentVariable("SLOW_MO")),
                Headless = Convert.ToBoolean(Environment.GetEnvironmentVariable("HEADLESS") ?? "true"),
                Timeout = 0,
            };

        public static LaunchOptions GetHeadfulOptions()
        {
            var options = GetDefaultBrowserOptions();
            options.Headless = false;
            return options;
        }

        internal static ILoggerFactory LoggerFactory { get; set; } = LoggerFactory = new LoggerFactory();
    }
}