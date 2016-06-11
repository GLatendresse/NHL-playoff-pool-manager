namespace NHL_Playoff_Pool.Models.Entities
{
    public class Prediction
    {
        public int Id { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Matchup Matchup { get; set; }
        public virtual NHLTeam VictoriousTeam { get; set; }
        public int NumberOfMatches { get; set; }
    }
}