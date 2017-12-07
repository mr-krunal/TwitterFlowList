using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
namespace TwitterFlowList
{
    public class Item : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        //public Color _Color = Color.FromHex("#0040ff");
        //public Color Color
        //{
        //    get { return _Color; }
        //    set { SetProperty(ref _Color, value); }            
        //}

        public Color _Color = Color.FromHex("#0040ff");
        public Color Color
        {
            get { return _Color; }
            set { _Color =  value; }
        }

        public String _MyColor = "#ff40ff";
        public String MyColor
        {
            get { return _MyColor; }
            set { SetProperty(ref _MyColor, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
    [CallerMemberName]string propertyName = "",
    Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
