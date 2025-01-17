﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string middlename;
        private string nickname;
        private string photo;
        private string title;
        private string company;
        private string address;
        private string telephone;
        private string home;
        private string mobile;
        private string work;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string birthday;
        private string anniversary;
        private string group;

        private string second_address;
        private string second_home;
        private string second_notes;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
