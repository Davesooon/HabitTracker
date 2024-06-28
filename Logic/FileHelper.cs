using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using HabitTracker.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Logic;

public class FileHelper
{
    private string _path = Path.Combine(FileSystem.Current.AppDataDirectory, "HabitTrackerData.txt");

    internal async Task SaveToDB(ObservableCollection<Habit> habits)
    {
        try
        {
            using StreamWriter streamWriter = new StreamWriter(_path);
            foreach (Habit habit in habits)
            {
                await streamWriter.WriteLineAsync(habit.GetOneLine());
            }
        }
        catch (Exception ex)
        {

        }
    }

    internal async Task<ObservableCollection<Habit>> GetHabits()
    {
        try
        {
            using Stream fileStream = File.OpenRead(_path);
            using StreamReader reader = new StreamReader(fileStream);
            ObservableCollection<Habit> habits = new ObservableCollection<Habit>();

            string read = await reader.ReadToEndAsync();
            string[] data = read.Split('\n');

            for (int i = 0; i < data.Length - 1; i++)
            {
                string[] record = data[i].Split(',');

                Habit habit = new Habit
                {
                    Name = record[1],
                    Tag = record[2],
                    StartDate = DateTime.Parse(record[3])
                };
                habits.Add(habit);
            }

            return habits;
        }
        catch (Exception ex)
        {
            return new ObservableCollection<Habit>();
        }
    }
}
