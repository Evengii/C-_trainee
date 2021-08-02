using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : TestBase
    {
        [Test]
        public void TheCreateGroupTest()
        {
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupPage();
            app.Others.InitGroupCreation();
            app.Filling.FillGroupForm(new GroupData("Evgenii","My group","Foote"));
            app.Others.SubmitGroupCreation();
            app.Navigator.ReturnGroupPage();
            app.Auth.Logout();
        }
    }
}
