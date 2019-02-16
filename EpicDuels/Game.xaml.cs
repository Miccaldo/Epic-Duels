using EpicDuels.Class;
using EpicDuels.Class.CHARACTER;
using EpicDuels.Class.CHARACTER.ENEMY;
using EpicDuels.Class.CHARACTER.Hero;
using EpicDuels.Class.CHARACTER.Skills;
using EpicDuels.Class.EQUIPMENT;
using EpicDuels.Class.EQUIPMENT.WEAPON;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.AXE;
using EpicDuels.Class.EQUIPMENT.WEAPON.ARTEFACT.DAGGER;
using EpicDuels.Class.LOCATION;
using EpicDuels.Class.SELECT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WMPLib;

namespace EpicDuels {
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    /// 


    public partial class Game : Window {

        private System.Random random = null;
        public DMGindicator dmgIndicator = null;
        public DMGindicator skillPreparationIndicator = null;
        private ClassArgs args = null;
        private List<Label> SkillLabelList = null;
        private ImageUri artefactUri = null;

        private System.Windows.Threading.DispatcherTimer dispatcherTimer = null;
        private System.Windows.Threading.DispatcherTimer delayingAttackTimer = null;
        private System.Windows.Threading.DispatcherTimer skillPreparationTimer = null;
        private System.Windows.Threading.DispatcherTimer dropTimer = null;
        private bool dropTimerFlag;

        public static bool addDifficultLocationFlag = false;

        private SelectHero selectHero;
        private Map map;

        private SelectWeapon selectWeapon = null;
        private SelectSkill selectSkill = null;
        private SelectEnemy selectEnemy = null;
        private SelectWeaponAssignment selectWeaponAssignment = null;

        public int selectWeaponListIndex { get; set; }


        System.Media.SoundPlayer Click = new System.Media.SoundPlayer();
        System.Media.SoundPlayer PotionGulp = new System.Media.SoundPlayer();

        public WMPLib.WindowsMediaPlayer Preparation = new WindowsMediaPlayer();


        public Game(SelectHero selectHero, Map map) {

            InitializeComponent();
            WindowState = WindowState.Maximized;

            this.selectHero = selectHero;
            this.map = map;

            int seed = 0;

            seed = System.DateTime.Now.Millisecond;
            random = new Random(seed);

            Initalize(random);

            selectSkill.UpdateSkill(selectHero.hero, args);
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

            SPECIALtext.Text = null;
            args.SPECIALCnt = 0;

            var item = sender as ListViewItem;
            int index = LvWeapon.Items.IndexOf(item.DataContext);
            ImageUri imageUri = new ImageUri(new Uri(selectHero.hero.equipment.weaponList[index].BackgroundURL, UriKind.Relative));

            if (item != null) {
                imageUri.UpdateImage(WeaponImageGrid);
                selectWeaponListIndex = index;
            }
        }

        private void GetArtefact() {

            cardGrid.Visibility = Visibility.Hidden;
            PotionGrid.Visibility = Visibility.Hidden;
            ArtefactGrid.Visibility = Visibility.Visible;

            if (map.location is MagicForest && Map.DifficultyLevel == 2)
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/cuirass.png", UriKind.Relative));
            else if (map.location is IceLand && Map.DifficultyLevel == 2)
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/greaves.png", UriKind.Relative));
            else if (Map.DifficultyLevel == 3)
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/cuirassGreaves.png", UriKind.Relative));
            else if (map.location is Cemetary && Map.DifficultyLevel == 4)
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/cuirassGreavesBoots.png", UriKind.Relative));
            else if (map.location is Cave && Map.DifficultyLevel == 4)
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/cuirassGreavesGloves.png", UriKind.Relative));
            else if (Map.DifficultyLevel == 5) {
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/cuirassGreavesGlovesBoots.png", UriKind.Relative));
            } else if (Map.DifficultyLevel == 6) {
                artefactUri = new ImageUri(new Uri(@"Images/Background/Artefact/fullArmor.png", UriKind.Relative));
            }

            selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
            selectHero.hero.equipment.EQartefactUri = artefactUri;

            artefactUri.UpdateImage(ArtefactGrid);
            selectHero.hero.equipment.EQartefactUri.UpdateImage(EQartefactGrid);
        }

        private void ChangeLocationEvent() {

            if (Map.DiractionFlag is true)
                Map.DiractionFlag = false;
            else {
                Map.DiractionFlag = true;
            }

            selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
            SelectLocation(Map.DifficultyLevel, Map.DiractionFlag);
            map.location.UpdateBackground(GameGrid);

            AddEnemy(map.location, random);
        }

        private void NewBackgroundEvent(Location location) {
            
            selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
            location.UpdateBackground(GameGrid);
            AddEnemy(location, random);
        }

        private void AddDrop(Hero hero, Enemy enemy, Location location) {

            if (enemy.HP <= 0) {
                hero.Experience += enemy.ExperienceDrop;
                selectHero.hero.equipment.SmallPotion.Drop(random);
                selectHero.hero.equipment.BigPotion.Drop(random);
                if (location.Drop(random, selectHero.hero) is true) {
                    dropTimerFlag = true;
                } else {
                    dropTimerFlag = false;
                }
            }
        }

        private void AddSkill(Hero hero, SelectSkill selectSkill) {

            List<Border> borderList = new List<Border>();

            borderList = selectSkill.BorderList;

            if (hero.NewSkillEnabled is true) {

                borderList[args.borderListSkillIndex].Visibility = Visibility.Visible;
                SkillLabelList[args.borderListSkillIndex].Content = hero.NewSkill;
                hero.SkillCnt++;
            }

            if (Map.DifficultyLevel > 2) {

                for(int i = 0; i < hero.SkillCnt; i++) {
                    SkillLabelList[i].Content = hero.SkillList()[i + 1].Name;
                }
            }
        }

        private void AddNameOfSkills(Hero hero) {

            if(Map.DifficultyLevel > 2) {

            }
        }

        public void SkillMessageUpdate(Hero hero) {

            LevelUPMessageGrid.Visibility = Visibility.Visible;
            LevelUPMessage.Text = $"Poziom {this.selectHero.hero.Level}!";

            SkillInfo.Content = $"Nowa zdolność: {hero.NewSkill}";
        }

        private void HeroTurn(Hero hero) {

            if (args.EnemyTurn is false && hero.PreparationSkillCnt == 1) {     // If the turn of Heros and the preparation of the Skill (the inscription has disappeared)

                //debager.Text += $"\n:{hero.equipment.AssignedWeaponDic[hero.selectWeaponIndex].Name}";
                HeroAttackControl(hero);
                //debager.Text += $"\n:{map.location.EnemyList[0].NumberAttacks_MAX}";

                if (hero.BuffStart is false && hero.HealStart is false) {                                  // If Buffstart or Buff was just thrown, then do not move forward as it would attack
                    hero.Move(true);
                } else {
                    hero.BuffStart = false;
                    AttackButton.IsEnabled = false;
                }
                hero.HealStart = false;
                dispatcherTimer.Start();
            } else {
                PreparationSkillMetod(hero);
            }
        }

