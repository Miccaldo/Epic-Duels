using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.MagicForest {

    public class Druid : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.slash;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private StrongerBlow lightning = new StrongerBlow(Brushes.SkyBlue, Brushes.DeepSkyBlue, 200, "Błyskawica", 3);
        private Stun blind = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 150, "Oślepienie", 2, 1);


        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                lightning,
                blind,
            };

            return list;
        }

        public Druid(double HP = 11, int level = 3, int NumberAttacks_MAX = 2, int kp = 20, int HitChanse = 10, int dmgMIN = 5, int dmgMAX = 6, int ExperienceDrop = 350, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Druid";
            base.BackgroundURL = "Images/Enemy/MagicForest/druid.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;

            base.Intelligence = 50;
        }
    }
}
