using OpenQA.Selenium;

namespace SmartlyAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        private By EmployeeListTab = By.CssSelector("div.oxd-topbar-body nav  ul li:nth-child(2) a");

        private By PIMNavLink = By.CssSelector("a[href='/web/index.php/pim/viewPimModule']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickEmployeeList()
        {
            driver.FindElement(EmployeeListTab).Click();
        }

        public void navigateToPIMModule()
        {
            driver.FindElement(PIMNavLink).Click();
        }
        public bool verifyEmployeeListPageIsLoaded()
        {
            String URL = driver.Url;
            if (URL == "https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList")
            {
                return true;
            }
            return false;
        }
    }
}