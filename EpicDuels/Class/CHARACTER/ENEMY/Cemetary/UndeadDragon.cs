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

    public class UndeadDragon : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.crush;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private VampirePower vampirePower = new VampirePower(Brushes.Red, Brushes.Black, 0, 5, 2);
        private Stun wingBlow = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Uderzenie Skrzydłem");
        private StrongerBlow dragonBlow = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray, 100, "Smoczy Cios", 2);

        public override List<Skill> SkillList() {


            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                vampirePower,
                wingBlow,
                dragonBlow,
            };

            return list;
        }

        public UndeadDragon(double HP = 248, int level = 4, int NumberAttacks_MAX = 3, int kp = 54, int HitChanse = 56, int dmgMIN = 25, int dmgMAX = 50, int ExperienceDrop = 50000, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Nieumarły Smok";
            base.BackgroundURL = "Images/Enemy/Cemetary/undeadDragon.jpg";
            base.BorderColor = Brushes.Gold;
            base._TargetBorderColor = Brushes.Gold;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
