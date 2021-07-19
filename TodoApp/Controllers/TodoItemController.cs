using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Contracts;
using TodoApp.Models.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{

    [Route("api")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoRepository _todos;

        public TodoItemController(ITodoRepository todos)
        {
            _todos = todos;
        }

        [HttpGet("TodoItem/{id}")]
        public async Task<ActionResult<TodoItemVM>> GetTodoItem(int id)
        {
            var data = await _todos.GetTodoItem(id);

            if(data == null)
            {
                return NotFound();
            }

            var model = new TodoItemVM
              {
                 Id = data.Id,
                 IsCompleted = data.IsCompleted,
                 TodoName = data.TodoName
             };

            return model;
        }
        
        [HttpGet("TodoGroup/{id}/TodoItems")]
        public async Task<IEnumerable<TodoItemVM>> GetTodoItems(int id)
        {
            var data = await _todos.GetTodoItems(id);

            var model = data.Select(x => new TodoItemVM
            {
                Id = x.Id,
                IsCompleted = x.IsCompleted,
                TodoName = x.TodoName
            }).ToList(); 

            return model;
        }


        [HttpPost("TodoGroup/{id}/TodoItems")]
        public async Task<ActionResult<TodoItemVM>> PostItem([FromRoute] int id, [FromBody] TodoItemVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = new TodoItem
            {
                 Id = model.Id,
                 TodoName = model.TodoName,
                 IsCompleted = model.IsCompleted,
                 TodoGroupId = id
    };
            var data = await _todos.PostItem(id, entity);
            model.Id = data.Id;

            return Ok(model);
        }

        [HttpDelete("TodoItem/{id}")]
        public async Task<ActionResult<TodoItemVM>> DeleteItem( int id)
        {
            var data = await _todos.DeleteItem(id);
            return Ok(data);
        }

        [HttpPut("TodoItem/{id}")]
        public async Task<IActionResult> PutItem(int id)
        {
            var data = await _todos.PutItem(id);
            
            if(data == null){
               return NotFound();
            }

            return Ok(data);
        }
    }
}
