using System.Windows;
using Engine;

namespace ScottsOpenSourceRPG
{
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();

            _game = new Game("Scott's Open Source C# RPG", 0, 1, 1999,
                "https://github.com/ScottLilly/ScottsOpenSourceRPG", "Scott's Open Source C# RPG");

            BindGameToUI();
        }

        private void BindGameToUI()
        {
            Title = _game.Name;
        }

        private void MenuItem_Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_About_OnClick(object sender, RoutedEventArgs e)
        {
            About aboutScreen = new About(_game);
            aboutScreen.ShowDialog();
        }
    }
}
