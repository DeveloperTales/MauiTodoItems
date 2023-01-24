
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TodoItems.Services.Models;

namespace TodoItems.Services.ViewModels
{
    public partial class TodoItemsViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<TodoItem> items;

        public TodoItemsViewModel()
        {
            Title = "Todo";
        }
    }
}
