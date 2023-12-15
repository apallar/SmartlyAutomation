using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SmartlyAutomation.Pages
{
    public class PersonalDetailsPage
    {
        private By AddButton = By.CssSelector(".orangehrm-action-header .oxd-button.oxd-button--medium.oxd-button--text");
        private By ConfirmDelete = By.CssSelector(".orangehrm-button-margin.oxd-button.oxd-button--label-danger.oxd-button--medium");
        private IWebDriver driver;

        private By FileUploaded = By.CssSelector("div[role='row'] > div:nth-of-type(2) > div");

        private By SaveAttachmentButton = By.CssSelector(".orangehrm-attachment  .oxd-form  .orangehrm-left-space.oxd-button.oxd-button--medium.oxd-button--secondary");

        private By TrashButton = By.CssSelector("button:nth-of-type(2) .bi-trash.oxd-icon");

        private By UploadButton = By.CssSelector(".oxd-file-input");

        public PersonalDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickAddButton()
        {
            var element = driver.FindElement(AddButton);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            driver.FindElement(AddButton).Click();
            Task.Delay(7000).Wait();
        }

        public void clickDeleteFileAndConfirm()
        {
            driver.FindElement(TrashButton).Click();
            Task.Delay(2000).Wait();
            driver.FindElement(ConfirmDelete).Click();
            Task.Delay(10000).Wait();
        }

        public bool fileExistsIntheAttachmentTable()
        {
            var element = driver.FindElement(FileUploaded);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            Task.Delay(7000).Wait();

            return driver.FindElement(FileUploaded).Displayed;
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

        public void uploadFile()
        {
            var element = driver.FindElement(UploadButton);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            Task.Delay(7000).Wait();

            string filePath = System.IO.Path.GetFullPath(@"..\..\..\Utility\\For Upload.pdf");
            Console.WriteLine("File path == " + filePath);
            driver.FindElement(UploadButton).SendKeys(filePath);
            Task.Delay(5000).Wait();

            var saveAttachmentBtn = driver.FindElement(SaveAttachmentButton);
            Actions clickSave = new Actions(driver);
            clickSave.MoveToElement(saveAttachmentBtn);
            clickSave.Perform();
            driver.FindElement(SaveAttachmentButton).Click();
            Task.Delay(3000).Wait();
        }

        public bool verifyEmployeeNameIsTheSameAsSelected(string name)
        {
            return driver.FindElement(By.XPath("//h6[contains(.,'" + name + "')]")).Displayed;
        }
        public void verifyFileIsNoLongerInTheAttachmentTable()
        {
            Assert.IsFalse(IsElementPresent(FileUploaded));
        }
    }
}