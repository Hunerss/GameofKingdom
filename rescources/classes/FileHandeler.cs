using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GameofKingdom.rescources.classes
{
    internal class FileHandeler
    {

        private static string GameDataDirectory = @"C:\ProgramData\GameOfKingdom";
        private static string LicenceFilePath = @"C:\ProgramData\GameOfKingdom\LicenceAgreement.json";
        private static string ScoresPath = @"C:\ProgramData\GameOfKingdom\Scores.json";
        private static string SettingsPath = @"C:\ProgramData\GameOfKingdom\Settings.json";

        public static Boolean CheckFile(Boolean repetitive)
        {
            Boolean fileExists = File.Exists(LicenceFilePath);
            Console.WriteLine("CheckFile - beggining log - do file exist - " + fileExists);
            Boolean directoryExists = Directory.Exists(GameDataDirectory);
            Console.WriteLine("CheckFile - beggining log - do directory exist - " + directoryExists);
            if (repetitive)
                return directoryExists && fileExists;
            else
            {
                if (!directoryExists)
                    Directory.CreateDirectory(GameDataDirectory);

                if (!fileExists)
                {
                    using (File.Create(LicenceFilePath)) { }
                    WriteLicence(false);
                }
                else if (!LicenceExist())
                    WriteLicence(true);

                return false;
            }
        }

        public static Boolean ReturnLicence()
        {
            if (File.Exists(LicenceFilePath))
            {
                List<LicenceModel> licences = new();
                string json = File.ReadAllText(LicenceFilePath);

                if (!String.IsNullOrEmpty(json))
                {
                    licences = JsonSerializer.Deserialize<List<LicenceModel>>(json);

                    foreach (var licence in licences)
                        if (licence.Name == System.Security.Principal.WindowsIdentity.GetCurrent().Name)
                            return true;
                }
                else
                    Console.WriteLine("ReturnLicence - error log - Licence File is empty");
            }
            else
                Console.WriteLine("ReturnLicence - error log - Licence File doesn't exists");
            return false;
        }

        private static Boolean LicenceExist()
        {
            if (File.Exists(LicenceFilePath))
            {
                string json = File.ReadAllText(LicenceFilePath);
                if (!string.IsNullOrEmpty(json))
                {
                    Console.WriteLine("LicenceExist() - middle log - json" + json);

                    List<LicenceModel> licences = JsonSerializer.Deserialize<List<LicenceModel>>(json);

                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                    return licences.Any(licence => licence.Name == userName);
                }
            }
            return false;
        }

        public static void WriteLicence(Boolean Edit)
        {
            List<LicenceModel> users = new();

            if (Edit && File.Exists(LicenceFilePath))
            {
                string json = File.ReadAllText(LicenceFilePath);
                if(!string.IsNullOrEmpty(json))
                    users = JsonSerializer.Deserialize<List<LicenceModel>>(json);
                else
                {
                    Console.WriteLine("WriteLicence - error log - Licence File is empty");
                    return;
                }
            }

            users.Add(new LicenceModel()
            {
                Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Code = Guid.NewGuid().ToString(),
                Licence = true
            });

            string licence = JsonSerializer.Serialize(users);

            if (!string.IsNullOrEmpty(licence))
                File.WriteAllText(LicenceFilePath, licence);
            else
                Console.WriteLine("WriteLicence - error log - licence string is null");
        }

        public static Boolean CheckSettingsFile()
        {
            if (File.Exists(SettingsPath))
                return true;
            else
            {
                CreateBasicSettings();
                return false;
            }
        }

        private static void CreateBasicSettings()
        {
            List<SettingsModel> settings = new();
            settings.Add(new SettingsModel()
            {
                Language = 0,
                Resolution = 0
            });

            string settingsSerialized = JsonSerializer.Serialize(settings);
            File.WriteAllText(SettingsPath, settingsSerialized);
        }

        public static void OverrideSettings(int language, int resolution)
        {
            if (File.Exists(SettingsPath))
            {
                List<SettingsModel> settings = new();
                settings.Add(new SettingsModel()
                {
                    Language = language,
                    Resolution = resolution
                });

                string settingsSerialized = JsonSerializer.Serialize(settings);
                File.WriteAllText(SettingsPath, settingsSerialized);
            }
        }

        public static string ReturnPath(int pathId)
        {
            if (pathId == 0)
                return LicenceFilePath;
            else if (pathId == 1)
                return ScoresPath;
            else if (pathId == 2)
                return SettingsPath;
            Console.WriteLine("RetrunPath - errror log - path id doesn't exist");
            return "Error";
        }

        public static Boolean CheckScore(int score, string name)
        {
            // sprawdza czy wynik rozegranej gry jest poprawny
            return score > 0 && name != "Admin" && name != "admin" && name != "";
        }

        public static Boolean CheckScores(Boolean repetitive)
        {
            // sprawdza czy plik z wynikami istnieje i jeśli nie to go tworzy
            if (File.Exists(ScoresPath))
            {
                return true;
            }
            else
            {
                if (repetitive)
                {
                    return false;
                }
                else
                {
                    List<ScoreModel> data = new()
                    {
                        new ScoreModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Admin",
                            Score = 250
                        }
                    };

                    string json = JsonSerializer.Serialize(data);
                    File.WriteAllText(ScoresPath, json);
                    return false;
                }
            }
        }

        private static void WriteScore(int score, string name)
        {
            // zapisuje wynik gry do pliky json
            List<ScoreModel> scores = new();

            if (File.Exists(ScoresPath))
            {
                string readedJson = File.ReadAllText(ScoresPath);
                if (!String.IsNullOrEmpty(readedJson))
                {
                    if (CheckScore(score, name))
                    {
                        scores = JsonSerializer.Deserialize<List<ScoreModel>>(readedJson);
                        scores.Add(new ScoreModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = name,
                            Score = score
                        });

                        string json = JsonSerializer.Serialize(scores);
                        File.WriteAllText(ScoresPath, json);
                    }
                    else
                    {
                        Console.WriteLine("WriteScore - error log - Inputed score or user name is incorect");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("WriteScore - error log - Json file is empty");
                    return;
                }
            }
            else
            {
                Console.WriteLine("WriteScore - error log - Score file doesn't exist");
                return;
            }
        }
    }
}
