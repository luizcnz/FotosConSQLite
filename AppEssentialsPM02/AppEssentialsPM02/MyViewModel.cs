using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppEssentialsPM02
{
    public class MyViewModel : INotifyPropertyChanged
    {
        bool isMenuItemEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsMenuItemEnabled
        {
            get { return isMenuItemEnabled; }
            set
            {
                isMenuItemEnabled = value;
                MyCommand.ChangeCanExecute();
            }
        }

        public Command MyCommand { get; private set; }

        public MyViewModel()
        {
            MyCommand = new Command(() =>
            {
                // Execute logic here
            },
            () => IsMenuItemEnabled);
        }
    }
}
