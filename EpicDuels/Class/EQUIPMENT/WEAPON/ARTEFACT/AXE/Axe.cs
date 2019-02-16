using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE {

    public class Axe : Artefact {

        public Axe(string Name, int DMG_MIN, int DMG_MAX, double Speed, int DropChanse, int Level, string BackgroundURL)
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            base.Type = (int)Type_Value.Axe;
            base.DMG_TYPE_Text = DMG_TYPE_TEXT_Value.Magiczne.ToString();
            base.Type_Text = Type_TEXT_Value.Topór.ToString();
        }
    }
}
