using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoItems.Services.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;
        [ObservableProperty]
        bool isNotBusy;
    }
}
