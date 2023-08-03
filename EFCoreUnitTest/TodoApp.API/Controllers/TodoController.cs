using Microsoft.AspNetCore.Mvc;
using TodoApp.API.Service;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/todo/")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _todoService.GetTodosAsync();

            _logger.LogInformation("Total Todo Found: {Count}", result.Count);

            if (result.Count > 0) return Ok(result);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _todoService.GetTodoAsync(id);

            _logger.LogInformation("Task found, Id: {Id}, Completed: {Completed}", result.Id, result.IsCompleted);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(int id, bool isCompleted)
        {
            var result = await _todoService.UpdateTodoAsync(id, isCompleted);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(string title, string description)
        {
            var result = await _todoService.AddAsync(title, description);
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}