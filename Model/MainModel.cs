using CommunityToolkit.Mvvm.ComponentModel;
using HabitTracker.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Model;

public partial class MainModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Habit> _habits = new ObservableCollection<Habit>();
    [ObservableProperty]
    private Habit _selectedHabit;
}
