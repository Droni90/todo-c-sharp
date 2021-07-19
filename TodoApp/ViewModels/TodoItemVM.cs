using System.ComponentModel.DataAnnotations;

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
