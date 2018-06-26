using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PUBG.Models
{
    public class PUBGmodels
    {
        public class Regions
        {
            public List<string> RegionNames { get; set; }
        }

        public class Seasons
        {
            [JsonProperty("data")]
            public List<SeasonsData> SeasonsData { get; set; }
        }
        public class Player
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }
            [JsonProperty("links")]
            public Links Links { get; set; }

            //public List<Stats> Stats { get; set; }
        }
    }

    public class MatchObject
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
        [JsonProperty("links")]
        public Links Links { get; set; }
        [JsonProperty("included")]
        public List<Included> Included { get; set; }
        public Stats Stats { get; set; }
        public bool Win { get; set; }

    }

    public class Included
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("attributes")]
        public RosterAttributes RosterAttributes { get; set; }
        [JsonProperty("relationships")]
        public RosterRelationships RosterRelationships { get; set; }
    }

    public class Stats
    {
        [JsonProperty("DBNOs")]
        public int DBNOs { get; set; }
        [JsonProperty("assits")]
        public int Assists { get; set; }
        [JsonProperty("boosts")]
        public int Boosts { get; set; }
        [JsonProperty("damageDealt")]
        public double DamageDealt { get; set; }
        [JsonProperty("deathType")]
        public string DeathType { get; set; }
        [JsonProperty("headshotKills")]
        public int HeadshotKills { get; set; }
        [JsonProperty("heals")]
        public int Heals { get; set; }
        [JsonProperty("killPlace")]
        public int KillPlace { get; set; }
        [JsonProperty("killPoints")]
        public int KillPoints { get; set; }
        [JsonProperty("killPointsDelta")]
        public double KillPointsDelta { get; set; }
        [JsonProperty("killStreaks")]
        public int KillStreaks { get; set; }
        [JsonProperty("kills")]
        public int Kills { get; set; }
        [JsonProperty("lastKillPoints")]
        public int LastKillPoints { get; set; }
        [JsonProperty("lastWinPoints")]
        public int LastWinPoints { get; set; }
        [JsonProperty("longestKill")]
        public int LongestKill { get; set; }
        [JsonProperty("mostDamage")]
        public double mostDamage { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("playerId")]
        public string PlayerId { get; set; }
        [JsonProperty("revives")]
        public int Revives { get; set; }
        [JsonProperty("rideDistance")]
        public double RideDistance { get; set; }
        [JsonProperty("roadKills")]
        public int RoadKills { get; set; }
        [JsonProperty("swimDistance")]
        public double SwimDistance { get; set; }
        [JsonProperty("teamKills")]
        public int TeamKills { get; set; }
        [JsonProperty("timeSurvived")]
        public int TimeSurvived { get; set; }
        [JsonProperty("vehicleDestroys")]
        public int VehicleDestroys { get; set; }
        [JsonProperty("walkDistance")]
        public double WalkDistance { get; set; }
        [JsonProperty("weaponsAcquired")]
        public int WeaponsAcquired { get; set; }
        [JsonProperty("winPlace")]
        public int WinPlace { get; set; }
        [JsonProperty("winPoints")]
        public int WinPoints { get; set; }
        [JsonProperty("winPointsDelta")]
        public double WinPointsDelta { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }

    public class RosterRelationships
    {
        [JsonProperty("team")]
        public Team Team { get; set; }
        [JsonProperty("participants")]
        public Participants Participants { get; set; }
    }

    public class Participants
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }

    public class Team
    {

    }

    public class RosterAttributes
    {
        [JsonProperty("won")]
        public bool Won { get; set; }
        [JsonProperty("shardId")]
        public string ShardId { get; set; }
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }

    public class SeasonsData
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("attributes")]
        public DataAttributes Attributes { get; set; }
        public string Name { get; set; }
    }


    public class DataAttributes
    {
        [JsonProperty("isCurrentSeason")]
        public bool IsCurrentSeason { get; set; }
        [JsonProperty("isOffseason")]
        public bool IsOffseason { get; set; }
    }

    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("Attributes")]
        public Attributes Attributes { get; set; }
        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }
        [JsonProperty("mapName")]
        public MapName MapName { get; set; }
        [JsonProperty("isCustomMatch")]
        public bool IsCustomMatch { get; set; }
        [JsonProperty("shardId")]
        public string ShardId { get; set; }
        [JsonProperty("titleId")]
        public string TitleId { get; set; }
    }

    //public enum GameMode
    //{
    //    duo,
    //    [Description("duo-fpp")]
    //    duo_fpp,
    //    solo,
    //    [Description("solo-fpp")]
    //    solo_fpp,
    //    squad,
    //    [Description("squad-fpp")]
    //    squad_fpp
    //}

    public enum MapName
    {
        Desert_Main,
        Erangel_Main,
        Savage_Main,
        Miramar,
        Erangel,
        Sanhok
    }


    public class Links
    {
        [JsonProperty("schema")]
        public string Schema { get; set; }
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class Matches
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }

    public class Relationships
    {
        [JsonProperty("matches")]
        public Matches Matches { get; set; }
        [JsonProperty("assets")]
        public Assets Assets { get; set; }
        [JsonProperty("rosters")]
        public Rosters Rosters { get; set; }
    }

    public class Rosters
    {
        public List<Data> Data { get; set; }
    }

    public class Assets
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
}
