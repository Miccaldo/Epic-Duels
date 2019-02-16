using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE {

    public class Flame : Axe {

        protected override void GetHeroFeature(Hero hero) {
            base.HeroFeature = hero.Strength;
        }

        public Flame(string Name = "Płomień", int DMG_MIN = 1, int DMG_MAX = 1, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/CM_Artefact/CemetaryAxe_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Burn = true;
            BloodSucking = true;

            FeaturesDescribe = $"- Bonus: Siła {Environment.NewLine}" +
            $"- Wysysanie 20% szans. {Environment.NewLine}" +
            $"- Poprzenie 20% szans. ";
        }
    }
}
