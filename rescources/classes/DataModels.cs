using System;

namespace GameofKingdom.rescources.classes
{
    class DataModels
    {
    }

    class ScoreModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    class LicenceModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Boolean Licence { get; set; }
    }

    class SettingsModel
    {
        public int Language { get; set; }

        public int Resolution { get; set; }
    }
}
