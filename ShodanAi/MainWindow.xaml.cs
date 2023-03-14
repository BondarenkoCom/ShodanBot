using ShodanAi.AbstractShodan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShodanAi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.Background = myBackGround;
        }

        private void StartShodan_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush myBackGround = new ImageBrush();
            //TODO сделать относительные пути
            myBackGround.ImageSource = new BitmapImage(new Uri(@"C:\Users\Honor\source\repos\ShodanAi\ShodanAi\Source\imageShodan\ShodanStandart.jpg"));
            this.Background = myBackGround;

            //MessageBox.Show("Кнопка нажата");
            var saveText = ShodanDialog.Text = "Кнопка нажата";
            InitShodan.InitShodanWelcome();

            //var mesInitText = ShodanDialog.Text = ;


        }

        //public void ShodanDialog_TextChanged(object sender, TextChangedEventArgs e)
        public void ShodanDialog_TextChanged(object sender , TextChangedEventArgs e)
        {
        
            //TextBox ShodanDialog = (TextBox)sender;
            //TextBox ShodanDialog = (TextBox)sender;
        
        }
    }
}
