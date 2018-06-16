﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TDD;

namespace TDD.pages
{
    /// <summary>
    /// Страница выбранного объявления.
    /// </summary>
    public class PageInfo
    {

        public static PageInfoBuilder Create(IWebDriver browser)
        {
            return new PageInfoBuilder(new PageInfo(browser));
        }

        public PageInfo(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
        

        /// <summary>
        /// Заголовок выбранного объявления.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "title-info-title-text")]
        public IWebElement TxtName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".title-info-title span")]
        public IWebElement TxtNameCss { get; set; }


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
       

        [FindsBy(How = How.CssSelector, Using = ".item-phone-number a")]
        public IWebElement BtnShowPhoneCss { get; set; }


        /// <summary>
        /// Рекомендация покупателю.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "item-phone-call-note")]
        public IWebElement TxtCallNote { get; set; }


        /// <summary>
        /// Количество просмотров.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "title-info-views")]
        public IWebElement TxtCountViews { get; set; }


        /// <summary>
        /// Стоимость.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".item-price span")]
        public IWebElement TxtPriceCss { get; set; }

        /// <summary>
        /// Изображение с номером телефона.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".item-phone-big-number img")]
        public IWebElement ImgPhone { get; set; }


        [FindsBy(How = How.ClassName, Using = "img")]
        public IWebElement ImgTag { get; set; }
    }
}
