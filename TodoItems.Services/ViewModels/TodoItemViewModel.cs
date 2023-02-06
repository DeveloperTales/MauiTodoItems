
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoItems.Services.Models;

namespace TodoItems.Services.ViewModels
{
    public partial class TodoItemViewModel : BaseViewModel
    {
        private readonly TodoItem _todoItem;

        [ObservableProperty]
        string? todoTitle;

        [ObservableProperty]
        bool titleHasError;

        [ObservableProperty]
        string? todoDescription;

        [ObservableProperty]
        bool saveCanExecute;

        [ObservableProperty]
        bool isCompleted;

        public TodoItemViewModel() 
        {
            Title = "Todo Item";
            _todoItem = new();
        }

        public void SetTodoItem(TodoItem todoItem)
        {
            _todoItem.Id = todoItem.Id;
            _todoItem.Title = todoItem.Title;
            _todoItem.Description = todoItem.Description;
            _todoItem.Created = todoItem.Created;
            _todoItem.Completed = todoItem.Completed;
            _todoItem.IsCompleted = todoItem.IsCompleted;

            TodoTitle = _todoItem.Title;
            TodoDescription = _todoItem.Description;
            IsCompleted = _todoItem.IsCompleted;
        }

        partial void OnTodoTitleChanged(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                TitleHasError = true;
                SaveCanExecute = false;
            }
            else
            {
                TitleHasError = false;
                SaveCanExecute = true;
            }
        }

        [RelayCommand(CanExecute = nameof(SaveCanExecute))]
        async Task SaveTodoItem()
        {
            if (string.IsNullOrWhiteSpace(todoTitle))
            {
                return;
            }

            _todoItem.Title = TodoTitle;
            _todoItem.Description = TodoDescription;
            _todoItem.IsCompleted = IsCompleted;
            if (_todoItem.Completed == null && _todoItem.IsCompleted) 
            {
                _todoItem.Completed = DateTime.Now;
            }
        }
    }
}
