using TodoItems.Services.Models;

namespace TodoItems.Services.Services;

public interface IDatabaseService
{
    public ICollection<TodoItem> GetTodoItems();
    public TodoItem GetTodoItem(string id);
    public TodoItem AddUpdateTodoItem(TodoItem todoItem);
    public bool DeleteTodoItem(string id);
    public ICollection<Quote> GetQuotes();
    public Quote GetQuote(string id);
    public Quote AddUpdateQuote(Quote todoItem);
    public bool DeleteQuote(string id);
}
