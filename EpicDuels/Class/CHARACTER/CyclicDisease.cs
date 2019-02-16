using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicDuels.Class.CHARACTER {

    public class CyclicDisease {

        public bool Poison { get; set; }
        public bool Burn { get; set; }

        public bool Enable { get; set; }

        public int Duration { get; set; }

        public int DMG_MIN { get; private set; }
        public int DMG_MAX { get; private set; }
        public int DMG_Pct { get; set; }
        public bool Death { get; set; }

        public int DeathCnt { get; set; }

        public DMGindicator DmgIndicator { get; private set; }

        System.Media.SoundPlayer Hit = new System.Media.SoundPlayer();

        public void Attack(Character character, Random random, ref DMGindicator dmgIndicator) {

            Hit.Play();

            int DMG = random.Next(DMG_MIN, DMG_MAX + 1);
            DMG += DMG * DMG_Pct / 100;

            character.HP -= DMG;

            if (character.HP <= 0)
                Death = true;

            this.DmgIndicator.Text = DMG.ToString();
            dmgIndicator = this.DmgIndicator;

            this.Duration--;
            if (Duration <= 0 || Death is true) {
                Enable = false;
            }
        }

        public CyclicDisease(bool Poison, bool Burn, int Duration, int DMG_MIN, int DMG_MAX, int DMG_Pct, bool Enable, DMGindicator DmgIndicator) {

            this.Enable = Enable;
            this.Duration = Duration;
            this.DMG_MIN = DMG_MIN;
            this.DMG_MAX = DMG_MAX;
            this.DMG_Pct = DMG_Pct;
            this.Poison = Poison;
            this.Burn = Burn;
            this.DmgIndicator = DmgIndicator;

            if(Burn is true)
                Hit.SoundLocation = "Sounds/Attack/flame.wav";
            else if(Poison is true)
                Hit.SoundLocation = "Sounds/Attack/poison.wav";
        }
    }
}
