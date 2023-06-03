using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm;
namespace Food.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        
        [ObservableProperty]
        string title;


        
        public bool IsNotBusy => !IsBusy;
         
        

        
    }
}
