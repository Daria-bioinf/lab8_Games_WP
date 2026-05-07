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

    List<(string name, int value)> playerCards = new();
    List<(string name, int value)> dealerCards = new();

    bool waitingForAceChoice = false;
    public BlackjackWindow()
    {
        InitializeComponent();
        StartGame();
    }
    private (string name, int value) GenerateCard()
    { 
        int card = rand.Next(1, 14);

        switch (card)
        {
            case 1: return ("As", 0);
            case 11: return ("Walet", 10);
            case 12: return ("Dama", 10);
            case 13: return ("Krol", 10);
            default: return (card.ToString(), card);
        }
       

    }

    private void StartGame()
    {
        playerCards.Clear();
        dealerCards.Clear();

        playerCards.Add(GenerateCard());
        playerCards.Add(GenerateCard());

        dealerCards.Add(GenerateCard());
        dealerCards.Add(GenerateCard());

        UpdateUI();

        txtStatus.Text = "Dobierz karte lub Pas?";

    }

    private void UpdateUI()
    {
        txtPlayerCards.Text =
            string.Join(" | ", playerCards.Select(c => c.name));

        txtDealerCards.Text =
            $"{dealerCards[0].name} | ??";

        int playerSum =
            playerCards.Sum(c => c.value);

        txtPlayerScore.Text =
            $"Suma: {playerSum}";
    }

    public void BtnHit_Click(object source, RoutedEventArgs args)
    {
        if (waitingForAceChoice)
        {
            return;
        }

        playerCards.Add(GenerateCard());

        var lastCard = playerCards.Last();

        if (lastCard.name == "As" && lastCard.value == 0)
        {
            waitingForAceChoice = true;

            AcePanel.IsVisible = true;

            txtStatus.Text = "Wybierz wartość Asa!";

            return;
        }

        UpdateUI();

        int playerSum =
            playerCards.Sum(c => c.value);

        if (playerSum > 21)
        {
            txtDealerCards.Text =
                string.Join(" | ", dealerCards.Select(c => c.name));

            txtStatus.Text = "Przegrałeś! Ponad 21";
        }
  
    }

    private void SetAceValue(int value)
    {
        var lastCard = playerCards.Last();

        playerCards[playerCards.Count - 1] =
            ("As", value);

        waitingForAceChoice = false;

        AcePanel.IsVisible = false;

        UpdateUI();

        int playerSum =
            playerCards.Sum(c => c.value);

        if (playerSum > 21)
        {
            txtStatus.Text = "Przegrałeś!";
        }
        else
        {
            txtStatus.Text = "Dobierz kartę lub Pas?";
        }
    }

    public void BtnAceOne_Click(object source, RoutedEventArgs args)
    {
        SetAceValue(1);
    }

    public void BtnAceEleven_Click(object source, RoutedEventArgs args)
    {
        SetAceValue(11);
    }

    public void BtnStand_Click(object source, RoutedEventArgs args)
    {
        int dealerSum =
            dealerCards.Sum(c => c.value);

        while (dealerSum < 17)
        {
            dealerCards.Add(GenerateCard());

            dealerSum =
                dealerCards.Sum(c => c.value);
        }

        txtDealerCards.Text =
            string.Join(" | ", dealerCards.Select(c => c.name));

        int playerSum =
            playerCards.Sum(c => c.value);

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