using NHL_Playoff_Pool.Models.Context;
using NHL_Playoff_Pool.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NHL_Playoff_Pool.Models
{
    public class Dal : IDal
    {
        private readonly PoolManagerDbContext poolManagerDbContext;

        public Dal()
        {
            poolManagerDbContext = new PoolManagerDbContext();
        }

        public void Dispose()
        {
            poolManagerDbContext.Dispose();
        }

        public List<Matchup> GetMatchups()
        {
            return poolManagerDbContext.Matchups.ToList();
        }

        public List<Participant> GetParticipants()
        {
            return poolManagerDbContext.Participants.ToList();
        }
    }
}
