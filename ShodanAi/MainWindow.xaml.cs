using ShodanAi.AbstractShodan;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ShodanAi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartShodan_Click(object sender, RoutedEventArgs e)
        {
            AnimatedGif.Source = new Uri(@"C:\Users\Honor\source\repos\ShodanAi\ShodanAi\Source\imageShodan\shodanFace.gif");
            AnimatedGif.Play();

            ShodanDialog.Text = "Button is clicked";

            await InitShodan.InitShodanWelcome(ShodanDialog, recognitionStatusLabel, LogTextBlock);
        }

        private void AnimatedGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            AnimatedGif.Position = new TimeSpan(0, 0, 1);
            AnimatedGif.Play();
        }

        public void ShodanDialog_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Future logic here
        }
    }
}
