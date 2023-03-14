
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
        bool saveCanExecute;

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

        partial void OnTodoTitleChanged(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                SaveCanExecute = false;
            }
            else
            {
                SaveCanExecute = true;
            }
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
            try
            {
                await _navigationHelper.GoToAsync("..");
            }
            catch (Exception ex)
            {
                var er = ex.ToString();
            }
        }
    }
}
