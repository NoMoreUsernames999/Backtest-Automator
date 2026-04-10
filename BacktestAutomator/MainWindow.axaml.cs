using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace BacktestAutomator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    //Instantiate button logic
    Buttons _click = new();
    private static string _directory = Directory.GetCurrentDirectory();
    
    //Execute search loop
    private void testCalc(object? sender, RoutedEventArgs e)
    {
        try
        {
            //Make sure file to be read actually exists to prevent crashing. Catch all other exceptions
            if (File.Exists($"{_directory}\\output.txt"))
            {
                _click.searchLoop();
                DebugText.Foreground = Brushes.Green;
                DebugText.Text = $"Output generated to {_directory}.";
            }
            else
            {
                DebugText.Foreground = Brushes.Red;
                DebugText.Text = "File output.txt is missing from operating directory. Add file and try again.";
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            File.AppendAllText($"{_directory}\\BacktestDebug.txt", exception.ToString());
            throw;
        }
    }
    
    //Execute saving of input values, then clear all fields except timestamp boxes
    private void testNext(object? sender, RoutedEventArgs e)
    {
        try
        {
            _click.saveEntries(DatesStamp.Text, Timestamp.Text, TradeType.Text, WinLoss.Text, TradeDirection.Text, Notes.Text);
            TradeType.Text = null;
            WinLoss.Text = null;
            TradeDirection.Text = null;
            Notes.Text = null;
            
            DebugText.Foreground = Brushes.Green;
            DebugText.Text = "Data saved. Enter more trades, or click calculate to generate output.";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            File.AppendAllText($"{_directory}\\BacktestDebug.txt", exception.ToString());
            throw;
        }
    }
}