using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlagsToCheckboxBinding;

namespace FlagsToCheckboxBinding
{
    public class ViewModel :INotifyPropertyChanged
    {
        public ViewModel()
        {
            iFlags = 1;
            iEnabledFlags = 7;
        }

        private IList<FlagDescription> iFlagsToDisplay;

        public IList<FlagDescription> FlagsToDisplay
        {
            get { return iFlagsToDisplay ?? ( iFlagsToDisplay = new List<FlagDescription>
                {
                    FlagDescription.FlagOne, FlagDescription.FlagTwo, FlagDescription.FlagThree, FlagDescription.FlagFour
                });
            }
        }

        private int iFlags;

        public int Flags
        {
            get { return iFlags; }
            set
            {
                iFlags = value;
                OnPropertyChanged("Flags");
            }
        }

        private int iEnabledFlags;

        public int EnabledFlags
        {
            get { return iEnabledFlags; }
            set
            {
                iEnabledFlags = value; 
                OnPropertyChanged("EnabledFlags");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
