using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TDD
{
    public partial class FormAvitoCat : Form
    {
        IWebDriver browser;
        IWebElement selectCategory; // ClassName("js-search-form-category ")
        IWebElement searchButton; // ClassName("search button button-origin")
        IWebElement catalogBreed; // ClassName("catalog-counts__row clearfix");

        public FormAvitoCat()
        {
            InitializeComponent();
        }

        private void buttonFindCat_Click(object sender, EventArgs e)
        {
            OpenBrowser("http://avito.ru");
            SelectCategory("Кошки");
        }

        public void OpenBrowser(string url)
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);
        }

        public void SelectCategory(string category)
        {            
            selectCategory = browser.FindElement(By.ClassName("js-search-form-category "));           
            SelectElement select = new SelectElement(selectCategory);
            IList<IWebElement> options = select.Options;
            select.SelectByText(category);
            searchButton = browser.FindElement(By.ClassName("button-origin"));
            searchButton.Click();
        }

        public void SelectFromCatalog()
        {

            //IList<IWebElement> catalog = 
        }

        private void FormAvitoCat_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Quit();
        }
    }
}
