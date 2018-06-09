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
            FindMaxFromCatalog();
            GetInfo();
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

        public void FindMaxFromCatalog()
        {
                        
            List<IWebElement> breed = browser.FindElements(By.ClassName("js-catalog-counts__link")).ToList();
            List<IWebElement> num = browser.FindElements(By.ClassName("catalog-counts__number")).ToList();           
            
            int max = 0;
            int maxIndex = 0;
            
            for(int i = 0; i < num.Count; i++)
            {
                int compare = Int32.Parse(num[i].Text);
                if ((compare > max) && (breed[i].Text != "Другая"))
                {
                    max = compare;
                    maxIndex = i;
                }
            }

            // MessageBox.Show(breed[maxIndex].Text + " - " + num[maxIndex].Text);

            breed[maxIndex].Click();

            IWebElement firstLink = browser.FindElement(By.ClassName("item-description-title-link"));
            firstLink.Click();

        }

        public void GetInfo()
        {
            IWebElement name = browser.FindElement(By.ClassName("title-info-title-text"));
            textBoxInfo.AppendText(name.Text + "\n");

            IWebElement date = browser.FindElement(By.ClassName("title-info-metadata-item"));
            textBoxInfo.AppendText(date.Text + "\n");

            IWebElement breed = browser.FindElement(By.ClassName("item-params"));
            textBoxInfo.AppendText(breed.Text + "\n");


            IWebElement adress = browser.FindElement(By.ClassName("item-map-label"));
            textBoxInfo.AppendText(adress.Text + "\n");            
            IWebElement adress2 = browser.FindElement(By.ClassName("item-map-address"));
            textBoxInfo.AppendText(adress2.Text + "\n");

            IWebElement description = browser.FindElement(By.ClassName("item-description-text"));
            textBoxInfo.AppendText(description.Text + "\n");

            IWebElement person = browser.FindElement(By.ClassName("seller-info-col"));
            textBoxInfo.AppendText(person.Text + "\n");

            //IWebElement phoneButton = browser.FindElement(By.ClassName("item-phone-button"));
            //phoneButton.Click();
        }


        private void FormAvitoCat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(browser != null)
            {
                browser.Quit();
            }            
        }
    }
}
