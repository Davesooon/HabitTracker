using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace HabitTracker.Model;

public partial class HabitModel : ObservableObject
{
    [ObservableProperty]
    private string _habitName = string.Empty;
    [ObservableProperty]
    private ObservableCollection<string> _habitTags = new ObservableCollection<string>()
    {
        "Rozrywka",
        "Nauka",
        "Sport"
    };
    [ObservableProperty]
    private string _selectedTag = string.Empty;
    [ObservableProperty]
    private DateTime _startDate = DateTime.Now;
    [ObservableProperty]
    private TimeSpan _reminderTime = TimeSpan.Zero;
}
