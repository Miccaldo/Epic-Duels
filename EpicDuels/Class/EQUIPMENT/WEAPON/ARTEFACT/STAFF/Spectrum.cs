using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.STAFF {

    public class Spectrum : Staff {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Intelligence;
        }

        public Spectrum(string Name = "Widmo", int DMG_MIN = 14, int DMG_MAX = 28, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/CM_Artefact/Level_4/CemetaryStaff_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            BloodSucking = true;
            Burn = true;

            FeaturesDescribe = $"- Bonus: Inteligencja {Environment.NewLine}" +
                               $"- Poparzenie 20% szans {Environment.NewLine}" +
                               $"- Wysysanie 20% szans.";
        }
    }
}
