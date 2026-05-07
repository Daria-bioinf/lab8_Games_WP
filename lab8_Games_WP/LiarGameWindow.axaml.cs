using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

namespace lab8_Games_WP;

public partial class LiarGameWindow : Window
{
    Random rand = new Random();
    int realCard = 0;
    int claimedCard = 0;
    int score = 0;
    bool isLying = false;

    string realSuit = "";

    string[] suits =
    {
        "♥ Kier",
        "♠ Pik",
        "♦ Karo",
        "♣ Trefl"
    };


    DispatcherTimer liarTimer;
    int timeLeft = 5;

    public LiarGameWindow()
    {
        InitializeComponent();
        liarTimer = new DispatcherTimer();
        liarTimer.Interval = TimeSpan.FromSeconds(1);
        liarTimer.Tick += LiarTimer_Tick;

        this.Opened += (s, e) => BtnNext_Click(null, null);
    }
    private void LiarTimer_Tick(object? sender, EventArgs e)
    {
        timeLeft--;
        txtStatus.Text = $"Szybciej! {timeLeft} s";

        if (timeLeft <= 0)
        {
            liarTimer.Stop();
            txtStatus.Text = "Za długo! Przegrałes!";
            btnBelieve.IsEnabled = false;
            btnLiar.IsEnabled = false;
            btnNext.IsEnabled = true;
        }
    }
    private void CheckResult(bool playerSaysLiar)
    {
        liarTimer.Stop();

        txtCardValue.Text =
            GetCardName(realCard);

        bool correct =
            (playerSaysLiar == isLying);

        if (correct)
        {
            score++;

            txtStatus.Text = "Dobrze! +1 punkt";
        }
        else
        {
            txtStatus.Text = "Źle!";
        }

        txtScore.Text = $"Punkty: {score}";

        btnBelieve.IsEnabled = false;
        btnLiar.IsEnabled = false;


        SuitPanel.IsVisible = true;

        txtStatus.Text +=
            " Zgadnij kolor karty!";
    }

    private string GetCardName(int cardValue)
    {
        return cardValue switch
        {
            1 => "As",
            11 => "Walet",
            12 => "Dama",
            13 => "Król",
            _ => cardValue.ToString()
        };
    }

    private void CheckSuit(string suit)
    {
        if (suit == realSuit)
        {
            score += 2;

            txtStatus.Text =
                $"Dobrze! To był {realSuit} (+2 punkty)";
        }
        else
        {
            txtStatus.Text =
                $"Źle! To był {realSuit}";
        }

        txtScore.Text =
            $"Punkty: {score}";

        SuitPanel.IsVisible = false;

        btnNext.IsEnabled = true;
    }

    public void BtnBelieve_Click(object source, RoutedEventArgs args)
    {
        CheckResult(false);
    }

    public void BtnLiar_Click(object source, RoutedEventArgs args)
    {
        CheckResult(true);
    }

    public void BtnNext_Click(object? source, RoutedEventArgs? args)
    {
        realCard = rand.Next(1, 14);

        realSuit =
            suits[rand.Next(0, suits.Length)];

        isLying =
            rand.Next(0, 2) == 0;

        if (isLying)
        {
            do
            {
                claimedCard = rand.Next(1, 14);

            } while (claimedCard == realCard);
        }
        else
        {
            claimedCard = realCard;
        }

        txtClaim.Text = $"Komputer mówi: To jest {GetCardName(claimedCard)}!";

        txtCardValue.Text = "?";

        txtStatus.Text = "Czy on kłamie?";

        btnBelieve.IsEnabled = true;
        btnLiar.IsEnabled = true;

        btnNext.IsEnabled = false;

        SuitPanel.IsVisible = false;

        timeLeft = 5;

        liarTimer.Start();
    }

    public void BtnHeart_Click(object source, RoutedEventArgs args)
    {
        CheckSuit("♥ Kier");
    }

    public void BtnSpade_Click(object source, RoutedEventArgs args)
    {
        CheckSuit("♠ Pik");
    }

    public void BtnDiamond_Click(object source, RoutedEventArgs args)
    {
        CheckSuit("♦ Karo");
    }

    public void BtnClub_Click(object source, RoutedEventArgs args)
    {
        CheckSuit("♣ Trefl");
    }
}