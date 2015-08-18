using System.Windows;
using Engine;
using Engine.Entities;

namespace ScottsOpenSourceRPG
{
    public partial class MainWindow : Window
    {
        private readonly Game _game;

        public MainWindow()
        {
            InitializeComponent();

            _game = new Game(new World(), new Player());
        }

        private void MenuItem_Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_About_OnClick(object sender, RoutedEventArgs e)
        {
            About aboutScreen = new About();
            aboutScreen.ShowDialog();
        }
    }
}
