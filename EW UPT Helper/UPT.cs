using System;
using System.IO;

namespace EW_UPT_Helper
{
    class UPT
    {
        private string fileName;
        private string template;
        private char[] splitter = { ' ', '\t' };
        public UPT(string templ)
        {
            template = templ; 
        }
        public void Convert(string uptFile)
        {
            if(uptFile == "")
            {
                System.Windows.MessageBox.Show("Brak pliku!", "Błąd", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            string templateACS = File.ReadAllText(template);
            string[] zmienne; 
            if (uptFile.IndexOf('.') > 0) fileName = uptFile.Remove(uptFile.IndexOf('.'));
            StreamReader uptRead = new StreamReader(uptFile);
            StreamWriter eptWrite = new StreamWriter(fileName + ".ept");
            StreamWriter acsWrite = new StreamWriter(fileName + ".acs");
            acsWrite.Write(templateACS);
            while(!uptRead.EndOfStream)
            {
                zmienne = uptRead.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                acsWrite.WriteLine("\"{0}\",\"{1}\",{2},{3},{4},{5},\"\",\"\"", zmienne[0], zmienne[1], zmienne[4], zmienne[5], zmienne[6], zmienne[7]);
                switch (zmienne[7])
                {
                    case "1":
                        zmienne[7] = "80";
                        break;
                    case "2":
                        zmienne[7] = "70";
                        break;
                    case "3":
                        zmienne[7] = "60";
                        break;
                    case "4":
                        zmienne[7] = "60";
                        break;
                    case "5":
                        zmienne[7] = "55";
                        break;
                    case "6":
                        zmienne[7] = "50";
                        break;
                    case "7":
                        zmienne[7] = "50";
                        break;
                }
                if ((zmienne[4] == "1") || (zmienne[4] == "2"))
                    zmienne[4] = "N";
                if ((zmienne[4] == "3") || (zmienne[4] == "4"))
                    zmienne[4] = "T";
                eptWrite.WriteLine("{0} {1} {2} {3} {4}", zmienne[0], zmienne[2], zmienne[3], zmienne[7], zmienne[4]);
            }
            acsWrite.Close();
            eptWrite.Close();
            uptRead.Close();
            System.Windows.MessageBox.Show("Konwersja przebiegła pomyślnie!", "Sukces!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        
    }
}
