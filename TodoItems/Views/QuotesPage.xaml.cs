using TodoItems.Services.ViewModels;

namespace TodoItems.Views;

public partial class QuotesPage : ContentPage
{
	public QuotesPage(QuotesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is QuotesViewModel viewModel)
        {
            viewModel.LoadQuotesCommand.Execute(null);
        }
    }
}