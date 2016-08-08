using System;
using System.IO;

namespace EW_UPT_Helper
{
    class ToUPT
    {
        private char[] eptSplitter = { ' ' }, acsSplitter = { ',', '\"' };

        public void Convert(string uptFile, string eptFile, string acsFile)
        {
            int lineCounter = 0;
            string lineFromEPT, lineFromACS;
            string[] eptVars, acsVars;

            StreamReader eptRead = new StreamReader(eptFile);
            StreamReader acsRead = new StreamReader(acsFile);
            StreamWriter uptWrite = new StreamWriter(uptFile);

            while(!acsRead.EndOfStream)
            {
                lineFromACS = acsRead.ReadLine();
                if(lineCounter < 46)
                {
                    lineCounter++;
                    continue;
                }
                lineFromEPT = eptRead.ReadLine();
                eptVars = lineFromEPT.Split(eptSplitter, StringSplitOptions.RemoveEmptyEntries);
                acsVars = lineFromACS.Split(acsSplitter, StringSplitOptions.RemoveEmptyEntries);
                uptWrite.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", acsVars[0], acsVars[1], eptVars[1], eptVars[2], acsVars[2], acsVars[3], acsVars[4], acsVars[5]);
            }
            uptWrite.Close();
            eptRead.Close();
            acsRead.Close();
            System.Windows.MessageBox.Show("Konwersja przebiegła pomyślnie!", "Sukces!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}
