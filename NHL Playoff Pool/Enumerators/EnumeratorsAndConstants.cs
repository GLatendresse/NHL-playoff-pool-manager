using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHL_Playoff_Pool.Enumerators
{
    public class EnumeratorsAndConstants
    {
        public enum MatchupLevels
        {
            StanleyCupFinal,
            RoundThree,
            RoundTwo,
            RoundOne
        }

        public enum PlayoffSpots
        {
            Unqualified,
            A1,
            A2,
            A3,
            M1,
            M2,
            M3,
            C1,
            C2,
            C3,
            P1,
            P2,
            P3,
            EWC1,
            EWC2,
            WWC1,
            WWC2
        }

        public enum Conferences
        {
            Eastern,
            Westnern,
            Undefined
        }

        public enum Divisions
        {
            Atlantic,
            Metropolitan,
            Central,
            Pacific,
            Undefined
        }

        public enum NumberOfMatchesGap
        {
            NoGap,
            OneMatchGap,
            TwoMatchesGap,
            ThreeMatchesGap
        }
    }

    public static class ScoreRules
    {
        public const int GoodTeam = 5;
        public const int BadTeam = 0;
        public const int GoodNumberOfMatches = 5;
        public const int OneMatchAway = 3;
        public const int TwoMatchesAway = 1;
        public const int ThreeMatchesAway = 0;
        public const double RoundOneMultiplicator = 1;
        public const double RoundTwoMultiplicator = 1.5;
        public const double RoundThreeMultiplicator = 2;
        public const double StanleyCupFinalMultiplicator = 2.5;
    }

    public static class PlayoffRules
    {
        public const int LastDivisionRankToGetQualified = 3;
        public const int LastDivisionRankToBeAWildcard = 5;
        public const int LastConferenceRankToBeAWildcard = 8;
        public const int LastDivisionRankToBeFirstWildcard = 4;
        public const int LastConferenceRankToBeFirstWildcard = 7;
        public const int RankedFirst = 1;
        public const int RankedSecond = 2;
        public const int RankedThird = 3;
    }
}