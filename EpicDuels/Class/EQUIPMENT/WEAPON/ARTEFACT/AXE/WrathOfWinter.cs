using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE {

    public class WrathOfWinter : Axe {

        protected override void GetHeroFeature(Hero hero) {
            base.HeroFeature = hero.Strength;
        }

        public WrathOfWinter(string Name = "Gniew Zimy", int DMG_MIN = 10, int DMG_MAX = 15, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/IL_Artefact/IceLandAxe_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Stun = true;
            FeaturesDescribe = $"- Bonus: Siła {Environment.NewLine}" +
                   $"- Ogłuszenie 20% szans. ";
        }
    }
}
