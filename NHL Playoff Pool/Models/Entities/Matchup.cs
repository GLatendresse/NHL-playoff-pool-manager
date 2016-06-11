using static NHL_Playoff_Pool.Enumerators.EnumeratorsAndConstants;

namespace NHL_Playoff_Pool.Models.Entities
{
    public class Matchup
    {
        public int Id { get; set; }
        public virtual NHLTeam IceAdvantageTeam { get; set; }
        public virtual NHLTeam IceDisadvantageTeam { get; set; }
        public virtual MatchupLevels Matchuplevel { get; set; }
        public virtual MatchupResults MatchupResults { get; set; }
    }
}