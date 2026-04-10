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
    private int slice1 = 0;
    private static string _directory = Directory.GetCurrentDirectory();
    private string stringOutput;
    
    //Function for finding values in a file based on filters
    public void searchLoop()
    {
        int safeguard = _timestamp.Count;
        
        foreach (var line in File.ReadLines($"{_directory}\\output.txt")) 
        {
            //Iterate over all the timestamps in the List<T>
            foreach (var timestamp in _timestamp)
            {
                if (line.Contains(timestamp))
                {
                    //Isolate a string that only includes the output values in the text file
                    slice1 = line.IndexOf('#') + 1;
                    stringOutput = line.Substring(slice1);
                    File.AppendAllText($"{_directory}\\generated.csv", $"{stringOutput},");   //Adjust to use stream reader?
            
                    Console.WriteLine(stringOutput);
                    _localIndex++;

                    //Every 4 loops (after the 4 output values have been extracted), suffix the traits of that value set and increment the index
                    if (_localIndex <= 3) continue;
                    File.AppendAllText($"{_directory}\\generated.csv", _suffix[_suffixIndex] + "\n");
                
                    _localIndex = 0;
                    if (_suffixIndex < safeguard)
                    {
                        _suffixIndex++;
                    }

                    Console.WriteLine("Value pairs created, new line started.");
                }
            }
        }
        
        //Clean up values to prevent crashing when doing multiple calculations per session
        _suffixIndex = 0;
        _localIndex = 0;
        _suffix.Clear();
        _suffix.TrimExcess();
        _timestamp.Clear();
        _timestamp.TrimExcess();
        
        Console.WriteLine($"All values reset!");
    }
    
    //Function for saving all the trade stats for the timestamps to test
    public void saveEntries(string date, string time, string type, string winloss, string direction, string notes)
    {
        string timestamp = $"{date} {time}";
        
        //Ensure there are no duplicate entries
        if (!_timestamp.Contains(timestamp))
        {
            _timestamp.Add(timestamp);
            _suffix.Add($"{type},{winloss},{direction},{notes},");
            
            Console.WriteLine($"{timestamp} added!");
            Console.WriteLine($"Added suffix: {type},{winloss},{direction},{notes},");
        }
        else
        {
            Console.WriteLine($"List already contains {timestamp}!");
        }
    }
}