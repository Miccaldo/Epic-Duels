using EpicDuels.Class;
using EpicDuels.Class.CHARACTER;
using EpicDuels.Class.CHARACTER.Hero;
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
    /// Logika interakcji dla klasy SelectHero.xaml
    /// </summary>
    public partial class SelectHero : Window {

        public Feature feature { get; set; }
        public Hero hero { get; set; }
        private ImageUri imageUri;
        private int imageCounter;

        private const int IMAGES_MIN = 0;
        private const int IMAGES_MAX = 14;

        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();

        public SelectHero() {

            InitializeComponent();
            WindowState = WindowState.Maximized;

            Click.SoundLocation = "Sounds/Click/click.wav";

            feature = new Feature();
            imageUri = new ImageUri(new Uri(@"Images/Hero/0.jpg", UriKind.Relative));

            feature.UpdateFeature(FeatureGrid);
            imageUri.UpdateImage(portraitGrid);

            //hero = new Warrior();
        }

        private void Submit_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            EpicDuels.Map.DifficultyLevel = 1;
            feature.ImageNumber = imageCounter;

            hero.Strength = feature.Strength;
            hero.Endurance = feature.Endurance;
            hero.Agility = feature.Agility;
            hero.Intelligence = feature.Intelligence;

            new Map(this).Show();
            this.Close();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new MainWindow().Show();
            this.Close();
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e) {

            ChangeImage(ref imageCounter, "left");
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e) {

            ChangeImage(ref imageCounter, "right");
        }

        private void StrengthDown_Click(object sender, RoutedEventArgs e) {

            feature.Strength--;
            feature.Counter++;
            UnselectContinue(feature.Counter);
        }

        private void StrengthUp_Click(object sender, RoutedEventArgs e) {

            feature.Strength++;
            feature.Counter--;
            UnselectContinue(feature.Counter);
        }

        private void EnduranceDown_Click(object sender, RoutedEventArgs e) {

            feature.Endurance--;
            feature.Counter++;
            UnselectContinue(feature.Counter);
        }

        private void EnduranceUp_Click(object sender, RoutedEventArgs e) {

            feature.Endurance++;
            feature.Counter--;
            UnselectContinue(feature.Counter);
        }

        private void AgilityDown_Click(object sender, RoutedEventArgs e) {

            feature.Agility--;
            feature.Counter++;
            UnselectContinue(feature.Counter);
        }

        private void AgilityUp_Click(object sender, RoutedEventArgs e) {

            feature.Agility++;
            feature.Counter--;
            UnselectContinue(feature.Counter);
        }

        private void IntelligenceDown_Click(object sender, RoutedEventArgs e) {

            feature.Intelligence--;
            feature.Counter++;
            UnselectContinue(feature.Counter);
        }

        private void IntelligenceUp_Click(object sender, RoutedEventArgs e) {

            feature.Intelligence++;
            feature.Counter--;
            UnselectContinue(feature.Counter);
        }

        private void UnselectContinue(int counter) {

            Click.Play();

            if (counter != 0)
                submit.IsEnabled = false;
            else if((warriorBoxItem.IsSelected == true || thiefBoxItem.IsSelected == true || mageBoxItem.IsSelected == true) && heroNameBox.Text.Length > 0 ) {
                submit.IsEnabled = true;
            }

        }

        private void ChangeImage(ref int counterImages, string direction) {

            Click.Play();

            if (direction == "left") {

                counterImages--;

                if (counterImages < IMAGES_MIN)
                    counterImages = IMAGES_MAX;
            }

            if (direction == "right") {

                counterImages++;

                if (counterImages > IMAGES_MAX)
                    counterImages = IMAGES_MIN;
            }

            imageUri = new ImageUri(new Uri($"Images/Hero/{counterImages}.jpg", UriKind.Relative));
            imageUri.UpdateImage(portraitGrid);
        }

        private void Strenght_MouseIn(object sender, MouseEventArgs e) {

            Click.Play();

            descriptionBox.Text = "Siła - wpływa na ilość zadanych obrażeń fizycznych.";
            descriptionGrid.Visibility = Visibility.Visible;
            descriptionGrid.Margin = new Thickness(330, 25, 0, 0);
        }

        private void Strenght_MouseOut(object sender, MouseEventArgs e) {

            descriptionGrid.Visibility = Visibility.Hidden;
        }

        private void Endurance_MouseIn(object sender, MouseEventArgs e) {

            Click.Play();

            descriptionBox.Text = "Wytrzymałość - wpływa na ilość punktów życia postaci oraz klasę pancerza.";
            descriptionGrid.Visibility = Visibility.Visible;
            descriptionGrid.Margin = new Thickness(330, 80, 0, 0);
        }

        private void Endurance_MouseOut(object sender, MouseEventArgs e) {

            descriptionGrid.Visibility = Visibility.Hidden;
        }

        private void Agility_MouseIn(object sender, MouseEventArgs e) {

            Click.Play();

            descriptionBox.Text = "Zwinność - wpływa na ilość ataków oraz klasę pancerza.";
            descriptionGrid.Visibility = Visibility.Visible;
            descriptionGrid.Margin = new Thickness(330, 130, 0, 0);
        }

        private void Agility_MouseOut(object sender, MouseEventArgs e) {

            descriptionGrid.Visibility = Visibility.Hidden;
        }

        private void Intelligence_MouseIn(object sender, MouseEventArgs e) {

            Click.Play();

            descriptionBox.Text = "Inteligencja - wpływa na ilość zadanych obrażeń magicznych.";
            descriptionGrid.Visibility = Visibility.Visible;
            descriptionGrid.Margin = new Thickness(330, 180, 0, 0);
        }

        private void Intelligence_MouseOut(object sender, MouseEventArgs e) {

            descriptionGrid.Visibility = Visibility.Hidden;
        }

        private void WarriorDescription_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            descriptionScroll.Visibility = Visibility.Visible;

            descriptionBlock.Text = $"WOJOWNIK {Environment.NewLine}" +
                                    $" - klasa bazująca na sile fizycznej oraz wytrzymałości. {Environment.NewLine}{Environment.NewLine}" +
                                    $" Umiejętności: {Environment.NewLine}" +
                                    $" • Poziom 2 - Potężny atak {Environment.NewLine}" +
                                    $" • Poziom 4 - Ogłuszający cios {Environment.NewLine}" +
                                    $" • Poziom 6 - Młyniec {Environment.NewLine}" +
                                    $" • Poziom 8 - Szał {Environment.NewLine}{Environment.NewLine}" +
                                    $" Opis umiejętności: {Environment.NewLine}" +
                                    $" • Potężny atak - obrażenia + 150%. {Environment.NewLine}" +
                                    $" • Ogłuszający cios - blokuje przeciwnika na 2 tury.{Environment.NewLine}" +
                                    $" • Młyniec - atakuje wszystkich przeciwników. Obrażenia + 50%.{Environment.NewLine}" +
                                    $" • Szał - Odporność na wszystkie umiejętności blokujące postać. Obrażenia + 100%. Liczba ataków + 100%. Czas trwania 3 tury. " +
                                    $"\n\nZalecana cecha: Siła";

        }

        private void ThiefDescription_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            descriptionScroll.Visibility = Visibility.Visible;

            descriptionBlock.Text = $"ZŁODZIEJ {Environment.NewLine}" +
                                    $" - klasa specjalizująca się w szybkości oraz unikach. {Environment.NewLine}{Environment.NewLine}" +
                                    $" Umiejętności: {Environment.NewLine}" +
                                    $" • Poziom 2 - Oślepienie {Environment.NewLine}" +
                                    $" • Poziom 3 - Zatrucie {Environment.NewLine}" +
                                    $" • Poziom 6 - Moc Wampira {Environment.NewLine}" +
                                    $" • Poziom 8 - Cios w plecy {Environment.NewLine}" +
                                    $" Opis umiejętności: {Environment.NewLine}" +
                                    $" • Oślepienie - blokuje przeciwnika na 2 tury. {Environment.NewLine}" +
                                    $" • Zatrucie - zadaje obrażenia (-50%)/turę. Czas trwania 3 tury. {Environment.NewLine}" +
                                    $" • Moc Wampira - Liczba ataków + 150%. KP + 50%. Szansa na trafienie + 100%. Ataki leczą bohatera. Czas trwania 3 tury. {Environment.NewLine}" +
                                    $" • Cios w plecy - obrażenia + 500%.{Environment.NewLine}" +
                                    $" \nZalecana cecha: Zwinność";
        }

        private void MageDescription_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            descriptionScroll.Visibility = Visibility.Visible;

            descriptionBlock.Text = $"MAG {Environment.NewLine}" +
                                    $" - klasa zadająca największe obrażenia przy pomocy zaklęć. Posiada jednak " +
                                    $"mniejszą ilość punktów życia oraz podatność na ataki. {Environment.NewLine}{Environment.NewLine}" +
                                    $" Umiejętności: {Environment.NewLine}" +
                                    $" • Poziom 2 - Błyskawica {Environment.NewLine}" +
                                    $" • Poziom 3 - Lustrzane odbicie {Environment.NewLine}" +
                                    $" • Poziom 5 - Deszcz Meteorów {Environment.NewLine}" +
                                    $" • Poziom 8 - Słup ognia {Environment.NewLine}{Environment.NewLine}" +
                                    $" Opis umiejętności: {Environment.NewLine}" +
                                    $" • Błyskawica  - obrażenia + 150%. {Environment.NewLine}" +
                                    $" • Lustrzane odbicie - KP + 100%. Czas trwania 3 tury.{Environment.NewLine}" +
                                    $" • Deszcz Meteorów - atakuje wszystkich przeciwników. Obrażenia + 100%. {Environment.NewLine}" +
                                    $" • Słup ognia - obrażenia + 300%. Szansa na podpalenie. {Environment.NewLine}{Environment.NewLine}" +
                                    $" Zalecana cecha: Inteligencja";

        }

        private void WarriorBoxItem_Selected(object sender, RoutedEventArgs e) {

            Click.Play();

            hero = new Warrior();

            if (feature.Counter == 0 && heroNameBox.Text.Length > 0)
                submit.IsEnabled = true;
            else {
                submit.IsEnabled = false;
            }
        }
        private void ThiefBoxItem_Selected(object sender, RoutedEventArgs e) {

            Click.Play();

            hero = new Thief();

            if (feature.Counter == 0 && heroNameBox.Text.Length > 0)
                submit.IsEnabled = true;
            else {
                submit.IsEnabled = false;
            }
        }
        private void MageBoxItem_Selected(object sender, RoutedEventArgs e) {

            Click.Play();

            hero = new Mage();

            if (feature.Counter == 0 && heroNameBox.Text.Length > 0)
                submit.IsEnabled = true;
            else {
                submit.IsEnabled = false;
            }
        }

        private void HeroNameBox_TextChanged(object sender, TextChangedEventArgs e) {

            Click.Play();

            if (feature.Counter == 0 && heroNameBox.Text.Length > 0 && (warriorBoxItem.IsSelected == true || thiefBoxItem.IsSelected == true || mageBoxItem.IsSelected == true)) {
                submit.IsEnabled = true;
            } else
                submit.IsEnabled = false;


            feature.Name = heroNameBox.Text;
        }
    }
}


