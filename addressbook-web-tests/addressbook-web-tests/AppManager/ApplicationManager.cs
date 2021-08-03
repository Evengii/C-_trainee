using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class ApplicationManager 
    {
        protected IWebDriver driver;
        protected string baseURL;
       
        protected LoginLogoutHelper loginLogoutHelper;
        protected NavigationHelper navigationHelper;
        protected FillingFormHelper fillingFormHelper;
        protected OthersHelper otherActionsHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() //сделали private, чтобы гарантировать уникальность создания потока app менеджером 
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";

            loginLogoutHelper = new LoginLogoutHelper(driver); // добавили помощника для разгрузки TestBase
            navigationHelper = new NavigationHelper(driver);
            fillingFormHelper = new FillingFormHelper(driver);
            otherActionsHelper = new OthersHelper(driver, baseURL);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                app.Value = newInstance; //если для текущего потока нет объекта ApplicationManager, он создает и возвращает его
                newInstance.Others.OpenPage();
            }
            return app.Value;
        }
        
        public LoginLogoutHelper Auth
        {
            get
            {
                return loginLogoutHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public FillingFormHelper Filling
        {
            get
            {
                return fillingFormHelper;
            }
        }
        public OthersHelper Others
        {
            get
            {
                return otherActionsHelper;
            }
        }
    }
}
