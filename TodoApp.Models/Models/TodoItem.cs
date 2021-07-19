namespace TodoApp.Models.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoGroupId { get; set; }
    }
}
