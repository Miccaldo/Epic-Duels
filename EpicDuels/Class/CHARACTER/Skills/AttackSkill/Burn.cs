using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class Burn : Skill {

        private const int BURN_CHANSE = 100;


        public override bool BurnChanse(Random random) {

            int RandomValue = random.Next(0, 100 + 1);

            if (BURN_CHANSE >= RandomValue)
                BurnChanseFlag = true;
            else {
                BurnChanseFlag = false;
            }

            return base.BurnChanse(random);
        }

        public Burn(Brush FirstColor, Brush SecondColor, int DMG_Pct = 50, string Name = "Poparzenie", int CoolDown_MAX = 3, int Duration = 2, string DiseaseType = "Poison")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Burn = true;
            BurnDMG_Pct = -50;
            base.Path = "Sounds/Attack/flame.wav";
        }
    }
}
