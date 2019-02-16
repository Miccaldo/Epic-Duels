using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.LOCATION;

namespace EpicDuels.Class.SELECT {

    public class SelectWeapon : Select {

        protected override void Mark(Hero hero) {
            base.Mark(hero);
            hero.selectWeaponIndex = SelectFlag + 1;
            AssignHeroDMG(hero, SelectFlag + 1);
        }

        protected override void DeselectEverything(Hero hero, Location location) {
            base.DeselectEverything(hero, location);

            hero.selectWeaponIndex = 0;
            AssignHeroDMG(hero, 0);
        }

        protected override void DeselectPreviousSelection(Hero hero, Location location) {
            base.DeselectPreviousSelection(hero, location);

            hero.selectWeaponIndex = 0;
            AssignHeroDMG(hero, 0);
        }

        private void AssignHeroDMG(Hero hero, int value) {
            if (hero.equipment.AssignedWeaponDic.ContainsKey(value) is true) {
                hero.DMG_MIN = hero.equipment.AssignedWeaponDic[value].DMG_MIN + hero.equipment.AssignedWeaponDic[value].FeatureMetod(hero);    // 0 - Melee, 1, 2, 3 - Assigned Weapons
                hero.DMG_MAX = hero.equipment.AssignedWeaponDic[value].DMG_MAX + hero.equipment.AssignedWeaponDic[value].FeatureMetod(hero);
            }
        }

        public SelectWeapon(Game game)
            : base(game) {

            SelectColor = Brushes.Green;
            DeselectColor = Brushes.Black;

            BorderList.Add(game.EQslotBORDER_1);
            BorderList.Add(game.EQslotBORDER_2);
            BorderList.Add(game.EQslotBORDER_3);
            BorderList.Add(game.EQslotBORDER_4);
        }
    }
}
