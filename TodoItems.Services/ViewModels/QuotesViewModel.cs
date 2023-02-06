using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoItems.Services.Models;
using TodoItems.Services.Services;

namespace TodoItems.Services.ViewModels
{
    public partial class QuotesViewModel : BaseViewModel
    {
        private readonly INavigationHelper _navigationHelper;

        [ObservableProperty]
        ObservableCollection<Quote> quotes;

        public QuotesViewModel(INavigationHelper navigationHelper)
        {
            Title = "Quotes";
            _navigationHelper = navigationHelper;
            quotes = new ObservableCollection<Quote>();
        }

        [RelayCommand]
        async Task CreateNewQuote()
        {
            await _navigationHelper.GoToAsync("//quote");
        }
    }
}
