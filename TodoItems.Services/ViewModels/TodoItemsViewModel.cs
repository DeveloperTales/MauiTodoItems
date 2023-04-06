
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoItems.Services.Models;
using TodoItems.Services.Services;

namespace TodoItems.Services.ViewModels
{
    public partial class TodoItemsViewModel : BaseViewModel
    {
        private readonly INavigationHelper _navigationHelper;
        private readonly IDatabaseService _databaseService;

        [ObservableProperty]
        ObservableCollection<TodoItem> items;

        [ObservableProperty]
        TodoItem? selectedItem;

        public TodoItemsViewModel(INavigationHelper navigationHelper, IDatabaseService databaseService)
        {
            Title = "Todo";
            _navigationHelper = navigationHelper;
            _databaseService = databaseService;
            items = new ObservableCollection<TodoItem>();
        }

        public void UpdateTodoItemCompleted(TodoItem todoItem, bool isCompleted)
        {
            todoItem.IsCompleted = isCompleted;
            todoItem.Updated = DateTime.Now;

            _databaseService.AddUpdateTodoItem(todoItem);
            LoadTodoItems();
        }

        [RelayCommand]
        async Task CreateTodoItem()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", new TodoItem() }
            };
            await _navigationHelper.GoToAsync("/todoItem", true, navigationParameter);
        }

        [RelayCommand]
        async Task UpdateTodoItem(TodoItem item)
        {
            if (item != null) 
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "TodoItem", item }
                };
                await _navigationHelper.GoToAsync("/todoItem", true, navigationParameter);
                SelectedItem = null;
            }
        }

        [RelayCommand]
        void LoadTodoItems()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                items.Clear();
                var randomQuotes = _databaseService.GetTodoItems().ToList();
                randomQuotes.ForEach(Items.Add);
                IsBusy = false;
            }
        }
    }
}
