using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EpicDuels.Class.CHARACTER.Skills {

    public class SkillSize {
        
        public string Name { get; set; }
        public int Margin_Y { get; set; }
        public int Width { get; set; }

        public Thickness Margin { get; set; }


        public SkillSize(string Name, Thickness Margin, int Margin_Y, int Width) {

            this.Margin_Y = Margin_Y;
            this.Name = Name;
            this.Margin = Margin;
            this.Width = Width;
        }
    }
}
