using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Service.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        [Route("get")]
        public JsonResult Get()
        {
            var result = _toDoListService.Get();
            return Json(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(string description)
        {
            var result = await _toDoListService.Create(description);
            if (result != 0)
            {
                return CreatedAtAction(
                nameof(Create),
                new { id = result }, result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(int id)
        {
            await _toDoListService.Update(id);

            return Ok();
        }
    }
}
