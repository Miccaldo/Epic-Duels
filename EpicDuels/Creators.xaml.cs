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
using System.Windows.Shapes;

namespace EpicDuels {
    /// <summary>
    /// Logika interakcji dla klasy Creators.xaml
    /// </summary>
    public partial class Creators : Window {

        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();

        public Creators() {

            InitializeComponent();
            Click = new System.Media.SoundPlayer();
            Click.SoundLocation = "Sounds/Click/click.wav";
            WindowState = WindowState.Maximized;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new MainWindow().Show();
            this.Close();
        }
    }
}
