using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.DTOs;

public class Habit
{
    private string id => CreateUniqueId();
    public string Name { get; set; }
    public string Tag { get; set; }
    public DateTime StartDate = DateTime.Now;

    private string CreateUniqueId()
    {
        return $"{Name}{Tag.Substring(0, 1)}";
    }

    internal string GetOneLine()
    {
        return $"{id},{Name},{Tag},{StartDate}";
    }
}
