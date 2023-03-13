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
        private readonly IDatabaseService _databaseService;

        [ObservableProperty]
        ObservableCollection<Quote> quotes;

        public QuotesViewModel(INavigationHelper navigationHelper, IDatabaseService databaseService)
        {
            Title = "Quotes";
            _navigationHelper = navigationHelper;
            _databaseService = databaseService;
            quotes = new ObservableCollection<Quote>();
        }

        [RelayCommand]
        async Task CreateNewQuote()
        {
            await _navigationHelper.GoToAsync("//quote");
        }

        [RelayCommand]
        void LoadQuotes()
        {
            quotes.Clear();
            var randomQuotes = _databaseService.GetRandomQuotes().ToList();
            randomQuotes.ForEach(Quotes.Add);
        }        
    }
}
