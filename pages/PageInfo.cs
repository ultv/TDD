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

        /// <summary>
        /// Кнопка "Показать телефон" на странице выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-phone-button-sub-text")]
        public IWebElement BtnShowPhone { get; set; }


        [FindsBy(How = How.ClassName, Using = "img")]
        public IWebElement ImgTag { get; set; }
    }
}
