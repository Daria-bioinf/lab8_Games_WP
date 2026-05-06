using Avalonia.Controls;
using Avalonia.Interactivity;

namespace lab8_Games_WP;

public partial class Window1 : Window
{
    string currentPLayer = "";
    public Window1()
    {
        InitializeComponent();
    }

    public void BtnDodajGracza_Click(object source, RoutedEventArgs args)
    {
        currentPLayer = txtLogin.Text ?? "";

        if (string.IsNullOrEmpty(currentPLayer))
        {
            txtObecnyGracz.Text = "Wpisz login!";
            return;
        }
        txtObecnyGracz.Text = $"obecny gracz: {currentPLayer}";
    }

    public void BtnGra1_Click(object source, RoutedEventArgs args)
    {
        if (string.IsNullOrEmpty(currentPLayer))
        {
            txtObecnyGracz.Text = "Najpierw dodaj gracza!";
            return;
        }
        var gameWindow = new MainWindow();
        gameWindow.ParentMenu = this;
        gameWindow.Show();
        this.Hide();
    }

    public void BtnGra2_Click(object source, RoutedEventArgs args)
    {
        var liarGame = new LiarGameWindow();
        liarGame.Show();
    }

    public void BtnGra3_Click(object source, RoutedEventArgs args)
    {
        var bj = new BlackjackWindow();
        bj.Show();
    }

    public void BtnHistoria_Click(object source, RoutedEventArgs args)
    {

    }


}