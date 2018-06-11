using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TDD.pages
{
    public class PageHome
    {
        
        /// <summary>
        /// Выпадающий список - категория поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "js-search-form-category")]
        public IWebElement SelectCategory { get; set; }

        /// <summary>
        /// Поле ввода текста для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "suggest_search")]
        public IWebElement InputSearch { get; set; }

        /// <summary>
        /// Кнопка "Найти" на панели параметров поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "button-origin")]
        public IWebElement BtnSearch { get; set; }

    }
}
