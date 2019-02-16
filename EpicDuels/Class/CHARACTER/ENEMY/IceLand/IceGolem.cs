using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class IceGolem : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private Stun deafeningBlow = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Ogłuszający Cios", 3, 1);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                deafeningBlow,
            };

            return list;
        }

        public IceGolem(double HP = 56, int level = 3, int NumberAttacks_MAX = 1, int kp = 30, int HitChanse = 25, int dmgMIN = 8, int dmgMAX = 22, int ExperienceDrop = 5400, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Lodowy Golem";
            base.BackgroundURL = "Images/Enemy/IceLand/iceGolem.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
