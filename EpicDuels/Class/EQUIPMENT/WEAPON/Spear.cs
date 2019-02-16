using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON {

    public class Spear : Weapon {

        public Spear(string Name, int DMG_MIN, int DMG_MAX, double Speed, int DropChanse, int Level, string BackgroundURL)
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            base.DMG_TYPE = (int)DMG_TYPE_Value.stab;
            base.Type = (int)Type_Value.Spear;
            base.DMG_TYPE_Text = DMG_TYPE_TEXT_Value.Kłóte.ToString();
            base.Type_Text = Type_TEXT_Value.Włócznia.ToString();
        }
    }
}
