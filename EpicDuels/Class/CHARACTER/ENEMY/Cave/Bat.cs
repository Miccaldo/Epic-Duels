using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class Bat : Enemy{

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.crush;

        private BloodSucking bloodSucking = new BloodSucking(Brushes.DarkSlateGray, Brushes.Silver);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                bloodSucking,
            };

            return list;
        }

        public Bat(double HP = 36, int level = 1, int NumberAttacks_MAX = 2, int kp = 34, int HitChanse = 12, int dmgMIN = 5, int dmgMAX = 8, int ExperienceDrop = 1900, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Nietoperz";
            base.BackgroundURL = "Images/Enemy/Cave/bat.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
