using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.ENEMY.FieryLands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class.LOCATION {

    public class FieryLands : Location {

        public override List<string> BackgroundList() {

            List<string> list = new List<string>();

            list.Add("Images/Location/FieryLands/1.jpg");
            list.Add("Images/Location/FieryLands/2.jpg");
            list.Add("Images/Location/FieryLands/3.jpg");


            return list;
        }

        public override List<Enemy> TargetListOfEnemies() {

            List<Enemy> list = new List<Enemy>();

            list.Add(new Glimmer());
            list.Add(new Tormentor());
            list.Add(new FieryLizard());
            list.Add(new FireElemental());
            list.Add(new NightMare());
            list.Add(new Ifrit());
            list.Add(new Phoenix());

            return list;
        }

        public FieryLands(int level = 1, string name = "Ogniste Ziemie")
            : base(level, name) {

          
        }
    }
}
