﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.ViewModels;

namespace TodoApp.Models
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

        
    }
}
