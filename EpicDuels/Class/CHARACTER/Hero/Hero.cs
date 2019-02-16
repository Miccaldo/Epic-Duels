using EpicDuels.Class.CHARACTER.Skills.AttackSkill;
using EpicDuels.Class.EQUIPMENT;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT;

namespace EpicDuels.Class.CHARACTER.Hero {

    public abstract class Hero : Character {

        public string Name { get; set; }

        private const int _EXPERIENCE_MIN = 625;

        private string _HeroClassName;
        public string HeroClassName {
            get { return _HeroClassName; }
            set {
                _HeroClassName = value;
                OnPropertyChanged(nameof(HeroClassName));
            }
        }

        private double _ExperienceMAX;
        public double Experience_MAX {
            get { return _ExperienceMAX; }
            set {
                _ExperienceMAX = value;
                OnPropertyChanged(nameof(Experience_MAX));
            }
        }

        public string NewSkill { get; set; }
        public bool LevelUPPoisonFlag { get; set; }

        public bool NewSkillEnabled {
            get {
                if (NewSkill != "brak")
                    return true;
                else { return false; }
            }
            private set {; }
        }

        private static double _Experience;
        public double Experience {

            get { return _Experience; }
            set {
                _Experience = value;
                OnPropertyChanged(nameof(XPindicator_1));
                OnPropertyChanged(nameof(XPindicator_2));
                OnPropertyChanged(nameof(Experience));
            }
        }

        public double XPindicator_1 { get { return (0.95 - _Experience / Experience_MAX); } private set {; } }
        public double XPindicator_2 { get { return (1 - _Experience / Experience_MAX); } private set {; } }


        public int SkillCnt { get; set; }

        public Equipment equipment { get; set; }

        protected NormalAttack NormalAttack = new NormalAttack(Brushes.DarkSlateGray, Brushes.LightGray);

        protected System.Media.SoundPlayer Avans = new System.Media.SoundPlayer();


        public void UpdateBackground(Grid grid, List<Grid> listGrid, SelectHero selectHero) {

            int i = 1;

            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri($"Images/Hero/{selectHero.feature.ImageNumber}.jpg", UriKind.Relative));
            grid.Background = image;
            grid.DataContext = this;


            foreach (Grid skillGrid in listGrid) {

                skillGrid.DataContext = SkillList()[i];
                i++;
            }
        }

        public void UpdateHeroFeatureInfo(Grid featureInfoGrid, Grid portraitGrid, Label name, SelectHero selectHero) {

            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri($"Images/Hero/{selectHero.feature.ImageNumber}.jpg", UriKind.Relative));
            portraitGrid.Background = image;
            name.Content = selectHero.feature.Name;
            portraitGrid.DataContext = this;

            featureInfoGrid.DataContext = this;
        }

        abstract public bool LevelUp(System.Random random, ClassArgs args);

        public override void Move(bool diraction) {

            if (diraction == true)
                MarginCharacter = new Thickness(TargetMargin + 10, 0, 0, 0);

            else {
                MarginCharacter = new Thickness(TargetMargin, 0, 0, 0);
            }
        }

        public abstract void AddFeatures(Random random);
        public abstract void AddSkills(ClassArgs args, int Level);



        protected override void ExtraPoisonEffect(Random random) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;
            base.WeaponEffect = (artefact.Poison == true && artefact.DiseaseEnable(random) == true) ? true : false;
        }

        protected override void ExtraBurnEffect(Random random) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;
            base.WeaponEffect = (artefact.Burn == true && artefact.DiseaseEnable(random) == true) ? true : false;
        }

        protected override void ExtraStunEffect(Random random) {

            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;
            base.WeaponEffect = (artefact.Stun == true && artefact.DiseaseEnable(random) == true) ? true : false;
        }

        protected override void ExtraSlowEffect(Random random) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;
            base.WeaponEffect = (artefact.Slow == true && artefact.DiseaseEnable(random) == true) ? true : false;
        }

        protected override void ExtraBloodSuckingEffect(Random random) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;
            base.WeaponEffect = (artefact.BloodSucking == true && artefact.DiseaseEnable(random) == true) ? true : false;
        }

        public bool ExtraHealEffect(Random random) {

            bool value = false;

            if (equipment.AssignedWeaponDic[selectWeaponIndex] is Artefact) {
                Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;

                if (artefact.Heal == true && artefact.DiseaseEnable(random) == true) {
                    Heal_Points = artefact.HealPoints;
                    value = true;
                } else {
                    value = false;
                }
            }
            return value;
        }


        protected override void SlowWeaponEnable(Character character) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;

            artefact.SlowEnable(character);
        }

        protected override void StunWeaponEnable(Character character) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;

            artefact.StunEnable(character);
        }

        protected override void CyclicDiseaseWeaponActivate(CyclicDisease cyclicDisease) {
            Artefact artefact = equipment.AssignedWeaponDic[selectWeaponIndex] as Artefact;

            artefact.CyclicDiseaseEnable(cyclicDisease);
        }

        protected override bool ActivateWeaponSkill(Random random) {

            if (equipment.AssignedWeaponDic[selectWeaponIndex] is Artefact) {
                ActiveSkill(random);
            } else {
                base.WeaponEffect = false;
            }
            return base.ActivateWeaponSkill(random);
        }

        protected override void AddEnemyResistances(Enemy enemy, ref int dmg) {

            if (equipment.AssignedWeaponDic[selectWeaponIndex].DMG_TYPE == enemy.Sensitivity) {
                dmg *= 2;
                enemy.BorderFillColor = Colors.Red;
                enemy.BorderOpacity = 0.3;
                StrongerBlow = true;

            } else if (equipment.AssignedWeaponDic[selectWeaponIndex].DMG_TYPE == enemy.Resistance) {
                dmg /= 2;
                WeakerBlow = true;
                enemy.BorderFillColor = Colors.White;
                enemy.BorderOpacity = 0.3;
                WeakerBlow = true;
            }
        }


        public void ClearEnemy(Enemy enemy) {

            if (StrongerBlow == true || WeakerBlow == true) {
                if (enemy.BuffSkill == false) {
                    enemy.BorderFillColor = Colors.Transparent;
                    enemy.BorderOpacity = 0;
                } else {
                    enemy.BorderFillColor = enemy.BorderBuffFillColor;
                    enemy.BorderOpacity = enemy.BorderBuffOpacity;
                }

                StrongerBlow = false;
                WeakerBlow = false;
            }
        }


        public Hero(double HP, int level, int NumberAttacks_MAX, int KP_MAX, int HitChanse)
            : base(HP, level, NumberAttacks_MAX, KP_MAX, HitChanse) {

            this.XPindicator_1 = 0.9;
            this.XPindicator_2 = 1;
            this.Experience = 0;
            this.Experience_MAX = _EXPERIENCE_MIN;
            base.MarginCharacter = new Thickness(50, 0, 0, 0);
            base.TargetMargin = 50;
            base.HPindicator_MAX = 350;
            base.BorderColor = Brushes.Black;
            this.equipment = new Equipment();

            this.MarginBigSign_Y = 7;
            this.MarginSmallSign_Y = 7;
            base.LeftMarginDiseaseSkill = 2;
            base.LeftSecondMarginDiseaseSkill = 2;

            equipment.AssignedWeaponDic.Add(0, new Melee());

            base.DMG_MIN = equipment.AssignedWeaponDic[0].DMG_MIN;
            base.DMG_MAX = equipment.AssignedWeaponDic[0].DMG_MAX;

            Avans.SoundLocation = "Sounds/Avans/avans.wav";

        }
    }
}
