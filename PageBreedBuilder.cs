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
    public class PageBreedBuilder
    {
        private PageBreed pageBreed;

        public PageBreedBuilder(PageBreed page)
        {
            pageBreed = page;
        }

        /// <summary>
        /// Переход по первому объявлению в результатах выбора породы.
        /// </summary>
        /// <returns></returns>
        public PageBreed GoToFirstLink()
        {
            pageBreed.LinkFirst.Click();

            return this;
        }

        public PageBreed GoToFirstLink(ref PageInfo pageInfo,  ref string name)
        {
            pageBreed.LinkFirst.Click();
            pageInfo = new PageInfo(pageBreed.browser);
            name = pageInfo.TxtName.Text;

            return this;
        }

        public static implicit operator PageBreed(PageBreedBuilder pbb)
        {
            return pbb.pageBreed;
        }
    }
}
