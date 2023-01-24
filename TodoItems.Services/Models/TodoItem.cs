namespace TodoItems.Services.Models
{
    public class TodoItem
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Completed { get; set; }
        public bool IsCompleted { get; set; }
    }
}
