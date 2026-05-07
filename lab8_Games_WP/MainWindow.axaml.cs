using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Threading;
namespace lab8_Games_WP
{
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer;
        int timeLeft = 5;
        public MainWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += GameTimer_Tick;
        }
        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            timeLeft--;
            txtResult.Text = $"Czas: {timeLeft} s!"; 

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                txtResult.Text = "Czas się skonczył! Koniec gry.";
                btnWieksza.IsEnabled = false;
                btnMniejsza.IsEnabled = false;

                GameHistory.History.Add($"Więcej/Mniej - Koniec czasu - Punkty: {score}");
            }
        }
        public Window? ParentMenu { get; set; }
        Random rand = new Random();
        int currentCard = 0;
        int score = 0;
        public void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            timeLeft = 5;
            gameTimer.Start();
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
            timeLeft = 5; 
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

                GameHistory.History.Add($"Więcej/Mniej - Przegrana - Punkty: {score}");
            }

            
        }

        public void BtnMniejsza_Click(object sender, RoutedEventArgs e)
        {
            timeLeft = 5; 
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

                GameHistory.History.Add($"Więcej/Mniej - Przegrana - Punkty: {score}");
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