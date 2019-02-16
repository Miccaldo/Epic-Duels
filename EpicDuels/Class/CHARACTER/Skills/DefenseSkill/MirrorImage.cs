using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.DefenseSkill {

    public class MirrorImage : Skill {

        public MirrorImage(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, int CoolDown_MAX = 5, int Duration = 3, string DiseaseType = "brak", string Name = "Lustrzane Odbicie")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Buff = true;
            KP_Pct = 100;

            base.BuffColor = Brushes.Blue;
            base.BuffFillColor = Colors.Blue;
            base.BuffOpacity = 0.4;
            base.Path = "Sounds/Attack/buff.wav";
        }
    }
}
