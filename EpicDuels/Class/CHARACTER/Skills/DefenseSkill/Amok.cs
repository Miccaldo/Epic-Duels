using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.DefenseSkill {

    public class Amok : Skill {

        public Amok(Brush FirstColor, Brush SecondColor, int DMG_Pct = 100, int CoolDown_MAX = 5, int Duration = 3, string DiseaseType = "brak", string Name = "Szał")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Buff = true;
            StunBlock = true;
            NumberAttacks_Pct = 100;
            base.BuffColor = Brushes.Crimson;
            base.BuffFillColor = Colors.Red;
            base.BuffOpacity = 0.4;
            base.Path = "Sounds/Attack/buff.wav";

        }
    }
}
