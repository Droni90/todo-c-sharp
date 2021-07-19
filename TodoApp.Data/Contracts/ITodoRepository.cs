using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models.Models;

namespace TodoApp.Data.Contracts
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
