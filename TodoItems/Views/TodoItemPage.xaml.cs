using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class TodoItemPage : ContentPage
{
	public TodoItemPage(TodoItemViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}