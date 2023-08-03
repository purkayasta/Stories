using Moq;
using Moq.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.Service;

namespace TodoApp.UnitTest
{
    public class TodoServiceTest
    {
        private readonly Mock<TodoDbContext> _dbContextMock;
        private readonly ITodoService _sut;

        public TodoServiceTest()
        {
            _dbContextMock = new Mock<TodoDbContext>();
            _sut = new TodoService(_dbContextMock.Object);
        }

        [Fact]
        public void GetTodos_ShouldReturnEmpty_WhenDatabaseIsEmpty()
        {
            _dbContextMock.Setup(x => x.Todo)
                .ReturnsDbSet(Enumerable.Empty<Todo>());

            var expected = _sut.GetTodos();
            Assert.Empty(expected);
        }

        [Fact]
        public async void GetTodosAsync_ShouldReturnEmpty_WhenDatabaseIsEmpty()
        {
            _dbContextMock.Setup(x => x.Todo)
                .ReturnsDbSet(Enumerable.Empty<Todo>());

            var expected = await _sut.GetTodosAsync();
            Assert.Empty(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetTodoAsync_ShouldReturnTodo_WhenIdFound(int id)
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 1, CreatedAtDateTime = DateTime.Now, UpdatedAtDateTime = DateTime.Now, Title = "test1", Description = "description1", IsActive = true },
                new Todo { Id = 2, CreatedAtDateTime = DateTime.Now, UpdatedAtDateTime = DateTime.Now, Title = "test2", Description = "description1", IsActive = true },
                new Todo { Id = 3, CreatedAtDateTime = DateTime.Now, UpdatedAtDateTime = DateTime.Now, Title = "test3", Description = "description1", IsActive = true },
            };

            _dbContextMock.Setup(x => x.Todo)
                .ReturnsDbSet(todos);

            var expected = await _sut.GetTodoAsync(id);
            var actual = todos.FirstOrDefault(x => x.Id == id);
            Assert.Same(expected, actual);
        }

        [Theory]
        [InlineData("", "test description")]
        public void Add_ShouldThrowException_WhenTitleIsEmpty(string title, string description)
            => Assert.Throws<ArgumentException>(() => _sut.Add(title, description));

        [Theory]
        [InlineData("learn rust", "rust is awesome")]
        [InlineData("learn go", "learn golang")]
        public void Add_ShouldReturnANewTodoObject_WhenParameterIsValid(string title, string description)
        {
            _dbContextMock.Setup(x => x.Todo)
                .ReturnsDbSet(Enumerable.Empty<Todo>());

            var actual = new Todo { Title = title, Description = description };
            var expected = _sut.Add(title, description);
            Assert.Same(expected.Title, actual.Title);
        }

        [Theory]
        [InlineData("learn rust", "rust is awesome")]
        [InlineData("learn go", "learn golang")]
        public async Task AddAsync_ShouldReturnANewTodoObject_WhenParameterIsValid(string title, string description)
        {
            _dbContextMock.Setup(x => x.Todo)
                .ReturnsDbSet(Enumerable.Empty<Todo>());

            var actual = new Todo { Title = title, Description = description };
            var expected = await _sut.AddAsync(title, description);
            Assert.Same(expected.Title, actual.Title);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public void UpdateTodo_ShouldReturnUpdateObject_WhenDataIsValid(int id, bool isCompleted)
        {
            var todos = new List<Todo>()
            {
                new Todo{ Id = 1, IsCompleted = false},
                new Todo{ Id = 2, IsCompleted = false}
            };
            _dbContextMock.Setup(x => x.Todo).ReturnsDbSet(todos);

            var expected = _sut.UpdateTodo(id, isCompleted);
            Assert.Equal(expected.IsCompleted, isCompleted);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public async Task UpdateTodoAsync_ShouldReturnUpdateObject_WhenDataIsValid(int id, bool isCompleted)
        {
            var todos = new List<Todo>()
            {
                new Todo{ Id = 1, IsCompleted = false},
                new Todo{ Id = 2, IsCompleted = false}
            };
            _dbContextMock.Setup(x => x.Todo).ReturnsDbSet(todos);

            var expected = await _sut.UpdateTodoAsync(id, isCompleted);
            Assert.Equal(expected.IsCompleted, isCompleted);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(20, false)]
        public async Task UpdateTodoAsync_ShouldThrowException_WhenDataNotFound(int id, bool isCompleted)
        {
            var todos = new List<Todo>()
            {
                new Todo{ Id = 1, IsCompleted = false},
                new Todo{ Id = 2, IsCompleted = false}
            };
            _dbContextMock.Setup(x => x.Todo).ReturnsDbSet(todos);

            await Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _sut.UpdateTodoAsync(id, isCompleted));
        }
    }
}
