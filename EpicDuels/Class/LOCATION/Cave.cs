using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.ENEMY.Cave;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.STAFF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.LOCATION {

    public class Cave : Location {

        public override List<string> BackgroundList() {

            List<string> list = new List<string>();

            list.Add("Images/Location/Cave/1.jpg");
            list.Add("Images/Location/Cave/2.jpg");
            list.Add("Images/Location/Cave/3.jpg");

            return list;
        }

        public override List<Enemy> TargetListOfEnemies() {

            List<Enemy> list = new List<Enemy>();

            if (Map.DifficultyLevel == 3) {
                list.Add(new Bat());
                list.Add(new UndergroundSpider());
                list.Add(new Ogre());
                list.Add(new RockWarrior());
                list.Add(new Observer());
                list.Add(new Horror());
                list.Add(new Hydra());
            } else {
                list.Add(new Bat(56, 1, 2, 38, 30, 8, 15, 6200));
                list.Add(new UndergroundSpider(50, 1, 3, 30, 32, 5, 20, 5800));
                list.Add(new Ogre(106, 2, 2, 38, 35, 12, 20, 11000));
                list.Add(new RockWarrior(82, 2, 3, 50, 39, 10, 20, 14000));
                list.Add(new Observer(132, 3, 1, 44, 58, 26, 38, 26000));
                list.Add(new Horror(121, 3, 3, 46, 50, 12, 22, 24000));
                list.Add(new Hydra(239, 4, 2, 56, 55, 25, 35, 50000));
            }

            return list;
        }

        public Cave(int level = 1, string name = "Mroczna Jaskinia")
            : base(level, name) {

            if(Map.DifficultyLevel == 3) {

                WeaponList.Add(new Sword("Postrach", 10, 12, 1.0, 30, 1, "Images/Equipment/Weapon/Lv7/Sword_Lv7.png"));
                WeaponList.Add(new Spear("Brzytwa", 4, 18, 0.8, 30, 1, "Images/Equipment/Weapon/Lv7/Spear_Lv7.png"));
                WeaponList.Add(new Hammer("Młot Runów", 1, 27, 1.0, 30, 1, "Images/Equipment/Weapon/Lv7/Hammer_Lv7.png"));

                WeaponList.Add(new Sword("Oczyszczacz", 12, 18, 1.0, 30, 2, "Images/Equipment/Weapon/Lv8/Sword_Lv8.png"));
                WeaponList.Add(new Spear("Włócznia Cieni", 5, 24, 0.8, 30, 2, "Images/Equipment/Weapon/Lv8/Spear_Lv8.png"));
                WeaponList.Add(new Mace("Maczuga Ogra", 3, 30, 0.5, 30, 2, "Images/Equipment/Weapon/Lv8/Mace.png"));

                WeaponList.Add(new Sword("Mroczne Ostrze", 15, 20, 1.5, 30, 3, "Images/Equipment/Weapon/Lv9/Sword_Lv9.png"));
                WeaponList.Add(new Spear("Przebijacz", 7, 26, 0.8, 30, 3, "Images/Equipment/Weapon/Lv9/Spear_Lv9.png"));
                WeaponList.Add(new Hammer("Zgniatacz Czaszek", 5, 35, 1.0, 30, 3, "Images/Equipment/Weapon/Lv9/Hammer_Lv9.png"));

                WeaponList.Add(new OgreTooth("Ząb Ogra", 18, 24));
                WeaponList.Add(new StoneSpike("Kamienny Kolec", 9, 13));
                WeaponList.Add(new EarthStaff("Laska Ziemi", 14, 28));
            } else {

                WeaponList.Add(new Sword("Pogromca", 16, 22, 1.0, 30, 1, "Images/Equipment/Weapon/Lv10/Sword_Lv10.png"));
                WeaponList.Add(new Spear("Rozpruwacz", 9, 28, 1.0, 30, 1, "Images/Equipment/Weapon/Lv10/Spear_Lv10.png"));
                WeaponList.Add(new Hammer("Odkupiciel", 7, 40, 1.0, 30, 1, "Images/Equipment/Weapon/Lv10/Hammer_Lv10.png"));

                WeaponList.Add(new Sword("Żądło", 19, 27, 1.5, 30, 2, "Images/Equipment/Weapon/Lv11/Sword_Lv11.png"));
                WeaponList.Add(new Spear("Zwiastun", 8, 34, 1.0, 30, 2, "Images/Equipment/Weapon/Lv11/Spear_Lv11.png"));
                WeaponList.Add(new Hammer("Boski Młot", 5, 48, 1.0, 30, 2, "Images/Equipment/Weapon/Lv11/Hammer_Lv11.png"));

                WeaponList.Add(new Sword("Lodowe Ostrze", 25, 35, 1.5, 30, 3, "Images/Equipment/Weapon/Lv12/Sword_Lv12.png"));
                WeaponList.Add(new Spear("Iglica", 12, 46, 1.0, 30, 3, "Images/Equipment/Weapon/Lv12/Spear_Lv12.png"));
                WeaponList.Add(new Hammer("Furia", 6, 60, 1.0, 30, 3, "Images/Equipment/Weapon/Lv12/Hammer_Lv12.png"));

                WeaponList.Add(new OgreTooth());
                WeaponList.Add(new StoneSpike());
                WeaponList.Add(new EarthStaff());
            }
        }
    }
}
