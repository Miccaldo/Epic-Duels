using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class GlacierDriade : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        private Burn fireball = new Burn(Brushes.Orange, Brushes.OrangeRed, 300, "Kula Ognia");
        private Stun freeze = new Stun(Brushes.LightCyan, Brushes.LightBlue, 150, "Zamrożenie", 3, 1);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                fireball,
                freeze,
            };

            return list;
        }

        public GlacierDriade(double HP = 26, int level = 2, int NumberAttacks_MAX = 2, int kp = 33, int HitChanse = 20, int dmgMIN = 3, int dmgMAX = 7, int ExperienceDrop = 3000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Driada Zimy";
            base.BackgroundURL = "Images/Enemy/IceLand/glacierDriade.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
