using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.FieryLands {

    public class FieryLizard : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Slow slow = new Slow(Brushes.Sienna, Brushes.Maroon, 0, "Spowolnienie");
        private Burn burn = new Burn(Brushes.Orange, Brushes.OrangeRed, 50, "Poparzenie");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                burn,

            };

            return list;
        }

        public FieryLizard(double HP = 140, int level = 2, int NumberAttacks_MAX = 2, int kp = 38, int HitChanse = 38, int dmgMIN = 22, int dmgMAX = 26, int ExperienceDrop = 34000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ognisty Jaszczur";
            base.BackgroundURL = "Images/Enemy/FieryLands/fieryLizard.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
