using NUnit.Framework;
using TodoListApplication.Models;

namespace Tests
{
    public class TodoItemFixture
    {
        [TestCase(3, "milk", false)]
        [TestCase(4, "cheese", true)]
        public void Test_Constructor(int id, string desc, bool isCompleted)
        {
            var item = new TodoItem(id, desc, isCompleted);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(desc, item.Description);
            Assert.AreEqual(isCompleted, item.IsCompleted);
        }
    }
}