        private void HeroAttackControl(Hero hero) {

            if (hero.AoESelect is false) {

                hero.Attack(map.location.EnemyList[selectEnemy.SelectFlag], random, ref dmgIndicator, args, false);
                TakeAttackHero(hero);

                AddDrop(hero, map.location.EnemyList[selectEnemy.SelectFlag], map.location);

                selectSkill.DeselectAll(selectHero.hero, map.location);

            } else {
                foreach (Enemy enemy in map.location.EnemyList) {
                    if (enemy.HP > 0) {
                        hero.Attack(enemy, random, ref dmgIndicator, args, false);
                        AddDrop(this.selectHero.hero, enemy, map.location);
                    }
                }
                selectEnemy.DeselectAll(selectHero.hero, map.location);
                selectSkill.DeselectAll(selectHero.hero, map.location);
                TakeAttackHero(hero);

                hero.Attack(map.location.EnemyList[0], random, ref dmgIndicator, args, true);       // Perform a fake attack to disable Buff if its already over
            }
        }

        private void TakeAttackHero(Hero hero) {        // The function takes the Hero attack

            hero.NumberAttacks--;

            if (hero.NumberAttacks == 0) {
                args.EnemyTurn = true;
                AttackButton.IsEnabled = false;
            }
        }

        private void PreparationSkillMetod(Character character) {

            character.PreparationSkillCnt++;
            if (character.SkillList()[character.selectSkillIndex].Name != "brak") {
                skillPreparationIndicator = new DMGindicator(character.SkillList()[character.selectSkillIndex].Name, 100, character.SkillList()[character.selectSkillIndex].FirstColor, character.SkillList()[character.selectSkillIndex].SecondColor, new Thickness(0, 100, 0, 0), new Thickness(10, 100, 0, 0));
                skillPreparationTimer.Start();
            } else if (args.EnemyTurn is false) {
                HeroTurn(selectHero.hero);
            } else {
                EnemyTurn(map.location.EnemyList[args.nextEnemy]);
            }
        }

        private void EnemyTurn(Enemy enemy) {

            if (args.EnemyTurn is true) {

                //debager.Text += $"\n:{enemy.NumberAttacks}";

                if (enemy.PreparationSkillCnt == 1) {
                    enemy.Attack(selectHero.hero, random, ref dmgIndicator, args, false);

                    selectEnemy.Refresh(map.location, args);
                    enemy.NumberAttacks -= 1;

                    if (enemy.HP > 0 && (enemy.BuffStart is false && enemy.HealStart is false)) {
                        enemy.Move(true);
                    } else {
                        //enemy.BuffStart = false;
                        EndEnemiesTurn(map.location.EnemyList[args.nextEnemy], args);
                    }
                    if (enemy.HP <= 0)
                        selectHero.hero.Experience += enemy.ExperienceDrop;

                    if (enemy.CyclicDiseaseTurn == 0 && enemy.NumberAttacks <= 0 && args.nextEnemy < args.NumberEnemies - 1) {       // If not poison and no longer attack
                        enemy.NumberAttacks = enemy.NumberAttacks_MAX;
                        args.nextEnemy++;
                    }
                    enemy.HealStart = false;
                    enemy.PreparationSkillCnt = 0;
                    dispatcherTimer.Start();

                    //debager.Text += $"\n:{enemy.NumberAttacks}";

                } else {
                    enemy.RandomSkill(random, args, selectHero.hero);
                    PreparationSkillMetod(enemy);
                }
            }
        }

        private void CyclicDiseaseAttack(CyclicDisease cyclicDisease, Character character) {        // The method supports poisons and burns

            if (cyclicDisease.Enable is true) {
                cyclicDisease.Attack(character, random, ref dmgIndicator);

                dispatcherTimer.Start();
            }
        }

        private void KillingPoisonMetod(Enemy enemy, CyclicDisease cyclingDisease, ClassArgs args) {

            if (cyclingDisease.Death is true) {
                delayingAttackTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer2);
                args.delayingTimerCnt = 0;
                cyclingDisease.DeathCnt++;

                if (cyclingDisease.DeathCnt == 2) {
                    selectHero.hero.Experience += enemy.ExperienceDrop;
                    cyclingDisease.Death = false;
                    enemy.CyclicDiseaseTurn = 0;
                    cyclingDisease.DeathCnt = 0;
                    args.delayingTimerCnt = 1;       

                    if (args.nextEnemy == args.NumberEnemies - 1)           // If this is the last killed mob by poison
                        map.location.Turn++;
                }
            }
        }

        private void BackEverybody(Hero hero, List<Enemy> enemyList) {

            hero.Move(false);

            foreach (Enemy enemy in enemyList) {

                enemy.Move(false);
            }
        }

        private void Initalize(System.Random random) {

            Click.SoundLocation = "Sounds/Click/click.wav";
            //Preparation.SoundLocation = "Sounds/Attack/preparation.wav";
            Preparation.URL = "Sounds/Attack/preparation.wav";
            Preparation.settings.volume = 70;
            Preparation.controls.stop();

            args = new ClassArgs();

            TimerInit();

            selectWeapon = new SelectWeapon(this);
            selectSkill = new SelectSkill(this);
            selectEnemy = new SelectEnemy(this);
            selectWeaponAssignment = new SelectWeaponAssignment(this);

            DataContext = this;

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
            selectHero.hero.equipment.UpdateWeaponImage(WeaponImageGrid);

            if(Map.DifficultyLevel > 1)
                selectHero.hero.equipment.EQartefactUri.UpdateImage(EQartefactGrid);

            PotionInitalize();
            selectHero.hero.selectSkillIndex = 0;

            AddSkillLabelToList();

            map.location.Turn += 1;

            AddEnemy(map.location, random);

            map.location.UpdateBackground(GameGrid);                                                // Preparing location for binding

            selectHero.hero.Name = selectHero.feature.Name;

            selectHero.hero.UpdateBackground(heroGrid, ListSkillGrid(), selectHero);      // Preparing heroes for binding

            selectHero.hero.UpdateHeroFeatureInfo(FeatureInfoGrid, PortraitGridFeatureInfo, HeroNameFeatureInfo, selectHero);
            ClassFeatureInfo.Content = $"Klasa: {selectHero.hero.HeroClassName}";

            selectWeaponAssignment.UpdateAssignWeapons(selectHero.hero);
            selectSkill.UpdateSkill(selectHero.hero, args);
            AddSkill(selectHero.hero, selectSkill);

        }

        private void PotionInitalize() {

            PotionGulp.SoundLocation = "Sounds/Potion/gulp.wav";

            selectHero.hero.equipment.SmallPotion.UpdateGrid(SmallPotionGrid);
            selectHero.hero.equipment.BigPotion.UpdateGrid(BigPotionGrid);
        }

        private void SelectLocation(int DifficultyLevel, bool DiractionFlag) {      // If False - Left Location selected

            if (DifficultyLevel < 3 && DiractionFlag is false)
                map.location = new MagicForest();
            else if(DifficultyLevel < 3 && DiractionFlag is true)
                map.location = new IceLand();
            else if(DifficultyLevel >=3 && DiractionFlag is false)
                map.location = new Cemetary();
            else if(DifficultyLevel >= 3 && DiractionFlag is true)
                map.location = new Cave();
        }

