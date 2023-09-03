using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Api.Controllers;
using TodoApp.Api.Models.Domain;
using TodoApp.Api.Models.DTO;
using TodoApp.Api.Repository;
using Xunit;

namespace TodoApp.Test.Controller
{
    public class TodoControllerTest
    {
        private readonly ITodoRepository todoRepository;
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;
        public TodoControllerTest()
        {
            todoRepository = FakeItEasy.A.Fake<ITodoRepository>();
            tokenRepository = A.Fake<ITokenRepository>();
            mapper = FakeItEasy.A.Fake<IMapper>();
        }

        [Fact]
        public async void TodoController_GetMyTodo_ReturnOk()
        {
            // Arrange
            var todos = FakeItEasy.A.Fake<ICollection<Todo>>();
            var todoList = FakeItEasy.A.Fake<List<TodoDto>>();
            FakeItEasy.A.CallTo(() => mapper.Map<List<TodoDto>>(todos)).Returns(todoList);
            var controller = new TodoController(todoRepository, tokenRepository, mapper);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer ta";
            
            // Act
            var result = await controller.GetMyTodo();
            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void TodoController_GetTodoById_ReturnOk()
        {
            var todoId = "1";
            var id = Guid.NewGuid();
            var todo = A.Fake<Todo>();
            var todoDto = A.Fake<TodoDto>();
            A.CallTo(() => tokenRepository.GetUserId(todoId)).Returns(id);
            A.CallTo(() => mapper.Map<TodoDto>(todo)).Returns(todoDto);
            var controller = new TodoController(todoRepository, tokenRepository, mapper);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer ta";

            var result = await controller.GetTodoById(id);
            result.Should().NotBeNull();

        }

        [Fact]
        public async void TodoController_CreateTodo_ReturnOk()
        {
            // Arrange
            var addDto = A.Fake<AddTodoDTO>();
            var todoDto = A.Fake<TodoDto>();
            var todo = A.Fake<Todo>();
            A.CallTo(() => todoRepository.InsertTodo(todo)).Returns(todo);
            A.CallTo(() => mapper.Map<Todo>(addDto)).Returns(todo);
            A.CallTo(() => mapper.Map<TodoDto>(todo)).Returns(todoDto);
            var controller = new TodoController(todoRepository, tokenRepository, mapper);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer ta";


            // Act
            var result = await controller.InsertTodo(addDto);
            // Assert
            result.Should().NotBeNull();

        }

        [Fact]
        public async void TodoController_UpdateTodo_ReturnOk()
        {
            // Arrange
            var update = A.Fake<UpdateTodoDto>();
            var todoDto = A.Fake<TodoDto>();
            var todo = A.Fake<Todo>();
            var id = Guid.NewGuid();
            A.CallTo(() => todoRepository.UpdateTodo(id, id, todo)).Returns(todo);
            A.CallTo(() => mapper.Map<Todo>(update)).Returns(todo);
            A.CallTo(() => mapper.Map<TodoDto>(todo)).Returns(todoDto);
            var controller = new TodoController(todoRepository, tokenRepository, mapper);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer ta";


            // Act
            var result = await controller.UpdateTodo(id, update);
            // Assert
            result.Should().NotBeNull();

        }

        [Fact]
        public async void TodoController_DeleteTodo_ReturnOk()
        {
            var todoId = "1";
            var id = Guid.NewGuid();
            var todo = A.Fake<Todo>();
            var todoDto = A.Fake<TodoDto>();
            A.CallTo(() => tokenRepository.GetUserId(todoId)).Returns(id);
            A.CallTo(() => todoRepository.DeleteTodo(id, id)).Returns(todo);
            A.CallTo(() => mapper.Map<TodoDto>(todo)).Returns(todoDto);
            var controller = new TodoController(todoRepository, tokenRepository, mapper);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer ta";

            var result = await controller.DeleteTodo(id);
            result.Should().NotBeNull();

        }
    }
}
