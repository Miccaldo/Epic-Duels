using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class UndeadMinotaur : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        private Stun deafeningBlow = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Omdlenie");

        public override List<Skill> SkillList() {      

        List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                deafeningBlow,
            };

            return list;
        }

        public UndeadMinotaur(double HP = 108, int level = 2, int NumberAttacks_MAX = 2, int kp = 38, int HitChanse = 55, int dmgMIN = 15, int dmgMAX = 25, int ExperienceDrop = 11000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Minotaur";
            base.BackgroundURL = "Images/Enemy/Cemetary/Minotaur.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
