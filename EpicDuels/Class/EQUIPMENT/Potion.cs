using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class.EQUIPMENT {


    public class Potion : Item {

        public int HP { get; private set; }

        private int _Count;
        public int Count {
            get {
                if (_Count >= 0)
                    return _Count;
                else {
                    return 0;
                }
            }
            set {
                _Count = value;
                if (_Count > 9)
                    _Count = 9;

                OnPropertyChanged(nameof(Count));
            }
        }

        public override void Drop(Random random) {
            base.Drop(random);
            if (DropChanse > RandomValue) {
                Count++;
            }
        }

        public override void UpdateGrid(Grid grid) {
            grid.DataContext = this;
        }

        public Potion(string Name, int HP, int DropChanse, int Count, string BackgroundURL)
            :base(Name, DropChanse, BackgroundURL) { 

            this.HP = HP;
            this.Count = 0;
            this.Count = Count;

        }
    }
}
