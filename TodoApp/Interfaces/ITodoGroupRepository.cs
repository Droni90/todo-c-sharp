using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public interface ITodoGroupRepository
    {
        Task<IEnumerable<TodoGroup>> GetGroups();
        Task<TodoGroup> GetGroup(int id);
        Task<TodoGroup> PostGroup(TodoGroup todoGroup);
        Task<TodoGroup> DeleteGroup(int id); 
    }
}
