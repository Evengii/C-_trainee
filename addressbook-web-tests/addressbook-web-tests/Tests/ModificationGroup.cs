using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ModificationGroup : AuthTestBase
    {
        [Test]
        public void Modification()
        {
            app.Navigator.OpenGroupPage();
            app.Others.SelectingGroup(1);
            app.Others.InitGroupModification();
            app.Filling.FillingModify(new GroupData("Niko", "", ""));
            app.Others.UpdateGroup();
            app.Navigator.ReturnGroupPage();
            app.Auth.Logout();
        }
    }
}
