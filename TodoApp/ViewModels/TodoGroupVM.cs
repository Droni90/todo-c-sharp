using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class TodoGroupVM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int TotalCount { get; internal set; }
        public int CompletedCount { get; internal set; }
    }
}
