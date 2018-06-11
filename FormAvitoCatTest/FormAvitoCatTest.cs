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

    [TestFixture]
    public class FormAvitoCatTest : NUnitSetupFixture
    {     
        
        [Test]
        public void test1()//GoToAvito()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://avito.ru/");

            Assert.IsTrue(browser.Title == "Доска объявлений от частных лиц и компаний на Avito");     
        }
        

        [Test]
        public void test2()//GoToCats()
        {
            PageFactory.InitElements(browser, pageHome);
            //pHome.InputSearch.SendKeys("Кошки" + Keys.Enter);

            SelectElement select = new SelectElement(pageHome.SelectCategory);
            IList<IWebElement> options = select.Options;
            select.SelectByText("Кошки");
            pageHome.BtnSearch.Click();

            Assert.IsTrue(browser.Title == "Купить кошек и котят из питомника и частные объявления о продаже животных в Ульяновске на Avito.");
        }


        [Test]
        public void test3()//GoToBreed()
        {            
            PageFactory.InitElements(browser, pageCatalogBreed);
            List<IWebElement> breed = browser.FindElements(linkBreed).ToList();
            List<IWebElement> count = browser.FindElements(elementCount).ToList();

            Comparator find = new Comparator();
            int index = find.FindMaxFromCatalog(breed, count);
            string findBreedName = breed[index].Text;
            breed[index].Click();

            Assert.IsTrue(browser.Title == $"Кошки и котята породы {findBreedName} - купить из питомников и частные объявления о продаже животных в Ульяновске на Avito");
        }


        [Test]
        public void test4()//GoToCat()
        {
            PageFactory.InitElements(browser, pageBreed);
            pageBreed.LinkFirst.Click();

            PageFactory.InitElements(browser, pageInfo);
            string name = pageInfo.TxtName.Text;

            Assert.IsTrue(browser.Title.Contains($"{name} - купить, продать или отдать в Ульяновской области на Avito"));
        }

        [Test]
        public void test5()
        {
            pageInfo.BtnShowPhone.Click();          

            WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            IWebElement note = browserWait.Until(ExpectedConditions.ElementIsVisible(callNote));

            Assert.IsTrue(pageInfo.TxtCallNote.Text == "Скажите продавцу, что нашли это объявление на Avito");
        }
        

    }
}
