using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.DefenseSkill {

    public class Heal : Skill {

        public Heal(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, int CoolDown_MAX = 5, int Duration = 3, string DiseaseType = "brak", string Name = "Leczenie")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Buff = true;
            Heal = true;
            Heal_Points = 20;

            base.BuffColor = Brushes.Green;
            base.BuffFillColor = Colors.ForestGreen;
            base.BuffOpacity = 0.4;
            base.Path = "Sounds/Attack/buff.wav";
        }
    }
}
