using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class QuotesPage : ContentPage
{
	public QuotesPage(QuotesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.LoadQuotesCommand.Execute(null);
    }
}