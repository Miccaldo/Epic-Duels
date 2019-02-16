using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.ENEMY.MagicForest;
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

    public class MagicForest : Location {

        public override List<string> BackgroundList() {

            List<string> list = new List<string>();

            list.Add("Images/Location/MagicForest/1.jpg");
            list.Add("Images/Location/MagicForest/2.jpg");
            list.Add("Images/Location/MagicForest/3.jpg");

            return list;
        }

        public override List<Enemy> TargetListOfEnemies() {

            List<Enemy> list = new List<Enemy>();

            if (Map.DifficultyLevel == 1) {

                list.Add(new Wolf());
                list.Add(new Spider());
                list.Add(new Bandit());
                list.Add(new Bear());
                list.Add(new Druid());
                list.Add(new Unicorn());
                list.Add(new Ent());
            } else {
                list.Add(new Wolf(24, 1, 1, 26, 15, 4, 8, 1400));
                list.Add(new Spider(16, 1, 2, 22, 12, 2, 10, 1100));
                list.Add(new Bandit(40, 2, 2, 30, 20, 5, 9, 3000));
                list.Add(new Bear(54, 2, 2, 26, 22, 8, 15, 3300));
                list.Add(new Druid(45, 3, 2, 28, 30, 5, 10, 4100));
                list.Add(new Unicorn(58, 3, 3, 36, 26, 4, 16, 5400));
                list.Add(new Ent(101, 4, 2, 40, 35, 12, 25, 10000));
            }

            return list;
        }      

        public MagicForest(int level = 1, string name = "Magiczny Las")
            : base(level, name) {

            if (Map.DifficultyLevel == 1) {

                WeaponList.Add(new Sword("Żelazny Miecz", 1, 4, 1.0, 60, 1, "Images/Equipment/Weapon/Lv1/Sword_Lv1.png"));
                WeaponList.Add(new Spear("Drewniana Włócznia", 1, 6, 0.8, 60, 1, "Images/Equipment/Weapon/Lv1/Spear_Lv1.png"));
                WeaponList.Add(new Mace("Żelazna Buława", 2, 3, 0.8, 60, 1, "Images/Equipment/Weapon/Lv1/Mace_Lv1.png"));

                WeaponList.Add(new Sword("Stalowy Miecz", 3, 5, 1.0, 100, 2, "Images/Equipment/Weapon/Lv2/Sword_Lv2.png"));
                WeaponList.Add(new Spear("Włócznia +1", 2, 7, 0.8, 60, 2, "Images/Equipment/Weapon/Lv2/Spear_Lv2.png"));
                WeaponList.Add(new Mace("Cep Bojowy", 2, 5, 0.5, 60, 2, "Images/Equipment/Weapon/Lv2/Mace_Lv2.png"));

                WeaponList.Add(new Sword("Katana", 4, 7, 1.0, 40, 3, "Images/Equipment/Weapon/Lv3/Sword_Lv3.png"));
                WeaponList.Add(new Spear("Włócznia +2", 2, 9, 0.8, 40, 3, "Images/Equipment/Weapon/Lv3/Spear_Lv3.png"));
                WeaponList.Add(new Mace("Stalowa Buława", 3, 7, 0.5, 40, 3, "Images/Equipment/Weapon/Lv3/Mace_Lv3.png"));

                WeaponList.Add(new DruidDefender());
                WeaponList.Add(new DaggerOfVenom());
                WeaponList.Add(new ShooterForest());


            } else {
                WeaponList.Add(new Sword("Elficki Miecz", 5, 6, 1.0, 40, 1, "Images/Equipment/Weapon/Lv4/Sword_Lv4.png"));
                WeaponList.Add(new Spear("Elficka Włócznia", 3, 7, 0.8, 40, 1, "Images/Equipment/Weapon/Lv4/Spear_Lv4.png"));
                WeaponList.Add(new Hammer("Młot Bojowy", 1, 14, 0.8, 40, 1, "Images/Equipment/Weapon/Lv4/Hammer_Lv4.png"));

                WeaponList.Add(new Sword("Adamantowy miecz", 4, 11, 1.0, 40, 2, "Images/Equipment/Weapon/Lv5/Sword_Lv5.png"));
                WeaponList.Add(new Spear("Adamantowa Włócznia", 3, 14, 0.8, 40, 2, "Images/Equipment/Weapon/Lv5/Spear_Lv5.png"));
                WeaponList.Add(new Hammer("Młot Bojowy +1", 1, 20, 0.5, 40, 2, "Images/Equipment/Weapon/Lv5/Hammer_Lv5.png"));

                WeaponList.Add(new Sword("Dwemerowy Miecz", 8, 13, 1.0, 40, 3, "Images/Equipment/Weapon/Lv6/Sword_Lv6.png"));
                WeaponList.Add(new Spear("Dwemerowa Włócznia", 4, 16, 0.8, 40, 3, "Images/Equipment/Weapon/Lv6/Spear_Lv6.png"));
                WeaponList.Add(new Hammer("Dwemerowy Młot", 2, 24, 0.5, 40, 3, "Images/Equipment/Weapon/Lv6/Hammer_Lv6.png"));


                WeaponList.Add(new DruidDefender("Obrońca Druidów", 10, 15));
                WeaponList.Add(new DaggerOfVenom("Sztylet Jadu", 6, 11));
                WeaponList.Add(new ShooterForest("Strzelista Puszcza", 7, 17));
            }
        }
    }
}
