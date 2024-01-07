using System;
using System.Collections.Generic;

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

    class Consequence
    {
        public string resource { get; set; }
        public int value { get; set; }
    }

    class Option1
    {
        public string text { get; set; }
        public string description { get; set; }
        public List<Consequence> consequences { get; set; }
    }

    class CriticalOption
    {
        public string text { get; set; }
        public string description { get; set; }
        public bool end { get; set; }
        public List<Consequence> consequences { get; set; }
    }

    class EventModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Option1 option_1 { get; set; }
        public Option1 option_2 { get; set; }
        public Option1 option_3 { get; set; }
    }

    class CriticalEventModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public CriticalOption option_1 { get; set; }
        public CriticalOption option_2 { get; set; }
        public CriticalOption option_3 { get; set; }
    }
}
