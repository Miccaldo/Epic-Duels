using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class.EQUIPMENT {

    public class EQslot {

        public Weapon weapon;
        public ImageUri imageUri;

        public void Clear(Grid grid) {

            grid.DataContext = null;
        }

        public EQslot(Weapon weapon, Grid grid) {

            this.weapon = weapon;
            imageUri = new ImageUri(new Uri(weapon.BackgroundURL, UriKind.Relative));
            imageUri.UpdateImage(grid);
        }
    }
}
