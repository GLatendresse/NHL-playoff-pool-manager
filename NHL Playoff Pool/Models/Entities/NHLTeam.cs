using static NHL_Playoff_Pool.Enumerators.EnumeratorsAndConstants;

namespace NHL_Playoff_Pool.Models.Entities
{
    public class NHLTeam
    {
        public int Id { get; set; }
        public string CityOrState { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public virtual Divisions Division { get; set; }
        public virtual Conferences Conference { get; set; }
        public virtual PlayoffSpots PlayoffSpot { get; set; }
    }
}