﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupAuthorization()
        {
            app.Auth.Authorization(new AccountData("admin", "secret"));
        }
    }
}
