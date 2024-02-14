using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UiTests.Utilities;

namespace UiTests.Pages;

public class HomePage : Driver
{
    [FindsBy(How = How.XPath, Using = "//li[@id='menu-item-992']//a[.='Company']")]
    private IWebElement _companyNavOption;
    
    [FindsBy(How = How.XPath, Using = "//li[@id='menu-item-829']//a[.='Overview']")]
    private IWebElement _overviewNavOption;
    
    public HomePage()
    {
        PageFactory.InitElements(_driver, this);
    }

    public void NavigateToCompanyOverviewPage()
    {
        _companyNavOption.Click();
        _overviewNavOption.Click();
    }
}