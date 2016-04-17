using System.Windows;
using Engine;

namespace WPFUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick_NewGame(object sender, RoutedEventArgs e)
        {
            CharacterCreator characterCreator = new CharacterCreator();
            characterCreator.Owner = this;
            characterCreator.ShowDialog();
        }

        private void OnClick_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}