using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using TDD;
using System.Linq;


namespace FormAvitoCatTest
{   

    [TestFixture]
    public class FormAvitoCatTest : NUnitSetupFixture
    {
       
        [Test]
        public void test1()//GoToAvito()
        {
            // Arrange
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://avito.ru/");            
            string expected = "Доска объявлений от частных лиц и компаний на Avito";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

     
        [Test]
        public void test2()//GoToCats()
        {
            //Arrange
            PageFactory.InitElements(browser, pageHome);         
            SelectElement select = new SelectElement(pageHome.SelectCategory);
            IList<IWebElement> options = select.Options;
            select.SelectByText("Кошки");
            pageHome.BtnSearch.Click();            
            string expected = "Купить кошек и котят из питомника и частные объявления о продаже животных в Ульяновске на Avito.";

            //Act
            string actual = browser.Title;

            //Assert
            Assert.AreEqual(expected, actual);            
        }


        [Test]
        public void test3()//GoToBreed()
        {   
            //Arrange
            PageFactory.InitElements(browser, pageCatalogBreed);
            List<IWebElement> breed = browser.FindElements(linkBreed).ToList();
            List<IWebElement> count = browser.FindElements(elementCount).ToList();

            Comparator find = new Comparator();
            int index = find.FindMaxFromCatalog(breed, count);
            string findBreedName = breed[index].Text;
            breed[index].Click();
            string expected = $"Кошки и котята породы {findBreedName} - купить из питомников и частные объявления о продаже животных в Ульяновске на Avito";

            //Act
            string actual = browser.Title;

            //Asset
            Assert.AreEqual(expected, actual);
        }
      

        [Test]
        public void test4()//GoToCat()
        {
            //Arrange
            PageFactory.InitElements(browser, pageBreed);
            pageBreed.LinkFirst.Click();
            PageFactory.InitElements(browser, pageInfo);
            string name = pageInfo.TxtName.Text;
            string expected = $"{name} - купить, продать или отдать в Ульяновской области на Avito";

            //Act            
            string actual = browser.Title;
            actual = actual.Substring(0, expected.Length);

            //Assert
            Assert.AreEqual(expected, actual);            
        }


        [Test]
        public void test5()//GoToPhone()
        {
            //Arrange
            pageInfo.BtnShowPhone.Click();          
            WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            IWebElement note = browserWait.Until(ExpectedConditions.ElementIsVisible(callNote));
            string expected = "Скажите продавцу, что нашли это объявление на Avito";

            //Act
            string actual = pageInfo.TxtCallNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);            
        }
        
        
    }
}
