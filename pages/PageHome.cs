using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TDD.pages
{
    /// <summary>
    /// Стартовая страница.
    /// </summary>
    public class PageHome
    {

        public PageHome(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
        
        /// <summary>
        /// Выпадающий список - категория поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "js-search-form-category")]
        public IWebElement SelectCategory { get; set; }

        [FindsBy(How = How.Id, Using = "category")]
        public IWebElement SelectCategoryId { get; set; }

        [FindsBy(How = How.Name, Using = "category_id")]
        public IWebElement SelectCategoryName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#category")]
        public IWebElement SelectCategoryCss { get; set; }


        /// <summary>
        /// Поле ввода текста для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "suggest_search")]
        public IWebElement InputSearch { get; set; }

        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement InputSearchId { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement InputSearchName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#search")]
        public IWebElement InputSearchCss { get; set; }


        /// <summary>
        /// Кнопка "Найти" на панели параметров поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "button-origin")]
        public IWebElement BtnSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".search-form__submit button")]
        public IWebElement BtnSearchCss { get; set; }

    }
}