        private void AddEnemy(Location location, System.Random random) {

            double randomValue = 0;
            double randomUpdate = 0;
            int indexOfRandomEnemy = 0;
            int index = 0;
            int _numberEnemies = NumberSlotsOfEnemies(random, location);

            List<Enemy> _EnemyList = new List<Enemy>();
            List<Enemy> realEnemyList = new List<Enemy>();

            _EnemyList = location.TargetListOfEnemies();

            location.EnemyGridList.Clear();
            location.EnemyBorderList.Clear();

            DrawEnemyGrid(_numberEnemies, location.EnemyGridList, location.EnemyBorderList);      // Draws the frame of the opponent cards

            for (int i = 0; i < _numberEnemies; i++) {     // Make as many opponents as you can

                if (location.Level < 4) {                   // At 4 lvl BOSS
                    foreach (Enemy enemy in _EnemyList) {

                        randomValue = random.Next(args.randomDownLimit, args.randomUpLimit + 1);

                        if (enemy.Level < location.Level)
                            randomValue = randomValue / (1 + (location.Level - enemy.Level));      // The value is divided into two, so that opponents with lower lvl than the level of the location are less frequent
                        else if (enemy.Level > location.Level)
                            randomValue = 0;                                // No chance of an opponent with a higher level

                        if (randomValue > randomUpdate) {                   // Assign the opponent's index of the greatest fate
                            randomUpdate = randomValue;
                            indexOfRandomEnemy = index;
                        }

                        ImageBrush imageCardEnemy = new ImageBrush() {
                            ImageSource = new BitmapImage(new Uri($"{_EnemyList.ElementAt(indexOfRandomEnemy).BackgroundURL}", UriKind.Relative))
                        };

                        location.EnemyGridList.ElementAt(i).Background = imageCardEnemy;
                        index++;
                    }
                } else {        // If BOSS
                    indexOfRandomEnemy = _EnemyList.FindIndex(x => x.Level == 4);           // Boss only has level 4

                    ImageBrush imageCardEnemy = new ImageBrush() {
                        ImageSource = new BitmapImage(new Uri($"{_EnemyList.ElementAt(indexOfRandomEnemy).BackgroundURL}", UriKind.Relative))
                    };
                    location.EnemyGridList.ElementAt(i).Background = imageCardEnemy;
                }

                var obj = (Enemy)Activator.CreateInstance(
                    _EnemyList[indexOfRandomEnemy].GetType(),
                    _EnemyList[indexOfRandomEnemy].HP,
                    _EnemyList[indexOfRandomEnemy].Level,
                    _EnemyList[indexOfRandomEnemy].NumberAttacks_MAX,
                    _EnemyList[indexOfRandomEnemy].KP,
                    _EnemyList[indexOfRandomEnemy].HitChanse,
                    _EnemyList[indexOfRandomEnemy].DMG_MIN,
                    _EnemyList[indexOfRandomEnemy].DMG_MAX,
                    _EnemyList[indexOfRandomEnemy].ExperienceDrop,
                    _EnemyList[indexOfRandomEnemy].HPindicator_MAX);

                realEnemyList.Add(obj);

                if (_numberEnemies > 1)
                    realEnemyList[i].HPindicator_MAX = 200;

                index = 0;
            }

            InitialEnemyParameters(realEnemyList, _numberEnemies);

            RefreshEnemies(location, realEnemyList, _numberEnemies);
        }

        private void InitialEnemyParameters(List<Enemy> realEnemyList, int _numberEnemies) {

            if (_numberEnemies == 1) {
                realEnemyList[0].TargetMargin = 50;
            } else if (_numberEnemies == 2) {
                realEnemyList[0].TargetMargin = 70;
                realEnemyList[0].MarginCharacter = new Thickness(0, 0, 70, 0);
                realEnemyList[1].TargetMargin = 130;
                realEnemyList[1].MarginCharacter = new Thickness(0, 0, 130, 0);
            } else {
                realEnemyList[0].TargetMargin = 135;
                realEnemyList[0].MarginCharacter = new Thickness(0, 0, 135, 0);
                realEnemyList[1].TargetMargin = 175;
                realEnemyList[1].MarginCharacter = new Thickness(0, 0, 175, 0);
                realEnemyList[2].TargetMargin = 0;
                realEnemyList[2].MarginCharacter = new Thickness(0, 0, 0, 0);
            }

            if (_numberEnemies > 1) {
                for (int i = 0; i < realEnemyList.Count; i++) {
                    realEnemyList[i].BigSignWidth = 35;
                    realEnemyList[i].SmallSignWidth = 20;
                    realEnemyList[i].MarginBigSign_Y = 5;
                    realEnemyList[i].MarginSmallSign_Y = 3;
                }
            }
        }

        private void RefreshEnemies(Location location, List<Enemy> realEnemyList, int _numberEnemies) {

            location.EnemyList.Clear();

            foreach (Enemy enemy in realEnemyList) {            // Update list with drawn opponents

                location.EnemyList.Add(enemy);
                args.NumberEnemies = _numberEnemies;
            }

            location.UpdateBackground(GameGrid);

            selectEnemy.DeselectAll(selectHero.hero, location);
        }
        
        private int NumberSlotsOfEnemies(System.Random random, Location location) {     //The function draws 3 times and chooses the largest number

            if (location.Level < 4) {       // Because level 4 is BOSS
                int numberOfEnemies = 0;
                double randomValue = 0;
                double randomUpdate = 0;

                for (int i = 0; i < 3; i++) {         

                    randomValue = random.Next(args.randomDownLimit, args.randomUpLimit + 1);

                    if (i == 1) {
                        randomValue = randomValue / 2;         // 2x less chance for two opponents
                    } else if (i == 2) {
                        randomValue = randomValue / 4;          // 3x less chance for two opponents
                    }

                    if (randomValue > randomUpdate) {
                        randomUpdate = randomValue;
                        numberOfEnemies = i + 1;
                    }
                }
                return numberOfEnemies;
            } else {
                return 1;
            }
        }

        void DrawEnemyGrid(int numberEnemies, List<Grid> enemySlotList, List<Border> enemyBorderList) {   

            if (numberEnemies == 1) {           // 1 enemy

                ShowEnemyGrid(oneAllEnemyGrid);

                enemySlotList.Add(oneAllEnemyGrid);
                enemyBorderList.Add(oneEnemyBorder);

            } else if (numberEnemies == 2) {    // 2 enemies

                ShowEnemyGrid(twoAllEnemiesGrid);

                enemySlotList.Add(twoEnemiesGrid_1);
                enemySlotList.Add(twoEnemiesGrid_2);

                enemyBorderList.Add(twoEnemiesBorder_1);
                enemyBorderList.Add(twoEnemiesBorder_2);

            } else {                            // 3 enemies

                ShowEnemyGrid(threeAllEnemiesGrid);

                enemySlotList.Add(threeEnemiesGrid_1);
                enemySlotList.Add(threeEnemiesGrid_2);
                enemySlotList.Add(threeEnemiesGrid_3);


                enemyBorderList.Add(threeEnemiesBorder_1);
                enemyBorderList.Add(threeEnemiesBorder_2);
                enemyBorderList.Add(threeEnemiesBorder_3);
            }
        }

        private void ShowEnemyGrid(Grid cardGrid) {

            selectEnemy.Counter = -1;       // -1 or any number if not 0, to mark the previously marked Border

            threeAllEnemiesGrid.Visibility = Visibility.Hidden;      // Hide all cards and proper cards
            oneAllEnemyGrid.Visibility = Visibility.Hidden;
            twoAllEnemiesGrid.Visibility = Visibility.Hidden;

            cardGrid.Visibility = Visibility.Visible;

            selectEnemy.SelectMetod(selectHero.hero, map.location, args);
        }


