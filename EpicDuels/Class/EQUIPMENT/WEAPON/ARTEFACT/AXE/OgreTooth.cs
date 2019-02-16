using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE {

    public class OgreTooth : Axe {

        protected override void GetHeroFeature(Hero hero) {
            base.HeroFeature = hero.Strength;
        }

        public OgreTooth(string Name = "Ząb Ogra", int DMG_MIN = 32, int DMG_MAX = 40, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/CV_Artefact/CaveAxe_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Slow = true;
            Stun = true;

            FeaturesDescribe = $"- Bonus: Siła {Environment.NewLine}" +
                               $"- Spowolnienie 20% szans. {Environment.NewLine}" +
                               $"- Ogłuszenie 20% szans. ";
        }
    }
}
