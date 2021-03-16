using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using PlaywrightSharp;

namespace autenti_homework.Helpers
{
    public class TestConstants
    {
        public const string BaseUrl = "https://account.autenti.com";
        public const string ChromiumProduct = "CHROMIUM";
        public const string WebkitProduct = "WEBKIT";
        public const string FirefoxProduct = "FIREFOX";

        public static string Product => string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PRODUCT"))
            ? ChromiumProduct
            : Environment.GetEnvironmentVariable("PRODUCT");

        public static string Url => string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BASEURL"))
            ? BaseUrl
            : Environment.GetEnvironmentVariable("BASEURL");

        internal static LaunchOptions GetDefaultBrowserOptions()
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
        internal static readonly bool IsWebKit = Product.Equals(WebkitProduct);
        internal static readonly bool IsFirefox = Product.Equals(FirefoxProduct);
        internal static readonly bool IsChromium = Product.Equals(ChromiumProduct);
        internal static readonly bool IsMacOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        internal static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}