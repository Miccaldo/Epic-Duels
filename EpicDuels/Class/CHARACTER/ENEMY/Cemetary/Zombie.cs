using EpicDuels.Class.CHARACTER.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class Zombie : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
            };

            return list;
        }

        public Zombie(double HP = 88, int level = 2, int NumberAttacks_MAX = 1, int kp = 20, int HitChanse = 45, int dmgMIN = 16, int dmgMAX = 20, int ExperienceDrop = 8900, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Zombie";
            base.BackgroundURL = "Images/Enemy/Cemetary/zombie.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
