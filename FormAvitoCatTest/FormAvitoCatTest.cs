using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using TDD.pages;

namespace FormAvitoCatTest
{
    
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        public IWebDriver br;
        public PageHome pHome = new PageHome(); 

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            br = new OpenQA.Selenium.Chrome.ChromeDriver();
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
        public void GoToAvito()
        {     
            Assert.IsTrue(br.Title == "Доска объявлений от частных лиц и компаний на Avito");     
        }
        

        [Test]
        public void SelCategory()
        {
            
            PageFactory.InitElements(br, pHome);
            pHome.InputSearch.SendKeys("Кошки" + Keys.Enter);

            Assert.IsTrue(br.Title == "Купить кошек и котят из питомника и частные объявления о продаже животных в Ульяновске на Avito.");
            
        }


    }
}
