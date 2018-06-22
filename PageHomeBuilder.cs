using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TDD
{
    public class PageHomeBuilder
    {
        private PageHome pageHome;

        public PageHomeBuilder(PageHome page)
        {
            this.pageHome = page;
        }

        /// <summary>
        /// Выбор категории из значений выпадающего списка.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public PageHomeBuilder SelectCategory(string category)
        {
            SelectElement select = new SelectElement(pageHome.SelectCategory);
            IList<IWebElement> options = select.Options;
            select.SelectByText(category);
            pageHome.BtnSearch.Click();

            return this;
        }

        public static implicit operator PageHome(PageHomeBuilder phb)
        {
            return phb.pageHome;
        }
    }
}
