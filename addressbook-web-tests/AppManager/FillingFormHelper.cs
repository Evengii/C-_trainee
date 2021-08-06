using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace addressbook_web_tests
{
    public class FillingFormHelper : HelperBase
    {
        public FillingFormHelper(IWebDriver driver) : base(driver) // используем базовый конструктор класса HelperBase
        {
        }

        public void FillingModify(GroupData newData)
        {
            Type(By.Name("group_name"), newData.Name);
            Type(By.Name("group_header"), newData.Header);
            Type(By.Name("group_footer"), newData.Footer);
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
    }
}
