using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Model;

public partial class HabitInfoModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;
    [ObservableProperty]
    private ObservableCollection<string> _tags = new ObservableCollection<string>()
    {
        "Rozrywka",
        "Sport",
        "Nauka"
    };
    [ObservableProperty]
    private string _selectedTag = string.Empty;
    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Now;
}
