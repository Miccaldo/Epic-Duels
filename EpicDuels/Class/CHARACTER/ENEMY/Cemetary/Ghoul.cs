using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class Ghoul : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Poison ghoulTouch = new Poison(Brushes.Green, Brushes.Black, 50, "Dotyk Ghula");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                ghoulTouch,
            };

            return list;
        }

        public Ghoul(double HP = 60, int level = 1, int NumberAttacks_MAX = 1, int kp = 30, int HitChanse = 38, int dmgMIN = 12, int dmgMAX = 15, int ExperienceDrop = 5800, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ghoul";
            base.BackgroundURL = "Images/Enemy/Cemetary/ghoul.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
