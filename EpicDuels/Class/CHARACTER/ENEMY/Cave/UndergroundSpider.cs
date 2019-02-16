using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY.Cave {

    public class UndergroundSpider : Enemy {

        private const int SENSITIVITY = (int)DMG_TYPE.stab;
        private const int RESISTANCE = (int)DMG_TYPE.slash;

        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                poison,
            };

            return list;
        }


        public UndergroundSpider(double HP = 30, int level = 1, int NumberAttacks_MAX = 2, int kp = 28, int HitChanse = 18, int dmgMIN = 2, int dmgMAX = 10, int ExperienceDrop = 2200, double HPindicator_MAX = 350)
        : base(HP, level, NumberAttacks_MAX, kp, HitChanse, dmgMIN, dmgMAX,ExperienceDrop, HPindicator_MAX) {

            base.Name = "Podziemny Pająk";
            base.BackgroundURL = "Images/Enemy/Cave/spider.jpg";
            base.BorderColor = Brushes.Black;
            base._TargetBorderColor = Brushes.Black;

            base.Sensitivity = SENSITIVITY;
            base.Resistance = RESISTANCE;
        }
    }
}
