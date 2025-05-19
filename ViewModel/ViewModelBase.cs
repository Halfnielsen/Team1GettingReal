using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GettingReal.ViewModel
{
    
    // Fælles baseklasse der giver INotifyPropertyChanged til alle ViewModels.    
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

       
        // Kaldes direkte, hvis du manuelt vil rejse PropertyChanged.        
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        
        // Sætter feltet hvis værdien er ændret og rejser PropertyChanged.
        // Returnerer true, hvis værdien rent faktisk blev ændret.        
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }
    }
}
