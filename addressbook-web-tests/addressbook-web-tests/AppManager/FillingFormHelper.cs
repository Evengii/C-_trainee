using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class FillingFormHelper : HelperBase
    {
        public FillingFormHelper(IWebDriver driver) : base(driver) // используем базовый конструктор класса HelperBase
        {
        }
        public void FillInfoForms(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
        }
        public void FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
        public void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
