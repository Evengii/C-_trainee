using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : AuthTestBase
    {
        [Test]
        public void TheCreateGroupTest()
        {
            GroupData group = new GroupData("Evgenii", "My group", "Foote");
            app.Navigator.OpenGroupPage();
            // проверка числа групп до и после создания новой группы с помощью числа групп в списке
            List<GroupData> oldGroups = app.Checks.GetGroupList(); // в массив заводится список старых групп (см. CheckHepler.GetGroupLIst)
            app.Others.InitGroupCreation();
            app.Filling.FillGroupForm(group); // создается новая группа 
            app.Others.SubmitGroupCreation();
            app.Navigator.ReturnGroupPage();
            List<GroupData> newGroups = app.Checks.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, app.Others.GetGroupCount()); // хэширование количества групп для быстрой проверки

            oldGroups.Add(group);
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); // вызывает метод Equals класса GroupData и проверяет одинаковость элементов массивов
        }
    }
}
