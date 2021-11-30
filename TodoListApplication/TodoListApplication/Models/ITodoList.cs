using System.Collections.Generic;

namespace TodoListApplication.Models
{
    public interface ITodoList
    {
        List<TodoItem> Items { get; }

        bool Remove(int id);
        bool Update(TodoItem item);
        bool Add(TodoItem item);
    }
}