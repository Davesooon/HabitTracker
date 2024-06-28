using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitTracker.DTOs;
using HabitTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.ViewModel;

[QueryProperty(nameof(Habit), "habit")]
public partial class HabitInfoViewModel : ObservableObject
{
    [ObservableProperty]
    private Habit _habit;

    public HabitInfoModel Model { get; } = new HabitInfoModel(); 

    public HabitInfoViewModel()
    {
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Habit))
            SetValues();
    }

    private void SetValues()
    {
        Model.Name = Habit.Name;
        Model.SelectedTag = Habit.Tag;
        Model.SelectedDate = Habit.StartDate;
    }

    [RelayCommand]
    private async void Save()
    {
        Habit updatedHabit = new Habit()
        {
            Name = Model.Name,
            Tag = Model.SelectedTag,
            StartDate = Model.SelectedDate
        };

        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "habit", updatedHabit }
        };

        await Shell.Current.GoToAsync("//main", parameters);
    }
}
