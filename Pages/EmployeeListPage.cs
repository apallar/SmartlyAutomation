using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SmartlyAutomation.Pages
{
    public class EmployeeListPage
    {
        private By AddEmployeeButton = By.CssSelector("div.orangehrm-header-container button");
        private IWebDriver driver;

        private By EmployeeNameField = By.CssSelector("div:nth-of-type(1) .oxd-input-field-bottom-space.oxd-input-group input");

        private By FirstRow = By.CssSelector(".oxd-table-card");

        private By LastNameSortDescendingIcon = By.CssSelector("div:nth-of-type(4)  div[role='dropdown'] > ul[role='menu']  .bi-sort-alpha-up.oxd-icon");

        private By LastNameSortIcon = By.CssSelector("div:nth-of-type(4) > .oxd-table-header-sort > .bi-arrow-down-up.oxd-icon.oxd-icon-button__icon.oxd-table-header-sort-icon");

        private By SearchButton = By.CssSelector(".orangehrm-left-space.oxd-button.oxd-button--medium.oxd-button--secondary");

        public EmployeeListPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickAddEmployee()
        {
            driver.FindElement(AddEmployeeButton).Click();
        }

        public void clickEmployeeNameInSearchTable()
        {
            driver.FindElement(FirstRow).Click();
            Task.Delay(7000).Wait();
        }

        public void clickFirstMiddleNameSortIcon()
        {
            driver.FindElement(LastNameSortIcon).Click();
        }

        public void clickSearchButton()
        {
            driver.FindElement(SearchButton).Click();
            Task.Delay(3000).Wait();
        }

        public void enterEmployeeName(string name)
        {
            driver.FindElement(EmployeeNameField).SendKeys(name);
            Task.Delay(2000).Wait();
        }
        public void sortFirstNameDescending()
        {
            driver.FindElement(LastNameSortIcon).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(LastNameSortDescendingIcon));
            driver.FindElement(LastNameSortDescendingIcon).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(FirstRow));
        }

        public bool verifyFirstNameColumnIsSortedAscending()
        {
            List<string> FirstNameList = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                string firstName = driver.FindElement(By.CssSelector($"div:nth-of-type(2) > div:nth-of-type({i}) > div[role='row'] > div:nth-of-type(3) > div")).Text;
                FirstNameList.Add(firstName);
            }
            Console.WriteLine("First 5 from the list:");
            FirstNameList.ForEach(Console.WriteLine);

            //Assigns the list to 'origList'. 'origList' will be used to compare to the sorted one
            List<string> origList = FirstNameList;
            Console.WriteLine("Assigned to origList:");
            origList.ForEach(Console.WriteLine);

            //Sorts the list to ascending
            FirstNameList.Sort();

            //Gets the sorted list and assigns to 'sortedAscendingList'
            List<string> sortedAscendingList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string firstNameSorted = FirstNameList[i].ToString();
                sortedAscendingList.Add(firstNameSorted);
            }
            return Enumerable.SequenceEqual(origList, sortedAscendingList);
        }
        public bool verifyFirstNameColumnIsSortedDescending()
        {
            List<string> LastNameList = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                string firstName = driver.FindElement(By.CssSelector($"div:nth-of-type(2) > div:nth-of-type({i}) > div[role='row'] > div:nth-of-type(4) > div")).Text;
                LastNameList.Add(firstName);
            }
            Console.WriteLine("First 5 from the list:");
            LastNameList.ForEach(Console.WriteLine);

            //Assigns the list to 'origList'. 'origList' will be used to compare to the sorted one
            List<string> origList = LastNameList;
            Console.WriteLine("Assigned to origList:");
            origList.ForEach(Console.WriteLine);

            //Sorts the list to descending
            LastNameList.Reverse();

            //Gets the sorted list and assigns to 'sortedDescendingList'
            List<string> sortedDescendingList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string firstNameSorted = LastNameList[i].ToString();
                sortedDescendingList.Add(firstNameSorted);
            }
            return Enumerable.SequenceEqual(origList, sortedDescendingList);
        }
    }
}