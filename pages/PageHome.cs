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
        public static PageHomeBuilder Create(IWebDriver browser)
        {
            return new PageHomeBuilder(new PageHome(browser));
        }

        public PageHome(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
        
        /// <summary>
        /// Выпадающий список - категория поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "js-search-form-category")]
        [FindsBy(How = How.Id, Using = "category")]
        [FindsBy(How = How.Name, Using = "category_id")]
        [FindsBy(How = How.CssSelector, Using = "#category")]
        public IWebElement SelectCategory { get; set; }
        
        
        /// <summary>
        /// Поле ввода текста для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "suggest_search")]
        [FindsBy(How = How.Id, Using = "search")]
        [FindsBy(How = How.Name, Using = "name")]
        [FindsBy(How = How.CssSelector, Using = "#search")]
        public IWebElement InputSearch { get; set; }

        
        /// <summary>
        /// Кнопка "Найти" на панели параметров поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "button-origin")]
        [FindsBy(How = How.CssSelector, Using = ".search-form__submit button")]
        public IWebElement BtnSearch { get; set; }
        
    }
}
