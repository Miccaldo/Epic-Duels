using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class Skeleton : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        StrongerBlow powerfulAttack = new StrongerBlow(Brushes.Sienna, Brushes.Maroon, 100, "Potężny Atak");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                powerfulAttack,
            };

            return list;
        }

        public Skeleton(double HP = 56, int level = 1, int NumberAttacks_MAX = 2, int kp = 32, int HitChanse = 35, int dmgMIN = 8, int dmgMAX = 18, int ExperienceDrop = 6200, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Szkielet";
            base.BackgroundURL = "Images/Enemy/Cemetary/skeleton.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
