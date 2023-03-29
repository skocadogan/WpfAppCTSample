using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfAppCTSample
{
    
    public partial class OtherWindowViewModel:ObservableObject
    {
        [ObservableProperty]
        public string? _sendingParameter;

        
        public OtherWindowViewModel()
        {
            
        }
    }
}
