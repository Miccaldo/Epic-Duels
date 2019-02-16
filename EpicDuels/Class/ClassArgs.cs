using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicDuels.Class {

    public class ClassArgs {

        public int borderListSkillIndex { get; set; }
        public int selectWeaponCnt { get; set; }
        public int Counter { get; set; }
        public int INFOCnt { get; set; }
        public int MENUCnt { get; set; }
        public int SPECIALCnt { get; set; }

        public int SelectSkillCnt { get; set; }
        public int dispatcherTimerCnt { get; set; }
        public int delayingTimerCnt { get; set; }
        public int skillPreparationTimerCnt { get; set; }
        public int dropTimerCnt { get; set; }

        public int poisonTimerCnt { get; set; }

        public bool EnemyTurn { get; set; }
        public bool EndTurnPreparationFlag { get; set; }
        public bool PassiveSkillIndex { get; set; }

        public int nextEnemy { get; set; }
        public int NumberEnemies { get; set; }

        public int EndingTurnCnt { get; set; }


        public int randomDownLimit { get { return 0; } private set {; } }
        public int randomUpLimit { get { return 100; } private set {; } }
        public int milisecondsTimer1 { get { return 600; } private set {; } }
        public int milisecondsTimer2 { get { return 300; } private set {; } }
        public int milisecondsTimer3 { get { return 600; } private set {; } }
        public int milisecondsTimer4 { get { return 1000; } private set {; } }
        public int milisecondsTimer1_Start { get { return 0; } private set {; } }
        public int milisecondsTimer2_Start { get { return 0; } private set {; } }
        public int milisecondsTimer3_Start { get { return 0; } private set {; } }
        public int milisecondsTimer4_Start { get { return 200; } private set {; } }

    }
}
