using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.SORT {

    public class SortByNumber : Sort {

        public SortByNumber(ObservableCollection<Weapon> SortedList)
            : base(SortedList) {
        }
    }
}
