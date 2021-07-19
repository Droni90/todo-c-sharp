using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data.Contracts;
using TodoApp.Data.Models;
using TodoApp.Data.Repositories;

namespace TodoApp.Data
{
    public class ContainerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, string connection)
        {
            services.AddDbContext<TodoGroupContext>(opt => opt.UseSqlServer(connection));
            services.AddScoped<ITodoGroupRepository, TodoGroupRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
