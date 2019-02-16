using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.IceLand {

    public class IceDragon : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private Burn fireBreath = new Burn(Brushes.Orange, Brushes.OrangeRed, 150, "Ognisty Oddech");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                fireBreath,
            };

            return list;
        }

        public IceDragon(double HP = 126, int level = 4, int NumberAttacks_MAX = 2, int kp = 40, int HitChanse = 35, int dmgMIN = 12, int dmgMAX = 25, int ExperienceDrop = 10000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Lodowy Smok";
            base.BackgroundURL = "Images/Enemy/IceLand/iceDragon.jpg";
            base.BorderColor = Brushes.Gold;
            base._TargetBorderColor = Brushes.Gold;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
