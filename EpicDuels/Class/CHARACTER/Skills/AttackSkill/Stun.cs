using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class Stun : Skill {

        public Stun(Brush FirstColor, Brush SecondColor, int DMG_Pct = 50, string Name = "Ogłuszający Cios", int CoolDown_MAX = 3, int Duration = 2, string DiseaseType = "Stun")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Stun = true;
            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
