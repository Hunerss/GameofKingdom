using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofKingdom.rescources.classes
{
    internal class FileHandeler
    {

        private static string licencePath = @"";
        private static string scoresPath = @"";

        public static Boolean CheckFile()
        {
            // sprawdza czy jest plik i czy ma zaakceptowane warunki
            return true;
        }

        public static void WriteLicence()
        {
            // wpisuje licencje do pliky json
            // a jeśli taki plik istnieje to najpierw go niszczy lub czyśic idk co lepsze
        }

        public static Boolean CheckScore(int score, string name)
        {
            // sprawdza czy wynik rozegranej gry jest poprawny
            return true;
        }

        private static void WriteScore(int score, string name)
        {
            // zapisuje wynik gry do pliky json
        }

    }
}
