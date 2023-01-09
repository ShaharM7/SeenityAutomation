﻿using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers.Options
{
    public sealed class BrowserOptions : ChromeOptions
    {
        public BrowserOptions(IOptions<BrowserOptionsConfig> browserOptionsConfig,
            IOptions<RemoteBrowserConfig> remoteBrowserConfig, IOptions<BrowserStackConfig> browserStackConfig)
        {
            AddArguments(browserOptionsConfig.Value.Arguments);

            if (remoteBrowserConfig.Value.UseSeleniumGrid)
            {
                AddAdditionalOption("bstack:options", browserStackConfig.Value.BrowserStackOptions);

                BrowserName = remoteBrowserConfig.Value.BrowserName;
                BrowserVersion = remoteBrowserConfig.Value.BrowserVersion;
            }
        }
    }
}