using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class LessIce : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private Stun freeze = new Stun(Brushes.LightCyan, Brushes.LightBlue, 50, "Zamrożenie", 3, 1);

        public override List<Skill> SkillList() {


            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                freeze,
            };

            return list;
        }

        public LessIce(double HP = 22, int level = 1, int NumberAttacks_MAX = 1, int kp = 22, int HitChanse = 15, int dmgMIN = 4, int dmgMAX = 8, int ExperienceDrop = 1400, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Pomniejszy Lód";
            base.BackgroundURL = "Images/Enemy/IceLand/Lodzik.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
