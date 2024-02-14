using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UiTests.Utilities;

public class Driver
{
    public static IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}