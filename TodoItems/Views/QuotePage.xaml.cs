using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class QuotePage : ContentPage
{
	public QuotePage(QuoteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}