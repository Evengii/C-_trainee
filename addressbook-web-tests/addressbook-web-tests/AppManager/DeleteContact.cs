using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteContact : TestBase
    {
        [Test]
        public void TheDeleteContactTest()
        {
            app.Others.OpenPage();
            app.Auth.Authorization(new AccountData("admin", "secret"));
            
        }
    }
}
