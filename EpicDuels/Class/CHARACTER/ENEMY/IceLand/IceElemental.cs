using EpicDuels.Class.CHARACTER.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class IceElemental : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
            };

            return list;
        }

        public IceElemental(double HP = 34, int level = 3, int NumberAttacks_MAX = 2, int kp = 33, int HitChanse = 30, int dmgMIN = 10, int dmgMAX = 12, int ExperienceDrop = 4100, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Żywiołak lodu";
            base.BackgroundURL = "Images/Enemy/IceLand/iceElemental.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
