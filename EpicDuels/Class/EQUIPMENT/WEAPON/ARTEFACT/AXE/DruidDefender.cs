using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE {

    public class DruidDefender : Axe {

        protected override void GetHeroFeature(Hero hero) {
            base.HeroFeature = hero.Strength;
        }

        public DruidDefender(string Name = "Obrońca Druidów", int DMG_MIN = 6, int DMG_MAX = 10, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/MF_Artefact/MagicForestAxe_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Heal = true;
            HealPoints = 20;
            FeaturesDescribe = $"- Bonus: Siła {Environment.NewLine}" +
                $"- Leczenie 20% szans {Environment.NewLine}" +
                $"  (+ 20 HP). {Environment.NewLine}";
        }
    }
}
