using System.Collections.Generic;

namespace TodoApp.Models.Models
{
    public class TodoGroup
    {
        
        public TodoGroup()
        {
            TodoItems = new List<TodoItem>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Color { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
        public bool IsDeleted { get; set; }
    }
}
