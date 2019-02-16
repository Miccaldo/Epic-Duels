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
using WMPLib;

namespace EpicDuels {
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public WMPLib.WindowsMediaPlayer Music;

        public WMPLib.WindowsMediaPlayer Test = new WindowsMediaPlayer();

        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();


        public MainWindow() {

            InitializeComponent();

            WindowState = WindowState.Maximized;


            Music = new WindowsMediaPlayer();

            Music.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Music.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);

            Music.URL = "Sounds/Background/music.mp3";
            Click.SoundLocation = "Sounds/Click/click.wav";

        }
        private void NewGame_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new SelectHero().Show();
            this.Close();
        }

        private void EndGame_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            this.Close();
        }

        private void Creators_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new Creators().Show();
            this.Close();
        }

        private void Player_PlayStateChange(int NewState) {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped) {

            }
        }

        private void Player_MediaError(object pMediaObject) {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }
    }
}
