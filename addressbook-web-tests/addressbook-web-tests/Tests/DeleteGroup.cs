using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroup : AuthTestBase
    {
        [Test]
        public void TheDeleteGroupTest()
        {
            app.Navigator.OpenGroupPage();
            if (app.Others.SelectingChoise())
            {
                app.Others.SelectingGroup(1);
                app.Others.RemoveGroup();
                app.Navigator.ReturnGroupPage();
            } else
            {
                app.Others.InitGroupCreation();
                app.Filling.FillGroupForm(new GroupData("Evgenii", "My group", "Foote"));
                app.Others.SubmitGroupCreation();
                app.Navigator.ReturnGroupPage();
                app.Others.SelectingGroup(1);
                app.Others.RemoveGroup();
                app.Navigator.ReturnGroupPage();
            } 
        }
    }
}
