using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class Slow : Skill {

        public Slow(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, string Name = "Spowolnienie", int CoolDown_MAX = 2, int Duration = 2, string DiseaseType = "Slow")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Slow = true;
            NumberAttacks_Pct = -50;
            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
