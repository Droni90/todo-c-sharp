using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class TodoItemVM
    {
        public int Id { get; set; }

        [Required]
        public string TodoName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
