using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TDD.pages
{
    class PageHome
    {
        //By elementCategory = By.ClassName("js-search-form-category ");
        //By searchButton = By.ClassName("button-origin");

        //[FindsBy(How = How.CssSelector, Using = "input[title='Поиск']")]
        //public IWebElement TxtSearchForm { get; set; }

        [FindsBy(How = How.ClassName, Using = "js-search-form-category")];
        public IWebElement BtnSearch { get; set; }


    }
}
