using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills.DefenseSkill {

    public class VampirePower : Skill {

        public VampirePower(Brush FirstColor, Brush SecondColor, int DMG_Pct = 0, int CoolDown_MAX = 5, int Duration = 3, string DiseaseType = "brak", string Name = "Moc Wampira")
            :base(FirstColor, SecondColor, DMG_Pct, Name, CoolDown_MAX, Duration, DiseaseType) {

            Buff = true;
            NumberAttacks_Pct = 150;
            KP_Pct = 50;
            HitChanse_Pct = 100;
            BloodSucking = true;

            base.BuffColor = Brushes.DarkSlateGray;
            base.BuffFillColor = Colors.Black;
            base.BuffOpacity = 0.7;
            base.Path = "Sounds/Attack/buff.wav";
        }
    }
}
