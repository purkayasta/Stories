using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;

namespace TodoApp.API.Service
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoService(TodoDbContext todoDbContext) => _todoDbContext = todoDbContext;

        public List<Todo> GetTodos() => _todoDbContext.Todo.Where(x => x.IsActive).AsNoTracking().ToList();

        public Task<List<Todo>> GetTodosAsync() => _todoDbContext.Todo.Where(x => x.IsActive).AsNoTracking().ToListAsync();

        public Task<Todo> GetTodoAsync(int id) => _todoDbContext.Todo.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

        public Todo Add(string title, string description)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentNullException.ThrowIfNullOrEmpty(description, nameof(description));
            Todo todo = new() { Title = title, Description = description, IsActive = true, IsCompleted = false };
            _todoDbContext.Todo.Add(todo);
            return todo;
        }

        public async Task<Todo> AddAsync(string title, string description)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentNullException.ThrowIfNullOrEmpty(description, nameof(description));
            Todo todo = new() { Title = title, Description = description, IsActive = true, IsCompleted = false };
            await _todoDbContext.Todo.AddAsync(todo);
            await _todoDbContext.SaveChangesAsync();
            return todo;
        }

        public Todo UpdateTodo(int id, bool isCompleted)
        {
            Todo todo = _todoDbContext.Todo.Where(x => x.Id == id).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(todo);
            todo.IsCompleted = isCompleted;
            _todoDbContext.SaveChanges();
            return todo;
        }

        public async Task<Todo> UpdateTodoAsync(int id, bool isCompleted)
        {
            Todo todo = await _todoDbContext.Todo.Where(x => x.Id == id).FirstOrDefaultAsync();
            ArgumentNullException.ThrowIfNull(todo);
            todo.IsCompleted = isCompleted;
            await _todoDbContext.SaveChangesAsync();
            return todo;
        }
    }

    public interface ITodoService
    {
        Todo Add(string title, string description);
        Task<Todo> AddAsync(string title, string description);
        Task<Todo> GetTodoAsync(int id);
        List<Todo> GetTodos();
        Task<List<Todo>> GetTodosAsync();
        Todo UpdateTodo(int id, bool isCompleted);
        Task<Todo> UpdateTodoAsync(int id, bool isCompleted);
    }
}
