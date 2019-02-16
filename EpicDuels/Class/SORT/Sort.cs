using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.SORT {

    public abstract class Sort {

        private List<Weapon> WeaponList = new List<Weapon>();
        private ObservableCollection<Weapon> SortedList;
        private int Counter;

        public virtual void SortMetod() {

            Counter++;
            if(Counter == 1) {

            } else {

                Counter = 0;
            }
            SortedList = new ObservableCollection<Weapon>(WeaponList);
        }


        public void SortType(List<Weapon> weaponList) {
            this.WeaponList = weaponList;
        }

        public Sort(ObservableCollection<Weapon> SortedList) {

            this.SortedList = SortedList;
        }
    }
}
