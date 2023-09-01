﻿using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.Models.Domain;

namespace TodoApp.Api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Todo>> GetMyTodo(Guid id)
        {
            return await dbContext.Todos.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<Todo> InsertTodo(Todo todo)
        {
            todo.CreatedDate = DateTime.Now;
            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();
            return todo;
        }
    }
}
