using System.Windows;

namespace lecturaXML {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            }

        private void button_Click(object sender, RoutedEventArgs e) {


            }

        private void ButtonShowMessageDialog_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                {
                Application.Current.Shutdown();
                }

            }
        }
    }
