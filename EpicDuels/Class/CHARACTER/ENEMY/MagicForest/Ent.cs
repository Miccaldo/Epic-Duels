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

    public class Ent : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.stab;

        private StrongerBlow crush = new StrongerBlow(Brushes.DarkSlateGray, Brushes.Black, 150, "Zgniecenie");
        private Slow entangling = new Slow(Brushes.ForestGreen, Brushes.DarkOliveGreen, 50, "Oplątanie");
        private Cure callOfNature = new Cure(Brushes.Green, Brushes.ForestGreen,0,3,0,"brak","Zew Natury");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                crush,
                entangling,
                callOfNature,
            };

            return list;
        }

        public Ent(double HP = 52, int level = 4, int NumberAttacks_MAX = 1, int kp = 20, int HitChanse = 20, int dmgMIN = 5, int dmgMAX = 15, int ExperienceDrop = 1000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Ent";
            base.BackgroundURL = "Images/Enemy/MagicForest/ent.jpg";
            base.BorderColor = Brushes.Gold;
            base._TargetBorderColor = Brushes.Gold;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
