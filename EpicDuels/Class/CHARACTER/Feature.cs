using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class.CHARACTER {

    public class Feature : Base {

        private const int FEATURE_MAX = 18;
        private const int FEATURE_MIN = 8;
        private const int COUNTER_MAX = 20;

        public string Name { get; set; }
        public int ImageNumber { get; set; }
        public int Value { get; set; }

        private int _Strength;
        public int Strength {
            get {
                return _Strength;
            }
            set {
                PropertiesMetod(ref _Strength, value);
                OnPropertyChanged(nameof(Strength));
            }
        }
        private int _Endurance;
        public int Endurance {
            get {
                return _Endurance;
            }
            set {
                PropertiesMetod(ref _Endurance, value);
                OnPropertyChanged(nameof(Endurance));
            }
        }
        private int _Agility;
        public int Agility {
            get {
                return _Agility;
            }
            set {
                PropertiesMetod(ref _Agility, value);
                OnPropertyChanged(nameof(Agility));
            }
        }
        private int _Intelligence;
        public int Intelligence {
            get {
                return _Intelligence;
            }
            set {
                PropertiesMetod(ref _Intelligence, value);
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private int _Counter;
        public int Counter {

            get { return _Counter; }
            set {
                _Counter = value;

                if (_Counter > COUNTER_MAX)
                    _Counter = COUNTER_MAX;
                else if (_Counter < 0)
                    _Counter = 0;

                OnPropertyChanged(nameof(Counter));
            }
        }

        private void PropertiesMetod(ref int feature, int value) {

            if (Counter <= 0 && (feature - value) == -1) {
                feature += 0;
            } else {
                feature = value;
            }

            if (feature > FEATURE_MAX) {
                feature = FEATURE_MAX;
                _Counter += 1;
            } else if (feature < FEATURE_MIN) {
                feature = FEATURE_MIN;
                _Counter -= 1;
            }
        }

        public void UpdateFeature(Grid grid) {

            grid.DataContext = this;
        }

        public Feature(int Strength = FEATURE_MIN, int Endurance = FEATURE_MIN, int Agility = FEATURE_MIN, int Intelligence = FEATURE_MIN, int Counter = COUNTER_MAX) {

            this.Strength = Strength;
            this.Endurance = Endurance;
            this.Agility = Agility;
            this.Intelligence = Intelligence;
            this.Counter = Counter;
        }
    }
}