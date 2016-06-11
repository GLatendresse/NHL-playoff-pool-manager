using NHL_Playoff_Pool.Enumerators;
using NHL_Playoff_Pool.Models.Context;
using NHL_Playoff_Pool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Xml;
using static NHL_Playoff_Pool.Enumerators.EnumeratorsAndConstants;

namespace NHL_Playoff_Pool.Engines.DataRetriever
{
    public class NHLTeamsParser
    {
        private readonly PoolManagerDbContext poolManagerDbContext;

        public NHLTeamsParser()
        {
            poolManagerDbContext = new PoolManagerDbContext();
        }

        //Using http://app.cgy.nhl.yinzcam.com/V2/Stats/Standings
        public void PopulateNHLTeams()
        {
            XmlTextReader reader = new XmlTextReader("http://app.cgy.nhl.yinzcam.com/V2/Stats/Standings");

            var nhlTeams = new List<NHLTeam>();

            string fullName = string.Empty;
            int? conferenceRank = null;
            int? divisionRank = null;
            PlayoffSpots playoffSpot = PlayoffSpots.Unqualified;
            Conferences conference = Conferences.Undefined;
            Divisions division= Divisions.Undefined;

            while (reader.Read())
            {
                //Conference
                if (reader.Name.Equals("Conference"))
                {
                    reader.MoveToAttribute("Name");

                    if (reader.Value.Equals("WESTERN"))
                        conference = Conferences.Westnern;
                    else
                        conference = Conferences.Eastern;
                }

                //Division
                if (reader.Name.Equals("StatsSection"))
                {
                    reader.MoveToAttribute("Heading");

                    switch (reader.Value)
                    {
                        case "PACIFIC":
                            division = Divisions.Pacific;
                            break;
                        case "CENTRAL":
                            division = Divisions.Central;
                            break;
                        case "ATLANTIC":
                            division = Divisions.Atlantic;
                            break;
                        case "METROPOLITAN":
                        default:
                            division = Divisions.Metropolitan;
                            break;
                    }
                }

                //Team
                if (reader.Name.Equals("Standing"))
                {
                    reader.MoveToAttribute("Team");
                    fullName = reader.Value;

                    if (!fullName.Equals(string.Empty))
                    {
                        reader.MoveToAttribute("ConfRank");
                        int _conferenceRank;
                        if (int.TryParse(reader.Value, out _conferenceRank))
                            conferenceRank = _conferenceRank;

                        reader.MoveToAttribute("DivRank");
                        int _divisionRank;
                        if (int.TryParse(reader.Value, out _divisionRank))
                            divisionRank = _divisionRank;

                        playoffSpot = getPlayoffSpot(conference, division, conferenceRank, divisionRank);

                        poolManagerDbContext.NHLTeams.Add(
                            new NHLTeam
                            {
                                FullName = fullName,
                                Conference = conference,
                                Division = division,
                                PlayoffSpot = playoffSpot
                            }
                        );
                    }
                }
            }

            poolManagerDbContext.SaveChanges();
        }

        private PlayoffSpots getPlayoffSpot(Conferences conference, Divisions division, int? conferenceRank, int? divisionRank)
        {
            var playoffSpot = string.Empty;

            if (divisionRank <= PlayoffRules.LastDivisionRankToGetQualified)
            {
                switch (division)
                {
                    case Divisions.Atlantic:
                        playoffSpot = "A";
                        break;
                    case Divisions.Metropolitan:
                        playoffSpot = "M";
                        break;
                    case Divisions.Central:
                        playoffSpot = "C";
                        break;
                    case Divisions.Pacific:
                        playoffSpot = "P";
                        break;
                }

                playoffSpot += divisionRank;
            }
            else if (divisionRank <= PlayoffRules.LastDivisionRankToBeAWildcard && conferenceRank <= PlayoffRules.LastConferenceRankToBeAWildcard)
            {
                switch (conference)
                {
                    case Conferences.Eastern:
                        playoffSpot = "EWC";
                        break;
                    case Conferences.Westnern:
                        playoffSpot = "WWC";
                        break;
                }

                if (divisionRank <= PlayoffRules.LastDivisionRankToBeFirstWildcard && conferenceRank <= PlayoffRules.LastConferenceRankToBeFirstWildcard)
                {
                    playoffSpot += "1";
                }
                else
                {
                    playoffSpot += "2";
                }
            }
            else
            {
                return PlayoffSpots.Unqualified;
            }

            return (PlayoffSpots)Enum.Parse(typeof(PlayoffSpots), playoffSpot);
        }
    }
}