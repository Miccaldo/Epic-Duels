using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class Horror : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                poison,
            };

            return list;
        }

        public Horror(double HP = 78, int level = 3, int NumberAttacks_MAX = 3, int kp = 44, int HitChanse = 34, int dmgMIN = 5, int dmgMAX = 20, int ExperienceDrop = 6800, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Horror";
            base.BackgroundURL = "Images/Enemy/Cave/horror.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
