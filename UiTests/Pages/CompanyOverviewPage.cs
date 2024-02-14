using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UiTests.Utilities;

namespace UiTests.Pages;

public class CompanyOverviewPage : Driver
{
    [FindsBy(How = How.XPath, Using = "//section[@class='four-col-textarea']//h3")]
    private IList<IWebElement> _companyValuesHeaders;
    
    [FindsBy(How = How.XPath, Using = "//a[@href='/contact']")]
    private IWebElement _letsgetStartedButton;

    public CompanyOverviewPage()
    
    {
        PageFactory.InitElements(_driver, this);
    }

    public List<string> GetListOfCompanyValues()
    {
        return UtilityMethods.GetListOfLocatorsText(_companyValuesHeaders);
    }
    
    public void ClickLetsGetStartedButton()
    {
        _letsgetStartedButton.Click();
    }
}