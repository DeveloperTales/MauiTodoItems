using TodoItems.Services.Models;

namespace TodoItems.Services.Services;

public interface IDatabaseService
{
    public ICollection<TodoItem> GetTodoItems();
    public TodoItem GetTodoItem(string id);
    public TodoItem AddUpdateTodoItem(TodoItem todoItem);
    public bool DeleteTodoItem(string id);
    public ICollection<Quote> GetQuotes();
    public ICollection<Quote> GetRandomQuotes(int numberOfQuotes = 3);
}
