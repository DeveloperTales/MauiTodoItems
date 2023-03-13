using LiteDB;
using System;
using TodoItems.Services.Models;

namespace TodoItems.Services.Services;

public class DatabaseService : IDatabaseService
{
    private readonly string _dbpath;
    private const string COLLECTION_TODOITEMS = "todoitems";
    private const string COLLECTION_QUOTES = "quotes";

    public DatabaseService(string appDirectory)
    {
       _dbpath = Path.Combine(appDirectory, "todoitems.db");
    }
    
    public TodoItem AddUpdateTodoItem(TodoItem todoItem)
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<TodoItem>(COLLECTION_TODOITEMS);

        if (string.IsNullOrWhiteSpace(todoItem.Id))
        {
            var newTodoItem = todoItem with
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
            };

            collection.Insert(todoItem);
            collection.EnsureIndex(x => x.Id);

            return newTodoItem;
        }

        collection.Update(todoItem);
        return todoItem;
    }

    public bool DeleteTodoItem(string id)
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<TodoItem>(COLLECTION_TODOITEMS);

        return collection.Delete(id);
    }

    public TodoItem GetTodoItem(string id)
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<TodoItem>(COLLECTION_TODOITEMS);

        return collection.FindById(id);
    }

    public ICollection<TodoItem> GetTodoItems()
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<TodoItem>(COLLECTION_TODOITEMS);

        return collection.Query().ToList();
    }

    public ICollection<Quote> GetRandomQuotes(int numberOfQuotes = 3)
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<Quote>(COLLECTION_QUOTES);
        var allQuotes = collection.Query().ToList();

        if (allQuotes == null || allQuotes.Count == 0) 
        {
            allQuotes = GetStarterQuotes();
            collection.InsertBulk(allQuotes);
        }

        if (numberOfQuotes > allQuotes.Count)
        {
            numberOfQuotes = allQuotes.Count;
        }

        var randomQuoes = new List<Quote>();
        var random = new Random();
        var prevNumbers = new HashSet<int>();
        while (randomQuoes.Count < numberOfQuotes) {
            var nextNumber = random.Next(allQuotes.Count);
            if (!prevNumbers.Contains(nextNumber))
            {
                prevNumbers.Add(nextNumber);
                randomQuoes.Add(allQuotes[nextNumber]);
            }
        }

        return randomQuoes;
    }

    public ICollection<Quote> GetQuotes()
    {
        using var db = new LiteDatabase(_dbpath);

        var collection = db.GetCollection<Quote>(COLLECTION_QUOTES);

        return collection.Query().ToList();
    }

    private List<Quote> GetStarterQuotes()
    {
        return new List<Quote>
        {
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "A healthy mind in a healthy body",
                Author = "Juvenal",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-100),
                Updated = DateTime.Now.AddDays(-100)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "No! Try not. Do. Or do not. There is no try.",
                Author = "Master Yoda",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-50),
                Updated = DateTime.Now.AddDays(-30)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Pass on what you have learned. Strength, mastery, hmm… but weakness, folly, failure, also. Yes, failure, most of all. The greatest teacher, failure is.",
                Author = "Master Yoda",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-40),
                Updated = DateTime.Now.AddDays(-25)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Many of the truths that we cling to depend on our point of view.",
                Author = "Master Yoda",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-20),
                Updated = DateTime.Now.AddDays(-15)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Named must your fear be, before banish it you can.",
                Author = "Master Yoda",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-20),
                Updated = DateTime.Now.AddDays(-15)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "The greatest glory in living lies not in never falling, but in rising every time we fall.",
                Author = "Nelson Mandela",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-10),
                Updated = DateTime.Now.AddDays(-10)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "The way to get started is to quit talking and begin doing.",
                Author = "Walt Disney",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-9),
                Updated = DateTime.Now.AddDays(-8)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "If you set your goals ridiculously high and it's a failure, you will fail above everyone else's success.",
                Author = "James Cameron",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-20),
                Updated = DateTime.Now.AddDays(-17)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Tell me and I forget. Teach me and I remember. Involve me and I learn.",
                Author = "Benjamin Franklin",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-6),
                Updated = DateTime.Now.AddDays(-6)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Life is really simple, but we insist on making it complicated.",
                Author = "Confucius",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-1),
                Updated = DateTime.Now.AddDays(-1)
            },
            new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Love the life you live. Live the life you love..",
                Author = "Bob Marley",
                ImageURL = null,
                Created = DateTime.Now.AddDays(-2),
                Updated = DateTime.Now.AddDays(-2)
            },
        };
    }
}
