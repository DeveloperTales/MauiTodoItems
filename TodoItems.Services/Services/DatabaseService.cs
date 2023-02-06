using TodoItems.Services.Models;

namespace TodoItems.Services.Services;

public class DatabaseService : IDatabaseService
{
    public Quote AddUpdateQuote(Quote todoItem)
    {
        throw new NotImplementedException();
    }

    public TodoItem AddUpdateTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public bool DeleteQuote(string id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTodoItem(string id)
    {
        throw new NotImplementedException();
    }

    public Quote GetQuote(string id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Quote> GetQuotes()
    {
        throw new NotImplementedException();
    }

    public TodoItem GetTodoItem(string id)
    {
        throw new NotImplementedException();
    }

    public ICollection<TodoItem> GetTodoItems()
    {
        throw new NotImplementedException();
    }
}
