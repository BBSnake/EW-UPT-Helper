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

        private void uptFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                Filter = "Plik UPT|*.upt|Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = true
            };
            if (ofd.ShowDialog() == false) return;
            uptFilePath.Text = "Wybrano plików: " + ofd.FileNames.Length;
        }

        private void fromUptConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            
            UPT fromUptConverter = new UPT();
            
            foreach (string fileName in ofd.FileNames)
            {
                fromUptConverter.Convert(fileName);
            }
        }

        private void eptFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                Filter = "Plik EPT|*.ept|Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = false
            };
            if (ofd.ShowDialog() == false) return;
            eptFilePath.Text = ofd.FileName;
        }

        private void acsFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                Filter = "Plik ACS|*.acs|Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = false
            };
            if (ofd.ShowDialog() == false) return;
            acsFilePath.Text = ofd.FileName;
        }

        private void toUptConvertBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                Filter = "Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = false
            };
            if (ofd.ShowDialog() == false) return;
            dataFilePath.Text = ofd.FileName;
        }

        private void measurementsFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                Filter = "Plik tekstowy|*.txt|Wszystkie pliki|*",
                Multiselect = false
            };
            if (ofd.ShowDialog() == false) return;
            measurementsFilePath.Text = ofd.FileName;
        }

        private void compareBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
