﻿using TodoApp.Api.Models.Domain;

namespace TodoApp.Api.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetMyTodo(Guid id);
    }
}