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
            if (app.Others.SelectingChoise())
            {
                app.Others.SelectingGroup(1);
                app.Others.InitGroupModification();
                app.Filling.FillingModify(new GroupData("Niko", "", ""));
                app.Others.UpdateGroup();
                app.Navigator.ReturnGroupPage();
            }
            else
            {
                app.Others.InitGroupCreation();
                app.Filling.FillGroupForm(new GroupData("Evgenii", "My group", "Foote"));
                app.Others.SubmitGroupCreation();
                app.Navigator.ReturnGroupPage();
                app.Others.SelectingGroup(1);
                app.Others.InitGroupModification();
                app.Filling.FillingModify(new GroupData("Niko", "", ""));
                app.Others.UpdateGroup();
                app.Navigator.ReturnGroupPage();
            }
        }
    }
}
