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

        /// <summary>
        /// To get all the todo items
        /// </summary>
        /// <returns>A list of todo items</returns>
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

        /// <summary>
        /// Add a new item to the list
        /// </summary>
        /// <param name="item">The new item to be added</param>
        /// <returns>Returns 200 if the action was successfull</returns>
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

        /// <summary>
        /// Update the existing item
        /// </summary>
        /// <param name="item">The item that should be updated</param>
        /// <returns>Returns 200 if the action was successfull</returns>
        [HttpPatch("items/{item.id}")]
        public ActionResult<bool> Patch(TodoItem item)
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

        /// <summary>
        /// Delete an existing item
        /// </summary>
        /// <param name="id">Id of the item that should be removed</param>
        /// <returns>Returns 200 if the action was successfull</returns>
        [HttpDelete("items/{id}")]
        public ActionResult<bool> Delete(int id)
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
