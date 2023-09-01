namespace TodoApp.Api.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}
        public Guid UserId { get; set; }
    }
}
