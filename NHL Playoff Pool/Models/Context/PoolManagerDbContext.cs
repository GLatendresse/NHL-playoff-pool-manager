using Microsoft.AspNet.Identity.EntityFramework;
using NHL_Playoff_Pool.Models.Entities;
using System.Data.Entity;

namespace NHL_Playoff_Pool.Models.Context
{
    public class PoolManagerDbContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<NHLTeam> NHLTeams { get; set; }
    }
}