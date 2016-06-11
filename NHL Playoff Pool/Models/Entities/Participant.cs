using System.Collections.Generic;

namespace NHL_Playoff_Pool.Models.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public int Rank { get; set; }
        public double Points { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}