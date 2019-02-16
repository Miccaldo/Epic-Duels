using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class RockWarrior : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        StrongerBlow stoning = new StrongerBlow(Brushes.Sienna, Brushes.Maroon, 150, "Ukamienowanie");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                stoning,
            };

            return list;
        }

        public RockWarrior(double HP = 54, int level = 2, int NumberAttacks_MAX = 2, int kp = 34, int HitChanse = 24, int dmgMIN = 8, int dmgMAX = 12, int ExperienceDrop = 3500, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Skalny Wojownik";
            base.BackgroundURL = "Images/Enemy/Cave/rockWarrior.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
