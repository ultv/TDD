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

namespace TDD
{
    public partial class FormAvitoCat : Form
    {
        IWebDriver browser;

        public FormAvitoCat()
        {
            InitializeComponent();
        }

        private void buttonFindCat_Click(object sender, EventArgs e)
        {
            OpenBrowser("http://avito.ru");
        }

        public void OpenBrowser(string url)
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);
        }

        private void FormAvitoCat_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Quit();
        }
    }
}
