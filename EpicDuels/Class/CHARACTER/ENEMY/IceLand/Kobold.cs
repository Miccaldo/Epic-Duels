using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class Kobold : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        private StrongerBlow frostbite = new StrongerBlow(Brushes.LightCyan, Brushes.LightBlue, 100, "Odmrożenie");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                frostbite,
            };

            return list;
        }

        public Kobold(double HP = 18, int level = 1, int NumberAttacks_MAX = 2, int kp = 26, int HitChanse = 12, int dmgMIN = 2, int dmgMAX = 7, int ExperienceDrop = 1100, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Kobold";
            base.BackgroundURL = "Images/Enemy/IceLand/kobold.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
