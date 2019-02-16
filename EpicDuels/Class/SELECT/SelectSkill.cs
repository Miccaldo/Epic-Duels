using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EpicDuels.Class.LOCATION;
using System.Windows.Controls;
using System.Windows;

namespace EpicDuels.Class.SELECT {

    public class SelectSkill : Select {

        private bool unselectAttackByAoEorBuff = false;
        private int index_1;
        private int index_2;

        public override void SelectMetod(Hero hero, Location location, ClassArgs args) {

            if ((hero.SkillList()[hero.selectSkillIndex].Buff is true || hero.SkillList()[hero.selectSkillIndex].Heal is true) && hero.NumberAttacks != hero.NumberAttacks_MAX)
                args.SelectSkillCnt = 0;
            else {
                base.SelectMetod(hero, location, args);
            }

            GetBuffOrAoE(hero, location);
        }

        protected override void DeselectPreviousSelection(Hero hero, Location location) {

            base.DeselectPreviousSelection(hero, location);
            hero.selectSkillIndex = 0;

            DeselectEnemyAfterAoE(hero, location);
        }

        protected override void DeselectEverything(Hero hero, Location location) {

            base.DeselectEverything(hero, location);

            DeselectEnemyAfterAoE(hero, location);
        }

        private void DeselectEnemyAfterAoE(Hero hero, Location location) {

            if (hero.AoESelect is true) {
                unselectAttackByAoEorBuff = true;
                foreach (Border border in location.EnemyBorderList) {
                    ChooseEnemyBorderColor(border, location.EnemyList[index_1]);
                }
                index_1 = 0;
            } else if (hero.BuffSelect is true)
                unselectAttackByAoEorBuff = true;
            else {
                unselectAttackByAoEorBuff = false;
            }
        }


        private void GetBuffOrAoE(Hero hero, Location location) {

            if ((hero.selectSkillIndex == hero.SkillList().FindIndex(x => (x.Buff is true || x.Heal is true))) && hero.NumberAttacks == hero.NumberAttacks_MAX) {
                hero.BuffSelect = true;
            } else {
                hero.BuffSelect = false;
            }
            if ((hero.selectSkillIndex == hero.SkillList().FindIndex(x => x.AoE is true))) {
                hero.AoESelect = true;
            } else {
                hero.AoESelect = false;
            }
            SelectBuffOrAoE(hero, location);
        }

        private void SelectBuffOrAoE(Hero hero, Location location) {

            if ((hero.BuffSelect is true || hero.AoESelect is true)) {     // Check if the index is different from zero, because if something is selected, it is certainly different from zero
                foreach (Border border in location.EnemyBorderList) {
                    if (hero.BuffSelect is true) {
                        ChooseEnemyBorderColor(border, location.EnemyList[index_2]);
                    } else {
                        if (location.EnemyList[index_2].HP > 0)
                            border.BorderBrush = Brushes.Red;
                    }
                    index_2++;
                }
                index_2 = 0;
                game.AttackButton.IsEnabled = true;
            } else {
                if (unselectAttackByAoEorBuff is true) {
                    game.AttackButton.IsEnabled = false;
                }
            }
        }

        public void UpdateSkill(Hero hero, ClassArgs args) {

            for(int i = 1; i <= hero.Level; i++) {

                hero.AddSkills(args, i);
                if (hero.NewSkillEnabled is true) {
                    BorderList[args.borderListSkillIndex].Visibility = Visibility.Visible;
                    //SkillLabelList[args.borderListSkillIndex].Content = hero.NewSkill;
                }
            }
        }

        public override void DeselectAll(Hero hero, Location location) {

            hero.BuffSelect = false;
            hero.AoESelect = false;
            hero.PreparationSkillCnt = 0;
            hero.selectSkillIndex = 0;
            base.DeselectAll(hero, location);
        }

        public SelectSkill(Game game)
            : base(game) {

            SelectColor = Brushes.Green;
            DeselectColor = Brushes.White;

            BorderList.Add(game.Skill_1);
            BorderList.Add(game.Skill_2);
            BorderList.Add(game.Skill_3);
            BorderList.Add(game.Skill_4);
        }
    }
}
