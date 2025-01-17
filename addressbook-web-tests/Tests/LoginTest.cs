﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void LoginWithValidCreds()
        {
            app.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.Others.OpenPage();
            app.Auth.Authorization(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account)); // подтверждение проверки
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout(); // предварительно выходим из аккаунта
            AccountData account = new AccountData("admin", "1343");
            app.Others.OpenPage();
            app.Auth.Authorization(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account)); // подтверждение проверки
        }
    }
}
