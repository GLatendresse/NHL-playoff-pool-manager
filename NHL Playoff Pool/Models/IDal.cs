using NHL_Playoff_Pool.Models.Entities;
using System;
using System.Collections.Generic;

namespace NHL_Playoff_Pool.Models
{
    public interface IDal : IDisposable
    {
        List<Matchup> GetMatchups();
        List<Participant> GetParticipants();
    }
}
