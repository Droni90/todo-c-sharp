using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoGroupContext _context;
        public TodoRepository(TodoGroupContext context)
        {
            _context = context;
        }
        public async Task<TodoItem> DeleteItem(int id)
        {
           var data = await _context.TodoItem.FindAsync(id);
            _context.TodoItem.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            return await _context.TodoItem
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems(int id)
        {
            return await _context.TodoItem.Where(x => x.TodoGroupId == id).ToListAsync();
        }

        public async Task<TodoItem> PostItem([FromRoute] int id, [FromBody] TodoItem model)
        {
            var data = new TodoItem
            {
                TodoName = model.TodoName,
                IsCompleted = model.IsCompleted,
                TodoGroupId = id
            };

            _context.TodoItem.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<TodoItem> PutItem(int id)
        {
            var data = _context.TodoItem.Where(x => x.Id == id).FirstOrDefault();
            data.IsCompleted = !data.IsCompleted;
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
