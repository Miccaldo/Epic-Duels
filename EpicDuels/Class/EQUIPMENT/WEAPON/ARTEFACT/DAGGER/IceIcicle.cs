using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER {

    public class IceIcicle : Dagger {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Agility;
        }

        public IceIcicle(string Name = "Lodowy Sopel", int DMG_MIN = 6, int DMG_MAX = 11, double Speed = 1.5, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/IL_Artefact/IceLandDagger_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Stun = true;

            FeaturesDescribe = $"- Bonus: Zręczność {Environment.NewLine}" +
                   $"- Ogłuszenie 20% szans. ";
        }
    }
}
