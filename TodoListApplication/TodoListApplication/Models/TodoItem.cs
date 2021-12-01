namespace TodoListApplication.Models
{
    /// <summary>
    /// Simple todo item class that contains
    /// Id: the unique identifier 
    /// Description: this is the text that will show up on UI
    /// IsCompleted: A boolean that indicates if the todo item is already completed 
    /// </summary>
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(int id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
