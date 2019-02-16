using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EpicDuels.Class.LOCATION {

    public abstract class Location : Base {

        private const int DEATH_COUNTER_LIMIT = 3;         // co ile potworkow zmiana background
        private const int CHANGE_LOCATION_MAX = 3;       // ile zmian background do zmiany lokacji

        private const int AXE_NUMBER = 5;
        private const int DAGGER_NUMBER = 6;
        private const int STAFF_NUMBER = 7;

        public int ChangeLocationLimit { get; private set; }

        private int _Level;
        public int Level {
            get { return _Level; }
            set {
                _Level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public int DeathCounter { get; set; }       // licznik pokonanych przeciwnikow

        private static int _Turn;
        public int Turn {
            get { return _Turn; }
            set {
                _Turn = value;
                OnPropertyChanged(nameof(Turn));
            }
        }

        public List<Border> EnemyBorderList = new List<Border>();
        public List<Grid> EnemyGridList = new List<Grid>();
        public List<Enemy> EnemyList = new List<Enemy>();

        public abstract List<Enemy> TargetListOfEnemies();
        public abstract List<string> BackgroundList();

        public List<Weapon> WeaponList = new List<Weapon>();


        public bool Drop(Random random, Hero hero) {

            int _RandomValue = 0;
            int indexOfRandomValue = 0;

            if (this.Level < 4) {
                foreach (Weapon _weapon in WeaponList.Where(x => x.Level == this.Level)) {
                    _weapon.Drop(random);
                    //MessageBox.Show($"{_weapon.Name}, {_weapon.Dropped}, {_weapon.RandomValue}");
                    if (_weapon.Dropped is true && _weapon.RandomValue > _RandomValue) {

                        indexOfRandomValue = WeaponList.FindIndex(x => x.Dropped == true);
                        WeaponList[indexOfRandomValue].Dropped = false;
                        _RandomValue = _weapon.RandomValue;
                    }
                }

                if (_RandomValue > 0) {
                    //MessageBox.Show($"{indexOfRandomValue}");
                    hero.equipment.weaponList.Add(WeaponList[indexOfRandomValue]);
                    return true;
                } else {
                    return false;
                }
            } else if(Map.DifficultyLevel < 5){
                if (hero is Warrior) {
                    hero.equipment.weaponList.Add(WeaponList.Find(x => x.Type == AXE_NUMBER));
                } else if (hero is Thief)
                    hero.equipment.weaponList.Add(WeaponList.Find(x => x.Type == DAGGER_NUMBER));
                else if (hero is Mage)
                    hero.equipment.weaponList.Add(WeaponList.Find(x => x.Type == STAFF_NUMBER));

                return true;
            } else {
                return false;

            }
        }


        private string _LocationName;
        public string LocationName {
            get { return _LocationName; }
            set {
                _LocationName = value;
                OnPropertyChanged(nameof(LocationName));
            }
        }

        public bool AllEnemiesDefeated() {

            if (EnemyList.FindIndex(x => x.HP > 0) != -1)  // jesli nic nie znajdzie to metoda zwraca -1
                return false;
            else {
                return true;
            }
        }

        public bool LevelUP() {

            if (DeathCounter == DEATH_COUNTER_LIMIT) {
                Level++;
                DeathCounter = 0;
                return true;
            } else {
                return false;
            }
        }

        public bool ChangeLocation() {

            if (Level == 4 && DeathCounter == 1) {      // 4 LVL i pokonany BOSS
                DeathCounter = 0;
                Map.DifficultyLevel++;
                return true;
            } else {
                return false;
            }
        }

        public virtual void UpdateBackground(Grid locationGrid) {

            short i = 0;

            if (Level < 4) {
                ImageBrush image = new ImageBrush();
                image.ImageSource = new BitmapImage(new Uri($"{BackgroundList().ElementAt(Level - 1)}", UriKind.Relative));
                locationGrid.Background = image;
            }

            foreach (Grid enemyGrid in EnemyGridList) {

                enemyGrid.DataContext = EnemyList.ElementAt(i);

                i++;
            }

            locationGrid.DataContext = this;
        }

        public Location(int level, string LocationName) {

            this.Level = level;
            this.LocationName = LocationName;
            this.ChangeLocationLimit = CHANGE_LOCATION_MAX;
            this.DeathCounter = 0;
        }
    }
}



