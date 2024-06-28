using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitTracker.DTOs;
using HabitTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.ViewModel;

public partial class HabitViewModel : ObservableObject
{
    public HabitModel Model { get; } = new HabitModel();

    public HabitViewModel()
    {
        Model.PropertyChanged += Model_PropertyChanged;
    }

    private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Model.HabitName))
            ((RelayCommand)SaveHabitCommand).NotifyCanExecuteChanged();
    }

    [RelayCommand]
    private void SelectedTagsChanged()
    {
        ((RelayCommand)SaveHabitCommand).NotifyCanExecuteChanged();
    }

    private bool CanSaveHabit()
    {
        return !string.IsNullOrEmpty(Model.HabitName) && !string.IsNullOrEmpty(Model.SelectedTag);
    }

    [RelayCommand(CanExecute = "CanSaveHabit")]
    private async void SaveHabit()
    {
        Habit habit = new Habit()
        {
            Name = Model.HabitName,
            Tag = Model.SelectedTag,
            StartDate = Model.StartDate,
        };

        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "habit", habit }
        };

        await Shell.Current.GoToAsync("//main", parameters);

        ResetValues();
    }

    private void ResetValues()
    {
        Model.HabitName = string.Empty;
        Model.SelectedTag = string.Empty;
        Model.StartDate = DateTime.Now;
    }
}
