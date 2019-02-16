using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.STAFF {

    public class EarthStaff : Staff {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Intelligence;
        }

        public EarthStaff(string Name = "Laska Ziemi", int DMG_MIN = 26, int DMG_MAX = 50, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/CV_Artefact/CaveStaff_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Slow = true;
            Heal = true;
            HealPoints = 35;

            FeaturesDescribe = $"- Bonus: Inteligencja {Environment.NewLine}" +
                               $"- Leczenie 20% szans {Environment.NewLine}" +
                               $"  (+ 35 HP). {Environment.NewLine}" +
                               $"- Spowolnienie 20% szans.";
        }
    }
}
