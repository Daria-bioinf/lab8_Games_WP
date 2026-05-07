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
        txtCardValue.Text = realCard.ToString();
        bool correct = (playerSaysLiar == isLying);

        if (correct)
        {
            score++;
            txtStatus.Text = "Dobrze!";
        }
        else
        {
            txtStatus.Text = "Zle!";
        }

        txtScore.Text = $"Punkty: {score}";

        btnBelieve.IsEnabled = false;
        btnLiar.IsEnabled = false;
        btnNext.IsEnabled = true;
    }

    private string GetCardName(int cardValue)
    {
        return cardValue switch
        {
            1 => "As",
            11 => "Walet",
            12 => "Dama",
            13 => "Krol",
            _ => cardValue.ToString()
        };
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
        isLying = rand.Next(0, 2) == 0;

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

        

        txtClaim.Text = $"Komputer mowi: To jest {GetCardName(claimedCard)}!";
        txtCardValue.Text = "?";
        txtStatus.Text = "Czy on klamie?";

        btnBelieve.IsEnabled = true;
        btnLiar.IsEnabled = true;
        btnNext.IsEnabled = false;

        timeLeft = 5;
        liarTimer.Start();
    }
}