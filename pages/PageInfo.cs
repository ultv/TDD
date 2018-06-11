using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TDD.pages
{
    class PageInfo
    {
        /*
        //By elementName = By.ClassName("title-info-title-text");
        //By elementDate = By.ClassName("title-info-metadata-item");
        //By elementBreed = By.ClassName("item-params");
        //By elementLocation = By.ClassName("item-map-location");
        //By elementDescription = By.ClassName("item-description-text");
        //By elementContact = By.ClassName("seller-info-col");
        By imageCat = By.ClassName("gallery-img-wrapper");
        By imageTag = By.TagName("img");
        */

        /// <summary>
        /// Заголовок выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "title-info-title-text")]
        public IWebElement TxtName { get; set; }

        /// <summary>
        /// Дата размещения выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "title-info-metadata-item")]
        public IWebElement TxtDate { get; set; }

        /// <summary>
        /// Название породы на странице выбраного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-params")]
        public IWebElement TxtBreed { get; set; }

        /// <summary>
        /// Район проживания продавца на странице выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-map-location")]
        public IWebElement TxtLocation { get; set; }

        /// <summary>
        /// Описание к выбранному объявлению.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-description-text")]
        public IWebElement TxtDescription { get; set; }

        /// <summary>
        /// Информация о продавце на странице выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "seller-info-col")]
        public IWebElement TxtContact { get; set; }

        /// <summary>
        /// Главное фото на странице выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gallery-img-wrapper")]       
        public IWebElement ImgMain { get; set; }


        //[FindsBy(How = How.ClassName, Using = "img")]
        //public IWebElement ImgTag { get; set; }
    }
}
