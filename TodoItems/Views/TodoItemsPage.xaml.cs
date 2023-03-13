using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class TodoItemsPage : ContentPage
{
	public TodoItemsPage(TodoItemsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is TodoItemsViewModel viewModel)
        {
            viewModel.LoadTodoItemsCommand.Execute(null);
        }
    }
}