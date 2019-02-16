using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER {

    public class StoneSpike : Dagger {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Agility;
        }

        public StoneSpike(string Name = "Kamienny Kolec", int DMG_MIN = 16, int DMG_MAX = 26, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/CV_Artefact/CaveDagger_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Heal = true;
            HealPoints = 35;
            Poison = true;

            FeaturesDescribe = $"- Bonus: Zręczność {Environment.NewLine}" +
                $"- Leczenie 20% szans {Environment.NewLine}" +
                $"  (+ 35 HP). {Environment.NewLine}" +
                $"- Trucizna 20% szans.";
        }
    }
}
