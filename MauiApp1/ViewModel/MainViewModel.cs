using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }
        
        [ObservableProperty]
        ObservableCollection<string> items;
        
        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task Add()
        {
            if(string.IsNullOrWhiteSpace(Text)) { return; }
            Items.Add(text);
            Text = String.Empty;

            if(connectivity.NetworkAccess != NetworkAccess.Internet) {
                await Shell.Current.DisplayAlert("Error", "No Internet", "Ok");
                return;
            }
        }

        [RelayCommand]
        void Delete(string toDelete)
        {
            if (Items.Contains(toDelete)) { Items.Remove(toDelete); }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?TaskName={s}");
        }
    }
}
