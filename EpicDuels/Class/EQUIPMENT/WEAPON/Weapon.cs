using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EpicDuels.Class.EQUIPMENT.WEAPON {

    public abstract class Weapon : Item {

        public int Type { get; set; }

        public string Type_Text { get; set; }

        public int DMG_MIN { get; private set; }
        public int DMG_MAX { get; private set; }
        public double Speed { get; private set; }

        public string SpeedTxt {
            get { return $"x{Speed}";}
            private set {; }
        }

        public string DMG_TYPE_Text { get; set; }

        public int DMG_TYPE { get; set; }

        protected enum Type_TEXT_Value {

            Miecz = 1,
            Młot,
            Włócznia,
            Buława,
            Topór,
            Sztylet,
            Laska,
        }

        protected enum DMG_TYPE_TEXT_Value {

            Sieczne = 1,
            Miażdżone,
            Kłóte,
            Magiczne,
        }

        protected enum Type_Value {

            Sword = 1,
            Hammer,
            Spear,
            Mace,
            Axe,
            Dagger,
            Staff,
        }

        protected enum DMG_TYPE_Value {
            melee,
            slash,
            crush,
            stab,
            magic,
        }

        public string Features { get; set; }
        public string FeaturesDescribe { get; set; }

        protected int HeroFeature;

        public int Level { get; set; }
        public bool Dropped { get; set; }

        public override void Drop(Random random) {
            base.Drop(random);
            //MessageBox.Show($"DR:{DropChanse},RV:{RandomValue}");
            if (DropChanse >= RandomValue)
                Dropped = true;
            else {
                Dropped = false;
            }
        }

        public int FeatureMetod(Hero hero) {

            int dmg = 0;
            double divider = 2;

            if (Features != null) {

                GetHeroFeature(hero);
                dmg = (int)Math.Round((DMG_MIN + DMG_MAX / divider) * HeroFeature / 100, 0, MidpointRounding.AwayFromZero);

                return dmg;
            } else {
                return 0;
            }
        }


        protected virtual void GetHeroFeature(Hero hero) { }

        public override void UpdateGrid(Grid grid) {
            ImageUri imageUri = new ImageUri(new Uri(BackgroundURL, UriKind.Relative));
            imageUri.UpdateImage(grid);
        }

        public Weapon(string Name, int DMG_MIN, int DMG_MAX, double Speed, int DropChanse, int Level, string BackgroundURL)
            :base(Name, DropChanse, BackgroundURL) {

            this.Name = Name;
            this.DMG_MIN = DMG_MIN;
            this.DMG_MAX = DMG_MAX;
            this.Speed = Speed;
            this.Level = Level;

            //base.BackgroundURL = BackgroundURL;
            FeaturesDescribe = "- brak";

        }
    }
}
