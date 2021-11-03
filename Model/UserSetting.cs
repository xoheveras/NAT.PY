using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace NAT.PY.Model
{
    public class UserGetSetting : INotifyPropertyChanged
    {
        private string _backGroundColor,_fontColor,_secondColor;

        public string backGroundColor
        {
            get 
            { 
                return _backGroundColor;
            }
            set
            {
                _backGroundColor = value;
                OnPropertyChanged("backGroundColor");
            }
        }
        public string fontColor
        {
            get
            {
                return _fontColor;
            }
            set
            {
                _fontColor = value;
                OnPropertyChanged("fontColor");
            }
        }

        public UserGetSetting() => InitUserSetting();

        public void InitUserSetting()
        {
            backGroundColor = "#FFFFFFFF";
            fontColor = "#000";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
