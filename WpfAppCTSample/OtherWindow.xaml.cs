
using System.Windows;


namespace WpfAppCTSample
{
  
    public partial class OtherWindow : Window
    {
        
        // Üst ekrandan parametre aktarımı için gerekli property.
        // MainWindowViewModel içerisine bakın.
        public string? passParameter;

        public OtherWindow()
        {
            InitializeComponent();
            DataContext = new OtherWindowViewModel();
        }

        // Bu nesneye bağlı bir viewModelvar. OtherWindowViewModel
        // O modelin içerisindeki herhangi bir nesneye erişebilmek için
        // aşağıdaki gibi bir tanımlama yapılmalı.
        // Örnekte Çağırıldığı üst pencereden bir değer alıyor
        // SendingParameter OtherWindowViewModel 'de Observable olarak
        // tanımlı bir property olduğundan ona değer atandığında
        // Tetiklenip ekranda aldığı değer ile gözükecek
        // SendingParameter XAML içerisinde {Binding SendingParameter} olarak tanımlı
        // Bu işi kurucu sınıfta yapamayız. Nesne tam kurulduktan sonra aktarılmalı
        // O yüzden Window_Loaded ile XAML da tanımlı Loading eventinde çalıştırıyoruz.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((OtherWindowViewModel)DataContext).SendingParameter = passParameter;
        }
    }
}
