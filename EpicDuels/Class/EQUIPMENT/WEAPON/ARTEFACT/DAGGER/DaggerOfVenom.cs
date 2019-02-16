using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicDuels.Class.CHARACTER.Hero;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER {

    public class DaggerOfVenom : Dagger{

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Agility;
        }

        public DaggerOfVenom(string Name = "Sztylet Jadu", int DMG_MIN = 3, int DMG_MAX = 5, double Speed = 1.5, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/MF_Artefact/MagicForestDagger_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Poison = true;
            FeaturesDescribe = $"- Bonus: Zręczność {Environment.NewLine}" +
                   $"- Trucizna 20% szans. ";

        }
    }
}
