using TodoItems.Services.Models;
using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

[QueryProperty(nameof(TodoItem), "TodoItem")]
public partial class TodoItemPage : ContentPage
{
    TodoItem todoItem;
    public TodoItem TodoItem
    {
        get => todoItem;
        set
        {
            todoItem = value;
            if (BindingContext is TodoItemViewModel viewModel)
            {
                viewModel.SetTodoItem(todoItem);
            }
        }
    }

    public TodoItemPage(TodoItemViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}