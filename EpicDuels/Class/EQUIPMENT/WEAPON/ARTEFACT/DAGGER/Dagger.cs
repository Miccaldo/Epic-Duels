using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER {

    public class Dagger : Artefact {

        public Dagger(string Name, int DMG_MIN, int DMG_MAX, double Speed, int DropChanse, int Level, string BackgroundURL)
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            //base.DMG_TYPE = 1;
            base.Type = (int)Type_Value.Dagger;
            base.DMG_TYPE_Text = DMG_TYPE_TEXT_Value.Magiczne.ToString();
            base.Type_Text = Type_TEXT_Value.Sztylet.ToString();
        }
    }
}
