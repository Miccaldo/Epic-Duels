using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class Poison : Skill {

        public Poison(Brush FirstColor, Brush SecondColor, int DMG_Pct = 50, string Name = "Trucizna", int CoolDown_MAX = 2, int Duration = 3, string DiseaseType = "Poison")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Poison = true;
            PoisonDMG_Pct = -50;
            base.Path = "Sounds/Attack/poison.wav";
        }
    }
}
