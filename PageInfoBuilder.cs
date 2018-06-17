using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Drawing;


namespace TDD
{
    public class PageInfoBuilder
    {
        private PageInfo pageInfo;
        public By imagePhone = By.CssSelector(".item-phone-big-number img");
        By imageTag = By.TagName("img");

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

        /// <summary>
        /// Заполнение элементов формы.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="browser"></param>
        /// <returns></returns>
        public PageInfo GetInfo(FormAvitoCat form, IWebDriver browser)
        {

            form.SetName(pageInfo.TxtName.Text);            
            form.SetNumber(pageInfo.TxtDate.Text);
            form.SetBreed(pageInfo.TxtBreed.Text);
            form.SetViews(pageInfo.TxtCountViews.Text);

            string substring = pageInfo.TxtPriceCss.Text;
            if (substring != "Цена не указана")
            {
                substring = substring.Substring(0, substring.Length - 2) + " рублей.";
            }

            form.SetPrice(substring);
            form.AddInfo(pageInfo.TxtDescription.Text + "\n");
            form.AddContact(pageInfo.TxtContact.Text + "\n");

            string adress = pageInfo.TxtLocation.Text;
            substring = "Посмотреть карту";

            if (adress.Contains(substring))
            {
                int index = adress.IndexOf("Посмотреть карту");
                adress = adress.Remove(index, substring.Length);
            }

            form.AddContact(adress + "\n");
            form.SetImageLocation(pageInfo.ImgMain.FindElement(imageTag).GetAttribute("src"));
            pageInfo.BtnShowPhoneCss.Click();

            WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            IWebElement note = browserWait.Until(ExpectedConditions.ElementIsVisible(imagePhone));

            Bitmap screenshot = GetScreenshot(browser, Directory.GetCurrentDirectory() + "/screenshot1.jpg");
            form.SetImagePhone(CutPhoneFromScreenshot(screenshot));

            pageInfo.LinkPhoneClose.Click();

            return this;

        }


        /// <summary>
        /// Создание и сохранение снимка экрана.
        /// </summary>
        /// <param name="br">Браузер</param>
        /// <param name="location">Путь для сохранения изображения</param>
        /// <returns>Возвращает сохраненное изображение</returns>
        public Bitmap GetScreenshot(IWebDriver br, string location)
        {
            ITakesScreenshot screenshotDriver = br as ITakesScreenshot;
            Screenshot screnshot = screenshotDriver.GetScreenshot();
            screnshot.SaveAsFile(location);
            Bitmap bmp = new Bitmap(location);

            return bmp;
        }

        /// <summary>
        /// Извлечение области из снимка экрана.
        /// !!! Проверялось с разрешением экрана 1680х900.        
        /// </summary>
        /// <param name="bmpIn">Исходное изображение</param>
        /// <returns>Возвращает обработанное изображение</returns>
        public Bitmap CutPhoneFromScreenshot(Bitmap bmpIn)
        {
            Bitmap bmpOut = bmpIn.Clone(new Rectangle(530, 340, 340, 60), bmpIn.PixelFormat);
            return bmpOut;
        }

    }
}
