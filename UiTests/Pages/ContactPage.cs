using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UiTests.Utilities;

namespace UiTests.Pages;

public class ContactPage : Driver
{
    [FindsBy(How = How.XPath, Using = "//section[@class='intro_header center-text']//h4[.='Contact']")]
    private IWebElement _contactHeader;
    
    public ContactPage()
    {
        PageFactory.InitElements(_driver, this);
    }

    public bool VerifyContactPageIsLoaded()
    {
        return _contactHeader.Displayed && _driver.Title.Equals("Contact - AGDATA");
    }
}