using System;
using System.IO;
using System.Windows;
using Engine;

namespace ScottsOpenSourceRPG
{
    public partial class SOSCSRPG : Window
    {
        private readonly Game _game;

        public SOSCSRPG()
        {
            InitializeComponent();

            try
            {
                var gameInformationFileName = Properties.Settings.Default.GameInformation;

                if(File.Exists(gameInformationFileName))
                {
                    var gameInformation = File.ReadAllText(gameInformationFileName);
                    _game = new Game(gameInformation);
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                throw;
            }

            DataContext = _game;
        }

        private void MenuItem_NewGame_OnClick(object sender, RoutedEventArgs e)
        {
            StartNewGame newGame = new StartNewGame();
            newGame.Owner = this;
            newGame.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            newGame.ShowDialog();
        }

        private void MenuItem_Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_About_OnClick(object sender, RoutedEventArgs e)
        {
            var aboutScreen = new About(_game);
            aboutScreen.Owner = this;
            aboutScreen.ShowDialog();
        }
    }
}