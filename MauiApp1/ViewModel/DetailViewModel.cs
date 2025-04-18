using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel
{
    [QueryProperty("TaskName", "TaskName")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        string taskName;

        [RelayCommand]  
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
