using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using Engine;
using ScottsOpenSourceRPG.Resources;

namespace ScottsOpenSourceRPG
{
    public partial class About : Window
    {
        public About(Game game)
        {
            InitializeComponent();

            Title = Literals.About;

            lblGameName.Content = game.Name;
            lblVersionLiteral.Content = string.Format("{0}: ", Literals.Version);
            lblVersion.Content = string.Format("{0}: {1}", Literals.Version, game.CurrentVersion);
            lblCopyrightLiteral.Content = string.Format("{0}: ", Literals.Copyright);
            lblCopyright.Content =
                (DateTime.Now.Year > game.CopyrightYear)
                    ? string.Format("{0}: {1} - {2}", Literals.Copyright, game.CopyrightYear, DateTime.Now.Year)
                    : string.Format("{0}: {1}", Literals.Copyright, game.CopyrightYear);

            txtWebsiteURL.Text = game.WebsiteName;
            hypWebsiteURL.NavigateUri = new Uri(game.WebsiteURL);

            btnClose.Content = Literals.Close;
        }

        private void NavigateToURL(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
