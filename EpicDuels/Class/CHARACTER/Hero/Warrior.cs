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
using System.Windows;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Hero {

    public class Warrior : Hero {

        public override bool LevelUp(System.Random random, ClassArgs args) {

            if (Experience >= Experience_MAX) {

                Avans.Play();

                double expDifference = Experience - Experience_MAX;

                Level += 1;
                Experience_MAX = Experience_MAX * 2;

                AddFeatures(random);
                AddSkills(args, this.Level);

                this.Experience = expDifference;
                base.HP = base.HP_MAX;
                base.KP = base.KP_MAX;
                base.HitChanse = base._HitChanse_MAX;
                base.cyclicDisease.Enable = false;
                base.Stun = false;
                base.NumberAttacks = base.NumberAttacks_MAX;

                foreach(Skill skill in SkillList()) {
                    skill.CoolDown = 0;
                }

                return true;
            } else
                return false;

        }

        public override void AddFeatures(Random random) {

            int randomHP = 0;
            randomHP = random.Next(1, 14 + 1);
            HP_MAX += randomHP + Endurance;

            Strength += 2;
            Endurance += 2;
            Agility += 1;
            Intelligence += 1;

            NumberAttacks_MAX = (1 + Agility / 16);
            _NumberAttacks_MAX = NumberAttacks_MAX;

            KP_MAX = 20 + Endurance / 4 + Agility / 4;

            _HitChanse_MAX = 10 + Strength / 4;
        }


        public override void AddSkills(ClassArgs args, int Level) {

            if (Level == 1 || Level == 3 || Level == 5 || Level == 7 || Level == 9)
                NewSkill = SkillList()[0].Name;
            else if (Level == 2) {
                NewSkill = SkillList()[1].Name;
                args.borderListSkillIndex = 0;
            } else if (Level == 4) {
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

        private StrongerBlow powerfulAttack = new StrongerBlow(Brushes.DarkSlateGray, Brushes.LightGray);
        private Stun deafeningBlow= new Stun(Brushes.DarkSlateGray, Brushes.LightGray, 50, "Ogłuszający Cios", 3, 2);
        private AoE whirl = new AoE(Brushes.DarkSlateGray, Brushes.LightGray, 200);
        private Amok Amok = new Amok(Brushes.Tomato, Brushes.Red);

        private Heal heal = new Heal(Brushes.Green, Brushes.DarkGreen);
        private Poison poison = new Poison(Brushes.Green, Brushes.LimeGreen, 50, "Zatrucie");

        private Cure cure = new Cure(Brushes.Green, Brushes.DarkGreen);

        private Slow entangling = new Slow(Brushes.ForestGreen, Brushes.DarkOliveGreen, 50, "Oplątanie", 2, 2);



        public override List<Skill> SkillList() {

            List<Skill> list = new List<Skill>() {

                base.NormalAttack,
                powerfulAttack,
                deafeningBlow,
                whirl,
                Amok,
            };

            return list;
        }


        public Warrior(double HP = 20, int level = 1, int NumberAttacks_MAX = 1, int KP_MAX = 20, int HitChanse = 20)
            : base(HP, level, NumberAttacks_MAX, KP_MAX, HitChanse) {

            base.HeroClassName = "Wojownik";
            base._TargetBorderColor = Brushes.Black;
        }
    }
}
