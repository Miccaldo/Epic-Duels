using EpicDuels.Class;
using EpicDuels.Class.LOCATION;
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
    /// Logika interakcji dla klasy Map.xaml
    /// </summary>
    public partial class Map : Window {

        public static int DifficultyLevel { get; set; }
        public static bool DiractionFlag { get; set; }

        public Location location { get; set; }
        private SelectHero selectHero;

        private ImageUri imageLocation;

        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();


        public Map(SelectHero selectHero) {

            InitializeComponent();
            WindowState = WindowState.Maximized;

            Click.SoundLocation = "Sounds/Click/click.wav";

            this.selectHero = selectHero;

            if(DifficultyLevel > 1 && DifficultyLevel < 5) {
                beginMessage.Visibility = Visibility.Hidden;
                MapGrid.Visibility = Visibility.Visible;
            } else if(DifficultyLevel == 5){
                MapGrid.Visibility = Visibility.Hidden;
                beginMessage.Visibility = Visibility.Hidden;
                EndMessage.Visibility = Visibility.Visible;
            }

            SelectLeftLocation(DifficultyLevel);
            SelectRightLocation(DifficultyLevel);

        }


        private void SelectLeftLocation(int Level) {

            if (Level == 1) {
                imageLocation = new ImageUri(new Uri(@"Images/Location/MagicForest/mapMagicForest.jpg", UriKind.Relative));
            } else {
                imageLocation = new ImageUri(new Uri(@"Images/Location/Cemetary/mapCemetary.jpg", UriKind.Relative));
            }

            imageLocation.UpdateImage(LeftLocationGrid);
        }


        private void SelectRightLocation(int Level) {

            if (Level == 1) {
                imageLocation = new ImageUri(new Uri(@"Images/Location/IceLand/mapIceLand.jpg", UriKind.Relative));
            } else {
                imageLocation = new ImageUri(new Uri(@"Images/Location/Cave/mapCave.jpg", UriKind.Relative));
            }

            imageLocation.UpdateImage(RightLocationGrid);
        }

        private void BeginMessage_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            beginMessage.Visibility = Visibility.Hidden;
            MapGrid.Visibility = Visibility.Visible;
        }

        private void LeftLocationButton_Click(object sender, RoutedEventArgs e) {

            //Click.Play();
            MapGrid.Visibility = Visibility.Hidden;

            DiractionFlag = false;


            if (DifficultyLevel == 1) {
                location = new MagicForest();
                new Game(selectHero, this).Show();
            } else {
                location = new Cemetary();
                new Game(selectHero, this).Show();
                selectHero.hero.equipment.SmallPotion.DropChanse = 10;
                selectHero.hero.equipment.BigPotion.DropChanse = 40;
            }

            this.Close();
        }

        private void RightLocationButton_Click(object sender, RoutedEventArgs e) {

            //Click.Play();
            MapGrid.Visibility = Visibility.Hidden;

            DiractionFlag = true;

            if (DifficultyLevel == 1) {
                location = new IceLand();
                new Game(selectHero, this).Show();
            }
            else {
                location = new Cave();
                new Game(selectHero, this).Show();
                selectHero.hero.equipment.SmallPotion.DropChanse = 40;      // zmien szanse na drop potionow od trudniejszych poziomow
                selectHero.hero.equipment.BigPotion.DropChanse = 60;              
            }

            this.Close();
        }

        private void EndMessage_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            EndMessage.Visibility = Visibility.Hidden;
            location = new FieryLands();
            new Game(selectHero, this).Show();
            this.Close();
        }
    }
}