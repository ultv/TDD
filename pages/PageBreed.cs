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
    /// Страница с объявлениями выбранной породы.
    /// </summary>
    public class PageBreed
    {
        
        public PageBreed(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Первая ссылка в объявлениях выбранной породы.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-description-title-link")]
        public IWebElement LinkFirst { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".item_table-header a")]
        public IWebElement LinkFirstCss { get; set; }
        
    }
}
