using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicDuels.Class {

    public class ImageUri : Base{

        private Uri _SourceUri;

        public Uri SourceUri {
            get { return _SourceUri; }
            set {
                _SourceUri = value;
                OnPropertyChanged(nameof(SourceUri));
            }
        }

        public void UpdateImage(Grid grid) {

            grid.DataContext = this;
        }

        public ImageUri(Uri SourceUri) {

            this.SourceUri = SourceUri;
        }
    }
}
