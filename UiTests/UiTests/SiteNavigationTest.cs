using UiTests.Pages;
using UiTests.Utilities;

namespace UiTests.UiTests;

[TestFixture]
public class SiteNavigationTest : Driver
{
    [Test]
    [Retry(2)]
    public void UserCanGoToContactPageViaOverviewPageTest()
    {
        HomePage homePage = new HomePage();
        CompanyOverviewPage overviewPage = new CompanyOverviewPage();
        ContactPage contactPage = new ContactPage();
     
        _driver.Navigate().GoToUrl("https://www.agdata.com/");
        
        homePage.NavigateToCompanyOverviewPage();
        
        overviewPage.GetListOfCompanyValues();
        
        Assert.That(overviewPage.GetListOfCompanyValues().Count == 4, "List of company values doesn't have 4 values.");
        
        overviewPage.ClickLetsGetStartedButton();
        
        Assert.That(contactPage.VerifyContactPageIsLoaded(), "Contact page not loaded");
    }
    
}