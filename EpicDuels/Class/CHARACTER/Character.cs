using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.CHARACTER.Skills.DefenseSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EpicDuels.Class.CHARACTER {

    public abstract class Character : Base {

        private const int BURN_CHANSE = 20;
        protected int LeftMarginDiseaseSkill;
        protected int LeftSecondMarginDiseaseSkill;

        protected Action<Random> ActiveSkill;

        public CyclicDisease cyclicDisease { get; set; }

        private int _PreparationSkillCnt;
        public int PreparationSkillCnt {
            get {
                return _PreparationSkillCnt;
            }
            set {
                _PreparationSkillCnt = value;
            }
        }

        private delegate void Desease(Character character, Random random, bool miss);
        private event Desease SkillEffectsEvent;

        private double _HP;    // health points
        private int _level;

        public int Level {
            get { return _level; }
            set {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public double HPindicator_MAX { get; set; }

        private int _KP;
        public int KP {
            get { return _KP; }
            set {
                _KP = value;
                OnPropertyChanged(nameof(KP));
            }
        }             // Armor class
        protected int KP_MAX { get; set; }


        // *********** Features ***********

        private int _Strength;
        public int Strength {
            get { return _Strength; }
            set {
                _Strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }
        private int _Endurance;
        public int Endurance {
            get { return _Endurance; }
            set {
                _Endurance = value;
                OnPropertyChanged(nameof(Endurance));
            }
        }
        private int _Agility;
        public int Agility {
            get { return _Agility; }
            set {
                _Agility = value;
                OnPropertyChanged(nameof(Agility));
            }
        }
        private int _Intelligence;
        public int Intelligence {
            get { return _Intelligence; }
            set {
                _Intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        public bool Undead { get; set; }

        // *********** Features STUN ***********

        public bool Stun { get; set; }
        public bool EndStun { get; set; }

        private int _StunDuration;
        public int StunDuration {

            get { return _StunDuration; }

            set {
                _StunDuration = value;
                if(_StunDuration <= 0 || HP <= 0) {
                    this.Stun = false;
                    this.EndStun = true;
                    this.NumberDisease--;
                    DiseaseSizeList.RemoveAt(DiseaseSizeList.FindIndex(x => x.Name == nameof(Stun)));
                }                  
                OnPropertyChanged(nameof(StunVisible));
            }
        }

        private Visibility _StunVisible;
        public Visibility StunVisible {

            get {
                if (Stun is true) {
                    StunMargin = ChangeDiseaseMargin(nameof(Stun));
                    return _StunVisible = Visibility.Visible;
                } else {                   
                    return _StunVisible = Visibility.Hidden;
                }
            }
            private set { _StunVisible = value ; }
        }

        private Thickness _StunMargin;
        public Thickness StunMargin {

            get { return _StunMargin; }
            set {
                _StunMargin = value;
                OnPropertyChanged(nameof(StunMargin));
            }
        }

        // *********** Features CYCLIC DISEASE ***********

        public int CyclicDiseaseTurn { get; set; }

        private Visibility _PoisonVisible;
        public Visibility PoisonVisible {

            get {
                if (cyclicDisease.Enable is true && cyclicDisease.Poison is true) {
                    PoisonMargin = ChangeDiseaseMargin(nameof(Poison));
                    return _PoisonVisible = Visibility.Visible;
                } else {
                    if (DiseaseSizeList.FindIndex(x => x.Name == nameof(Poison)) != -1) {
                        this.NumberDisease--;
                        DiseaseSizeList.RemoveAt(DiseaseSizeList.FindIndex(x => x.Name is nameof(Poison)));
                    }
                    return _PoisonVisible = Visibility.Hidden;
                }
            }
            private set { _PoisonVisible = value; }
        }

        private Thickness _PoisonMargin;
        public Thickness PoisonMargin {

            get {  return _PoisonMargin; }
            set {
                _PoisonMargin = value;
                OnPropertyChanged(nameof(PoisonMargin));
            }
        }

        // *********** Features BURN ***********

        private Visibility _BurnVisible;
        public Visibility BurnVisible {

            get {
                if (cyclicDisease.Enable is true && cyclicDisease.Burn is true) {
                    PoisonMargin = ChangeDiseaseMargin(nameof(Burn));
                    return _BurnVisible = Visibility.Visible;
                } else {
                    if (DiseaseSizeList.FindIndex(x => x.Name == nameof(Burn)) != -1) {
                        this.NumberDisease--;
                        DiseaseSizeList.RemoveAt(DiseaseSizeList.FindIndex(x => x.Name is nameof(Burn)));
                    }
                    return _BurnVisible = Visibility.Hidden;
                }
            }
            private set { _BurnVisible = value; }
        }

        // *********** Features SLOW ***********


        private bool _Slow;
        public bool Slow {
            get {
                return _Slow;
            }
            set {
                OnPropertyChanged(nameof(SlowVisible));
                _Slow = value;
            }
        }

        private int _SlowDuration;
        public int SlowDuration {

            get { return _SlowDuration; }

            set {
                _SlowDuration = value;
                if (_SlowDuration <= 0 || HP <= 0) {
                    this.Slow = false;
                    this.NumberDisease--;
                    this.NumberAttacks_MAX = this._NumberAttacks_MAX;
                    DiseaseSizeList.RemoveAt(DiseaseSizeList.FindIndex(x => x.Name == nameof(Slow)));
                }
                OnPropertyChanged(nameof(SlowVisible));
            }
        }

        private Thickness _SlowMargin;
        public Thickness SlowMargin {

            get { return _SlowMargin; }
            set {
                _SlowMargin = value;
                OnPropertyChanged(nameof(SlowMargin));
            }
        }

        private Visibility _SlowVisible;
        public Visibility SlowVisible {

            get {
                if (Slow is true) {
                    SlowMargin = ChangeDiseaseMargin(nameof(Slow));
                    return _SlowVisible = Visibility.Visible;
                } else {
                    return _SlowVisible = Visibility.Hidden;
                }
            }
            set { _SlowVisible = value; }
        }

        // *********** Features Attack, Skill ***********

        public int DMG { get; set; }

        private int _DMG_MIN;
        public int DMG_MIN {
            get {
                return _DMG_MIN;
            }
            set {
                _DMG_MIN = value;
                OnPropertyChanged(nameof(DMG_MIN));
            }
        }
        private int _DMG_MAX;
        public int DMG_MAX {
            get {
                return _DMG_MAX;
            }
            set {
                _DMG_MAX = value;
                OnPropertyChanged(nameof(DMG_MAX));
            }
        }

        private int _DMG_Buff;
        public int DMG_Buff {
            get { return _DMG_Buff; }
            set {
                _DMG_Buff = value;
                OnPropertyChanged(nameof(DMG_Buff));
            }
        }
        public bool BuffStart { get; set; }
        public bool AoESelect { get; set; }
        public bool BuffSelect { get; set; }
        public bool BloodSucking { get; set; }

        // *********** Features Heal ***********


        public bool Heal { get; set; }
        public int Heal_Points { get; set; }
        public int HealTurn { get; set; }
        public bool HealStart { get; set; }


        // *********** -------------- ***********

        private int _BuffDuration;
        public int BuffDuration {

            get { return _BuffDuration; }

            set {
                _BuffDuration = value;
                OnPropertyChanged(nameof(BorderColor));
                OnPropertyChanged(nameof(BorderFillColor));
            }
        }

        protected int _HitChanse_MAX;

        private int _HitChanse;
        public int HitChanse {
            get { return _HitChanse; }
            set {
                _HitChanse = value;
                OnPropertyChanged(nameof(HitChanse));
            }
        }


        public abstract List<Skill> SkillList();


        public bool BuffSkill { get; set; }
        private bool StunBlock;
        public int selectSkillIndex { get; set; }
        public int selectWeaponIndex { get; set; }

        protected int _NumberAttacks_MAX;

        private int _numberAttacks_MAX;
        public int NumberAttacks_MAX {
            get { return _numberAttacks_MAX; }
            set {
                _numberAttacks_MAX = value;
                OnPropertyChanged(nameof(NumberAttacks_MAX));
            }
        }

        private int _NumberAttacks;
        public int NumberAttacks {

            get { return _NumberAttacks; }
            set {
                _NumberAttacks = value;
                OnPropertyChanged(nameof(NumberAttacks));
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        // *********** Features graphics skills ***********

        public Brush _TargetBorderColor { get; set; }
        public Brush BorderBuffColor { get; set; }
        public double BorderBuffOpacity { get; set; }

        private double _BorderOpacity;
        public double BorderOpacity {
            get { return _BorderOpacity; }
            set {
                _BorderOpacity = value;
                OnPropertyChanged(nameof(BorderOpacity));
            }
        }

        private Brush _BorderColor;
        public Brush BorderColor {
            get { return _BorderColor; }
            set {
                _BorderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        public Color BorderBuffFillColor { get; set; }
        private Color _BorderFillColor;
        public Color BorderFillColor {

            get { return _BorderFillColor; }
            set {
                _BorderFillColor = value;
                OnPropertyChanged(nameof(BorderFillColor));
            }
        }

        public int MarginBigSign_Y { get; set; }
        public int MarginSmallSign_Y { get; set; }

        public int BigSignWidth { get; set; }
        public int SmallSignWidth { get; set; }


        // *********** ---------------- ***********

        public int TargetMargin { get; set; }

        private Thickness _MarginCharacter;
        public Thickness MarginCharacter {

            get { return _MarginCharacter; }
            set {
                _MarginCharacter = value;
                OnPropertyChanged(nameof(MarginCharacter));
                OnPropertyChanged(nameof(StunVisible));
                OnPropertyChanged(nameof(PoisonVisible));
                OnPropertyChanged(nameof(BurnVisible));
                OnPropertyChanged(nameof(SlowVisible));
            }
        }

        public List<SkillSize> DiseaseSizeList = new List<SkillSize>();

        private int _NumberDisease;
        public int NumberDisease {
            get {
                return _NumberDisease;
            }
            set {
                _NumberDisease = value;
            }
        }

        private double _HP_MAX;
        public double HP_MAX {
            get { return _HP_MAX; }
            set {
                _HP_MAX = value;
                OnPropertyChanged(nameof(HP_MAX));
            }
        }

        public double HP {
            get {
                if(_HP > HP_MAX)
                    return HP_MAX;
                else {
                    return _HP;
                }
            }
            set {
                _HP = value;
                if(HP <= 0) {
                    this.Stun = false;
                }
                OnPropertyChanged(nameof(HP));
                OnPropertyChanged(nameof(HPindicator));
            }
        }

        public double HPindicator { get { return (100 - (HP * 100 / HP_MAX)) * HPindicator_MAX / 100; } private set {; } }

        protected bool StrongerBlow;
        protected bool WeakerBlow;

        protected bool WeaponEffect;


        System.Media.SoundPlayer Hit = new System.Media.SoundPlayer();


        // ******************************  METODS TO FIGHT ****************************** 

        public void HealMetod(ref DMGindicator dmgIndicator) {

            Hit.SoundLocation = "Sounds/Attack/buff.wav";
            Hit.Play();
            this.HP += this.Heal_Points;
            dmgIndicator = new DMGindicator($"+{Heal_Points}", 250, Brushes.Green, Brushes.LimeGreen, new Thickness(0, 0, 30, 0), new Thickness(10, 0, 30, 0));
            this.cyclicDisease.Enable = false;
        }

        public void Attack(Character character,Random random, ref DMGindicator dmgIndicator, ClassArgs args, bool AoETurnOffBuff) {

            bool miss = false;

            if (AoETurnOffBuff is false) {
                int dmg = 0;

                AddBuff();
                HealEnable(ref dmgIndicator);

                Hit.SoundLocation = SkillList()[selectSkillIndex].Path;
                Hit.Play();

                AttackControl(character, random, args, ref dmg, ref miss);

                DMGIndicatorMetod(ref dmgIndicator, dmg, miss, args);

                CoolDownSkill();
            }

            if (AoESelect is false) {
                SkillEffectsEvent(character, random, miss);
            }
        }

        private int GetDMG(Random random, ClassArgs args) {

            int dmg = 0;
            int skillDmg = 0;

            if (this.HP > 0 && this.Stun is false) {

                dmg = random.Next(DMG_MIN, DMG_MAX + 1);
                dmg += (dmg * Strength / 100);      // dodatkowy dmg fizyczny jako bonus z sily

                skillDmg = dmg * SkillList()[this.selectSkillIndex].DMG_Pct / 100;
                skillDmg += (skillDmg * Intelligence) / 100;        // dodatkowy dmg ze skilli jako bonus z inteligencji dla maga

                if (skillDmg != 0)
                    dmg = skillDmg;

            }
            return dmg;
        }

        private void AttackControl(Character character, Random random, ClassArgs args, ref int dmg, ref bool miss) {

            if (BuffStart is false && HealStart is false) {               // If this is not a buff

                Miss(random, character, ref miss);

                if (miss is false) {
                    dmg = GetDMG(random, args);

                    dmg += dmg * DMG_Buff / 100;   // Additional DMG with buff if it is

                    AddEnemyResistances(character as Enemy, ref dmg);

                    character.HP -= dmg;

                    BloodSuckingEnable(character, dmg, random);
                }
            }
        }

        protected virtual void AddEnemyResistances(Enemy enemy, ref int dmg) { }


        private void CoolDownSkill() {

            if (this.NumberAttacks == 1) {
                foreach (Skill skill in SkillList()) {      

                    if (skill.CoolDown != 0 && skill.StartSkill is false)        // If the skill has some cool down, take it off
                        skill.CoolDown--;

                    if (skill.StartSkill is true)
                        skill.StartSkill = false;
                }
            }

            SkillList()[this.selectSkillIndex].CoolDown = SkillList()[this.selectSkillIndex].CoolDown_MAX;  // If the currently used skill has CoolDown (something other than Normal), then save
            SkillList()[this.selectSkillIndex].StartSkill = false;
        }      
        
        private void StunEnable(Character character, Random random, bool miss) {

            ActiveSkill = new Action<Random>(ExtraStunEffect);

            if ((character.HP > 0 && character.Stun is false && miss is false)
                && (SkillList()[this.selectSkillIndex].Stun is true || ActivateWeaponSkill(random) is true)
                && character.StunBlock is false) {

                if(WeaponEffect is false)
                    character.StunDuration = SkillList()[this.selectSkillIndex].Duration;
                else {
                    StunWeaponEnable(character);
                }

                character.Stun = true;
                character.NumberDisease++;

                character.DiseaseSizeList.Add(new SkillSize("Stun", new Thickness(0, 0, 0, 0), character.MarginBigSign_Y, character.BigSignWidth));
            }
        }
        private void SlowEnable(Character character, Random random, bool miss) {

            ActiveSkill = new Action<Random>(ExtraSlowEffect);

            if ((character.HP > 0 && character.Slow is false && miss is false) && (SkillList()[this.selectSkillIndex].Slow || ActivateWeaponSkill(random) is true) is true && character.StunBlock is false) {

                if(WeaponEffect is false) {
                    character.SlowDuration = SkillList()[this.selectSkillIndex].Duration;
                    character.NumberAttacks_MAX = character.NumberAttacks_MAX + character.NumberAttacks_MAX * SkillList()[this.selectSkillIndex].NumberAttacks_Pct / 100;
                    character.NumberAttacks = character.NumberAttacks_MAX;
                } else {
                    SlowWeaponEnable(character);
                }
                character.Slow = true;
                character.NumberDisease++;
               
                character.DiseaseSizeList.Add(new SkillSize("Slow", new Thickness(0, 0, 0, 0), character.MarginSmallSign_Y, character.SmallSignWidth));
            }

            if (this.Slow is true) {
                if (this.NumberAttacks == this.NumberAttacks_MAX) {
                    this.SlowDuration--;
                }
            }
        }

        private void PoisonEnable(Character character, Random random, bool miss) {

            ActiveSkill = new Action<Random>(ExtraPoisonEffect);

            if ((character.HP > 0 && character.cyclicDisease.Enable is false && miss is false)
                && (SkillList()[this.selectSkillIndex].Poison is true || ActivateWeaponSkill(random))) {

                DMGindicator dmgIndicator = new DMGindicator(null, 250, Brushes.Green, Brushes.LimeGreen, new Thickness(0, 0, 30, 0), new Thickness(10, 0, 30, 0));

                character.cyclicDisease = new CyclicDisease(
                    true,
                    false,
                    SkillList()[this.selectSkillIndex].Duration,
                    this.DMG_MIN,
                    this.DMG_MAX,
                    SkillList()[this.selectSkillIndex].PoisonDMG_Pct,
                    true,
                    dmgIndicator);

                if(WeaponEffect is true) {
                    CyclicDiseaseWeaponActivate(character.cyclicDisease);
                }

                character.DiseaseSizeList.Add(new SkillSize("Poison", new Thickness(0, 0, 0, 0), character.MarginSmallSign_Y, character.SmallSignWidth));
                character.NumberDisease++;
            }
        }

        private void BurnEnable(Character character, Random random, bool miss) {

            ActiveSkill = new Action<Random>(ExtraBurnEffect);

            if ((character.HP > 0 && character.cyclicDisease.Enable is false && miss is false)
                && ((SkillList()[this.selectSkillIndex].Burn is true && SkillList()[this.selectSkillIndex].BurnChanse(random)) is true
                || ActivateWeaponSkill(random))) {

                DMGindicator dmgIndicator = new DMGindicator(null, 250, Brushes.Red, Brushes.OrangeRed, new Thickness(0, 0, 30, 0), new Thickness(10, 0, 30, 0));

                character.cyclicDisease = new CyclicDisease(
                    false,
                    true,
                    SkillList()[this.selectSkillIndex].Duration,
                    this.DMG_MIN,
                    this.DMG_MAX,
                    SkillList()[this.selectSkillIndex].BurnDMG_Pct,
                    true,
                    dmgIndicator);

                if (WeaponEffect is true) {
                    CyclicDiseaseWeaponActivate(character.cyclicDisease);
                }

                character.DiseaseSizeList.Add(new SkillSize("Burn", new Thickness(0, 0, 0, 0), character.MarginSmallSign_Y, character.SmallSignWidth));
                character.NumberDisease++;
            }
        }

        private void HealEnable(ref DMGindicator dmgIndicator) {

            if(SkillList()[this.selectSkillIndex].Heal is true && SkillList()[this.selectSkillIndex].Buff is false) {
                Heal_Points = SkillList()[this.selectSkillIndex].Heal_Points;
                HealStart = true;
                HealMetod(ref dmgIndicator);
            }
        }

        protected virtual void ExtraPoisonEffect(Random random) { }
        protected virtual void ExtraBurnEffect(Random random) { }
        protected virtual void ExtraStunEffect(Random random) { }
        protected virtual void ExtraSlowEffect(Random random) { }
        protected virtual void ExtraBloodSuckingEffect(Random random) { }

        protected virtual void SlowWeaponEnable(Character character) { }
        protected virtual void StunWeaponEnable(Character character) { }
        protected virtual void CyclicDiseaseWeaponActivate(CyclicDisease cyclicDisease) { }

        protected virtual bool ActivateWeaponSkill(Random radnom) {

            return WeaponEffect;
        }

        private void BuffEnable(Character character, Random random, bool miss) {

            if (this.BuffSkill is true) {
                if (this.BuffStart is false && this.NumberAttacks == this.NumberAttacks_MAX) {
                    this.BuffDuration--;
                }
            }

            if (this.BuffDuration == 0 && NumberAttacks == 1 && BuffSkill is true) {
                this.KP = this.KP_MAX;
                this.HitChanse = this._HitChanse_MAX;
                this.NumberAttacks_MAX = this._NumberAttacks_MAX;
                this.BorderColor = _TargetBorderColor;
                this.BorderBuffColor = _TargetBorderColor;
                this.BorderFillColor = Colors.Transparent;
                this.BorderBuffFillColor = Colors.Transparent;
                this.BorderBuffOpacity = 0;
                this.BloodSucking = false;
                this.DMG_Buff = 0;
                this.Heal_Points = 0;
                this.Heal = false;
                this.BuffSkill = false;
                this.BuffDuration = 0;
            }
        }

        private void BloodSuckingEnable(Character character, int dmg, Random random) {

            ActiveSkill = new Action<Random>(ExtraBloodSuckingEffect);

            if (character.HP > 0 && character.Undead is false && (SkillList()[this.selectSkillIndex].BloodSucking is true || this.BloodSucking is true || ActivateWeaponSkill(random) is true))
                this.HP += dmg;
        }
        private void Miss(Random random, Character character, ref bool miss) {

            int chanceToMiss = character.KP - this.HitChanse;

            int randomValue = random.Next(0, 100 + 1);

            this.DMG = randomValue;

            if (chanceToMiss > randomValue)
                miss = true;
            else {
                miss = false;
            }
        }
        private void AddBuff() {

            if (SkillList()[this.selectSkillIndex].Buff is true) {

                this.BuffStart = true;
                this.NumberAttacks = 1;        // 1 to be buffed
                this.BuffDuration = SkillList()[this.selectSkillIndex].Duration;
                this.StunBlock = SkillList()[this.selectSkillIndex].StunBlock;
                this.BorderColor = SkillList()[this.selectSkillIndex].BuffColor;
                this.BorderBuffColor = SkillList()[this.selectSkillIndex].BuffColor;
                this.BorderFillColor = SkillList()[this.selectSkillIndex].BuffFillColor;
                this.BorderBuffFillColor = SkillList()[this.selectSkillIndex].BuffFillColor;
                this.BorderOpacity = SkillList()[this.selectSkillIndex].BuffOpacity;
                this.BorderBuffOpacity = SkillList()[this.selectSkillIndex].BuffOpacity;
                this.BuffSkill = SkillList()[this.selectSkillIndex].Buff;
                this.BloodSucking = SkillList()[this.selectSkillIndex].BloodSucking;
                this.Heal = SkillList()[this.selectSkillIndex].Heal;
                this.Heal_Points = SkillList()[this.selectSkillIndex].Heal_Points;

                this.NumberAttacks_MAX += NumberAttacks_MAX * SkillList()[this.selectSkillIndex].NumberAttacks_Pct / 100;
                this.DMG_Buff = SkillList()[this.selectSkillIndex].DMG_Pct;
                this.KP += KP_MAX * SkillList()[this.selectSkillIndex].KP_Pct / 100;
                this.HitChanse += _HitChanse_MAX * SkillList()[this.selectSkillIndex].HitChanse_Pct / 100;
            }
        }
        private void DMGIndicatorMetod(ref DMGindicator dmgIndicator, int dmg, bool miss, ClassArgs args) {

            if (BuffStart is false && HealStart is false) {
                if (miss is false) {                                                                    
                    dmgIndicator = new DMGindicator(dmg.ToString(), 250, this.SkillList()[this.selectSkillIndex].FirstColor, this.SkillList()[this.selectSkillIndex].SecondColor, new Thickness(0, 0, 30, 0), new Thickness(10, 0, 30, 0));

                } else {
                    dmgIndicator = new DMGindicator("miss", 150, Brushes.LightGray, Brushes.SlateGray, new Thickness(0, 100, 40, 0), new Thickness(10, 100, 40, 0));                     // iF MISS
                }
            } else if(BuffStart is true){
                dmgIndicator = new DMGindicator("buff", 150, this.SkillList()[this.selectSkillIndex].FirstColor, this.SkillList()[this.selectSkillIndex].SecondColor, new Thickness(0, 100, 40, 0), new Thickness(10, 100, 40, 0));                             // jesli BUFF
            }
        }

        public abstract void Move(bool diraction);


        // ****************************** GENERAL METHODS ****************************** 


        private Thickness ChangeDiseaseMargin(string text) {

            if (NumberDisease == 1) {
                DiseaseSizeList[0].Margin = new Thickness(LeftMarginDiseaseSkill, DiseaseSizeList[0].Margin_Y, 0, 0);
            } else {

                for (int index = 0; index < DiseaseSizeList.Count; index++) {

                    int width = 0;
                    int i = 0;

                    while(i < index) {
                        width += DiseaseSizeList[i].Width;
                        i++;
                    }

                    DiseaseSizeList[index].Margin = new Thickness(LeftMarginDiseaseSkill + width, DiseaseSizeList[index].Margin_Y, 0, 0);
                }
            }
            return DiseaseSizeList.Find(x => x.Name == text).Margin;
        }

        // ******************************  CONSTRUKTOR ****************************** 

        public Character(double HP, int level, int NumberAttacks_MAX, int KP_MAX, int HitChanse) {

            this.Level = level;
            this.HP = HP;
            this.HP_MAX = HP;
            this._NumberAttacks_MAX = NumberAttacks_MAX;
            this.NumberAttacks_MAX = NumberAttacks_MAX;
            this.NumberAttacks = NumberAttacks_MAX;
            this.KP_MAX = KP_MAX;
            this.KP = KP_MAX;
            this._HitChanse_MAX = HitChanse;
            this.HitChanse = HitChanse;
            this.HPindicator = 0;

            this.BigSignWidth = 50;
            this.SmallSignWidth = 27;

            cyclicDisease = new CyclicDisease(false, false, 0, 0, 0, 0, false, null);

            SkillEffectsEvent += SlowEnable;
            SkillEffectsEvent += PoisonEnable;
            SkillEffectsEvent += BurnEnable;
            SkillEffectsEvent += StunEnable;
            SkillEffectsEvent += BuffEnable;
        }
    }
}
