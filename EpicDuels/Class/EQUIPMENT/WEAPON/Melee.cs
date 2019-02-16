using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON {

    public class Melee : Weapon {

        public Melee(string Name = "Walka wręcz", int DMG_MIN = 1, int DMG_MAX = 2,double Speed = 1.0, int DropChanse = 0, int Level = 0, string BackgroundURL = "brak")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            DMG_TYPE = (int)DMG_TYPE_Value.melee;
        }
    }
}