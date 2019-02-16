using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.ENEMY.IceLand;
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

    public class IceLand : Location {

        public override List<string> BackgroundList() {

            List<string> list = new List<string>();

            list.Add("Images/Location/IceLand/1.jpg");
            list.Add("Images/Location/IceLand/2.jpg");
            list.Add("Images/Location/IceLand/3.jpg");

            return list;
        }

        public override List<Enemy> TargetListOfEnemies() {

            List<Enemy> list = new List<Enemy>();

            if (Map.DifficultyLevel == 2) {
                list.Add(new Kobold());
                list.Add(new LessIce());
                list.Add(new IceWolf());
                list.Add(new GlacierDriade());
                list.Add(new IceGolem());
                list.Add(new IceElemental());
                list.Add(new IceDragon());
            } else {
                list.Add(new Kobold(5, 1, 1, 20, 6, 1, 4, 150));
                list.Add(new LessIce(3, 1, 2, 18, 3, 1, 2, 100));
                list.Add(new IceWolf(12, 2, 2, 24, 8, 2, 5, 200));
                list.Add(new GlacierDriade(7, 2, 1, 25, 12, 3, 4, 300));
                list.Add(new IceGolem(20, 3, 1, 26, 20, 4, 12, 500));
                list.Add(new IceElemental(16, 3, 2, 28, 25, 5, 7, 350));
                list.Add(new IceDragon(54, 4, 1, 32, 30, 5, 15, 1000));
            }

            return list;
        }

        public IceLand(int level = 1, string name = "Lodowa Kraina")
            : base(level, name) {

            if (Map.DifficultyLevel == 1) {

                WeaponList.Add(new Sword("Żelazny Miecz", 1, 4, 1.0, 60, 1, "Images/Equipment/Weapon/Lv1/Sword_Lv1.png"));
                WeaponList.Add(new Spear("Drewniana Włócznia", 1, 6, 0.8, 60, 1, "Images/Equipment/Weapon/Lv1/Spear_Lv1.png"));
                WeaponList.Add(new Mace("Żelazna Buława", 2, 3, 0.8, 60, 1, "Images/Equipment/Weapon/Lv1/Mace_Lv1.png"));

                WeaponList.Add(new Sword("Stalowy Miecz", 3, 5, 1.0, 60, 2, "Images/Equipment/Weapon/Lv2/Sword_Lv2.png"));
                WeaponList.Add(new Spear("Włócznia +1", 2, 7, 0.8, 60, 2, "Images/Equipment/Weapon/Lv2/Spear_Lv2.png"));
                WeaponList.Add(new Mace("Cep Bojowy", 2, 5, 0.5, 60, 2, "Images/Equipment/Weapon/Lv2/Mace_Lv2.png"));

                WeaponList.Add(new Sword("Katana", 4, 7, 1.0, 40, 3, "Images/Equipment/Weapon/Lv3/Sword_Lv3.png"));
                WeaponList.Add(new Spear("Włócznia +2", 2, 9, 0.8, 40, 3, "Images/Equipment/Weapon/Lv3/Spear_Lv3.png"));
                WeaponList.Add(new Mace("Stalowa Buława", 3, 7, 0.5, 40, 3, "Images/Equipment/Weapon/Lv3/Mace_Lv3.png"));

                WeaponList.Add(new WrathOfWinter("Gniew Zimy", 6, 10));
                WeaponList.Add(new IceIcicle("Lodowy Sopel", 3, 6));
                WeaponList.Add(new IceGem("Klejnot Lodu", 5, 9));

            } else {
                WeaponList.Add(new Sword("Elficki Miecz", 5, 6, 1.0, 40, 1, "Images/Equipment/Weapon/Lv4/Sword_Lv4.png"));
                WeaponList.Add(new Spear("Elficka Włócznia", 3, 7, 0.8, 40, 1, "Images/Equipment/Weapon/Lv4/Spear_Lv4.png"));
                WeaponList.Add(new Hammer("Młot Bojowy", 1, 14, 0.8, 30, 1, "Images/Equipment/Weapon/Lv4/Hammer_Lv4.png"));

                WeaponList.Add(new Sword("Adamantowy miecz", 4, 11, 1.0, 40, 2, "Images/Equipment/Weapon/Lv5/Sword_Lv5.png"));
                WeaponList.Add(new Spear("Adamantowa Włócznia", 3, 14, 0.8, 40, 2, "Images/Equipment/Weapon/Lv5/Spear_Lv5.png"));
                WeaponList.Add(new Hammer("Młot Bojowy +1", 1, 20, 0.5, 40, 2, "Images/Equipment/Weapon/Lv5/Hammer_Lv5.png"));

                WeaponList.Add(new Sword("Dwemerowy Miecz", 8, 13, 1.0, 40, 3, "Images/Equipment/Weapon/Lv6/Sword_Lv6.png"));
                WeaponList.Add(new Spear("Dwemerowa Włócznia", 4, 16, 0.8, 40, 3, "Images/Equipment/Weapon/Lv6/Spear_Lv6.png"));
                WeaponList.Add(new Hammer("Dwemerowy Młot", 2, 24, 0.5, 40, 3, "Images/Equipment/Weapon/Lv6/Hammer_Lv6.png"));

                WeaponList.Add(new WrathOfWinter());
                WeaponList.Add(new IceIcicle());
                WeaponList.Add(new IceGem());
            }
        }
    }
}
