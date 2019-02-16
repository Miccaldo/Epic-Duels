using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.EQUIPMENT;
using System.Windows;
using System.Windows.Controls;
using EpicDuels.Class.LOCATION;
using EpicDuels.Class.EQUIPMENT.WEAPON;

namespace EpicDuels.Class.SELECT {

    public class SelectWeaponAssignment : SelectWeapon {

        private List<TextBlock> textBlockList = new List<TextBlock>();
        private List<Grid> gridList = new List<Grid>();

        private int index;
        private EQslot eqSlot;
        public bool AssignWeapon { get; set; }

        protected override void Mark(Hero hero) {
            base.Mark(hero);
            eqSlot = new EQslot(hero.equipment.weaponList[game.selectWeaponListIndex], gridList[SelectFlag]);
            textBlockList[SelectFlag].Visibility = Visibility.Hidden;
            AssignWeapon = true;
        }

        protected override void DeselectEverything(Hero hero, Location location) {

            base.DeselectEverything(hero, location);
            
            foreach(Grid grid in gridList) {

                index += 1;
                if (hero.equipment.AssignedWeaponDic.ContainsKey(index) is true) {      // Jeśli słownik w ogóle ma jakiś element
                    //eqSlot = new EQslot(hero.equipment.AssignedWeaponDic[index], gridList[SelectFlag]);
                } else {
                    textBlockList[index - 1].Visibility = Visibility.Visible;
                    AssignWeapon = false;
                    gridList[index - 1].DataContext = null;
                }
            }
            index = 0;
            AssignWeapon = false;
        }

        public void UpdateAssignWeapons(Hero hero) {

            int index = 0;

            while(index < 4) {

                if (hero.equipment.AssignedWeaponDic.ContainsKey(index + 1) is true)
                    eqSlot = new EQslot(hero.equipment.AssignedWeaponDic[index + 1], gridList[index]);

                index++;
            }
        }

        protected override void DeselectPreviousSelection(Hero hero, Location location) {
            base.DeselectPreviousSelection(hero, location);

            if(hero.equipment.AssignedWeaponDic.ContainsKey(SelectFlag + 1) is true)
                eqSlot = new EQslot(hero.equipment.AssignedWeaponDic[SelectFlag + 1], gridList[SelectFlag]);
            else {
                eqSlot.Clear(gridList[SelectFlag]);
            }
            textBlockList[SelectFlag].Visibility = Visibility.Visible;
            AssignWeapon = false;
        }

        public override void DeselectAll(Hero hero, Location location) {
            DeselectEverything(hero, location);

            foreach (KeyValuePair<int, Weapon> entry in hero.equipment.AssignedWeaponDic.Where(x => x.Key > 0)) {
                if (!(hero.equipment.weaponList.Any(x => x.Name == entry.Value.Name))) {
                    gridList[entry.Key - 1].DataContext = null;
                }
            }

            foreach (TextBlock textBlock in textBlockList) {
                textBlock.Visibility = Visibility.Hidden;
            }
            index = 0;
            AssignWeapon = false;
            hero.equipment.AssignFlag = false;
        }

        public SelectWeaponAssignment(Game game)
            : base(game) {

            //this.hero = hero;

            textBlockList.Add(game.AssignEQSlot_1);
            textBlockList.Add(game.AssignEQSlot_2);
            textBlockList.Add(game.AssignEQSlot_3);
            textBlockList.Add(game.AssignEQSlot_4);

            gridList.Add(game.EQslotGRID_1);
            gridList.Add(game.EQslotGRID_2);
            gridList.Add(game.EQslotGRID_3);
            gridList.Add(game.EQslotGRID_4);
        }
    }
}
