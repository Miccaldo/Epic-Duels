using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.ENEMY {

    public abstract class Enemy : Character {

        public string Name { get; set; }
        public int ExperienceDrop { get; private set; }
        public string BackgroundURL { get; set; }
        public bool NextEnemyEnable { get; set; }

        public int Sensitivity { get; set; } 
        public int Resistance { get; set; }   

                                                                                    
        protected enum DMG_TYPE {
            melee,
            slash,
            crush,
            stab,
            magic,
        }

        public Visibility BossVisibility {
            get {
                if (base.Level == 4)
                    return BossVisibility = Visibility.Visible;
                else {
                    return BossVisibility = Visibility.Hidden;
                }
            }
            private set {; }
        }

        public override void Move(bool diraction) {

            if (diraction is true)
                MarginCharacter = new Thickness(0, 0, TargetMargin + 10, 0);

            else {
                MarginCharacter = new Thickness(0, 0, TargetMargin, 0);
            }
        }

        protected NormalAttack NormalAttack = new NormalAttack(Brushes.DarkSlateGray, Brushes.Black);


        public void RandomSkill(Random random, ClassArgs args, Character character) {

            if (args.EnemyTurn is true) {        // If you are attacking an opponent, randomly choose which skill to choose

                int index = 0;
                bool randomFlag = false;        // This flag forces a draw instead of the index = 0, which is Normal and skips While

                while (!((SkillList()[index].Buff is true && this.NumberAttacks == this.NumberAttacks_MAX) || ((SkillList()[index].Buff is false) && randomFlag is true))) {
                    int randomValue = 0;
                    int randomUpdate = 0;
                    randomFlag = true;

                    for (int i = 0; i < SkillList().Count; i++) {

                        randomValue = random.Next(0, 100 + 1);

                        if (randomValue > randomUpdate && SkillList()[i].CoolDown == 0) {

                            randomUpdate = randomValue;
                            index = i;
                        }
                    }

                    if (character.DiseaseSizeList.Count > 0) {
                        foreach (SkillSize skillSize in character.DiseaseSizeList) {

                            if (SkillList()[index].DiseaseType == skillSize.Name)
                                randomFlag = false;
                        }
                    }
                    this.selectSkillIndex = index;
                }
            }
        }


        public Enemy(double HP, int Level,int NumberAttacks_MAX, int KP, int HitChanse, int dmgMIN, int dmgMAX, int ExperienceDrop, double HPindicator_MAX)
            : base(HP, Level, NumberAttacks_MAX, KP, HitChanse) {


            this.Name = Name;
            this.ExperienceDrop = ExperienceDrop;
            base.HP_MAX = HP_MAX;
            base.MarginCharacter = new Thickness(0, 0, 50, 0);
            base.TargetMargin = 50;
            base.HPindicator_MAX = HPindicator_MAX;

            base.MarginBigSign_Y = 7;
            base.MarginSmallSign_Y = 2;
            base.LeftMarginDiseaseSkill = 3;
            base.LeftSecondMarginDiseaseSkill = 2;

            base.DMG_MIN = dmgMIN;
            base.DMG_MAX = dmgMAX;
        }
    }
}
