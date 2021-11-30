using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Linq;
using TodoListApplication.Models;

namespace Tests
{
    public class TodoListFixture
    {
        private TodoList list;

        [SetUp]
        public void Setup()
        {
            ILogger<TodoList> logger = NSubstitute.Substitute.For<ILogger<TodoList>>();
            list = new TodoList(logger);
            list.Add(new TodoItem(1, "apple", false));
            list.Add(new TodoItem(2, "orange", false));
        }

        [TestCase(3, "milk", false)]
        [TestCase(4, "cheese", true)]
        public void Test_Add(int id, string desc, bool isCompleted)
        {
            Assert.IsTrue(list.Add(new TodoItem(id, desc, isCompleted)));
            Assert.IsTrue(list.Items.Any(x => x.Id == id && x.Description.Equals(desc) && x.IsCompleted == isCompleted));
        }

        [Test]
        public void Test_Add_Duplicate()
        {
            Assert.IsFalse(list.Add(new TodoItem(1, "another apple", false)));
            Assert.IsTrue(list.Items.Any(x => x.Id == 1 && x.Description.Equals("apple") && x.IsCompleted == false));
            Assert.IsFalse(list.Items.Any(x => x.Id == 1 && x.Description.Equals("another apple") && x.IsCompleted == false));
        }

        [TestCase(1, "canadian apple", false)]
        [TestCase(2, "orange", true)]
        public void Test_Update(int id, string desc, bool isCompleted)
        {
            var updatedItem = new TodoItem(id, desc, isCompleted);
            Assert.IsTrue(list.Update(updatedItem));
            Assert.IsTrue(list.Items.Any(x => x.Id == id && x.Description.Equals(desc) && x.IsCompleted == isCompleted));
        }

        [TestCase(10, "chocolate", false)]
        public void Test_Update_ItemDoesNotExists(int id, string desc, bool isCompleted)
        {
            var updatedItem = new TodoItem(id, desc, isCompleted);
            Assert.IsFalse(list.Update(updatedItem));
            Assert.IsFalse(list.Items.Any(x => x.Id == id));
        }

        [TestCase(1)]
        [TestCase(20)]
        public void Test_Delete(int id)
        {
            Assert.IsTrue(list.Remove(id));
            Assert.IsFalse(list.Items.Any(x => x.Id == id));
        }
    }
}