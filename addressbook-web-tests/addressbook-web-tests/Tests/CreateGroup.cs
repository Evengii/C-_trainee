using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : AuthTestBase
    {
        [Test]
        public void TheCreateGroupTest()
        {
            app.Navigator.OpenGroupPage();
            List<GroupData> oldGroups = app.Checks.GetGroupList(); // проверка числа групп до и после создания с помощью списков
            app.Others.InitGroupCreation();
            app.Filling.FillGroupForm(new GroupData("Evgenii","My group","Foote"));
            app.Others.SubmitGroupCreation();
            app.Navigator.ReturnGroupPage();
            List<GroupData> newGroups = app.Checks.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
