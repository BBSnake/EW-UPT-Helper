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
        private SaveFileDialog sfd;
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
            
            FromUPT fromUptConverter = new FromUPT();
            
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
            sfd = new SaveFileDialog()
            {
                Filter = "Plik UPT|*.upt|Plik tekstowy|*.txt|Wszystkie pliki|*"
            };
            if((sfd.ShowDialog() == true) && (sfd.FileName != null))
            {
                ToUPT toUptConverter = new ToUPT();
                toUptConverter.Convert(sfd.FileName, eptFilePath.Text, acsFilePath.Text);
            }
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

        private void xyzRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            attrCheckBox.IsChecked = false;
            attrCheckBox.IsEnabled = false;
        }

        private void xyzRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            attrCheckBox.IsEnabled = true;
        }
    }
}
