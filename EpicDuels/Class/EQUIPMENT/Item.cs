using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class.EQUIPMENT {

    public abstract class Item : Base {

        public string Name { get; set; }
        public int DropChanse { get; set; }
        public string BackgroundURL { get; set; }

        public int RandomValue { get; set; }


        public virtual void Drop(Random random) {
            RandomValue = random.Next(0, 100 + 1);
        }

        public abstract void UpdateGrid(Grid grid);

        public Item(string Name, int DropChanse, string BackgroundURL) {

            this.Name = Name;
            this.DropChanse = DropChanse;
            this.BackgroundURL = BackgroundURL;
        }
    }
}
