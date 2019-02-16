using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER.Skills {

    public abstract class Skill : Base {

        public string Name { get; set; }
        public int DMG_Pct { get; set; }
        public int Duration { get; set; }
        public bool StartSkill { get; set; }

        public string DiseaseType { get; private set; }

        private int _CoolDown;
        public int CoolDown {
            get { return _CoolDown; }
            set {
                _CoolDown = value;
                OnPropertyChanged(nameof(SkillEnabled));
            }
        }
        public int CoolDown_MAX { get; set; }


        private Color _SkillEnabled;
        public Color SkillEnabled {
            get {
                if (CoolDown > 0)
                    return _SkillEnabled = Colors.RosyBrown;
                else {
                    return _SkillEnabled = Colors.Red;
                }
            }
            set {
                _SkillEnabled = value;
                OnPropertyChanged(nameof(SkillEnabled));
            }
        }

        public bool Stun { get; set; }
        public bool Poison { get; set; }
        public bool Burn { get; set; }
        public bool AoE { get; set; }  // Area of effect
        public bool BloodSucking { get; set; }
        public bool Slow { get; set; }

        public bool Heal { get; set; }
        public int Heal_Points { get; set; }


        public Brush BuffColor { get; set; }
        public Color BuffFillColor { get; set; }
        public double BuffOpacity { get; protected set; }

        public bool Buff { get; protected set; }
        public bool StunBlock { get; protected set; }
        public int NumberAttacks_Pct { get; protected set; }
        public int KP_Pct { get; protected set; }
        public int HitChanse_Pct { get; protected set; }
        public int PoisonDMG_Pct { get; protected set; }
        public int BurnDMG_Pct { get; protected set; }


        public int Width { get; protected set; }
        public int Margin_Y { get; protected set; }


        public Brush FirstColor { get; set; }
        public Brush SecondColor { get; set; }

        public bool Magic { get; set; }

        public string Path { get; set; }


        protected bool BurnChanseFlag;
        public virtual bool BurnChanse(Random random) {

            return BurnChanseFlag;
        }


        public Skill(Brush FirstColor, Brush SecondColor, int DMG_Pct, string Name, int CoolDown_MAX, int Duration, string DiseaseType) {

            this.Name = Name;
            this.DMG_Pct = DMG_Pct;
            this.CoolDown_MAX = CoolDown_MAX;
            this.CoolDown = 0;
            this.Duration = Duration;
            this.DiseaseType = DiseaseType;
            this.StartSkill = false;
            this.FirstColor = FirstColor;
            this.SecondColor = SecondColor;
        }
    }
}
