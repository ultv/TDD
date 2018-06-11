using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using TDD;
using TDD.pages;
using System.Linq;


namespace FormAvitoCatTest
{
    
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        public IWebDriver br;
        public PageHome pHome = new PageHome();
        public PageCatalogBreed pCatalogBreed = new PageCatalogBreed();
        public By linkBreed = By.ClassName("js-catalog-counts__link");
        public By elementCount = By.ClassName("catalog-counts__number");

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            br = new OpenQA.Selenium.Chrome.ChromeDriver();
            //br.Manage().Window.Maximize();
            br.Navigate().GoToUrl("http://avito.ru/");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            br.Quit();
        }
    }

    [TestFixture]
    public class FormAvitoCatTest : NUnitSetupFixture
    {     
        
        [Test]
        public void test1()//GoToAvito()
        {     
            Assert.IsTrue(br.Title == "Доска объявлений от частных лиц и компаний на Avito");     
        }

        
        [Test]
        public void test2()//GoToCats()
        {
            PageFactory.InitElements(br, pHome);
            pHome.InputSearch.SendKeys("Кошки" + Keys.Enter);

            Assert.IsTrue(br.Title == "Купить кошек и котят из питомника и частные объявления о продаже животных в Ульяновске на Avito.");            
        }
        

        
        [Test]
        public void test3()//GoToBreed()
        {
        
            PageFactory.InitElements(br, pCatalogBreed);
            List<IWebElement> breed = br.FindElements(linkBreed).ToList();
            List<IWebElement> count = br.FindElements(elementCount).ToList();

            Comparator find = new Comparator();
            breed[find.FindMaxFromCatalog(breed, count)].Click();

            Assert.IsTrue(br.Title == "Кошки и котята породы Шотландская - купить из питомников и частные объявления о продаже животных в Ульяновске на Avito");
        }
        

    }
}
