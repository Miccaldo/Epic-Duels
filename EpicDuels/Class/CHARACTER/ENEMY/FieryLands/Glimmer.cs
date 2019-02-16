using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.FieryLands {

    public class Glimmer : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        private Stun flash = new Stun(Brushes.Orange, Brushes.OrangeRed, 0, "Rozbłysk", 2, 1);
        private Cure heat = new Cure(Brushes.Green, Brushes.DarkGreen);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                flash,
                heat,
            };

            return list;
        }

        public Glimmer(double HP = 84, int level = 1, int NumberAttacks_MAX = 2, int kp = 42, int HitChanse = 45, int dmgMIN = 15, int dmgMAX = 15, int ExperienceDrop = 15000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ognik";
            base.BackgroundURL = "Images/Enemy/FieryLands/glimmer.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
