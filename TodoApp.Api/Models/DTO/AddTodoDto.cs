using System.ComponentModel.DataAnnotations;

namespace TodoApp.Api.Models.DTO
{
    public class AddTodoDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
