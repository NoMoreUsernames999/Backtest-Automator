using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BacktestAutomator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    //Instantiate button logic
    Buttons _click = new();
    
    //Execute search loop
    private void testCalc(object? sender, RoutedEventArgs e)
    {
        _click.searchLoop();
    }
    
    //Execute saving of input values, then clear all fields except timestamp boxes
    private void testNext(object? sender, RoutedEventArgs e)
    {
       _click.saveEntries(DatesStamp.Text, Timestamp.Text, TradeType.Text, WinLoss.Text, TradeDirection.Text, Notes.Text);
       
       TradeType.Text = null;
       WinLoss.Text = null;
       TradeDirection.Text = null;
       Notes.Text = null;
    }
}