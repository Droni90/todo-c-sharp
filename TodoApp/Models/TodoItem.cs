using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{

    public class TodoItem
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoGroupId { get; set; }
    }
}
