using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TodoListApplication.Models
{
    public class TodoList : ITodoList
    {
        private List<TodoItem> _list = new List<TodoItem>();
        private readonly ILogger<TodoList> _logger;
        public List<TodoItem> Items => _list;

        public TodoList(ILogger<TodoList> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// search the items in the list to find the one that matches the given id
        /// </summary>
        /// <param name="id">The id that should be found</param>
        /// <param name="todoItem">The return item if it was found</param>
        /// <returns>Returns true if the item was found, otherwise return false</returns>
        private bool TryGetItem(int id, out TodoItem todoItem)
        {
            foreach(var item in _list)
            {
                if(item.Id == id)
                { todoItem = item;
                    return true;
                }
            }
            todoItem = null;
            return false;
        }

        public bool Add(TodoItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Description))
            {
                throw new ArgumentException($"The description for todo item cannot be empty or white space");
            }

            if (TryGetItem(item.Id, out var todoItem) == false)
            {
                _list.Add(item);
                return true;
            }

            _logger.LogError($"Duplicate: Todo item with the id: {item.Id} already exists");
            return false;
        }

        public bool Update(TodoItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Description))
            {
                throw new ArgumentException($"The description for todo item cannot be empty or white space");
            }

            if (TryGetItem(item.Id, out var todoItem) == true)
            {
                todoItem.Description = item.Description;
                todoItem.IsCompleted = item.IsCompleted;
                return true;
            }

            _logger.LogError($"Not found: Cannot find todo item with id: {item.Id}");
            return false;
        }

        public bool Remove(int id)
        {
            if (TryGetItem(id, out var todoItem) == true)
            {
                _list.Remove(todoItem);
            }
            else _logger.LogError($"Not found: Cannot find todo item with id: {id}");
            return true;
        }
    }
}
