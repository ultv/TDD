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
        public readonly string url = "http://avito.ru";
        public PageHome pageHome;
        public PageCatalogBreed pageCatalogBreed;
        public PageBreed pageBreed;
        public PageInfo pageInfo;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            browser.Quit();
        }
    }
}
