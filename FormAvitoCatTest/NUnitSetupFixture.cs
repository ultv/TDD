using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using TDD.pages;


namespace FormAvitoCatTest
{
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        static public IWebDriver browser;
        public PageHome pageHome;
        public PageCatalogBreed pageCatalogBreed;
        public PageBreed pageBreed;
        public PageInfo pageInfo;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            // browser.Manage().Window.Maximize();
            // browser.Navigate().GoToUrl("http://avito.ru/");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            browser.Quit();
        }
    }
}
