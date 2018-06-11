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
        public IWebDriver browser;
        public PageHome pageHome = new PageHome();
        public PageCatalogBreed pageCatalogBreed = new PageCatalogBreed();
        public PageBreed pageBreed = new PageBreed();
        public PageInfo pageInfo = new PageInfo();
        public By linkBreed = By.ClassName("js-catalog-counts__link");
        public By elementCount = By.ClassName("catalog-counts__number");
        public By callNote = By.ClassName("item-phone-call-note");

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
