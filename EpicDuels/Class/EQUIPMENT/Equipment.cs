using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class.EQUIPMENT {

    public class Equipment {

        public Potion SmallPotion { get; set; }
        public Potion BigPotion { get; set; }

        public ObservableCollection<Weapon> weaponList = new ObservableCollection<Weapon>();
        public Dictionary<int, Weapon> AssignedWeaponDic = new Dictionary<int, Weapon>();
        private List<Weapon> AuxiliaryList = new List<Weapon>();


        public ImageUri EQartefactUri { get; set; }

        private int Counter = 0;


        public void Sort(List<Weapon> SortType_1, List<Weapon> SortType_2) {

            Counter++;
            if (Counter == 1) {
                AuxiliaryList = SortType_1;

            } else {
                AuxiliaryList = SortType_2;
                Counter = 0;
            }

            weaponList = new ObservableCollection<Weapon>(AuxiliaryList);
        }

        public void UpdateWeaponImage(Grid grid) {

            if (weaponList.Count > 0) {
                ImageUri imageUri = new ImageUri(new Uri(weaponList[0].BackgroundURL, UriKind.Relative));
                imageUri.UpdateImage(grid);
            } else {
                grid.DataContext = null;
            }
        }


        public bool AssignFlag { get; set; }

        public Equipment() {

            this.SmallPotion = new Potion("Mały eliksir", 20, 40, 3, "Images/Background/potion.png");
            this.BigPotion = new Potion("Duży eliksir", 50, 10, 1, "Images/Background/BigPotion.png");
        }
    }
}