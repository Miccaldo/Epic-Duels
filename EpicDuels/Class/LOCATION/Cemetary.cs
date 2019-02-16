using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.ENEMY.Cemetary;
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

    public class Cemetary : Location {

        public override List<string> BackgroundList() {

            List<string> list = new List<string>();

            list.Add("Images/Location/Cemetary/1.jpg");
            list.Add("Images/Location/Cemetary/2.jpg");
            list.Add("Images/Location/Cemetary/3.jpg");


            return list;
        }

        public override List<Enemy> TargetListOfEnemies() {

            List<Enemy> list = new List<Enemy>();

            if (Map.DifficultyLevel == 4) {
                list.Add(new Skeleton());
                list.Add(new Ghoul());
                list.Add(new UndeadMinotaur());
                list.Add(new Zombie());
                list.Add(new SpiderQueen());
                list.Add(new GrimReaper());
                list.Add(new UndeadDragon());
            } else {
                list.Add(new Skeleton(32, 1, 2, 28, 30, 3, 10, 1900));
                list.Add(new Ghoul(38, 1, 1, 26, 32, 4, 8, 2300));
                list.Add(new UndeadMinotaur(76, 2, 2, 36, 28, 6, 16, 4800));
                list.Add(new Zombie(52, 2, 1, 16, 34, 12, 18, 4200));
                list.Add(new SpiderQueen(72, 3, 3, 42, 36, 6, 15, 7200));
                list.Add(new GrimReaper(84, 3, 2, 38, 32, 10, 16, 8000));
                list.Add(new UndeadDragon(174, 4, 2, 40, 52, 10, 25));
            }

            return list;
        }

        public Cemetary(int level = 1, string name = "Cmentarz Zapomnienia")
            : base(level, name) {

            if (Map.DifficultyLevel == 3) {
                WeaponList.Add(new Sword("Postrach", 10, 12, 1.0, 30, 1, "Images/Equipment/Weapon/Lv7/Sword_Lv7.png"));
                WeaponList.Add(new Spear("Brzytwa", 4, 18, 0.8, 30, 1, "Images/Equipment/Weapon/Lv7/Spear_Lv7.png"));
                WeaponList.Add(new Hammer("Młot Runów", 1, 27, 1.0, 30, 1, "Images/Equipment/Weapon/Lv7/Hammer_Lv7.png"));

                WeaponList.Add(new Sword("Oczyszczacz", 12, 18, 1.0, 30, 2, "Images/Equipment/Weapon/Lv8/Sword_Lv8.png"));
                WeaponList.Add(new Spear("Włócznia Cieni", 5, 24, 0.8, 30, 2, "Images/Equipment/Weapon/Lv8/Spear_Lv8.png"));
                WeaponList.Add(new Mace("Maczuga Ogra", 3, 30, 0.5, 30, 2, "Images/Equipment/Weapon/Lv8/Mace_Lv8.png"));

                WeaponList.Add(new Sword("Mroczne Ostrze", 15, 20, 1.5, 30, 3, "Images/Equipment/Weapon/Lv9/Sword_Lv9.png"));
                WeaponList.Add(new Spear("Przebijacz", 7, 26, 0.8, 30, 3, "Images/Equipment/Weapon/Lv9/Spear_Lv9.png"));
                WeaponList.Add(new Hammer("Zgniatacz Czaszek", 5, 35, 1.0, 30, 3, "Images/Equipment/Weapon/Lv9/Hammer_Lv9.png"));

                WeaponList.Add(new Flame());
                WeaponList.Add(new LifeThief());
                WeaponList.Add(new Spectrum());

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

                WeaponList.Add(new Flame("Płomień", 32, 40));
                WeaponList.Add(new LifeThief("Złodziej Życia", 16, 26));
                WeaponList.Add(new Spectrum("Widmo", 26, 50));
            }
        }
    }
}
