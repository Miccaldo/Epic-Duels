using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class Ogre : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Slow crump = new Slow(Brushes.Sienna, Brushes.Maroon, 50, "Tąpnięcie");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                crump,
            };

            return list;
        }

        public Ogre(double HP = 76, int level = 2, int NumberAttacks_MAX = 2, int kp = 35, int HitChanse = 25, int dmgMIN = 8, int dmgMAX = 22, int ExperienceDrop = 4800, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ogr";
            base.BackgroundURL = "Images/Enemy/Cave/ogre.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
