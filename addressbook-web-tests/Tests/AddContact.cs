using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddContact : AuthTestBase
    { 
        [Test]
        public void TheAddContactTest()
        {
            ContactData contact = new ContactData("Evgenii", "Lalalalov");
            app.Navigator.OpenAddNewContactPage();
            app.Filling.FillInfoForms(contact);
            app.Others.SubmitCreating();
            app.Navigator.ReturnToHomepage();
        }
    }
}
