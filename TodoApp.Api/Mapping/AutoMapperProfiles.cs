using AutoMapper;
using TodoApp.Api.Models.Domain;
using TodoApp.Api.Models.DTO;

namespace TodoApp.Api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddTodoDTO, Todo>().ReverseMap();
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}
