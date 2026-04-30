using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace lab8_Games_WP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        int currentCard = 0;
        int score = 0;
        public void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            currentCard = rand.Next(1, 11);
            score = 0;

            txtCurrentCard.Text = currentCard.ToString();
            txtScore.Text = "Punkty: 0";
            txtResult.Text = "Zgadnij następną kartę!";
        }

        public void BtnWieksza_Click(object sender, RoutedEventArgs e)
        {
            int newCard = rand.Next(1, 11);

            if (newCard > currentCard)
            {
                score++;
                txtResult.Text = "Dobrze!";
            }
            else
            {
                txtResult.Text = "Źle! Koniec gry";
                return;
            }

            currentCard = newCard;
            txtCurrentCard.Text = currentCard.ToString();
            txtScore.Text = $"Punkty: {score}";
        }

        public void BtnMniejsza_Click(object sender, RoutedEventArgs e)
        {
            int newCard = rand.Next(1, 11);

            if (newCard < currentCard)
            {
                score++;
                txtResult.Text = "Dobrze!";
            }
            else
            {
                txtResult.Text = "Źle! Koniec gry";
                return;
            }

            currentCard = newCard;
            txtCurrentCard.Text = currentCard.ToString();
            txtScore.Text = $"Punkty: {score}";
        }
    }
}