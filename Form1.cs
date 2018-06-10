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
using System.Net;
using System.Drawing.Imaging;
using System.IO;


namespace TDD
{
    public partial class FormAvitoCat : Form
    {
        IWebDriver browser;
                        
        By elementCategory = By.ClassName("js-search-form-category ");
        By searchButton = By.ClassName("button-origin");
        By linkBreed = By.ClassName("js-catalog-counts__link");
        By elementCount = By.ClassName("catalog-counts__number");
        By linkFirst = By.ClassName("item-description-title-link");
        By elementName = By.ClassName("title-info-title-text");
        By elementDate = By.ClassName("title-info-metadata-item");
        By elementBreed = By.ClassName("item-params");

        By elementDescription = By.ClassName("item-description-text");
        By elementPerson = By.ClassName("seller-info-col");

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
            var element = browser.FindElement(elementCategory);           
            SelectElement select = new SelectElement(element);
            IList<IWebElement> options = select.Options;
            select.SelectByText(category);
            var button = browser.FindElement(searchButton);
            button.Click();
        }

        public void FindMaxFromCatalog()
        {
                        
            List<IWebElement> breed = browser.FindElements(linkBreed).ToList();
            List<IWebElement> num = browser.FindElements(elementCount).ToList();           
            
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

            var link = browser.FindElement(linkFirst);
            link.Click();

        }

        public void GetInfo()
        {
            var name = browser.FindElement(elementName);
            textBoxInfo.AppendText(name.Text + "\n");

            var date = browser.FindElement(elementDate);
            textBoxInfo.AppendText(date.Text + "\n");

            var breed = browser.FindElement(elementBreed);
            textBoxInfo.AppendText(breed.Text + "\n");


            IWebElement adress = browser.FindElement(By.ClassName("item-map-label"));
            textBoxInfo.AppendText(adress.Text + "\n");            
            IWebElement adress2 = browser.FindElement(By.ClassName("item-map-address"));
            textBoxInfo.AppendText(adress2.Text + "\n");

            var description = browser.FindElement(elementDescription);
            textBoxInfo.AppendText(description.Text + "\n");

            var person = browser.FindElement(elementPerson);
            textBoxInfo.AppendText(person.Text + "\n");

            string urlImageCat = browser.FindElement(By.ClassName("gallery-img-wrapper")).FindElement(By.TagName("img")).GetAttribute("src");
            pictureBoxCat.ImageLocation = urlImageCat;


            IWebElement phoneButton = browser.FindElement(By.ClassName("item-phone-button-sub-text"));
            phoneButton.Click();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Bitmap screenshot = GetScreenshot(browser, Directory.GetCurrentDirectory() + "/screenshot1.jpg");
            pictureBoxPhone.Image = CutPhoneFromScreenshot(screenshot);

            this.Activate();
            browser.Manage().Window.Minimize();

            
            

            /*
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string urlImagePhone = browser.FindElement(By.ClassName("item-phone-big-number")).FindElement(By.TagName("img")).GetAttribute("src");
            textBoxInfo.AppendText(urlImagePhone + "\n");
            WebClient client = new WebClient();
            Uri uri = new Uri(urlImagePhone);
            client.DownloadFile(uri, "imagePhone.jpg");
            pictureBoxPhone.Image = Image.FromFile("imagePhone.jpg");
            */

        










        }

        public Bitmap GetScreenshot(IWebDriver br, string location)
        {
            ITakesScreenshot screenshotDriver = br as ITakesScreenshot;
            Screenshot screnshot = screenshotDriver.GetScreenshot();
            screnshot.SaveAsFile(location);
            Bitmap bmp = new Bitmap(location);

            return bmp;
        }

        public Bitmap CutPhoneFromScreenshot(Bitmap bmpIn)
        {

            Bitmap bmpOut = bmpIn.Clone(new Rectangle(530, 330, 340, 60), bmpIn.PixelFormat);
            return bmpOut;
        }



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
