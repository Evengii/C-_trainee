using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddContact : TestBase
    { 
        [Test]
        public void TheAddContactTest()
        {
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            app.Navigator.OpenAddNewContactPage();
            app.Filling.FillInfoForms(new ContactData("Evgenii", "Lalalalov"));
            app.Others.SubmitCreating();
            app.Navigator.ReturnToHomepage();
            app.Auth.Logout();
        }
    }
}
