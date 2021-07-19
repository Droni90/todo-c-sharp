using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Contracts;
using TodoApp.Data.Models;
using TodoApp.Models.Models;

namespace TodoApp.Data.Repositories
{
    public class TodoGroupRepository : ITodoGroupRepository
    {
        private readonly TodoGroupContext _context;
        public TodoGroupRepository(TodoGroupContext context)
        {
            _context = context;
        }

        public async Task<TodoGroup> GetGroup(int id)
        {
            var data = await _context.TodoGroup.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<IEnumerable<TodoGroup>> GetGroups()
        {
            var data = await _context.TodoGroup.Where(x => !x.IsDeleted).ToListAsync();
            return data;
        }

        public async Task<TodoGroup> PostGroup(TodoGroup model)
        {
            var data = new TodoGroup();
            data.GroupName = model.GroupName;
            _context.TodoGroup.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<TodoGroup> DeleteGroup(int id)
         {
             var data = await _context.TodoGroup.FindAsync(id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<TodoGroup> PutColor(int id, string color)
        {
            var data = _context.TodoGroup.Where(x => x.Id == id).FirstOrDefault();
            data.Color = color;
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }

    }
}
