using OpenQA.Selenium;
using NUnit.Framework;

namespace SmartlyAutomation.Pages
{
    public class AddEmployeePage
    {
        private By ConfirmaPasswordField = By.CssSelector(".oxd-grid-item--gutters:nth-of-type(2) [type='password']");
        private By ConfirmPasswordRequired = By.CssSelector(".oxd-input-field-bottom-space.oxd-input-group > .oxd-input-field-error-message.oxd-input-group__message.oxd-text.oxd-text--span");
        private By CreateLoginDetailsToggle = By.CssSelector(".oxd-switch-input");
        private IWebDriver driver;

        private By EmployeeFirstName = By.Name("firstName");

        private By EmployeeLastName = By.Name("lastName");

        private By EmployeeMiddleName = By.Name("middleName");

        private By PasswordField = By.CssSelector(".oxd-grid-item.oxd-grid-item--gutters.user-password-cell .oxd-input-field-bottom-space.oxd-input-group .oxd-input");

        private By PasswordRequired = By.CssSelector(".oxd-grid-item.oxd-grid-item--gutters.user-password-cell > .oxd-input-field-bottom-space.oxd-input-group > .oxd-input-field-error-message.oxd-input-group__message.oxd-text.oxd-text--span");

        private By SaveButton = By.CssSelector(".oxd-form-actions .orangehrm-left-space.oxd-button.oxd-button--medium.oxd-button--secondary");

        private By UsernameField = By.CssSelector("div:nth-of-type(3) .orangehrm-full-width-grid.oxd-grid-2 div:nth-of-type(1) .oxd-input-field-bottom-space.oxd-input-group .oxd-input");

        private By UsernameRequired = By.CssSelector("div:nth-of-type(3) .orangehrm-full-width-grid.oxd-grid-2 div:nth-of-type(1) .oxd-input-field-bottom-space.oxd-input-group .oxd-input-field-error-message.oxd-input-group__message.oxd-text.oxd-text--span");

        public AddEmployeePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickCreateLoginDetailsToggle()
        {
            driver.FindElement(CreateLoginDetailsToggle).Click();
            Task.Delay(2000).Wait();
        }

        public void clickSave()
        {
            driver.FindElement(SaveButton).Click();
            Task.Delay(2000).Wait();
        }

        public void fillInEmployeeFullName(string firstName, string middleName, string lastName)
        {
            driver.FindElement(EmployeeFirstName).SendKeys(firstName);
            driver.FindElement(EmployeeMiddleName).SendKeys(middleName);
            driver.FindElement(EmployeeLastName).SendKeys(lastName);
            Task.Delay(5000).Wait();
        }
        public void fillInMandatoryLoginDetails(string username, string password, string confirmPassword)
        {
            Random rnd = new Random();
            string empNum = rnd.Next(1, 999).ToString();
            driver.FindElement(UsernameField).SendKeys(username + empNum);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(ConfirmaPasswordField).SendKeys(confirmPassword);
            Task.Delay(3000).Wait();
        }

        public bool IsElementPresent(By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool verifyCreateLoginInputsAreMandatory()
        {
            bool UsernameFieldErrorDisplayed = driver.FindElement(UsernameRequired).Displayed;
            bool PasswordFieldErrorDisplayed = driver.FindElement(PasswordRequired).Displayed;
            bool ConfirmPasswordFieldErrorDisplayed = driver.FindElement(ConfirmPasswordRequired).Displayed;
            Task.Delay(5000).Wait();
            return UsernameFieldErrorDisplayed && PasswordFieldErrorDisplayed && ConfirmPasswordFieldErrorDisplayed;
        }

        public bool verifyEmployeeIsAddedToTheList()
        {
            Task.Delay(7000).Wait();
            if (driver.Url.Contains("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber"))
                return true;
            return false;
        }

        public void verifyErrorsAreNoLongerDisplayed()
        {
            Assert.IsFalse(IsElementPresent(UsernameRequired));
            Assert.IsFalse(IsElementPresent(PasswordRequired));
            Assert.IsFalse(IsElementPresent(ConfirmPasswordRequired));
        }
    }
}