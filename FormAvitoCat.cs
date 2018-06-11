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
        IWebDriver browser;
        PageHome pageHome = new PageHome();
        PageCatalogBreed pageCatalogBreed = new PageCatalogBreed();
        PageBreed pageBreed = new PageBreed();
        PageInfo pageInfo = new PageInfo();
                        
        //By elementCategory = By.ClassName("js-search-form-category ");
        //By searchButton = By.ClassName("button-origin");
        By linkBreed = By.ClassName("js-catalog-counts__link");
        By elementCount = By.ClassName("catalog-counts__number");
        //By linkFirst = By.ClassName("item-description-title-link");
        By elementName = By.ClassName("title-info-title-text");
        By elementDate = By.ClassName("title-info-metadata-item");
        By elementBreed = By.ClassName("item-params");
        By elementLocation = By.ClassName("item-map-location");
        By elementDescription = By.ClassName("item-description-text");
        By elementContact = By.ClassName("seller-info-col");
        By imageCat = By.ClassName("gallery-img-wrapper");
        By imageTag = By.TagName("img");
        By phoneButton = By.ClassName("item-phone-button-sub-text");
        By phoneImage = By.ClassName("item-phone-big-number");

        public FormAvitoCat()
        {
            InitializeComponent();
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
            
            textBoxInfo.Clear();                        
            textBoxContact.Clear();

            textBoxInfo.Enabled = false;
            textBoxContact.Enabled = false;
            labelName.Enabled = false;
            labelNumber.Enabled = false;
            labelContact.Enabled = false;
            labelBreed.Enabled = false;
            labelDescription.Enabled = false;            
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
            PageFactory.InitElements(browser, pageHome);
            SelectCategory("Кошки");
            PageFactory.InitElements(browser, pageCatalogBreed);

            List<IWebElement> breed = browser.FindElements(linkBreed).ToList();
            List<IWebElement> count = browser.FindElements(elementCount).ToList();

            Comparator find = new Comparator();

            breed[find.FindMaxFromCatalog(breed, count)].Click();

            PageFactory.InitElements(browser, pageBreed);
            pageBreed.LinkFirst.Click();
            
            SetEnabled();
            PageFactory.InitElements(browser, pageInfo);
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
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
            
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);            
        }

        /// <summary>
        /// Выбор категории из значений выпадающего списка.
        /// </summary>
        /// <param name="category">Название категории</param>
        public void SelectCategory(string category)
        {            
            
            SelectElement select = new SelectElement(pageHome.SelectCategory);
            IList<IWebElement> options = select.Options;
            select.SelectByText(category);                                    
            pageHome.BtnSearch.Click();
            
        }

        /// <summary>
        /// Поиск ссылки на породу с максимальным количеством предложений.
        /// </summary>
        /// <param name="breed">Список элементов с названием породы</param>
        /// <param name="count">Список элементов с количеством предложений</param>
        /// <returns>Возвращает индекс элемента с максимальным количеством предложений</returns>        
        public int FindMaxFromCatalog(List<IWebElement> breed, List<IWebElement> count)
        {
            
            int max = 0;
            int maxIndex = 0;
            
            for(int i = 0; i < count.Count; i++)
            {
                int compare = Int32.Parse(count[i].Text);
                if ((compare > max) && (breed[i].Text != "Другая"))
                {
                    max = compare;
                    maxIndex = i;
                }
            }

            return maxIndex;           
        }

        /// <summary>
        /// Получение информации из объявления и заполнение соответствующих элементов формы.
        /// </summary>
        public void GetInfo()
        {
            
            labelName.Text = pageInfo.TxtName.Text;            

            //var date = browser.FindElement(elementDate);
            labelNumber.Text = pageInfo.TxtDate.Text;            

            //var breed = browser.FindElement(elementBreed);
            labelBreed.Text = pageInfo.TxtBreed.Text;            

            //var description = browser.FindElement(elementDescription);
            textBoxInfo.AppendText(pageInfo.TxtDescription.Text + "\n");            

            //var contact = browser.FindElement(elementContact);
            textBoxContact.AppendText(pageInfo.TxtContact.Text + "\n");
           
            //var location = browser.FindElement(elementLocation);
            string adress = pageInfo.TxtLocation.Text;
            string substring = "Посмотреть карту";

            if (adress.Contains(substring))
            {                
                int index = adress.IndexOf("Посмотреть карту");
                adress = adress.Remove(index, substring.Length);
            }

            textBoxContact.AppendText(adress + "\n");
            
            pictureBoxCat.ImageLocation = pageInfo.ImgMain.FindElement(imageTag).GetAttribute("src");
            
            var phone = browser.FindElement(phoneButton);
            phone.Click();            
            System.Threading.Thread.Sleep(1000);
            Bitmap screenshot = GetScreenshot(browser, Directory.GetCurrentDirectory() + "/screenshot1.jpg");
            pictureBoxPhone.Image = CutPhoneFromScreenshot(screenshot);

            this.Activate();
            browser.Manage().Window.Minimize();

        }

        /// <summary>
        /// Получение адреса, загрузка и сохранение изображения.
        /// !!! Не работает с длинным url .
        /// </summary>
        public void GetPhotoPhone()
        {            
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            
            string urlImagePhone = browser.FindElement(phoneImage).FindElement(imageTag).GetAttribute("src");
            textBoxInfo.AppendText(urlImagePhone + "\n");
            WebClient client = new WebClient();
            Uri uri = new Uri(urlImagePhone);
            client.DownloadFile(uri, "imagePhone.jpg");
            pictureBoxPhone.Image = Image.FromFile("imagePhone.jpg");            
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
            Bitmap bmpOut = bmpIn.Clone(new Rectangle(530, 330, 340, 60), bmpIn.PixelFormat);
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

        private void FormAvitoCat_Load(object sender, EventArgs e)
        {

        }
    }
}