        private void Attack_Click(object sender, RoutedEventArgs e) {

            //Click.Play();
            args.EnemyTurn = false;
            args.nextEnemy = 0;

            if (selectHero.hero.ExtraHealEffect(random) is true && selectHero.hero.NumberAttacks == selectHero.hero.NumberAttacks_MAX) {
                selectHero.hero.Heal = true;
                HealControl(selectHero.hero);
            } else if ((selectHero.hero.cyclicDisease.Enable is true) && selectHero.hero.NumberAttacks == selectHero.hero.NumberAttacks_MAX) {
                CyclicDiseaseAttack(selectHero.hero.cyclicDisease, selectHero.hero);
                AttackButton.IsEnabled = false;
                selectHero.hero.CyclicDiseaseTurn = 1;

            } else {

                ControlHero(selectHero.hero);
            }
        }

        private void ControlHero(Hero hero) {

            if (hero.Stun is false) {               // If there is no stun, attack

                AttackButton.IsEnabled = false;
                HeroTurn(hero);

            } else if (hero.cyclicDisease.Enable is false) {
                hero.StunDuration--;

                foreach (Skill skill in hero.SkillList()) {    // Only renewal skill
                    if (skill.CoolDown != 0)
                        skill.CoolDown--;
                }

                AttackButton.IsEnabled = false;
                args.EnemyTurn = true;
                delayingAttackTimer.Start();
                //ControlEnemyAttack(map.location.EnemyList, map.location.EnemyList[args.nextEnemy].cyclicDisease, args);
            }
        }
        private List<Grid> ListSkillGrid() {

            List<Grid> gridList = new List<Grid>() {
                SkillGrid_1,
                SkillGrid_2,
                SkillGrid_3,
                SkillGrid_4,
        };
            return gridList;
        }

        private List<Grid> ListWeaponGrid() {

            List<Grid> gridList = new List<Grid>() {
                EQslotGRID_1,
                EQslotGRID_2,
                EQslotGRID_3,

        };
            return gridList;
        }

        private void AddSkillLabelToList() {

            SkillLabelList = new List<Label>();

            SkillLabelList.Add(SkillLabel_1);
            SkillLabelList.Add(SkillLabel_2);
            SkillLabelList.Add(SkillLabel_3);
            SkillLabelList.Add(SkillLabel_4);
        }             

        private void SelectOneEnemy(object sender, MouseButtonEventArgs e) {

            if (map.location.EnemyList[0].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 0;//args.selectEnemyFlag = 0;
                selectEnemy.SelectMetod(selectHero.hero, map.location, args);//SelectEnemy(map.location.EnemyList, selectHero.hero, args);
            }
        }
        private void SelectTwoEnemies_1(object sender, MouseButtonEventArgs e) {

            if (map.location.EnemyList[0].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 0;//args.selectEnemyFlag = 0;

                selectEnemy.SelectMetod(selectHero.hero, map.location, args);//SelectEnemy(map.location.EnemyList, selectHero.hero, args);
            }
        }
        private void SelectTwoEnemies_2(object sender, MouseButtonEventArgs e) {

            if (map.location.EnemyList[1].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 1;//args.selectEnemyFlag = 1;

                selectEnemy.SelectMetod(selectHero.hero, map.location, args);//SelectEnemy(map.location.EnemyList, selectHero.hero, args);
            }
        }
        private void SelectThreeEnemies_1(object sender, MouseButtonEventArgs e) {
 
            if (map.location.EnemyList[0].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 0;//args.selectEnemyFlag = 0;

                selectEnemy.SelectMetod(selectHero.hero, map.location, args);// SelectEnemy(map.location.EnemyList, selectHero.hero, args);//SelectEnemy(map.location.EnemyBorderList, true);
            }
        }
        private void SelectThreeEnemies_2(object sender, MouseButtonEventArgs e) {

            if (map.location.EnemyList[1].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 1;//args.selectEnemyFlag = 1;

                selectEnemy.SelectMetod(selectHero.hero, map.location, args);//SelectEnemy(map.location.EnemyList, selectHero.hero, args);//SelectEnemy(map.location.EnemyBorderList, true);
            }
        }
        private void SelectThreeEnemies_3(object sender, MouseButtonEventArgs e) {
        
            if (map.location.EnemyList[2].HP > 0 && selectHero.hero.Stun is false) {
                selectEnemy.SelectFlag = 2;//args.selectEnemyFlag = 2;

                selectEnemy.SelectMetod(selectHero.hero, map.location, args);//SelectEnemy(map.location.EnemyList, selectHero.hero, args);//SelectEnemy(map.location.EnemyBorderList, true);
            }
        }

        private void SelectSkill_1(object sender, MouseButtonEventArgs e) {

            if (selectHero.hero.SkillList()[1].CoolDown == 0 && selectHero.hero.Stun is false) {
                selectSkill.SelectFlag = 0;
                selectHero.hero.selectSkillIndex = 1;
                selectSkill.SelectMetod(selectHero.hero, map.location, args);//(ListSkillBorder(), selectHero.hero, args);
            }
        }
        private void SelectSkill_2(object sender, MouseButtonEventArgs e) {

            if (selectHero.hero.SkillList()[2].CoolDown == 0 && selectHero.hero.Stun is false) {
                selectSkill.SelectFlag = 1;
                selectHero.hero.selectSkillIndex = 2;
                selectSkill.SelectMetod(selectHero.hero, map.location, args);//SelectSkill(ListSkillBorder(), selectHero.hero, args); //SelectEnemy(ListSkillBorder(), false);
            }
        }
        private void SelectSkill_3(object sender, MouseButtonEventArgs e) {

            if (selectHero.hero.SkillList()[3].CoolDown == 0 && selectHero.hero.Stun is false) {
                selectSkill.SelectFlag = 2;
                selectHero.hero.selectSkillIndex = 3;
                selectSkill.SelectMetod(selectHero.hero, map.location, args);//SelectSkill(ListSkillBorder(), selectHero.hero, args);
            }
        }
        private void SelectSkill_4(object sender, MouseButtonEventArgs e) {

            if (selectHero.hero.SkillList()[4].CoolDown == 0 && selectHero.hero.Stun is false) {
                selectSkill.SelectFlag = 3;
                selectHero.hero.selectSkillIndex = 4;
                selectSkill.SelectMetod(selectHero.hero, map.location, args);//SelectSkill(ListSkillBorder(), selectHero.hero, args);//SelectEnemy(ListSkillBorder(), false);
            }
        }


        private void EQslot_1_Click(object sender, RoutedEventArgs e) {

            if (selectHero.hero.equipment.AssignFlag is false) {
                selectWeapon.SelectFlag = 0;
                selectWeapon.SelectMetod(selectHero.hero, map.location, args);
            } else {
                selectWeaponAssignment.SelectFlag = 0;
                selectWeaponAssignment.SelectMetod(selectHero.hero, map.location, args);
            }
        }

        private void EQslot_2_Click(object sender, RoutedEventArgs e) {

            if (selectHero.hero.equipment.AssignFlag is false) {
                selectWeapon.SelectFlag = 1;
                selectWeapon.SelectMetod(selectHero.hero, map.location, args);
            } else {
                selectWeaponAssignment.SelectFlag = 1;
                selectWeaponAssignment.SelectMetod(selectHero.hero, map.location, args);
            }
        }

