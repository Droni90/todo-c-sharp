using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Models;
using TodoApp.Models.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoGroupController : ControllerBase
    {
        private readonly ITodoGroupRepository _groups;

        public TodoGroupController(ITodoGroupRepository groups)
        {
            _groups = groups;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoGroupVM>>> GetGroups()
        {
            var data = await _groups.GetGroups();
            var model = data.Select(MapToModel).ToList();
            return model;
        }

        // GET: api/TodoGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoGroupVM>> GetGroup(int id)
        {
            var data = await _groups.GetGroup(id);
            if (data == null)
            {
                return NotFound();
            }
            var model = MapToModel(data);
            return model;
        }


        [HttpPost]
        public async Task<ActionResult<TodoGroupVM>> PostGroup(TodoGroupVM model)
        {
            var entity = new TodoGroup();
            entity = MapToEntity(model, entity);

            var data = await _groups.PostGroup(entity);

            var modelVM = MapToModel(data);

            return modelVM;
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<TodoGroupVM>> DeleteGroup(int id)
        {
           var data = await _groups.DeleteGroup(id);
            if (data == null)
            {
                return NotFound();
            }
            var model = MapToModel(data);
            return model;
        }
        private TodoGroupVM MapToModel(TodoGroup entity)
        {
            var model = new TodoGroupVM
            {
                Id = entity.Id,
                GroupName = entity.GroupName,
                TotalCount = entity.TodoItems.Count(),
                CompletedCount = entity.TodoItems.Count(x => x.IsCompleted),
            };
            return model;
        }

        private TodoGroup MapToEntity(TodoGroupVM model, TodoGroup entity)
        {
            entity.GroupName = model.GroupName;
            return entity;
        }
    }

}

