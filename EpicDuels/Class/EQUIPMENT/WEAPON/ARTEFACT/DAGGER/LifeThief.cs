using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER {

    public class LifeThief : Dagger {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Agility;
        }

        public LifeThief(string Name = "Złodziej Życia", int DMG_MIN = 9, int DMG_MAX = 13, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/CM_Artefact/CemetaryDagger_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            BloodSucking = true;
            Poison = true;

            FeaturesDescribe = $"- Bonus: Zręczność {Environment.NewLine}" +
                   $"- Wysysanie 20% szans. {Environment.NewLine}" +
                   $"- Trucizna 20% szans. ";
        }
    }
}
