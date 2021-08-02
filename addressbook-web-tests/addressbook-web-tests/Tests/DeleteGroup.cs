using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroup : TestBase
    {
        [Test]
        public void TheDeleteGroupTest()
        {
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupPage();
            app.Others.SelectingGroup(1);
            app.Others.RemoveGroup();
            app.Navigator.ReturnGroupPage();
            app.Auth.Logout();
        }
    }
}
