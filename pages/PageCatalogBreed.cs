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
    /// Страница со всеми породами.
    /// </summary>
    public class PageCatalogBreed
    {
        public static PageCatalogBreedBuilder Create(IWebDriver browser)
        {
            return new PageCatalogBreedBuilder(new PageCatalogBreed(browser));
        }

        public PageCatalogBreed(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Ссылка на объявления определенной породы.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "js-catalog-counts__link")]
        public IWebElement LinkBreed { get; set; }


        /// <summary>
        /// Значение количества предложений определённой породы.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "catalog-counts__number")]
        public IWebElement TxtCounts { get; set; }

    }
}
