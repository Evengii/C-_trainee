﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : AuthTestBase
    {
        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void TheCreateGroupTest(GroupData group)
        {
            app.Navigator.OpenGroupPage();
            // проверка числа групп до и после создания новой группы с помощью числа групп в списке
            List<GroupData> oldGroups = app.Others.GetGroupList(); // в массив заводится список старых групп (см. OthersHepler.GetGroupLIst)
            app.Others.InitGroupCreation();
            app.Filling.FillGroupForm(group); // создается новая группа 
            app.Others.SubmitGroupCreation();
            app.Navigator.ReturnGroupPage();
            List<GroupData> newGroups = app.Others.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, app.Others.GetGroupCount()); // хэширование количества групп для быстрой проверки

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); // вызывает метод Equals класса GroupData и проверяет одинаковость элементов массивов
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"C:\Users\uklad\source\repos\Evengii\Csharp_trainee\addressbook-web-tests\addressbook-web-tests\groups.csv");
            foreach(string l in lines)
            {
                string [] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>)).
                Deserialize(new StreamReader(@"C:\Users\uklad\source\repos\Evengii\Csharp_trainee\addressbook-web-tests\addressbook-web-tests\groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"C:\Users\uklad\source\repos\Evengii\Csharp_trainee\addressbook-web-tests\addressbook-web-tests\groups.json"));
        }
    }
}
