using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using EpicDuels.Class.EQUIPMENT;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Hero {

    public class Mage : Hero {

        public override bool LevelUp(System.Random random, ClassArgs args) {

            if (Experience >= Experience_MAX) {

                Avans.Play();

                double expDifference = Experience - Experience_MAX;

                Level += 1;
                Experience_MAX = Experience_MAX * Level;

                AddFeatures(random);
                AddSkills(args, this.Level);

                this.Experience = expDifference;
                base.HP = base.HP_MAX;
                base.cyclicDisease.Enable = false;
                base.Stun = false;
                base.NumberAttacks = base.NumberAttacks_MAX;

                foreach (Skill skill in SkillList()) {
                    skill.CoolDown = 0;
                }

                return true;
            } else
                return false;
        }

        public override void AddFeatures(Random random) {

            int randomHP = 0;
            randomHP = random.Next(1, 10 + 1);
            HP_MAX += randomHP + Endurance;

            Strength += 1;
            Endurance += 1;
            Agility += 1;
            Intelligence += 3;

            NumberAttacks_MAX = (1 + Agility / 16);
            _NumberAttacks_MAX = NumberAttacks_MAX;

            KP_MAX = 20 + Endurance / 2 + Agility / 2;

            _HitChanse_MAX = 6 + Intelligence / 2;
        }

        public override void AddSkills(ClassArgs args, int Level) {

            if (Level == 1 || Level == 4 || Level == 5 || Level == 7 || Level == 9)
                NewSkill = SkillList()[0].Name;
            else if (Level == 2) {
                NewSkill = SkillList()[1].Name;
                args.borderListSkillIndex = 0;
            } else if (Level == 3) {
                NewSkill = SkillList()[2].Name;
                args.borderListSkillIndex = 1;
            } else if (Level == 6) {
                NewSkill = SkillList()[3].Name;
                args.borderListSkillIndex = 2;
            } else if (Level == 8) {
                NewSkill = SkillList()[4].Name;
                args.borderListSkillIndex = 3;
            }
        }


        private StrongerBlow lightning = new StrongerBlow(Brushes.SkyBlue, Brushes.DeepSkyBlue, 150, "Błyskawica", 1);
        private MirrorImage mirrorImage = new MirrorImage(Brushes.RoyalBlue, Brushes.Blue, 0, 4, 2);
        private AoE meteorShower = new AoE(Brushes.Sienna, Brushes.Maroon, 100, "Deszcz Meteorów");
        private Burn flameStrike = new Burn(Brushes.Orange, Brushes.OrangeRed, 300, "Słup Ognia");


        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                lightning,
                mirrorImage,
                meteorShower,
                flameStrike,
            };

            return list;
        }


        public Mage(double HP = 16, int level = 1, int NumberAttacks_MAX = 1, int KP_MAX = 20, int HitChanse = 6)
            : base(HP, level, NumberAttacks_MAX, KP_MAX, HitChanse) {

            base.HeroClassName = "Mag";
            base._TargetBorderColor = Brushes.Black;

            this.lightning.Magic = true;
            this.meteorShower.Magic = true;
            this.flameStrike.Magic = true;

            meteorShower.Path = "Sounds/Attack/meteor.wav";
            lightning.Path = "Sounds/Attack/ligthning.wav";

        }
    }
}
