using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : TestBase
    {
        [Test]
        public void TheCreateGroupTest()
        {
            GroupData group = new GroupData("Evgenii", "My group", "Foote");
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupPage();
            List<GroupData> oldGroup = app.Filling.GetGroupList();
            app.Others.InitGroupCreation();
            app.Filling.FillGroupForm(group);
            app.Others.SubmitGroupCreation();
            List<GroupData> newGroup = app.Filling.GetGroupList(); 
            //app.Navigator.ReturnGroupPage();
            app.Auth.Logout();
            Assert.AreEqual(oldGroup, newGroup);
        }
    }
}
