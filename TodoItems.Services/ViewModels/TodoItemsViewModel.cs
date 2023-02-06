
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

        [ObservableProperty]
        ObservableCollection<TodoItem> items;

        public TodoItemsViewModel(INavigationHelper navigationHelper)
        {
            Title = "Todo";
            _navigationHelper = navigationHelper;
            items = new ObservableCollection<TodoItem>();
        }

        [RelayCommand]
        async Task CreateTodoItem()
        {
            await _navigationHelper.GoToAsync("//todoItem");
        }

        [RelayCommand]
        async Task UpdateTodoItem(TodoItem todoItem)
        {
            await _navigationHelper.GoToAsync("//todoItem");
        }
    }
}
