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

    public class Phoenix : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Amok burningLust = new Amok(Brushes.Orange, Brushes.OrangeRed, 50, 5, 3, "brak", "Paląca Żądza");
        private Burn carbonization = new Burn(Brushes.Orange, Brushes.OrangeRed, 150, "Zwęglenie");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
            };

            return list;
        }

        public Phoenix(double HP = 402, int level = 4, int NumberAttacks_MAX = 2, int kp = 50, int HitChanse = 50, int dmgMIN = 40, int dmgMAX = 60, int ExperienceDrop = 100000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Feniks";
            base.BackgroundURL = "Images/Enemy/FieryLands/phoenix.jpg";
            base.BorderColor = Brushes.Gold;
            base._TargetBorderColor = Brushes.Gold;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
