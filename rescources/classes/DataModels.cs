using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
