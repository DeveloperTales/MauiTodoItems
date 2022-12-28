using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class TodoItemsPage : ContentPage
{
	public TodoItemsPage(TodoItemsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}