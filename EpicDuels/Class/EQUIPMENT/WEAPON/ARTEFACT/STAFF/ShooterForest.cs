using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.STAFF {

    public class ShooterForest : Staff {

        protected override void GetHeroFeature(Hero hero) {
            HeroFeature = hero.Intelligence;
        }

        public ShooterForest(string Name = "Strzelista Puszcza", int DMG_MIN = 5, int DMG_MAX = 9, double Speed = 1.0, int DropChanse = 100, int Level = 4, string BackgroundURL = @"Images/Equipment/Weapon/MF_Artefact/MagicForestStaff_Lv4.png")
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            Heal = true;
            HealPoints = 20;

            FeaturesDescribe = $"- Bonus: Inteligencja {Environment.NewLine}" +
                               $"- Leczenie 20% szans {Environment.NewLine}" +
                               $"  (+ 20 HP). {Environment.NewLine}";
        }
    }
}
