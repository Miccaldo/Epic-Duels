using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.MagicForest {

    public class Bear : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private StrongerBlow hittingPaw = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray, 100, "Uderzenie łapą");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                hittingPaw,
            };

            return list;
        }

        public Bear(double HP = 12, int level = 2, int NumberAttacks_MAX = 1, int kp = 16, int HitChanse = 8, int dmgMIN = 3, int dmgMAX = 5, int ExperienceDrop = 300, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Niedźwiedź";
            base.BackgroundURL = "Images/Enemy/MagicForest/bear.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
