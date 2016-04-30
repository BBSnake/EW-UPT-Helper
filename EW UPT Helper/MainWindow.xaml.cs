using System.Windows;
using Microsoft.Win32;


namespace EW_UPT_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog ofd;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void fileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Plik UPT|*.upt|Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = true
            };
            if (ofd.ShowDialog() == false) return;
            filePath.Text = "Wybrano plików: " + ofd.FileNames.Length;
        }

        private void convertBtn_Click(object sender, RoutedEventArgs e)
        {
            
            UPT fromUptConverter = new UPT("szablon.acs");
            
            foreach (string fileName in ofd.FileNames)
            {
                fromUptConverter.Convert(fileName);
            }
        }
    }
}
