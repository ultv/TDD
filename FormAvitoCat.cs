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
using TDD.pages;




namespace TDD
{
    public partial class FormAvitoCat : Form
    {
        static IWebDriver browser;
        readonly string url = "http://avito.ru";
        IJavaScriptExecutor javaEx;
        PageHome pageHome;
        PageInfo pageInfo;        
        PageBreed pageBreed;
        PageCatalogBreed pageCatalogBreed;                

        public FormAvitoCat()
        {            
            InitializeComponent();            
        }

        private void FormAvitoCat_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        /// <summary>
        /// Установка элементов формы в исходное состояние.
        /// </summary>
        public void InitForm()
        {
            labelName.Text = "Имя";                        
            labelNumber.Text = "Номер объявления:";                       
            labelBreed.Text = "Порода:";
            labelViews.Text = "Кол-во просмотров:";
            labelPrice.Text = "Стоимость:";
            
            textBoxInfo.Clear();                        
            textBoxContact.Clear();

            textBoxInfo.Enabled = false;
            textBoxContact.Enabled = false;
            labelName.Enabled = false;
            labelNumber.Enabled = false;
            labelContact.Enabled = false;
            labelBreed.Enabled = false;
            labelDescription.Enabled = false;
            labelViews.Enabled = false;
            labelPrice.Enabled = false;
        }

        /// <summary>
        /// Активация доступности элементов формы.
        /// </summary>
        public void SetEnabled()
        {
            textBoxInfo.Enabled = true;
            textBoxContact.Enabled = true;
            labelName.Enabled = true;
            labelNumber.Enabled = true;
            labelContact.Enabled = true;
            labelBreed.Enabled = true;
            labelDescription.Enabled = true;
            labelViews.Enabled = true;
            labelPrice.Enabled = true;
        }

        /// <summary>
        /// Обработка нажатия кнопки поиска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindCat_Click(object sender, EventArgs e)
        {
            InitForm();
            OpenBrowser(url);

            pageHome = PageHome.
                                Create(browser).
                                SelectCategory("Кошки");            

            pageCatalogBreed = PageCatalogBreed.
                                                Create(browser).
                                                SelectMaxSentences();

            pageBreed = PageBreed.
                                 Create(browser).
                                 GoToFirstLink();            
            
            SetEnabled();

            pageInfo = PageInfo.
                                Create(browser).
                                GetInfo(this);

                              
            if(FindScrollBar())
            {
                System.Threading.Thread.Sleep(2000);
                MakeDoubleScroll();
                System.Threading.Thread.Sleep(5000);
            }
            
            this.Activate();
            browser.Manage().Window.Minimize();
        }

        /// <summary>
        /// Открытие браузера.
        /// </summary>
        /// <param name="url">Адрес открываемой страницы</param>
        public void OpenBrowser(string url)
        {
            if(browser == null)
            {
                browser = new OpenQA.Selenium.Chrome.ChromeDriver();           
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
            
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);            
        }
                                       

        /// <summary>
        /// Закрытие браузера при закрытии формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAvitoCat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(browser != null)
            {
                browser.Quit();
            }            
        }
       

        /// <summary>
        /// Скролл дважды вниз.
        /// </summary>
        /// <param name="offset"></param>
        public void MakeDoubleScroll()
        {
                               
            javaEx = (IJavaScriptExecutor)browser;           
            javaEx.ExecuteScript("alert('Будет выпполнен скролл вниз');");
            System.Threading.Thread.Sleep(2000);

            try
            {
                IAlert alert = browser.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {

            }

            System.Threading.Thread.Sleep(1000);
            javaEx.ExecuteScript($"window.scrollTo(0, window.innerHeight);");
            System.Threading.Thread.Sleep(2000);

            javaEx.ExecuteScript("alert('Повторное выпполнение скролла вниз');");
            System.Threading.Thread.Sleep(2000);

            try
            {
                IAlert alert = browser.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {

            }

            System.Threading.Thread.Sleep(1000);
            javaEx.ExecuteScript($"window.scrollTo(0, document.body.scrollHeight);");
                        
        }

        /// <summary>
        /// Проверка присутствия скроллбара на странице.
        /// </summary>
        /// <returns>Возвращает истину, если скроллбар присутствует.</returns>
        public bool FindScrollBar()
        {
            javaEx = (IJavaScriptExecutor)browser;

            string script = "return document.body.offsetHeight > window.innerHeight? true : false;";

            return (bool)javaEx.ExecuteScript(script);
        }


        /// <summary>
        /// Присвоение имени.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            labelName.Text = name;
        }

        /// <summary>
        /// Присвоение номера объявления.
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(string number)
        {
            labelNumber.Text = number;
        }

        /// <summary>
        /// Присвоение породы.
        /// </summary>
        /// <param name="breed"></param>
        public void SetBreed(string breed)
        {
            labelBreed.Text = breed;
        }

        /// <summary>
        /// Присвоение количества просмотров.
        /// </summary>
        /// <param name="views"></param>
        public void SetViews(string views)
        {
            labelViews.Text += views;
        }

        /// <summary>
        /// Присвоение стоимости.
        /// </summary>
        /// <param name="price"></param>
        public void SetPrice(string price)
        {
            labelPrice.Text += price;
        }
        
        /// <summary>
        /// Добавление информации.
        /// </summary>
        /// <param name="info"></param>
        public void AddInfo(string info)
        {
            textBoxInfo.AppendText(info);
        }

        /// <summary>
        /// Добавление контактов.
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(string contact)
        {
            textBoxContact.AppendText(contact);
        }

        /// <summary>
        /// Присвоение адреса изображения.
        /// </summary>
        /// <param name="location"></param>
        public void SetImageLocation(string location)
        {
            pictureBoxCat.ImageLocation = location;
        }

        /// <summary>
        /// Присвоение изображения.
        /// </summary>
        /// <param name="image"></param>
        public void SetImagePhone(Image image)
        {
            pictureBoxPhone.Image = image;
        }

    }
}
