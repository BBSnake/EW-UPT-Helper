using System;
using System.IO;

namespace EW_UPT_Helper
{
    class FromUPT
    {
        private char[] splitter = { ' ', '\t' };
        // The converter builds .acs and .ept file based on the contents
        // of .upt file according to geodetical standards
        public void Convert(string uptFile)
        {
            if(uptFile == "")
            {
                System.Windows.MessageBox.Show("Brak pliku!", "Błąd", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            string templateACS = Properties.Resources.szablon;
            string[] vars; 
            StreamReader uptRead = new StreamReader(uptFile);
            // Just append the extension without removing anything
            // Usually the files have weird geodetic names e.g., punkty.2015.06.12.1378g.upt
            // no need to bother about that, it's easier for the user to find and import
            StreamWriter eptWrite = new StreamWriter(uptFile + ".ept");
            StreamWriter acsWrite = new StreamWriter(uptFile + ".acs");
            acsWrite.Write(templateACS);
            while(!uptRead.EndOfStream)
            {
                vars = uptRead.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                // Some weird geodetic standard for the .acs and .ept files
                // or else it won't import correctly to another program
                acsWrite.WriteLine("\"{0}\",\"{1}\",{2},{3},{4},{5},\"\",\"\"", vars[0], vars[1], vars[4], vars[5], vars[6], vars[7]);
                switch (vars[7])
                {
                    case "1":
                        vars[7] = "80";
                        break;
                    case "2":
                        vars[7] = "70";
                        break;
                    case "3":
                    case "4":
                        vars[7] = "60";
                        break;
                    case "5":
                        vars[7] = "55";
                        break;
                    case "6":
                    case "7":
                        vars[7] = "50";
                        break;
                }
                switch (vars[4])
                {
                    case "1":
                    case "2":
                        vars[4] = "N";
                        break;
                    case "3":
                    case "4":
                    case "5":
                        vars[4] = "T";
                        break;
                }
                eptWrite.WriteLine("{0} {1} {2} {3} {4}", vars[0], vars[2], vars[3], vars[7], vars[4]);
            }
            acsWrite.Close();
            eptWrite.Close();
            uptRead.Close();
            System.Windows.MessageBox.Show("Konwersja przebiegła pomyślnie!", "Sukces!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}
