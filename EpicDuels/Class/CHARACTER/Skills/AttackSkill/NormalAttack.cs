using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.AttackSkill {

    public class NormalAttack : Skill {

        public NormalAttack(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, string Name = "brak", int CoolDown_MAX = 0, int Duration = 0, string DiseaseType = "brak")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            base.Path = "Sounds/Attack/hit.wav";
        }
    }
}
