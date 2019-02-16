using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class AoE : Skill {

        public AoE(Brush FirstColor, Brush SecondColor, int DMG_Pct = 50, string Name = "Młyniec", int CoolDown_MAX = 3, int Duration = 0, string DiseaseType = "brak")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            AoE = true;
            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
