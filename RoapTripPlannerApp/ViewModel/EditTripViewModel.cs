using CommunityToolkit.Mvvm.ComponentModel;
using RoapTripPlannerApp.Model;
using System.Collections.ObjectModel;

namespace RoapTripPlannerApp.ViewModel;

public partial class EditTripViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<UserModel> users;
    public EditTripViewModel()
    {
        Users =
        [
            new UserModel { Username = "John Doe", Email = "1"},
            new UserModel { Username = "John Doe", Email = "2"},
            new UserModel { Username = "John Doe", Email = "3"},
            new UserModel { Username = "John Doe", Email = "4"},
            new UserModel { Username = "John Doe", Email = "5"},
            new UserModel { Username = "John Doe", Email = "6"},
            new UserModel { Username = "John Doe", Email = "7"},
            new UserModel { Username = "John Doe", Email = "8"},
            new UserModel { Username = "John Doe", Email = "9"},
            new UserModel { Username = "John Doe", Email = "10"},
            new UserModel { Username = "John Doe", Email = "11"},
            new UserModel { Username = "John Doe", Email = "12"},
            new UserModel { Username = "John Doe", Email = "13"},
            new UserModel { Username = "John Doe", Email = "14"},
            new UserModel { Username = "John Doe", Email = "15"},
            new UserModel { Username = "John Doe", Email = "16"},
            new UserModel { Username = "John Doe", Email = "17"},
            new UserModel { Username = "John Doe", Email = "18"},
            new UserModel { Username = "John Doe", Email = "19"},
            new UserModel { Username = "John Doe", Email = "20"},
            new UserModel { Username = "John Doe", Email = "21"},
            new UserModel { Username = "John Doe", Email = "22"},
            new UserModel { Username = "John Doe", Email = "23"},
            new UserModel { Username = "John Doe", Email = "24"},
            new UserModel { Username = "John Doe", Email = "25"},
            new UserModel { Username = "John Doe", Email = "26"},
            new UserModel { Username = "John Doe", Email = "27"},
            new UserModel { Username = "John Doe", Email = "28"},
            new UserModel { Username = "John Doe", Email = "29"},
            new UserModel { Username = "John Doe", Email = "30"},
        ];
    }
}
