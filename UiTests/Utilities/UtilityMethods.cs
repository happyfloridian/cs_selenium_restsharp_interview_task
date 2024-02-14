using OpenQA.Selenium;

namespace UiTests.Utilities;

public class UtilityMethods
{
    public static List<string> GetListOfLocatorsText(IList<IWebElement> locators)
    {
        var locatorsText = new List<string>();

        foreach (var each in locators)
        {
            locatorsText.Add(each.Text);
        }

        return locatorsText;
    }
}