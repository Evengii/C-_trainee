using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout(); // предварительно выходим из аккаунта
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Authorization(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account)); // подтверждение проверки
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout(); // предварительно выходим из аккаунта
            AccountData account = new AccountData("admin", "1343");
            app.Auth.Authorization(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account)); // подтверждение проверки
        }
    }
}
