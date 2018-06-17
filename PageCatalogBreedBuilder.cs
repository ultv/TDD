using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.pages;
using OpenQA.Selenium;

namespace TDD
{

    public class PageCatalogBreedBuilder
    {
       
        private PageCatalogBreed pageCatalogBreed;

        public PageCatalogBreedBuilder(PageCatalogBreed page)
        {
            pageCatalogBreed = page;
        }

        /// <summary>
        /// Переход по ссылке на породу с максимальным количеством предложений.
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public PageCatalogBreedBuilder SelectMaxSentences(IWebDriver browser)
        {
            pageCatalogBreed = new PageCatalogBreed(browser);
            List<IWebElement> breed = browser.FindElements(pageCatalogBreed.LinkBreedBy).ToList();
            List<IWebElement> count = browser.FindElements(pageCatalogBreed.TxtCountsBy).ToList();

            Comparator find = new Comparator();
            breed[find.FindMaxFromCatalog(breed, count)].Click();

            return this;
        }

        /// <summary>
        /// Переход по ссылке на породу с максимальным количеством предложений.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="findBreedName">Принимает ссылку на строку с названием породы</param>
        /// <returns></returns>
        public PageCatalogBreedBuilder SelectMaxSentences(IWebDriver browser, ref string findBreedName)
        {
            pageCatalogBreed = new PageCatalogBreed(browser);
            List<IWebElement> breed = browser.FindElements(pageCatalogBreed.LinkBreedBy).ToList();
            List<IWebElement> count = browser.FindElements(pageCatalogBreed.TxtCountsBy).ToList();

            Comparator find = new Comparator();
            int index = find.FindMaxFromCatalog(breed, count);
            findBreedName = breed[index].Text;
            breed[index].Click();

            return this;
        }

        public static implicit operator PageCatalogBreed(PageCatalogBreedBuilder pcbb)
        {
            return pcbb.pageCatalogBreed;
        }
    }
}