        private void EQslot_3_Click(object sender, RoutedEventArgs e) {

            if (selectHero.hero.equipment.AssignFlag is false) {
                selectWeapon.SelectFlag = 2;
                selectWeapon.SelectMetod(selectHero.hero, map.location, args);
            } else {
                selectWeaponAssignment.SelectFlag = 2;
                selectWeaponAssignment.SelectMetod(selectHero.hero, map.location, args);
            }
        }

        private void EQslot_4_Click(object sender, RoutedEventArgs e) {

            if (selectHero.hero.equipment.AssignFlag is false) {
                selectWeapon.SelectFlag = 3;
                selectWeapon.SelectMetod(selectHero.hero, map.location, args);
            } else {
                selectWeaponAssignment.SelectFlag = 3;
                selectWeaponAssignment.SelectMetod(selectHero.hero, map.location, args);
            }
        }


        private void ControlEnemyAttack(List<Enemy> enemy, CyclicDisease cyclicDisease, ClassArgs args) {     // Główna funckja do kontroli ataku mobow

            //debager.Text += $"\n{args.EnemyTurn}, {args.EndingTurnCnt}";
            if (args.EnemyTurn is true && (args.EndingTurnCnt == 0)) {

                if (enemy[args.nextEnemy].NumberAttacks == enemy[args.nextEnemy].NumberAttacks_MAX)
                    HealControl(enemy[args.nextEnemy]);

                if (enemy[args.nextEnemy].HealTurn == 2 || enemy[args.nextEnemy].Heal is false) {
                    SkipStunOrDead(enemy, cyclicDisease);       // METHOD OF MEASURING THE ENEMIES WHO HAVE NOTHING OR THE STUN BUT DOES NOT TRUCK IF THE TRUCK IS NEXT

                    // LIFE IF ANY LIFE LIFE AND NO STUN OR LIVING IS STUN BUT TRUCY BUT LIKE TO TRY

                    if ((enemy[args.nextEnemy].HP > 0 && enemy[args.nextEnemy].Stun is false) || (enemy[args.nextEnemy].HP > 0 && enemy[args.nextEnemy].Stun is true && (enemy[args.nextEnemy].cyclicDisease.Enable is true))) {
                        AttackMainControl(enemy[args.nextEnemy], cyclicDisease, args);

                    } else if (enemy[args.nextEnemy].HP > 0 && enemy[args.nextEnemy].Stun is true) {
                        enemy[args.nextEnemy].NumberAttacks = 0;
                        enemy[args.nextEnemy].CyclicDiseaseTurn = 0;
                        if (enemy[args.nextEnemy].Slow is true) {
                            enemy[args.nextEnemy].SlowDuration--;
                        }
                        AttackButton.IsEnabled = true;
                    }
                    EndEnemiesTurn(map.location.EnemyList[args.nextEnemy], args);
                }
            }
        }

        private void SkipStunOrDead(List<Enemy> enemy, CyclicDisease cyclicDisease) {

            args.NumberEnemies = enemy.Count;

            if (enemy[args.nextEnemy].HP <= 0 || (enemy[args.nextEnemy].Stun is true && cyclicDisease.Enable is false)) {
                while ((enemy[args.nextEnemy].HP <= 0 && args.nextEnemy < args.NumberEnemies - 1) || (enemy[args.nextEnemy].Stun is true && args.nextEnemy < args.NumberEnemies - 1)) {
                    if (enemy[args.nextEnemy].Stun is true) {
                        enemy[args.nextEnemy].StunDuration--;
                    }
                    args.nextEnemy++;
                }
            }
        }

        private void AttackMainControl(Enemy enemy, CyclicDisease cyclicDisease, ClassArgs args) {

            if (enemy.cyclicDisease.Enable is true) {    // TRUCK COUNCIL, IF POISON TURN = 1, TRUCK FITTAL, MUST BE 0, ENEMY
                enemy.CyclicDiseaseTurn++;
            } else {
                enemy.CyclicDiseaseTurn = 0;
            }

            if (enemy.CyclicDiseaseTurn == 1 && enemy.NumberAttacks == enemy.NumberAttacks_MAX) {       // The poison crushes at the beginning only if the mob does not once hit
                CyclicDiseaseAttack(enemy.cyclicDisease, enemy);

                if (cyclicDisease.Death is true && args.nextEnemy == args.NumberEnemies - 1) {
                    args.EnemyTurn = false;
                }
                if(enemy.Stun is true) {
                    //enemy.CyclicDiseaseTurn = 0;
                    enemy.StunDuration--;
                    if (enemy.Slow is true) {
                        enemy.SlowDuration--;
                    }
                    enemy.NumberAttacks = 0;
                }

            } else {            // POISON HIT, COUNTER + = 1, AND NOW MOB
                //if (enemy.Stun is false) {     // If there is no STUN, for a moment it will strike
                EnemyTurn(enemy);
                enemy.CyclicDiseaseTurn = 0;
            }
            if (enemy.Stun is true && args.nextEnemy < args.NumberEnemies - 1) {
                enemy.StunDuration--;
                args.nextEnemy++;
            }
        }

        private void HealControl(Character character) {

            if (character.Heal is true)
                character.HealTurn++;
            else {
                character.HealTurn = 0;
            }
            GetHeal(character);
        }

        private void GetHeal(Character character) {

            if (character.HealTurn == 1) {
                character.HealMetod(ref dmgIndicator);
                dispatcherTimer.Start();
            }
        }

        private void EndEnemiesTurn(Enemy enemy, ClassArgs args) {

            EndTurnPreparationFlag(map.location.EnemyList, args);
            //Debager.Text += $"\n{enemy.NumberAttacks},{enemy.PreparationSkillCnt}";
            if ((args.nextEnemy == args.NumberEnemies - 1 && (enemy.NumberAttacks <= 0 || (enemy.NumberAttacks == 1 && enemy.PreparationSkillCnt == 1) || enemy.Stun is true && enemy.cyclicDisease.Enable is false))
                || (args.nextEnemy == args.NumberEnemies - 1 && (enemy.HP <= 0 /*|| (enemy.Stun is true && enemy.cyclicDisease.Enable is false)*/)) || args.EndTurnPreparationFlag == true) {     // Wszystkie potworki walnely, I NA TO UWAGA BO TU WCHODZI NA OSTATNIEGO MOBA I MOZE GO WYLACZYC                                                                                      //debager.Text += $"\n{map.location.EnemyList[args.nextEnemy].PoisonTurn}";
                ///debager.Text += $"\nNAefef";                                                                                      //if (enemy.CyclicDiseaseTurn == 0) {                                                                                                            //debager.Text += $"\n2";
                if (enemy.BuffStart is true || (enemy.Stun is true && enemy.CyclicDiseaseTurn == 0) || enemy.HealStart is true) {
                    //Debager.Text += $"\n{0}";
                    args.EndingTurnCnt = 2;
                    if (enemy.Stun is true)
                        enemy.StunDuration--;
                } else {
                    args.EndingTurnCnt = 1;
                    //Debager.Text += $"\n{0}";
                }

                enemy.HealTurn = 0;

                HeroStunControl();

                if (enemy.CyclicDiseaseTurn == 0) {
                    if (enemy.PoisonVisible == Visibility.Visible) { }
                    if (enemy.BurnVisible == Visibility.Visible) { }
                    if (enemy.SlowVisible == Visibility.Visible) { }
                    if (enemy.StunVisible == Visibility.Visible) { }
                }

                enemy.NumberAttacks = enemy.NumberAttacks_MAX;        // Save the attack to the last mob

                if (selectHero.hero.HP <= 0) {
                    DeathMessage.Visibility = Visibility.Visible;

                    INFO.IsEnabled = false;
                    cardGrid.IsEnabled = false;
                    PotionGrid.IsEnabled = false;
                }
            }
        }

