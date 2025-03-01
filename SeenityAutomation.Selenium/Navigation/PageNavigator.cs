﻿using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using SeenityAutomation.Selenium.Configuration;
using SeenityAutomation.Selenium.Pages;

namespace SeenityAutomation.Selenium.Navigation
{
    public class PageNavigator
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        private readonly string _baseUrl;
        private readonly string _homePageRoute;

        public PageNavigator(IWebDriver driver, HomePage homePage, IOptions<NavigationConfig> navigationConfig)
        {
            _driver = driver;
            _homePage = homePage;

            _baseUrl = navigationConfig.Value.BaseUrl;
            _homePageRoute = navigationConfig.Value.HomePageRoute;
        }

        public HomePage NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + _homePageRoute);
            return _homePage;
        }
    }
}