using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cemetary {

    public class GrimReaper : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private StrongerBlow deathBlow = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray, 200, "Cios śmierci", 4);

        public override List<Skill> SkillList() {


            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                deathBlow,
            };

            return list;
        }

        public GrimReaper(double HP = 130, int level = 3, int NumberAttacks_MAX = 3, int kp = 40, int HitChanse = 50, int dmgMIN = 15, int dmgMAX = 20, int ExperienceDrop = 26000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Kostucha";
            base.BackgroundURL = "Images/Enemy/Cemetary/grimReaper.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
