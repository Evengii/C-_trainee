using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests {
    public class OthersHelper : HelperBase
    {
        private string baseURL;
        public OthersHelper(IWebDriver driver, string baseURL) : base(driver) // используем базовый конструктор класса HelperBase
        {
            this.baseURL = baseURL;

        }
        public List<GroupData> groupCashe = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text)); // здесь каждый раз создаетс объект GroupData и вызываются все его методы - Equals, CompareTo
                }
            }
            return new List<GroupData>(groupCashe); // возвращается "копия" кэша, чтобы никто не мог его изменить
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null; // очистка кэша
        }
        public void SubmitContactCreating()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        public void InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
        }
        public void UpdateGroup()
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form/input[3]")).Click();
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }

        public void SelectingGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        public bool SelectingChoise()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
    }
}
