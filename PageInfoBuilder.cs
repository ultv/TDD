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
    public class PageInfoBuilder
    {
        private PageInfo pageInfo;
        public By imagePhone = By.CssSelector(".item-phone-big-number img");

        public PageInfoBuilder(PageInfo page)
        {
            pageInfo = page;            
        }

        public PageInfo ShowPhone(IWebDriver browser)
        {
            pageInfo.BtnShowPhone.Click();
            WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            IWebElement note = browserWait.Until(ExpectedConditions.ElementIsVisible(imagePhone));

            return this;
        }

        public static implicit operator PageInfo(PageInfoBuilder pib)
        {
            return pib.pageInfo;
        }
    }
}
