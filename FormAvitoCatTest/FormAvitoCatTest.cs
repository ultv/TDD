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
        public void test1_GoToAvito()
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
        public void test2_GoFromHomeToCats()
        {
            //Arrange            
            pageHome = PageHome.
                                Create(browser).
                                SelectCategory("Кошки");           

            string expected = "Купить кошек и котят из питомника и частные объявления о продаже животных в Ульяновске на Avito.";

            //Act
            string actual = browser.Title;

            //Assert
            Assert.AreEqual(expected, actual);            
        }


        [Test]
        public void test3_GoFromCatsToBreed()
        {
            //Arrange
            string findBreedName = "";            
            pageCatalogBreed = PageCatalogBreed.
                                                Create(browser).
                                                SelectMaxSentences(ref findBreedName);
            
            string expected = $"Кошки и котята породы {findBreedName} - купить из питомников и частные объявления о продаже животных в Ульяновске на Avito";

            //Act
            string actual = browser.Title;

            //Asset
            Assert.AreEqual(expected, actual);
        }
        

        [Test]
        public void test4_GoFromBreedToCat()
        {
            //Arrange
            string name = "";
            pageBreed = PageBreed.
                                Create(browser).
                                GoToFirstLink(ref pageInfo, ref name);
                                    
            string expected = $"{name} - купить, продать или отдать в Ульяновской области на Avito";

            //Act            
            string actual = browser.Title;
            actual = actual.Substring(0, expected.Length);

            //Assert
            Assert.AreEqual(expected, actual);
        }
       

        [Test]
        public void test5_ShowPhone()
        {
            //Arrange            
            pageInfo = PageInfo.
                                Create(browser).
                                ShowPhone();
                            
            string expected = "Скажите продавцу, что нашли это объявление на Avito";

            //Act
            string actual = pageInfo.TxtCallNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
