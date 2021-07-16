using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems(int id);
        Task<TodoItem> GetTodoItem(int id);
        Task<TodoItem> PostItem([FromRoute] int id, [FromBody] TodoItem model);
        Task<TodoItem> DeleteItem(int id);
        Task<TodoItem> PutItem(int id);
    }
}
