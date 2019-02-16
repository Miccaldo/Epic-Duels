using EpicDuels.Class.CHARACTER;
using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT {

    public class Artefact : Weapon {

        public const int CHANSE_TO_EFFECT = 20;

        public bool Poison { get; set; }
        public bool Burn { get; set; }
        public bool Stun { get; set; }
        public bool Slow { get; set; }
        public bool Heal { get; set; }
        public bool BloodSucking { get; set; }

        private const int Duration = 1;
        private const int Slow_Pct = -50;
        private const int CyclicDMG_Pct = -50;

        public int HealPoints { get; set; }

        public bool DiseaseEnable(Random random) {

            int randomValue = random.Next(0, 100 + 1);
            bool value = (CHANSE_TO_EFFECT > randomValue) ? true : false;

            return value;
        }

        public void SlowEnable(Character character) {

            character.SlowDuration = Duration;
            character.NumberAttacks_MAX = character.NumberAttacks_MAX + character.NumberAttacks_MAX * Slow_Pct / 100;
            character.NumberAttacks = character.NumberAttacks_MAX;
        }

        public void StunEnable(Character character) {
            character.StunDuration = Duration;
        }

        public void CyclicDiseaseEnable(CyclicDisease cyclicDisease) {

            cyclicDisease.DMG_Pct = CyclicDMG_Pct;
            cyclicDisease.Duration = Duration;
        }

        public Artefact(string Name, int DMG_MIN, int DMG_MAX, double Speed, int DropChanse, int Level, string BackgroundURL)
            : base(Name, DMG_MIN, DMG_MAX, Speed, DropChanse, Level, BackgroundURL) {

            DMG_TYPE = 4;
            Features = "SPECIAL";
        }
    }
}
