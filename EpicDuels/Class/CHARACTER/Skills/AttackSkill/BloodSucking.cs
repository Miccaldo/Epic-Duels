using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class BloodSucking : Skill {

        public BloodSucking(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, string Name = "Wyssanie życia", int CoolDown_MAX = 2, int Duration = 0, string DiseaseType = "brak")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            BloodSucking = true;
            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
