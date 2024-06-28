using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitTracker.DTOs;
using HabitTracker.Logic;
using HabitTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HabitTracker.ViewModel;

[QueryProperty(nameof(Habit), "habit")]
public partial class MainViewModel : ObservableObject
{
    private readonly FileHelper _fileHelper = new FileHelper();
    [ObservableProperty]
    private Habit _habit;
    public MainModel Model { get; } = new MainModel();

    public MainViewModel()
    {
        Model.PropertyChanged += Model_PropertyChanged;
        InitHabitTracker();
    }

    private async Task InitHabitTracker()
    {
        Model.Habits = await _fileHelper.GetHabits();
    }

    protected async override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Habit))
        {
            if (Model.Habits.Any(x => x.Name == Habit.Name))
            {
                Model.Habits.Remove(Model.Habits.FirstOrDefault(x => x.Name == Habit.Name));
                Model.Habits.Add(Habit);
            }
            else
            {
                Model.Habits.Add(Habit);
            }
            await _fileHelper.SaveToDB(Model.Habits);
        }
    }

    private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MainModel.SelectedHabit))
        {
            RemoveHabitCommand.NotifyCanExecuteChanged();
            OpenDetailsCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand]
    private async Task AddHabit()
    {
        await Shell.Current.GoToAsync("//habit");
    }

    private bool CanRemoveHabit()
    {
        return Model.SelectedHabit != null;
    }

    [RelayCommand(CanExecute = "CanRemoveHabit")]
    private async Task RemoveHabit()
    {
        if (Model.Habits.Contains(Model.SelectedHabit))
        {
            Model.Habits.Remove(Model.SelectedHabit);
            await _fileHelper.SaveToDB(Model.Habits);
        }
    }

    private bool CanOpenDetails()
    {
        return Model.SelectedHabit != null;
    }

    [RelayCommand(CanExecute = "CanOpenDetails")]
    private async Task OpenDetails()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "habit", Model.SelectedHabit }
        };

        await Shell.Current.GoToAsync("//info", parameters);
    }
}
