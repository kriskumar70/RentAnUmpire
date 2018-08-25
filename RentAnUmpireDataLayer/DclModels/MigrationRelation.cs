using System;
using System.Collections.Generic;

namespace RentAnUmpireDataLayer.DclModels
{
    public partial class MigrationRelation
    {
        public string Key { get; set; }
        public int SqlId { get; set; }
        public int SecondaryKey { get; set; }
    }
}
