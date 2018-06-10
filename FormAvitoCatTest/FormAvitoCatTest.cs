using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using TDD;

namespace FormAvitoCatTest
{
    
    [TestClass]
    public class FormAvitoCatTest
    {
        IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
              
        [TestMethod]
        public void GoToAvito()
        {            
            browser.Navigate().GoToUrl("http://avito.ru/");
            NUnit.Framework.Assert.IsTrue(browser.Title == "Доска объявлений от частных лиц и компаний на Avito");
        }

        /*
        public void FindMaxFromCatalog_15_and_120_and_53_1returned()
        {
            // Arrange
            List<IWebElement> breed = new List<IWebElement>();
            List<IWebElement> count = new List<IWebElement>();
            Comparator find = new Comparator();
            //IWebElement brd = ;
            
            breed.Add(brd);
            int expected = 1;
            

            
            // Act
            int actual = find.FindMaxFromCatalog(breed, count);

            //Assert
            NUnit.Framework.Assert.AreEqual(expected, actual);

        }
        */
    }
}
