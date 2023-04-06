using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoItems.Services.Models;
using TodoItems.Services.Services;

namespace TodoItems.Services.ViewModels
{
    public partial class QuotesViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;

        [ObservableProperty]
        ObservableCollection<Quote> quotes;

        public QuotesViewModel(INavigationHelper navigationHelper, IDatabaseService databaseService)
        {
            Title = "Quotes";
            _databaseService = databaseService;
            quotes = new ObservableCollection<Quote>();
        }

        [RelayCommand]
        void LoadQuotes()
        {
            IsBusy = true;
            quotes.Clear();
            var randomQuotes = _databaseService.GetRandomQuotes().ToList();
            randomQuotes.ForEach(Quotes.Add);
            IsBusy = false;
        }        
    }
}
