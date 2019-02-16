using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.DefenseSkill {

    public class Cure : Skill {

        public Cure(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, int CoolDown_MAX = 2, int Duration = 0, string DiseaseType = "brak", string Name = "Uleczenie")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Heal = true;
            Heal_Points = 30;
            base.Path = "Sounds/Attack/buff.wav";
        }
    }
}