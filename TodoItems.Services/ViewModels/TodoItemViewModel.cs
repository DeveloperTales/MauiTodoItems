
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoItems.Services.Models;
using TodoItems.Services.Services;

namespace TodoItems.Services.ViewModels
{
    public partial class TodoItemViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly INavigationHelper _navigationHelper;
        private TodoItem? _todoItem;

        [ObservableProperty]
        string? todoTitle;

        [ObservableProperty]
        string? todoDescription;

        [ObservableProperty]
        bool isCompleted;

        public TodoItemViewModel(INavigationHelper navigationHelper, IDatabaseService databaseService) 
        {
            _navigationHelper = navigationHelper;
            _databaseService = databaseService;
            Title = "Todo Item";
        }

        public void SetTodoItem(TodoItem todoItem)
        {
            _todoItem = todoItem;

            TodoTitle = _todoItem.Title;
            TodoDescription = _todoItem.Description;
            IsCompleted = _todoItem.IsCompleted;
        }

        [RelayCommand]
        async Task SaveTodoItem()
        {
            if (_todoItem == null)
            {
                return;
            }

            _todoItem.Title = TodoTitle;
            _todoItem.Description = TodoDescription;
            _todoItem.IsCompleted = IsCompleted;
            _todoItem.Updated = DateTime.Now;

            _databaseService.AddUpdateTodoItem(_todoItem);
            await _navigationHelper.GoToAsync("..");
        }

        [RelayCommand]
        async Task DeleteTodoItem()
        {
            if (_todoItem == null || string.IsNullOrWhiteSpace(_todoItem.Id))
            {
                return;
            }

            _databaseService.DeleteTodoItem(_todoItem.Id);
            await _navigationHelper.GoToAsync("..");
        }
    }
}