        private void EndTurnPreparationFlag(List<Enemy> enemyList, ClassArgs args) {

            if (args.NumberEnemies > 1) {
                if ((enemyList[args.NumberEnemies - 1].HP <= 0 || enemyList[args.NumberEnemies - 1].Stun is true) && (enemyList[args.NumberEnemies - 2].HP > 0 && enemyList[args.NumberEnemies - 2].NumberAttacks == 1 && enemyList[args.NumberEnemies - 2].PreparationSkillCnt == 1)) {
                    args.EndTurnPreparationFlag = true;
                }
                else if(args.NumberEnemies == 3 && (enemyList[args.NumberEnemies - 1].HP <= 0 || enemyList[args.NumberEnemies - 1].Stun is true) && (enemyList[args.NumberEnemies - 2].HP <= 0 || enemyList[args.NumberEnemies - 2].Stun is true) && (enemyList[0].HP > 0 && enemyList[0].NumberAttacks == 1 && enemyList[0].PreparationSkillCnt == 1)) {
                    args.EndTurnPreparationFlag = true;
                }              
            }
        }

        private void CheckIfEnemyIsSelect() {    // If it was marked mob it does not deselect, in the case of buff eg or after AoE is not selected

            if (map.location.EnemyBorderList.FindIndex(x => x.BorderBrush == Brushes.Red) != -1) {
                AttackButton.Content = "Atakuj!";
                AttackButton.IsEnabled = true;
            } else if(selectHero.hero.Stun is false){
                AttackButton.IsEnabled = false;
            }
        }

        private void HeroStunControl() {

            if (selectHero.hero.Stun is true) {
                selectEnemy.DeselectAll(selectHero.hero, map.location);
                AttackButton.IsEnabled = true;
                AttackButton.Content = "Pass";

            } else if (selectHero.hero.EndStun is true) {
                AttackButton.Content = "Atakuj!";
                AttackButton.IsEnabled = false;
                selectHero.hero.EndStun = false;
            }
        } 

        private void TimerInit() {      // Initalize timers

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer1_Start);

