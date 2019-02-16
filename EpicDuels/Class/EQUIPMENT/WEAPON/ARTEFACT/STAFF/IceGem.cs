using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.STAFF {

    public class IceGem : Staff {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Intelligence;
        }

        public IceGem(string Name = "Klejnot Lodu", int DMG_MIN = 7, int DMG_MAX = 17, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/IL_Artefact/IceLandStaff_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Stun = true;

            FeaturesDescribe = $"- Bonus: Inteligencja {Environment.NewLine}" +
                               $"- Ogłuszenie 20% szans.";
        }
    }
}
