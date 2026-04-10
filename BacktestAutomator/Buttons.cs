using System;
using System.Collections.Generic;
using System.IO;

namespace BacktestAutomator;

public class Buttons
{
    //Initialize vars
    private List<string> _timestamp = new();
    private List<string> _suffix = new();
    private int _suffixIndex = 0;
    private int _localIndex = 0;
    private int _safeguard = 0;
    private static string _directory = Directory.GetCurrentDirectory();
    private string _timestampMerge;

    
    //Function for finding values in a file based on filters
    public void searchLoop()
    {
        _safeguard = _timestamp.Count;
        
        foreach (var line in File.ReadLines($"{_directory}\\output.txt")) 
        {
            //Iterate over all the timestamps in the List<T>
            foreach (var localTimestampStore in _timestamp)
            {
                if (line.Contains(localTimestampStore))
                {
                    //Isolate a string that only includes the output values in the text file
                    int slice1 = line.IndexOf('#') + 1;
                    var str = line.Substring(slice1);
                    File.AppendAllText($"{_directory}\\generated.csv", $"{str},");   //Adjust to use stream reader?
            
                    Console.WriteLine(str);
                    _localIndex++;

                    //Every 4 loops (after the 4 output values have been extracted), suffix the traits of that value set and increment the index
                    if (_localIndex <= 3) continue;
                    File.AppendAllText($"{_directory}\\generated.csv", _suffix[_suffixIndex] + "\n");
                
                    _localIndex = 0;
                    if (_suffixIndex < _safeguard)
                    {
                        _suffixIndex++;
                    }

                    Console.WriteLine("Value pairs created, new line started.");
                }
            }
        }
    }
    
    //Function for saving all the trade stats for the timestamps to test
    public void saveEntries(string date, string time, string type, string winloss, string direction, string notes)
    {
        _timestampMerge = $"{date} {time}";
        
        _timestamp.Add(_timestampMerge);
        _suffix.Add($"{type},{winloss},{direction},{notes},");
            
        Console.WriteLine($"{_timestampMerge} added!");
        Console.WriteLine($"Added suffix: {type},{winloss},{direction},{notes},");
    }
}