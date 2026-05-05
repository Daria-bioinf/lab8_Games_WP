using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace lab8_Games_WP;

public partial class LiarGameWindow : Window
{
    Random rand = new Random();
    int realCard = 0;
    int claimedCard = 0;
    int score = 0;
    bool isLying = false;

    public LiarGameWindow()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void BtnBelieve_Click(object source, RoutedEventArgs args)
    {
        
    }

    public void BtnLiar_Click(object source, RoutedEventArgs args)
    {
        
    }

    public void BtnNext_Click(object source, RoutedEventArgs args)
    {
        realCard = rand.Next(1, 11);

        isLying = rand.Next(0, 2) == 0;

        if (isLying)
        {
            do
            {
                claimedCard = rand.Next(1, 11);
            } while (claimedCard == realCard);
        }
        else
        {
            claimedCard = realCard;
        }
        txtClaim.Text = $"Komputer mowi: To jest {claimedCard}";
        txtCardValue.Text = "?";
        txtStatus.Text = "Czy on klamie?";

        btnNext.IsEnabled = false;
    }
}