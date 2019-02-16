using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.LOCATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicDuels.Class.SELECT {

    public abstract class Select {

        public List<Border> BorderList = new List<Border>();
        protected Brush SelectColor;
        protected Brush DeselectColor;
        public int SelectFlag { get; set; }
        public int Counter { get; set; }
        protected Game game;

        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();


        protected virtual void ControlSelect(Hero hero, Location location, ClassArgs args) {

            Counter++;
            if (Counter == 1 && BorderList[SelectFlag].BorderBrush == SelectColor) {
                DeselectPreviousSelection(hero, location);
            } else {
                DeselectEverything(hero, location);
                if (Counter >= 1)
                    Mark(hero);

                Counter = 0;
            }
        }

        protected void ChooseEnemyBorderColor(Border border, Enemy enemy) {

            if (enemy.BuffSkill is false)
                border.BorderBrush = enemy._TargetBorderColor;
            else {
                border.BorderBrush = enemy.BorderBuffColor;
            }
        }

        protected virtual void DeselectPreviousSelection(Hero hero, Location location) {

            BorderList[SelectFlag].BorderBrush = DeselectColor;
        }

        protected virtual void Mark(Hero hero) {

            Click.Play();

            BorderList[SelectFlag].BorderBrush = SelectColor;
        }

        protected virtual void DeselectEverything(Hero hero, Location location) {

            foreach (Border border in BorderList) {
                border.BorderBrush = DeselectColor;
            }
        }

        public virtual void SelectMetod(Hero hero, Location location, ClassArgs args) {

            Click.Play();
            ControlSelect(hero, location, args);
        }

        public virtual void DeselectAll(Hero hero, Location location) {

            DeselectEverything(hero, location);
        }

        public Select(Game game) {

            this.game = game;
            Click.SoundLocation = "Sounds/Click/click.wav";
        }
    }
}
