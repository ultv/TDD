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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Net;
using System.Drawing.Imaging;
using System.IO;
using TDD.pages;




namespace TDD
{
    public partial class FormAvitoCat : Form
    {
        static IWebDriver browser;
        PageHome pageHome;
        PageInfo pageInfo;        
        PageBreed pageBreed;
        PageCatalogBreed pageCatalogBreed;

       // By linkBreed = By.ClassName("js-catalog-counts__link");
      //  By elementCount = By.ClassName("catalog-counts__number");       
        By imagePhone = By.CssSelector(".item-phone-big-number img");
        By imageTag = By.TagName("img");       

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
            OpenBrowser("http://avito.ru");

            pageHome = PageHome.
                                Create(browser).
                                SelectCategory("Кошки");            

            pageCatalogBreed = PageCatalogBreed.
                                                Create(browser).
                                                SelectMaxSentences(browser);

            pageBreed = PageBreed.
                                 Create(browser).
                                 GoToFirstLink();

            
            SetEnabled();
            pageInfo = new PageInfo(browser);
            GetInfo();
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
                //browser = new OpenQA.Selenium.Firefox.FirefoxDriver();
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
            
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);            
        }
        

        /// <summary>
        /// Получение информации из объявления и заполнение соответствующих элементов формы.
        /// </summary>
        public void GetInfo()
        {
            
            labelName.Text = pageInfo.TxtName.Text;                    
            labelNumber.Text = pageInfo.TxtDate.Text;           
            labelBreed.Text = pageInfo.TxtBreed.Text;
            labelViews.Text += pageInfo.TxtCountViews.Text;

            string substring = pageInfo.TxtPriceCss.Text;
            if(substring != "Цена не указана")
            {
                substring = substring.Substring(0, substring.Length - 2) + " рублей.";
            }

            labelPrice.Text += substring;                               
            textBoxInfo.AppendText(pageInfo.TxtDescription.Text + "\n");                    
            textBoxContact.AppendText(pageInfo.TxtContact.Text + "\n");
                   
            string adress = pageInfo.TxtLocation.Text;
            substring = "Посмотреть карту";

            if (adress.Contains(substring))
            {                
                int index = adress.IndexOf("Посмотреть карту");
                adress = adress.Remove(index, substring.Length);
            }

            textBoxContact.AppendText(adress + "\n");
            pictureBoxCat.ImageLocation = pageInfo.ImgMain.FindElement(imageTag).GetAttribute("src");            
            pageInfo.BtnShowPhoneCss.Click();

            WebDriverWait browserWait = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            IWebElement note = browserWait.Until(ExpectedConditions.ElementIsVisible(imagePhone));

            Bitmap screenshot = GetScreenshot(browser, Directory.GetCurrentDirectory() + "/screenshot1.jpg");
            pictureBoxPhone.Image = CutPhoneFromScreenshot(screenshot);            

            this.Activate();
            browser.Manage().Window.Minimize();

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
        
    }
}
