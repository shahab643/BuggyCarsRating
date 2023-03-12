using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Principal;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Buggy_Cars_Rating.StepDefinitions
{
    [Binding]
    
    
        public class BuggyRatingStepDefinations
        {
            private IWebDriver driver;

            [Given(@"Open the browser")]
            public void GivenOpenTheBrowser()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            [When(@"Navigate to Main page")]
            public void WhenNavigateToMainPage()
            {
                driver.Url = "https://buggy.justtestit.org/";
                Thread.Sleep(2000);
            
            }
            [Then(@"Main Page is loaded")]
            public void ThenMainPageIsLoaded()
            {
                driver.FindElement(By.XPath("/html/body/my-app/header/div/div/div/div[1]/h1"));
                Thread.Sleep(2000);
                driver.Quit();

            }

        [Then(@"Enter Username and Password '([^']*)' '([^']*)'")]
        public void ThenEnterUsernameAndPassword(string username, string password)
        {
            driver.FindElement(By.Name("login")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/form/button")).Click();
            Thread.Sleep(3000);
            
        }

        [Then(@"User should login")]
        public void ThenUserShouldLogin()
        {
            String Result = driver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[2]/a")).Text;
            String Expected = "Profile";
            Assert.AreEqual(Result, Expected);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/my-app/header/nav/div/my-login/div/ul/li[3]/a")).Click();
            Thread.Sleep(2000);
            driver.Quit();
        }

        [Then(@"Verify the vote count for Popular Make")]
        public void ThenVerifyTheVoteCountForPopularMake()
        {
            String Result = driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[1]/div/div/h3/small")).Text;
            IList<IWebElement> all = driver.FindElements(By.XPath("/html/body/my-app/div/main/my-make/div/div[2]/div/div/table/tbody/tr[1]/td[4]"));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }
        }

        [Then(@"Verify the vote count for Popular Model")]
        public void ThenVerifyTheVoteCountForPopularModel()
        {
            String Result = driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/div/h3/small")).Text;
            String Expected = driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]/td[5]")).Text; 
            Assert.AreEqual(Result, Expected);
            driver.Quit();
        }

        [Then(@"Verify User is not able to Vote without Login")]
        public void ThenVerifyUserIsNotAbleToVoteWithoutLogin()
        {
            driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/a/img")).Click();
            Thread.Sleep(7000);
            String Result = driver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/p")).Text;
            String Expected = "You need to be logged in to vote.";
            Assert.AreEqual(Result, Expected);
            driver.Quit();

        }

    }
}