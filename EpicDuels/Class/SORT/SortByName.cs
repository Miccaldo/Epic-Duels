using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.SORT {

    public class SortByName : Sort {

        public SortByName(ObservableCollection<Weapon> SortedList)
            : base(SortedList) {
        }
    }
}
