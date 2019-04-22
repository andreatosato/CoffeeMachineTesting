using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace CoffeeMachine.Test.UI
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl("http://www.google.com");
            

        }
    }
}
