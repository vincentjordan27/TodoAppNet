using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models.Domain;
using TodoApp.Api.Models.DTO;
using TodoApp.Api.Repository;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository todoRepository;
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;

        public TodoController(ITodoRepository todoRepository, ITokenRepository tokenRepository, IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyTodo()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty); ;
            var userId = tokenRepository.GetUserId(token);
            var userGuid = new Guid(userId);
            var todo = await todoRepository.GetMyTodo(userGuid);
            return Ok(mapper.Map<List<TodoDto>>(todo));
        }

        [HttpPost]
        public async Task<IActionResult> InsertTodo([FromBody] AddTodoDTO addTodo)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty); ;
            var userId = tokenRepository.GetUserId(token);
            var userGuid = new Guid(userId);
            var todoDomain = mapper.Map<Todo>(addTodo);
            todoDomain.UserId = userGuid;
            todoDomain = await todoRepository.InsertTodo(todoDomain);
            var todoDto = mapper.Map<TodoDto>(todoDomain);
            return Ok(todoDto);
        }
        
    }
}
