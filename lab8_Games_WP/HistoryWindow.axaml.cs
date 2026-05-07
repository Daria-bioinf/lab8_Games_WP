using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace lab8_Games_WP;

public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();

        lstHistory.ItemsSource = GameHistory.History;
    }

    public void BtnZamknij_Click(object source, RoutedEventArgs args)
    {
        this.Close(); 
    }
}