using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class TodoGroup
    {
        //protected TodoGroup()
        //{ }

        //public TodoGroup(string groupName)
        //{
        //    TodoItems = new List<TodoItem>();
        //    GroupName = groupName;
        //}

        public TodoGroup()
        {
            TodoItems = new List<TodoItem>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
        public bool IsDeleted { get; set; }
    }
}
