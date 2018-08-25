namespace RentAnUmpireWebApi.RentalUmpire.DataLayer.DclModels
{
    public partial class MatchStats
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public byte InningSw { get; set; }
        public int? RunsScored { get; set; }
        public int? TotalRuns { get; set; }
        public int? Wickets { get; set; }
        public double? Overs { get; set; }
        public byte? Extras { get; set; }
        public byte? Nos { get; set; }
        public byte? Wides { get; set; }
        public byte? LegByes { get; set; }
        public byte? Byes { get; set; }
        public byte? OverThrow { get; set; }
    }
}
