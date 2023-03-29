using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WpfAppCTSample
{
  
    // MainWindow'un işlerini halledecek olan ViewModel
    // MainWindow içerisinde kurucu metod içerisinde Tanımlı.
    // Eğer property'leri kontrol etmek istiyorsak ObservableValidator
    // nesnesini miras almalı. Aksi durumda ObservableObject ya da 
    // [INotifyProperyChanges] annotation'u clasın başına eklenmeli.
    public partial class MainWindowViewModel:ObservableValidator
    {
        // Community Toolkit güzelliği
        
        [ObservableProperty]
        string? _FirstName;
        
        [ObservableProperty]
        string? _LastName;

        [ObservableProperty]
        [Required]
        string? _Email;

        [ObservableProperty]
        string? _FullName;

        
        // MainWindow daki butonlara atabilecek bir komut
        // Eğer butona atanacaksa XAML içerisinde adı OpenWindowCommand olmalı
        [RelayCommand]
        void OpenWindow()
        {
            // Bu pencere bir servis çağısı olarak alıyor. 
            // Öncelikle App.xaml.cs içerisinde servisler kısmında tanımlı olmalı
            var otherWindow = App.Current.Services.GetService<OtherWindow>();

            // Buradaki FullName otomatik üretilen bir property
            // Community Toolkit tarafından üretiliyor.
            // orijinal değişken string? _FullName; olarak yukarıda tanımlananı
            otherWindow.passParameter = FullName;


            if (otherWindow.ShowDialog() == true) { };

        }

        // MainWindow daki butonlara atabilecek bir komut daha
        // Eğer butona atanacaksa XAML içerisinde adı SubmitCommand olmalı
        [RelayCommand]
        void Submit()
        {

            // yukarıdaki _Email tanımlaması örnek olarak Required yapıldı
            // Tüm Required alanları kontrol etmek için Community Toolkit'in
            // bu yapısını kullanıyoruz. Bu kısımda bize en yukarıdaki class
            // tanımlamasında MainWindowViewModel:ObservableValidator tarafından 
            // miras geliyor.
            ValidateAllProperties();

            // Community Toolkit'in Validate sonucunda dönen değeri
            if (HasErrors)
            {
                Debug.WriteLine("Soyad ve ad bilgisi girilmelidir");
            } else
            {
                FullName = $"Girilen Değerler = {FirstName} {LastName} {Email}";
               
            }
            
        }

    }
}
