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
            app.Navigator.OpenAddNewContactPage();
            app.Filling.FillInfoForms(new ContactData("Easd","asf"));
            app.Others.SubmitContactCreating();
            app.Navigator.ReturnToHomepage();
        }    
    }
}
