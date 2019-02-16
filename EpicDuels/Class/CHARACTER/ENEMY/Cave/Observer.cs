using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class Observer : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private Stun blind = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Oślepienie");
        private StrongerBlow deadlyBeam = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray, 150, "Zabójczy Promień");

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                deadlyBeam,
                blind,
            };

            return list;
        }

        public Observer(double HP = 86, int level = 3, int NumberAttacks_MAX = 1, int kp = 40, int HitChanse = 56, int dmgMIN = 18, int dmgMAX = 28, int ExperienceDrop = 8000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Obserwator";
            base.BackgroundURL = "Images/Enemy/Cave/observer.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
