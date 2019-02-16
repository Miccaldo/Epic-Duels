using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.LOCATION;
using System.Windows.Controls;

namespace EpicDuels.Class.SELECT {

    public class SelectEnemy : Select {

        private int index;

        public override void SelectMetod(Hero hero, Location location, ClassArgs args) {

            if (hero.BuffSelect is true || hero.AoESelect is true)
                Counter = 0;
            else {
                base.SelectMetod(hero, location, args);
            }
            //game.debager.Text += $"\n{hero.BuffSelect}";
        }

        protected override void Mark(Hero hero) {

            if (hero.BuffSelect is false) {
                base.Mark(hero);
                game.AttackButton.IsEnabled = true;
            }
        }

        protected override void DeselectPreviousSelection(Hero _hero, Location location) {

            ChooseEnemyBorderColor(BorderList[SelectFlag], location.EnemyList[SelectFlag]);
            game.AttackButton.IsEnabled = false;
        }

        protected override void DeselectEverything(Hero hero, Location location) {
            foreach (Border border in location.EnemyBorderList) {
                ChooseEnemyBorderColor(border, location.EnemyList[index]);
                index++;
            }
            index = 0;
        }

        protected override void ControlSelect(Hero hero, Location location, ClassArgs args) {

            BorderList = location.EnemyBorderList;

            Counter++;
            if (Counter == 1 && BorderList[SelectFlag].BorderBrush == SelectColor && hero.AoESelect is false) {
                DeselectPreviousSelection(hero, location);
            } else {
                DeselectEverything(hero, location);
                if (Counter >= 1) {
                    Mark(hero);
                } else {
                    game.AttackButton.IsEnabled = false;
                    if (args.EnemyTurn is false && hero.Stun is true)
                        game.AttackButton.IsEnabled = true;
                }
                Counter = 0;
            }
        }

        public void Refresh(Location location, ClassArgs args) {

            if(location.EnemyList[SelectFlag].BuffStart is true) {
                ChooseEnemyBorderColor(BorderList[SelectFlag], location.EnemyList[SelectFlag]);
            }
        }

        public SelectEnemy(Game game)
            : base(game) {

            SelectColor = Brushes.Red;
            DeselectColor = Brushes.Black;
        }
    }
}
