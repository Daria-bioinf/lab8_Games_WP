using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8_Games_WP;

public partial class BlackjackWindow : Window
{
    Random rand = new Random();

    List<int> playerCards = new List<int>();
    List<int> dealerCards = new List<int>();

    public BlackjackWindow()
    {
        InitializeComponent();
        StartGame();
    }

    private void StartGame()
    {
        playerCards.Clear();
        dealerCards.Clear();

        playerCards.Add(rand.Next(1, 11));
        playerCards.Add(rand.Next(1, 11));

        dealerCards.Add(rand.Next(1, 11));
        dealerCards.Add(rand.Next(1, 11));

        UpdateUI();

        txtStatus.Text = "Dobierz karte lub Pas?";

    }

    private void UpdateUI()
    {
        txtPlayerCards.Text = string.Join(" | ", playerCards);
        txtDealerCards.Text = $"{dealerCards[0]} ??";

        int playerSum = playerCards.Sum();
        txtPlayerScore.Text = $"Suma: {playerSum}";
    }

    public void BtnHit_Click(object source, RoutedEventArgs args)
    {
        playerCards.Add(rand.Next(1, 11));

        UpdateUI();

        int playerSum = playerCards.Sum();

        if (playerSum > 21)
        {
            txtStatus.Text = "Przegrałeś! Ponad 21";
        }
    }

    public void BtnStand_Click(object source, RoutedEventArgs args)
    {
        int dealerSum = dealerCards.Sum();

        while (dealerSum < 17)
        {
            dealerCards.Add(rand.Next(1, 11));
            dealerSum = dealerCards.Sum();
        }

        txtDealerCards.Text = string.Join(" ", dealerCards);

        int playerSum = playerCards.Sum();

        if (dealerSum > 21 || playerSum > dealerSum)
        {
            txtStatus.Text = "Wygrałeś!";
        }
        else if (dealerSum == playerSum)
        {
            txtStatus.Text = "Remis!";
        }
        else
        {
            txtStatus.Text = "Przegrałeś!";
        }
    }

    public void BtnReset_Click(object source, RoutedEventArgs args)
    {
        StartGame();

    }

    public void BtnClose_Click(object source, RoutedEventArgs args)
    {
        this.Close();
    }
}