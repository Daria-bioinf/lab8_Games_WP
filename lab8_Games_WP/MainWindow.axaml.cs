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
        public Window? ParentMenu { get; set; }
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

            btnWieksza.IsEnabled = true;
            btnMniejsza.IsEnabled = true;
        }

        public void BtnWieksza_Click(object sender, RoutedEventArgs e)
        {
            int newCard;
            do
            {
                newCard = rand.Next(1, 11);
            } while (newCard == currentCard);

            if (newCard > currentCard)
            {
                score++;
                txtResult.Text = "Dobrze!";

                currentCard = newCard;
                txtCurrentCard.Text = currentCard.ToString();
                txtScore.Text = $"Punkty: {score}";
            }
            else
            {
                txtResult.Text = $"Źle! Karta była {newCard}. Koniec gry";
                btnWieksza.IsEnabled = false;
                btnMniejsza.IsEnabled = false;
                return;
            }

            
        }

        public void BtnMniejsza_Click(object sender, RoutedEventArgs e)
        {
            int newCard;
            do
            {
                newCard = rand.Next(1, 11);
            } while (newCard == currentCard);

            if (newCard < currentCard)
            {
                score++;
                txtResult.Text = "Dobrze!";
                currentCard = newCard;
                txtCurrentCard.Text = currentCard.ToString();
                txtScore.Text = $"Punkty: {score}";
            }
            else
            {
                txtResult.Text = $"Źle! Karta była {newCard}. Koniec gry";
                btnWieksza.IsEnabled = false;
                btnMniejsza.IsEnabled = false;
            }
        }

        public void BtnBack_Click(object source, RoutedEventArgs args)
        {
            if (ParentMenu != null)
            {
                ParentMenu.Show(); 
            }
            this.Close();
        }
    }
}