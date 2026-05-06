using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace lab8_Games_WP;

public partial class BlackjackWindow : Window
{
    public BlackjackWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void BtnHit_Click(object source, RoutedEventArgs args)
    {
        
    }

    public void BtnStand_Click(object source, RoutedEventArgs args)
    {
        
    }

    public void BtnReset_Click(object source, RoutedEventArgs args)
    {
      
    }

    public void BtnClose_Click(object source, RoutedEventArgs args)
    {
        this.Close();
    }
}