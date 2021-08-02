using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.AppManager
{
    [TestFixture]
    public class ModificationGroup : TestBase
    {
        [Test]
        public void Modification()
        {
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            app.Navigator.OpenGroupPage();
            app.Others.SelectingGroup(1);
            app.Others.InitGroupModification();
            app.Filling.FillingModify(new GroupData("Niko Belik", "Niko's group", "Shmooter"));
            app.Others.UpdateGroup();
            app.Auth.Logout();
        }
    }
}
