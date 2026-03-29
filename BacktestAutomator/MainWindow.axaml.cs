using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BacktestAutomator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private string testString = """
                                2/24/2026 6:15:00 PM -> Volatility: #40
                                2/24/2026 6:15:00 PM -> R-Volatility: #27
                                2/24/2026 6:15:00 PM -> R-Volume: #25
                                2/24/2026 6:15:00 PM -> Deviation: #107
                                2/25/2026 6:16:00 AM -> Volatility: #40
                                2/25/2026 6:16:00 AM -> R-Volatility: #50
                                2/25/2026 6:16:00 AM -> R-Volume: #25
                                2/25/2026 6:16:00 AM -> Deviation: #195
                                2/25/2026 6:16:00 PM -> Volatility: #40
                                2/25/2026 6:16:00 PM -> R-Volatility: #11
                                2/25/2026 6:16:00 PM -> R-Volume: #9
                                2/25/2026 6:16:00 PM -> Deviation: #121
                                2/25/2026 6:18:00 PM -> Volatility: #40
                                2/25/2026 6:18:00 PM -> R-Volatility: #27
                                2/25/2026 6:18:00 PM -> R-Volume: #8
                                2/25/2026 6:18:00 PM -> Deviation: #318
                                """;
    
    private void TestCalc(object? sender, RoutedEventArgs e)
    {
       
    }
    
    private void TestNext(object? sender, RoutedEventArgs e)
    {
       
    }
}