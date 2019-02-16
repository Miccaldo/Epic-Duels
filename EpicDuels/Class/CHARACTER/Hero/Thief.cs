using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Hero {

    public class Thief : Hero {

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
            randomHP = random.Next(1, 12 + 1);
            HP_MAX += randomHP + Endurance;

            Strength += 1;
            Endurance += 1;
            Agility += 3;
            Intelligence += 1;

            NumberAttacks_MAX = (2 + Agility / 16);
            _NumberAttacks_MAX = NumberAttacks_MAX;

            KP_MAX = 30 + Endurance / 2 + Agility / 2;

            _HitChanse_MAX = 8 + Strength / 2;
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

        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen, 50, "Zatrucie");
        private Stun blind = new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Oślepienie", 2, 2);
        private StrongerBlow backstab = new StrongerBlow(Brushes.LightGray, Brushes.Black, 500, "Cios w plecy", 4);
        private VampirePower vampirePower = new VampirePower(Brushes.Red, Brushes.Black);

        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                blind,
                poison,
                vampirePower,
                backstab,
            };

            return list;
        }

        public Thief(double HP = 18, int level = 1, int NumberAttacks_MAX = 2, int KP_MAX = 30, int HitChanse = 8)
            : base(HP, level, NumberAttacks_MAX, KP_MAX, HitChanse) {

            base.HeroClassName = "Złodziej";
            base._TargetBorderColor = Brushes.Black;

        }
    }
}