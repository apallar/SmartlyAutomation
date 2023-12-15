using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SmartlyAutomation.Pages;
using NUnit.Framework;

namespace SmartlyAutomation.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        EmployeeListPage employeeListPage;
        AddEmployeePage addEmployeePage;
        PersonalDetailsPage personalDetailsPage;

        public EmployeeStepDefinitions(IWebDriver driver, LoginPage loginPage, HomePage homePage, EmployeeListPage employeeListPage, 
            AddEmployeePage addEmployeePage, PersonalDetailsPage personalDetailsPage)
        {
            this.driver = driver;
            this.loginPage = loginPage;
            this.homePage = homePage;
            this.employeeListPage = employeeListPage;
            this.addEmployeePage = addEmployeePage;
            this.personalDetailsPage = personalDetailsPage;
        }

        [Given(@"a user logs in to the application ""([^""]*)"" ""([^""]*)""")]
        public void GivenAUserLogsInToTheApplication(string username, string password)
        {
            loginPage.login(username, password);
        }

        [When(@"user clicks PIM")]
        public void WhenUserClicksPIM()
        {
            homePage.navigateToPIMModule();
        }

        [When(@"clicks Employee List")]
        public void WhenClicksEmployeeList()
        {
            homePage.clickEmployeeList();
        }

        [Then(@"Employee List page is loaded")]
        public void ThenEmployeeListPageIsLoaded()
        {
            Assert.IsTrue(homePage.verifyEmployeeListPageIsLoaded());
        }

        [When(@"clicks Add button")]
        public void WhenClicksAddButton()
        {
            employeeListPage.clickAddEmployee();
        }

        [When(@"enters employee name ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenEntersEmployeeName(string firstname, string middlename, string lastname)
        {
            addEmployeePage.fillInEmployeeFullName(firstname, middlename, lastname);
        }

        [When(@"clicks Create Login Details toggle")]
        public void WhenClicksCreateLoginDetailsToggle()
        {
            addEmployeePage.clickCreateLoginDetailsToggle();
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            addEmployeePage.clickSave();
        }

        [When(@"validates errors")]
        public void WhenValidatesErrors()
        {
            Assert.IsTrue(addEmployeePage.verifyCreateLoginInputsAreMandatory());
        }

        [When(@"populates the mandatory create login fields ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenPopulatesTheMandatoryCreateLoginFields(string username, string password, string confirmPassword)
        {
            addEmployeePage.fillInMandatoryLoginDetails(username, password, confirmPassword);
        }

        [When(@"validate errors are gone")]
        public void WhenValidateErrorsAreGone()
        {
            addEmployeePage.verifyErrorsAreNoLongerDisplayed();
        }

        [Then(@"the errors are gone")]
        public void ThenTheErrorsAreGone()
        {
            addEmployeePage.verifyErrorsAreNoLongerDisplayed();
        }

        [When(@"the user saves the login details")]
        public void WhenTheUserSavesTheLoginDetails()
        {
            addEmployeePage.clickSave();
        }

        [Then(@"the employee is added to the list")]
        public void ThenTheEmployeeIsAddedToTheList()
        {
            Assert.IsTrue(addEmployeePage.verifyEmployeeIsAddedToTheList());
        }

        [When(@"enters employee name ""([^""]*)""")]
        public void WhenEntersEmployeeName(string name)
        {
            employeeListPage.enterEmployeeName(name);
        }

        [When(@"clicks Search button")]
        public void WhenClicksSearchButton()
        {
            employeeListPage.clickSearchButton();
        }

        [When(@"user clicks on the employee name in the search table")]
        public void WhenUserClicksOnTheEmployeeNameInTheSearchTable()
        {
            employeeListPage.clickEmployeeNameInSearchTable();
        }

        [Then(@"the employee name ""([^""]*)"" is the same as the selected name")]
        public void ThenTheEmployeeNameIsTheSameAsTheSelectedName(string name)
        {
            personalDetailsPage.verifyEmployeeNameIsTheSameAsSelected(name);
        }

        [When(@"user clicks the Add button in the Attachments")]
        public void WhenUserClicksTheAddButtonInTheAttachments()
        {
            personalDetailsPage.clickAddButton();
        }

        [When(@"clicks Browse button and attaches the file")]
        public void WhenClicksBrowseButtonAndAttachesTheFile()
        {
            personalDetailsPage.uploadFile();
        }

        [Then(@"the filename is displayed in the Attachment table")]
        public void ThenTheFilenameIsDisplayedInTheAttachmentTable()
        {
            Assert.IsTrue(personalDetailsPage.fileExistsIntheAttachmentTable());
        }

        [When(@"the user deletes the file from the attachment table")]
        public void WhenTheUserDeletesTheFileFromTheAttachmentTable()
        {
            personalDetailsPage.clickDeleteFileAndConfirm();
        }

        [Then(@"the file is no longer displayed in the attachment table")]
        public void ThenTheFileIsNoLongerDisplayedInTheAttachmentTable()
        {
            personalDetailsPage.verifyFileIsNoLongerInTheAttachmentTable();
        }

        [Then(@"the First and Middle Name column is sorted in ascending order by default")]
        public void ThenTheFirstAndMiddleNameColumnIsSortedInAscendingOrderByDefault()
        {
            Assert.IsTrue(employeeListPage.verifyFirstNameColumnIsSortedAscending());
        }

        [When(@"the user clicks the Descending order in the Last Name column")]
        public void WhenTheUserClicksTheDescendingOrderInTheLastNameColumn()
        {
            employeeListPage.sortFirstNameDescending();
        }

        [Then(@"the Last name column is sorted in descending order")]
        public void ThenTheLastNameColumnIsSortedInDescendingOrder()
        {
            Assert.IsTrue(employeeListPage.verifyFirstNameColumnIsSortedDescending());
        }


    }
}
