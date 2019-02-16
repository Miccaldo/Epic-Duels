using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class StrongerBlow : Skill {

        public StrongerBlow(Brush FirstColor, Brush SecondColor, int DMG_Pct = 150, string Name = "Potężny Atak", int CoolDown_MAX = 2, int Duration = 0, string DiseaseType = "brak")
            : base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
