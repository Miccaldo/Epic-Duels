using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.FieryLands {

    public class FireElemental : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Burn fireStrike = new Burn(Brushes.Orange, Brushes.OrangeRed, 200, "Uderzenie Ognia");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                fireStrike,
            };

            return list;
        }

        public FireElemental(double HP = 121, int level = 2, int NumberAttacks_MAX = 1, int kp = 40, int HitChanse = 50, int dmgMIN = 22, int dmgMAX = 28, int ExperienceDrop = 37000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Żywiołak Ognia";
            base.BackgroundURL = "Images/Enemy/FieryLands/fireElemental.png";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
