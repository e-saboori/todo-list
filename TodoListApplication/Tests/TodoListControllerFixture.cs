using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Controllers;
using TodoListApplication.Models;

namespace Tests
{
    public class TodoListControllerFixture
    {
        private TodoListController controller;

        [SetUp]
        public void Setup()
        {
            ILogger<TodoListController> logger = NSubstitute.Substitute.For<ILogger<TodoListController>>();
            ITodoList todoList = NSubstitute.Substitute.For<ITodoList>();
            var mockItems = new List<TodoItem>()
            {
                new TodoItem(1,"apple", false),
                new TodoItem(2,"orange", false),
            };
            todoList.Items.Returns(mockItems);
            todoList.Add(Arg.Is<TodoItem>(x => x.Id == 3)).Returns(true);
            todoList.Update(Arg.Is<TodoItem>(x => x.Id == 1)).Returns(true);
            todoList.Remove(Arg.Any<int>()).Returns(true);

            controller = new TodoListController(todoList, logger);
        }

        [Test]
        public void Test_Get()
        {
            var items = (List<TodoItem>)((Microsoft.AspNetCore.Mvc.ObjectResult)controller.Get().Result).Value;
            Assert.IsTrue(items.Any(x=>x.Id == 1 && x.Description == "apple" && x.IsCompleted == false));
            Assert.IsTrue(items.Any(x => x.Id == 2 && x.Description == "orange" && x.IsCompleted == false));
        }

        [TestCase(3, "milk", false, true)]
        [TestCase(4, "cheese", true, false)]
        public void Test_Post(int id, string desc, bool isCompleted, bool result)
        {
            Assert.AreEqual(result, ((bool)((Microsoft.AspNetCore.Mvc.ObjectResult)controller.Post(new TodoItem(id, desc, isCompleted)).Result).Value));

        }

        [TestCase(1, "milk", false, true)]
        [TestCase(4, "cheese", true, false)]
        public void Test_Patch(int id, string desc, bool isCompleted, bool result)
        {
            Assert.AreEqual(result, ((bool)((Microsoft.AspNetCore.Mvc.ObjectResult)controller.Patch(new TodoItem(id, desc, isCompleted)).Result).Value));
        }

        [Test]
        public void Test_Delete()
        {
            Assert.IsTrue((bool)((Microsoft.AspNetCore.Mvc.ObjectResult)controller.Delete(1).Result).Value);

        }
    }
}
