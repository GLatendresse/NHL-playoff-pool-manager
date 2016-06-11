using System.ComponentModel.DataAnnotations;

namespace NHL_Playoff_Pool.Models.Entities
{
    public class MatchupResults
    {
        public int Id { get; set; }
        public virtual NHLTeam VictoriousTeam { get; set; }
        public int NumberOfMatches { get; set; }

        [Required]
        public virtual Matchup Matchup { get; set; }
    }
}