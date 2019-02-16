using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class Hydra : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Amok amok = new Amok(Brushes.Tomato, Brushes.Red);
        StrongerBlow powerfulBlow = new StrongerBlow(Brushes.Sienna, Brushes.Maroon, 150, "Potężny Cios");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                amok,
                powerfulBlow,
            };

            return list;
        }

        public Hydra(double HP = 174, int level = 4, int NumberAttacks_MAX = 3, int kp = 54, int HitChanse = 46, int dmgMIN = 10, int dmgMAX = 20, int ExperienceDrop = 20000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Hydra";
            base.BackgroundURL = "Images/Enemy/Cave/hydra.jpg";
            base.BorderColor = Brushes.Gold;
            base._TargetBorderColor = Brushes.Gold;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
