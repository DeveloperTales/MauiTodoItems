using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TodoItems.Services.Models;

namespace TodoItems.Services.ViewModels
{
    public partial class QuotesViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Quote> quotes;

        public QuotesViewModel()
        {
            Title = "Quotes";
        }
    }
}
