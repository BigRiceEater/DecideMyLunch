using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Annotations;

namespace DecideMyLunch.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion 

        #region Methods
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Delegates
        public delegate void UpdateAppStatusDelegate(string msg);
        protected UpdateAppStatusDelegate UpdateAppStatus { get; set; }
        #endregion 
    }
}
