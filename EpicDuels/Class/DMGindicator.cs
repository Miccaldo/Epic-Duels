using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicDuels.Class {

    public class DMGindicator : Base {

        private string _text;
        private System.Windows.Media.Brush _DMGColour_1;
        private System.Windows.Media.Brush _DMGColour_2;
        private int _Size;

        public string Text {

            get { return _text; }
            set {
                _text = value;

                OnPropertyChanged(nameof(Text));
            }
        }

        public System.Windows.Media.Brush DMGColour_1 {
            get { return _DMGColour_1; }
            set {
                _DMGColour_1 = value;
                OnPropertyChanged(nameof(DMGColour_1));
            }
        }

        public System.Windows.Media.Brush DMGColour_2 {
            get { return _DMGColour_2; }
            set {
                _DMGColour_2 = value;
                OnPropertyChanged(nameof(DMGColour_2));
            }
        }

        public int Size {
            get { return _Size; }
            set {
                _Size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        private Thickness _SkillIndicatorMarginA;
        public Thickness SkillIndicatorMarginA {

            get { return _SkillIndicatorMarginA; }
            set {
                _SkillIndicatorMarginA = value;
                OnPropertyChanged(nameof(SkillIndicatorMarginA));
            }
        }

        private Thickness _SkillIndicatorMarginB;
        public Thickness SkillIndicatorMarginB {

            get { return _SkillIndicatorMarginB; }
            set {
                _SkillIndicatorMarginB = value;
                OnPropertyChanged(nameof(SkillIndicatorMarginB));
            }
        }

        public DMGindicator(string text,int Size, System.Windows.Media.Brush DMGColour_1, System.Windows.Media.Brush DMGColour_2, Thickness SkillIndicatorMarginA, Thickness SkillIndicatorMarginB) {

            this.Text = text;
            this.Size = Size;
            this.DMGColour_1 = DMGColour_1;
            this.DMGColour_2 = DMGColour_2;
            this.SkillIndicatorMarginA = SkillIndicatorMarginA;
            this.SkillIndicatorMarginB = SkillIndicatorMarginB;
        }
    }
}
