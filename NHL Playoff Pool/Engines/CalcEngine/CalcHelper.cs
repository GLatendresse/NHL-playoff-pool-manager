using NHL_Playoff_Pool.Enumerators;
using NHL_Playoff_Pool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static NHL_Playoff_Pool.Enumerators.EnumeratorsAndConstants;

namespace NHL_Playoff_Pool.Engines.CalcEngine
{
    public class CalcHelper
    {
        public double CalculatePointsEarnedFromPrediction(Prediction prediction)
        {
            var matchupResults = prediction.Matchup.MatchupResults;

            var matchupLevels = prediction.Matchup.Matchuplevel;

            double points = 0;

            if (prediction.VictoriousTeam.Id == matchupResults.VictoriousTeam.Id)
            {
                points += ScoreRules.GoodTeam;

                var numberOfMatchesGap = Math.Abs(matchupResults.NumberOfMatches - prediction.NumberOfMatches);

                switch (numberOfMatchesGap)
                {
                    case (int)NumberOfMatchesGap.NoGap:
                        points += ScoreRules.GoodNumberOfMatches;
                        break;
                    case (int)NumberOfMatchesGap.OneMatchGap:
                        points *= ScoreRules.OneMatchAway;
                        break;
                    case (int)NumberOfMatchesGap.TwoMatchesGap:
                        points *= ScoreRules.TwoMatchesAway;
                        break;
                    case (int)NumberOfMatchesGap.ThreeMatchesGap:
                    default:
                        points *= ScoreRules.ThreeMatchesAway;
                        break;
                }
            }

            else
            {
                points += ScoreRules.BadTeam;
            }

            switch (matchupLevels)
            {
                case MatchupLevels.RoundOne:
                    points *= ScoreRules.RoundOneMultiplicator;
                    break;
                case MatchupLevels.RoundTwo:
                    points *= ScoreRules.RoundTwoMultiplicator;
                    break;
                case MatchupLevels.RoundThree:
                    points *= ScoreRules.RoundThreeMultiplicator;
                    break;
                case MatchupLevels.StanleyCupFinal:
                    points *= ScoreRules.StanleyCupFinalMultiplicator;
                    break;
            }

            return points;
        }

        //Total calc
        public double CalculateParticipantTotalPoints(Participant participant)
        {
            double points = 0;

            foreach (var prediction in participant.Predictions)
            {
                points += CalculatePointsEarnedFromPrediction(prediction);
            }

            return points;
        }

        //Partial calc
        public double CalculateParticipantAdditionnalPoints(Participant participant, List<Matchup> matchups)
        {
            double points = 0;

            var predictions = participant.Predictions.Where(p => matchups.Any(c => c.Id == p.Matchup.Id));

            foreach (var prediction in predictions)
            {
                points += CalculatePointsEarnedFromPrediction(prediction);
            }

            return points;
        }
    }
}