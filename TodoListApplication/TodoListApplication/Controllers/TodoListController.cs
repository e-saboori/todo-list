using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TodoListApplication.Models;

namespace TodoListApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoList _todoList;
        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ITodoList todoList, ILogger<TodoListController> logger)
        {
            _todoList = todoList;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            try
            {
                return Ok(_todoList.Items);
            }

            // In memoty implementation of list manager does not return any exception
            // This exception handling can be used when other implementation of TodoListManager is being used
            catch (Exception ex)
            {
                _logger.LogError($"Unable to retrive todo list due to {Environment.NewLine}{ex.Message}", ex);
            }

            return StatusCode(500);
        }


        [HttpPost("items")]
        public ActionResult<bool> Post(TodoItem item)
        {
            try
            {
                return Ok(_todoList.Add(item));
            }

            // In memoty implementation of list manager does not return any exception
            // This exception handling can be used when other implementation of TodoListManager is being used
            catch (Exception ex)
            {
                _logger.LogError($"Unable to add new todo item to the list due to {Environment.NewLine}{ex.Message}", ex);
            }

            return StatusCode(500);
        }

        [HttpPatch("items/{item.id}")]
        public ActionResult<bool> Path(TodoItem item)
        {
            try
            {
                return Ok(_todoList.Update(item));
            }

            // In memoty implementation of list manager does not return any exception
            // This exception handling can be used when other implementation of TodoListManager is being used
            catch (Exception ex)
            {
                _logger.LogError($"Unable to update todo item with ID: {item.Id} in the list due to {Environment.NewLine}{ex.Message}", ex);
            }

            return StatusCode(500);
        }

        [HttpDelete("items/{id}")]
        public ActionResult<IEnumerable<TodoItem>> Delete(int id)
        {
            try
            {
                return Ok(_todoList.Remove(id));
            }

            // In memoty implementation of list manager does not return any exception
            // This exception handling can be used when other implementation of TodoListManager is being used
            catch (Exception ex)
            {
                _logger.LogError($"Unable to delete todo item with ID: {id} from the list due to {Environment.NewLine}{ex.Message}", ex);
            }

            return StatusCode(500);
        }
    }
}
