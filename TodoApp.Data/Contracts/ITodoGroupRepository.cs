using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models.Models;

namespace TodoApp.Data.Contracts 
{ 
    public interface ITodoGroupRepository
    {
        Task<IEnumerable<TodoGroup>> GetGroups();
        Task<TodoGroup> GetGroup(int id);
        Task<TodoGroup> PostGroup(TodoGroup todoGroup);
        Task<TodoGroup> DeleteGroup(int id);
        Task<TodoGroup> PutColor(int id, string color);
    }
}
