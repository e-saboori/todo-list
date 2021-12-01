using System.Collections.Generic;

namespace TodoListApplication.Models
{
    /// <summary>
    /// This is the interface to work with list manager
    /// </summary>
    public interface ITodoList
    {
        /// <summary>
        /// Provides the lists of added items 
        /// </summary>
        List<TodoItem> Items { get; }

        /// <summary>
        /// Removes a todo item with specific id
        /// </summary>
        /// <param name="id">todo item's id</param>
        /// <returns>returns true if the action was successful</returns>
        bool Remove(int id);

        /// <summary>
        /// Update a todo item that already exists
        /// </summary>
        /// <param name="item">Updated todo item</param>
        /// <returns>returns true if the action was successful</returns>
        bool Update(TodoItem item);

        /// <summary>
        /// Add a new item to the list
        /// </summary>
        /// <param name="item">The new item</param>
        /// <returns>returns true if the action was successful</returns>
        bool Add(TodoItem item);
    }
}