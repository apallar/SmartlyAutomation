using OpenQA.Selenium;

namespace SmartlyAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        private By loginButton = By.CssSelector("button[type='submit']");

        private By passwordField = By.CssSelector("[type='password']");

        private By usernameField = By.Name("username");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void login(string username, string password)
        {
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(loginButton).Click();
        }
    }
}