using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.MagicForest {

    public class Wolf : Enemy {

        private const int SENSITIVITY = (int) DMG_TYPE.stab;
        private const int RESISTANCE = (int) DMG_TYPE.crush;

        private StrongerBlow bite = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray, 150, "Ugryzienie", 2);
        private Heal heal = new Heal(Brushes.Green, Brushes.DarkGreen);
        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen, 50, "Zatrucie", 2, 2);
        private Stun blind = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Oślepienie", 2, 1);
        private Cure callOfNature = new Cure(Brushes.Green, Brushes.ForestGreen, 0, 2, 0, "brak", "Zew Natury");

        private Burn fireball = new Burn(Brushes.Orange, Brushes.OrangeRed, 100, "Kula Ognia");

        private Amok amok = new Amok(Brushes.Tomato, Brushes.Red);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

               base.NormalAttack,
               bite,
               //heal,
               //poison,
            };

            return list;
        }

        public Wolf(double HP = 5, int level = 1, int NumberAttacks_MAX = 1, int kp = 20, int HitChanse = 10, int dmgMIN = 1, int dmgMAX = 4, int ExperienceDrop = 150, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Wilk";
            base.BackgroundURL = "Images/Enemy/MagicForest/wolf.jpg";
            base.BorderColor = Brushes.Black;
            _TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
