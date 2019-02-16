using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class SpiderQueen : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen);
        private BloodSucking bloodSucking = new BloodSucking(Brushes.DarkSlateGray, Brushes.Silver);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                poison,
                bloodSucking,
            };

            return list;
        }

        public SpiderQueen(double HP = 122, int level = 3, int NumberAttacks_MAX = 3, int kp = 44, int HitChanse = 45, int dmgMIN = 10, int dmgMAX = 24, int ExperienceDrop = 24000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Pajęcza Królowa";
            base.BackgroundURL = "Images/Enemy/Cemetary/spiderQueen.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
