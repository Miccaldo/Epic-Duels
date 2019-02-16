using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.MagicForest {

    public class Bandit : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                poison,
            };

            return list;
        }

        public Bandit(double HP = 7, int level = 2, int NumberAttacks_MAX = 2, int kp = 20, int HitChanse = 5, int dmgMIN = 2, int dmgMAX = 4, int ExperienceDrop = 200, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Bandyta";
            base.BackgroundURL = "Images/Enemy/MagicForest/thief.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
