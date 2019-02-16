using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.FieryLands {

    public class NightMare : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private StrongerBlow flamingCharge = new StrongerBlow(Brushes.Orange, Brushes.OrangeRed, 100, "Płomienna Szarża");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                flamingCharge,
            };

            return list;
        }

        public NightMare(double HP = 196, int level = 3, int NumberAttacks_MAX = 2, int kp = 44, int HitChanse = 46, int dmgMIN = 25, int dmgMAX = 30, int ExperienceDrop = 52000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Zmora";
            base.BackgroundURL = "Images/Enemy/FieryLands/nightMare.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
