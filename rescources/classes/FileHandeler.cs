using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameofKingdom.rescources.classes
{
    internal class FileHandeler
    {

        private static string GameDataDirectory = @"AppData\Roaming\GameOfKingdom";
        private static string LicenceFilePath = @"AppData\Roaming\LicenceAgreement.json";
        private static string scoresPath = @"";

        public static Boolean CheckFile(Boolean repetitive)
        {
            if (repetitive)
            {
                return Directory.Exists(GameDataDirectory) ? File.Exists(LicenceFilePath) : false;
            }
            else
            {
                if (!Directory.Exists(GameDataDirectory))
                {
                    Directory.CreateDirectory(GameDataDirectory);
                }
                if (File.Exists(LicenceFilePath))
                {
                    if (!FileHandeler.LicenceExist())
                        FileHandeler.WriteLicence(true);
                    else
                        return true;
                }
                else
                {
                    File.Create(LicenceFilePath);
                    FileHandeler.WriteLicence(false);
                }
                return false;
            }
        }

        private static Boolean LicenceExist()
        {
            string json = File.ReadAllText(LicenceFilePath);
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            List<ScoreModel> scores = JsonSerializer.Deserialize<List<ScoreModel>>(json);
            foreach (ScoreModel score in scores)
                if (score.Name == userName)
                    return true;

            return false;
        }

        public static void WriteLicence(Boolean Edit)
        {
            Random rn = new();
            // wpisuje licencje do pliky json
            // a jeśli taki plik istnieje to najpierw go niszczy lub czyśic idk co lepsze
            
            if (Edit)
            {
                // dodaje coś do pliku licencjowego
                if (File.Exists(LicenceFilePath))
                {

                }
            }
            else
            {
                // pisze plik zupełnie od zera
                List<LicenceModel> data = new()
                {
                    new LicenceModel()
                    {
                        Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                        Code = Convert.ToString(rn.Next(999999999)),
                        Licence = true
                    }
                };
                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(LicenceFilePath, json);
            }
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
