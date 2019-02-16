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

    public class Ifrit : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Burn fireStrike = new Burn(Brushes.Orange, Brushes.OrangeRed, 200, "Uderzenie Ognia");
        private Cure heat = new Cure(Brushes.Green, Brushes.DarkGreen);
        private Stun blind = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Oślepienie");


        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                fireStrike,
                heat,
                blind,
            };

            return list;
        }

        public Ifrit(double HP = 178, int level = 3, int NumberAttacks_MAX = 3, int kp = 42, int HitChanse = 52, int dmgMIN = 20, int dmgMAX = 25, int ExperienceDrop = 75000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ifrit";
            base.BackgroundURL = "Images/Enemy/FieryLands/ifrit.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
