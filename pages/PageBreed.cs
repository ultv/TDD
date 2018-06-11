using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TDD.pages
{
    public class PageBreed
    {
        
        /// <summary>
        /// Первая ссылка в объявлениях выбранной породы.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-description-title-link")]
        public IWebElement LinkFirst { get; set; }
    }
}