            delayingAttackTimer = new DispatcherTimer();
            delayingAttackTimer.Tick += new EventHandler(delayingAttackTimer_Tick);
            delayingAttackTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer2_Start);

            skillPreparationTimer = new DispatcherTimer();
            skillPreparationTimer.Tick += new EventHandler(skillPreparationTimer_Tick);
            skillPreparationTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer3_Start);

            dropTimer = new DispatcherTimer();
            dropTimer.Tick += new EventHandler(dropTimer_Tick);
            dropTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer4_Start);

        }

        private void ControlSelectTimer() {

            if (selectHero.hero.AoESelect is true) {
                selectHero.hero.AoESelect = false;
                selectEnemy.DeselectAll(selectHero.hero, map.location);
            }

            if (map.location.EnemyList[selectEnemy.SelectFlag].HP <= 0) {  // If the marked opponent dies, uncheck it

                selectEnemy.DeselectAll(selectHero.hero, map.location);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e) {                 // Timer to show injuries and back cards to their place

            args.dispatcherTimerCnt++;
            //debager.Text += $"\nW TIMERZE:{args.EndingTurnCnt}";
            if (args.dispatcherTimerCnt == 1) {
                DMGgrid.Visibility = Visibility.Visible;
                DMGgrid.DataContext = dmgIndicator;                     
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer1);

                //debager.Text += $"\nPRZED:{args.EndingTurnCnt}";

            } else {          
                DMGgrid.Visibility = Visibility.Hidden;
                dmgIndicator.Text = null;

                BackEverybody(selectHero.hero, map.location.EnemyList);                 // Everyone back
                selectHero.hero.ClearEnemy(map.location.EnemyList[selectEnemy.SelectFlag]);
                ControlSelectTimer();

                dispatcherTimer.Stop();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer1_Start);
                args.dispatcherTimerCnt = 0;

                if (dropTimerFlag is true) {
                    dropTimer.Start();
                } else {
                    delayingAttackTimer.Start();
                }
            }
        }

        private void delayingAttackTimer_Tick(object sender, EventArgs e) {   

            args.delayingTimerCnt++;
            if (args.delayingTimerCnt == 1) {

                KillingPoisonMetod(map.location.EnemyList[args.nextEnemy], map.location.EnemyList[args.nextEnemy].cyclicDisease, args);                                               // If the poison killed someone

                if (selectHero.hero.LevelUp(random, args) is true) {             
                    SkillMessageUpdate(selectHero.hero);
                    delayingAttackTimer.Stop();

                    INFO.IsEnabled = false;
                    PotionGrid.IsEnabled = false;
                }

                if (map.location.EnemyList[args.nextEnemy].cyclicDisease.Death is false)
                    delayingAttackTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer2);


            } else {

                delayingAttackTimer.Stop();
                delayingAttackTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer2_Start);

                ControlEnemyAttack(map.location.EnemyList, map.location.EnemyList[args.nextEnemy].cyclicDisease, args);


                if (map.location.EnemyList.Count > 0)
                    LastStageEndingEnemyTurn(args, map.location.EnemyList[args.nextEnemy]);

                LastStageHeroTurn(selectHero.hero);

                if (map.location.EnemyList[args.nextEnemy].cyclicDisease.Death is false)        // If everyone attaks, update the map
                     LocationUpdateAll();


                AutomaticHeroTurn(selectHero.hero, args);                    // When you hit a poison, it comes to this point and Hero must make an attack

                /*if(map.location.EnemyList.Count > 0)
                    LastStageEndingEnemyTurn(args, map.location.EnemyList[args.nextEnemy]);
                LastStageHeroTurn(selectHero.hero);*/

                if (selectHero.hero.HP <= 0) {
                    DeathMessage.Visibility = Visibility.Visible;

                    INFO.IsEnabled = false;
                    cardGrid.IsEnabled = false;
                    PotionGrid.IsEnabled = false;
                }

                args.delayingTimerCnt = 0;
            }
        }

        private void LastStageEndingEnemyTurn(ClassArgs args, Enemy enemy) {

            //debager.Text += $"\n{args.EndingTurnCnt}";

            if (args.EndingTurnCnt == 2) {

                //Debager.Text += $"\nTOO:{args.EndTurnPreparationFlag}";
                CheckIfEnemyIsSelect();              // It is important that 'Attack' is activated only when the opponent attacks, goes back, and all Timers
                args.EndingTurnCnt = 0;              // finish. Without this counter, the ControlEnemyAttack function would start the attack and eventually activate
                map.location.Turn += 1;              // and at the end it would activate the 'Attack' that could be pressed during the opponent's turn.
                args.EnemyTurn = false;
                enemy.BuffStart = false;
                enemy.CyclicDiseaseTurn = 0;
                args.EndTurnPreparationFlag = false;
                args.nextEnemy = 0;
                selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
                enemy.NumberAttacks = enemy.NumberAttacks_MAX;

                HeroStunControl();

                if (selectHero.hero.HP <= 0) {
                    DeathMessage.Visibility = Visibility.Visible;

                    INFO.IsEnabled = false;
                    cardGrid.IsEnabled = false;
                    PotionGrid.IsEnabled = false;
                }
            }
            if (args.EndingTurnCnt == 1) {
                args.EndingTurnCnt = 2;
                //Debager.Text += $"\n{0}";
                if (map.location.EnemyList[args.nextEnemy].Stun is true) {
                    //map.location.EnemyList[args.nextEnemy].StunDuration--;
                    //delayingAttackTimer.Start();
                }
                else if (map.location.EnemyList[args.nextEnemy].BuffSkill is true) {
                    //delayingAttackTimer.Start();
                }
            }
        }

        private void LastStageHeroTurn(Hero hero) {
            if(args.EnemyTurn is false && hero.NumberAttacks > 0) {
                CheckIfEnemyIsSelect();
            }
        }

        private void skillPreparationTimer_Tick(object sender, EventArgs e) {           // Timer to show attack name, except Normal Attack

            args.skillPreparationTimerCnt++;
            if (args.skillPreparationTimerCnt == 1) {

                Preparation.controls.play();
                //Preparation.Play();
                DMGgrid.Visibility = Visibility.Visible;
                DMGgrid.DataContext = skillPreparationIndicator;


                skillPreparationTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer3);

            } else {

                DMGgrid.Visibility = Visibility.Hidden;
                skillPreparationIndicator.Text = null;

                skillPreparationTimer.Stop();
                skillPreparationTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer3_Start);

                if (args.EnemyTurn is false) {
                    HeroTurn(selectHero.hero);
                } else {
                    EnemyTurn(map.location.EnemyList[args.nextEnemy]);
                    //if(map.location.EnemyList[args.nextEnemy].BuffStart is false)
                    //args.EnemyTurn = false;       // tego tu kurwa nie moze byc
                }
                
                args.skillPreparationTimerCnt = 0;
            }
        }

        private void dropTimer_Tick(object sender, EventArgs e) {                 // Timer to show injuries and back cards to their place

            args.dropTimerCnt++;

            if (args.dropTimerCnt == 1) {
                DropGrid.Visibility = Visibility.Visible;
                selectHero.hero.equipment.weaponList[selectHero.hero.equipment.weaponList.Count - 1].UpdateGrid(DropGrid);

                dropTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer4);

            } else {
                DropGrid.Visibility = Visibility.Hidden;
                dropTimer.Stop();
                dropTimer.Interval = new TimeSpan(0, 0, 0, 0, args.milisecondsTimer4_Start);

                args.dropTimerCnt = 0;
                dropTimerFlag = false;

                delayingAttackTimer.Start();
            }
        }

        private void AutomaticHeroTurn(Hero hero, ClassArgs args) {

            if (hero.CyclicDiseaseTurn == 1 || hero.HealTurn == 1) {

                if (hero.Stun is false) {
                    args.EnemyTurn = false;
                    HeroTurn(hero);
                    AttackButton.IsEnabled = true;

                    if (hero.NumberAttacks == 0) {
                        //hero.NumberAttacks = hero.NumberAttacks_MAX;
                    }
                } else {
                    hero.StunDuration--;
                    args.EnemyTurn = true;
                    ControlEnemyAttack(map.location.EnemyList, map.location.EnemyList[args.nextEnemy].cyclicDisease, args);
                }
                hero.Heal = false;
                hero.HealTurn = 0;
                hero.CyclicDiseaseTurn = 0;
            }
        }

        private void LocationUpdateAll() {

            if (map.location.AllEnemiesDefeated() is true) {
                args.EnemyTurn = false;
                map.location.Turn += 1;
                map.location.DeathCounter++;
                args.EndingTurnCnt = 0;
            }

            if (map.location.ChangeLocation() is true) {
                GetArtefact();
            } else if (map.location.LevelUP() is true)
                NewBackgroundEvent(map.location);
            else if (map.location.AllEnemiesDefeated() is true) {
                AddEnemy(map.location, random);
                if (selectHero.hero.NumberAttacks <= 0)
                    selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
            }
        }

        private void LevelUPMessage_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            AddSkill(selectHero.hero, selectSkill);
            LevelUPMessageGrid.Visibility = Visibility.Hidden;

            INFO.IsEnabled = true;
            cardGrid.IsEnabled = true;
            PotionGrid.IsEnabled = true;

            HeroStunControl();                                  

            if (args.NumberEnemies > 1 && map.location.AllEnemiesDefeated() is false) {         // If the enemies are still alive, continue their attack
                args.delayingTimerCnt = 1;
                delayingAttackTimer.Start();

            } else {
                args.EnemyTurn = false;                                                         //If all the enemies are killed, the turn of Heros
            }

            LocationUpdateAll();
        }


        private void SmallPotion_Click(object sender, RoutedEventArgs e) {

            GetPotion(selectHero.hero.equipment.SmallPotion);
        }

        private void BigPotion_Click(object sender, RoutedEventArgs e) {

            GetPotion(selectHero.hero.equipment.BigPotion);
        }

        private void GetPotion(Potion potion) {

            if (args.EnemyTurn is false && selectHero.hero.Stun is false && potion.Count > 0) {

                PotionGulp.Play();

                selectHero.hero.HP += potion.HP;
                potion.Count--;
            }
        }

        private void ArtefactButton_Click(object sender, RoutedEventArgs e) {                    // Changes location and shows map if needed

            if (Map.DifficultyLevel == 2 || Map.DifficultyLevel == 4) {
                ArtefactGrid.Visibility = Visibility.Hidden;
                cardGrid.Visibility = Visibility.Visible;
                PotionGrid.Visibility = Visibility.Visible;

                ChangeLocationEvent();
            } else if(Map.DifficultyLevel == 3) {
                new Map(selectHero).Show();
                this.Close();
                ArtefactGrid.Visibility = Visibility.Hidden;

            } else if(Map.DifficultyLevel == 5) {
                new Map(selectHero).Show();
                this.Close();
                ArtefactGrid.Visibility = Visibility.Hidden;
            } else {
                new MainWindow().Show();
                this.Close();
            }
        }

        private void INFO_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            args.INFOCnt++;

            if(args.INFOCnt == 1) {
                FeatureInfoGrid.Visibility = Visibility.Visible;
                cardGrid.IsEnabled = false;
                WeaponSlotsGrid.IsEnabled = false;
                PotionGrid.IsEnabled = false;

            } else {
                FeatureInfoGrid.Visibility = Visibility.Hidden;
                EQGrid.Visibility = Visibility.Hidden;
                cardGrid.IsEnabled = true;
                PotionGrid.IsEnabled = true;
                WeaponSlotsGrid.IsEnabled = true;

                args.INFOCnt = 0;
            }
        }

        private void FeatureBack_Click(object sender, RoutedEventArgs e) {

            FeatureInfoGrid.Visibility = Visibility.Hidden;
            cardGrid.IsEnabled = true;
            PotionGrid.IsEnabled = true;
            WeaponSlotsGrid.IsEnabled = true;

            args.INFOCnt = 0;
        }

        private void EquipmentButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            FeatureInfoGrid.Visibility = Visibility.Hidden;
            EQGrid.Visibility = Visibility.Visible;
            selectHero.hero.equipment.UpdateWeaponImage(WeaponImageGrid);
            if (selectHero.hero.equipment.weaponList.Count == 0) {
                EQequipWeaponButton.IsEnabled = false;
                EQdropWeaponButton.IsEnabled = false;
            }

        }

        private void Menu_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            args.MENUCnt++;

            if (args.MENUCnt == 1) {
                MenuGrid.Visibility = Visibility.Visible;

                SelectMenuFlag(false);
            } else {
                MenuGrid.Visibility = Visibility.Hidden;

                SelectMenuFlag(true);

                args.MENUCnt = 0;
            }
        }

        private void Continue_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            MenuGrid.Visibility = Visibility.Hidden;

            SelectMenuFlag(true);

            args.MENUCnt = 0;
        }

        private void SelectMenuFlag(bool value) {

            INFO.IsEnabled = value;
            cardGrid.IsEnabled = value;
            PotionGrid.IsEnabled = value;
            WeaponSlotsGrid.IsEnabled = value;
            FeatureInfoGrid.IsEnabled = value;
            EQGrid.IsEnabled = value;
        }

        private void ResurrectionButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.HP = selectHero.hero.HP_MAX;
            selectHero.hero.NumberAttacks = selectHero.hero.NumberAttacks_MAX;
            selectHero.hero.BloodSucking = false;
            selectHero.hero.cyclicDisease.Burn = false;
            selectHero.hero.cyclicDisease.Poison = false;
            selectHero.hero.cyclicDisease.Enable = false;
            selectHero.hero.cyclicDisease.Death = false;


            if(selectHero.hero.equipment.SmallPotion.Count < 3)
                selectHero.hero.equipment.SmallPotion.Count = 3;
            if(selectHero.hero.equipment.BigPotion.Count < 1)
                selectHero.hero.equipment.BigPotion.Count = 1;


            DeathMessage.Visibility = Visibility.Hidden;

            INFO.IsEnabled = true;
            cardGrid.IsEnabled = true;
            PotionGrid.IsEnabled = true;
        }

        private void EQequipWeaponButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            selectHero.hero.equipment.AssignFlag = true;
            WeaponSlotsGrid.IsEnabled = true;
            EQequipWeaponButton.IsEnabled = false;
            EQdropWeaponButton.IsEnabled = false;
            selectWeapon.DeselectAll(selectHero.hero, map.location);

            AssignEQSlot_1.Visibility = Visibility.Visible;
            AssignEQSlot_2.Visibility = Visibility.Visible;
            AssignEQSlot_3.Visibility = Visibility.Visible;
            AssignEQSlot_4.Visibility = Visibility.Visible;
        }

        private void EQdropWeaponButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            selectHero.hero.equipment.weaponList.RemoveAt(selectWeaponListIndex);

            selectWeaponAssignment.DeselectAll(selectHero.hero, map.location);
            selectHero.hero.equipment.UpdateWeaponImage(WeaponImageGrid);
            EQequipWeaponButton.IsEnabled = true;

            selectWeaponListIndex = 0;

            if (!(selectHero.hero.equipment.weaponList.Count > 0)) {
                EQequipWeaponButton.IsEnabled = false;
                EQdropWeaponButton.IsEnabled = false;
            }
        }

        private void EQacceptButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();

            if (selectHero.hero.equipment.weaponList.Count > 0) {
                AssignWeapon(selectHero.hero, selectWeaponAssignment);
                selectWeaponAssignment.DeselectAll(selectHero.hero, map.location);
                EQequipWeaponButton.IsEnabled = true;
                EQdropWeaponButton.IsEnabled = true;
                WeaponSlotsGrid.IsEnabled = false;
            }
        }

        private void AssignWeapon(Hero hero, SelectWeaponAssignment selectSlotWeapon) {

            if (selectSlotWeapon.AssignWeapon is true && hero.equipment.AssignedWeaponDic.ContainsKey(selectSlotWeapon.SelectFlag + 1) is true) {
                hero.equipment.AssignedWeaponDic.Remove(selectSlotWeapon.SelectFlag + 1);
            }
            if (selectSlotWeapon.AssignWeapon is true) {
                selectHero.hero.equipment.AssignedWeaponDic.Add(selectSlotWeapon.SelectFlag + 1, hero.equipment.weaponList[selectWeaponListIndex]);
            }
        }

        private void EQbackButton_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            EQGrid.Visibility = Visibility.Hidden;
            selectWeaponAssignment.DeselectAll(selectHero.hero, map.location);

            cardGrid.IsEnabled = true;
            PotionGrid.IsEnabled = true;
            WeaponSlotsGrid.IsEnabled = true;
            INFO.IsEnabled = true;

            EQequipWeaponButton.IsEnabled = true;
            EQdropWeaponButton.IsEnabled = true;
            selectWeaponListIndex = 0;

            SPECIALtext.Text = null;
            args.SPECIALCnt = 0;

            args.INFOCnt = 0;
        }

        private void SPECIAL_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            args.SPECIALCnt++;
            if(args.SPECIALCnt == 1) {
                WeaponImageGrid.DataContext = null;

                if (selectHero.hero.equipment.weaponList.Count > 0)
                    SPECIALtext.Text = selectHero.hero.equipment.weaponList[selectWeaponListIndex].FeaturesDescribe;

            } else {
                if(selectHero.hero.equipment.weaponList.Count > 0) {
                    ImageUri imageUri = new ImageUri(new Uri(selectHero.hero.equipment.weaponList[selectWeaponListIndex].BackgroundURL, UriKind.Relative));
                    imageUri.UpdateImage(WeaponImageGrid);
                }
                    //selectHero.hero.equipment.UpdateWeaponImage(WeaponImageGrid);

                SPECIALtext.Text = null;
                args.SPECIALCnt = 0;
            }
        }

    private void MainMenu_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new MainWindow().Show();
            this.Close();
        }

        private void End_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            this.Close();
        }

        private void DeathMessage_End_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            new MainWindow().Show();
            this.Close();
        }

        private void lvNameColumnHeader_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.equipment.Sort(selectHero.hero.equipment.weaponList.OrderBy(x => x.Name).ToList(),
                                           selectHero.hero.equipment.weaponList.OrderByDescending(x => x.Name).ToList());

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
        }

        private void lvTypeColumnHeader_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.equipment.Sort(selectHero.hero.equipment.weaponList.OrderBy(x => x.Type).ToList(),
                                           selectHero.hero.equipment.weaponList.OrderByDescending(x => x.Type).ToList());

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
        }


        private void lvDMG_MINColumnHeader_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.equipment.Sort(selectHero.hero.equipment.weaponList.OrderBy(x => x.DMG_MIN).ToList(),
                               selectHero.hero.equipment.weaponList.OrderByDescending(x => x.DMG_MIN).ToList());

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
        }

        private void lvDMG_MAXColumnHeader_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.equipment.Sort(selectHero.hero.equipment.weaponList.OrderBy(x => x.DMG_MAX).ToList(),
                   selectHero.hero.equipment.weaponList.OrderByDescending(x => x.DMG_MAX).ToList());

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
        }

        private void lvDMG_TYPEColumnHeader_Click(object sender, RoutedEventArgs e) {

            Click.Play();
            selectHero.hero.equipment.Sort(selectHero.hero.equipment.weaponList.OrderBy(x => x.DMG_TYPE).ToList(),
                                           selectHero.hero.equipment.weaponList.OrderByDescending(x => x.DMG_TYPE).ToList());

            LvWeapon.ItemsSource = selectHero.hero.equipment.weaponList;
        }
    }
}