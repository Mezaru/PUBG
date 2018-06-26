using Flurl;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static PUBG.Models.PUBGmodels;

namespace PUBG.Models
{
    public class ApiCalls
    {
        private const string baseUrl = "https://api.playbattlegrounds.com/shards/";
        private const string ApiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5YjU3YWY1MC00YTA1LTAxMzYtNDE4My0yNTE1Y2RhMTQzMzYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNTI4MTAzNjY4LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InB1YmdzdGF0aXN0aWNzIn0.Teep9hWwlVG8kunMj6VWU6ShDLEI8C_oV3XfRTpjmpE";

        public Regions GetRegions()
        {
            return new Regions
            {
                RegionNames = new List<string>
                {
                    "xbox-as",
                    "xbox-eu",
                    "xbox-na",
                    "xbox-oc",
                    "pc-krjp",
                    "pc-jp",
                    "pc-na",
                    "pc-eu",
                    "pc-ru",
                    "pc-oc",
                    "pc-kakao",
                    "pc-sea",
                    "pc-sa",
                    "pc-as",
                }
            };
        }

        internal async Task<List<MatchObject>> GetMatchInfo(Player playerModel, string region)
        {
            List<MatchObject> model = new List<MatchObject>();
            foreach (var item in playerModel.Data.First().Relationships.Matches.Data)
            {
                var match = JsonConvert.DeserializeObject<MatchObject>(await GetMatchInfoFromApi(item.Id, playerModel.Data.First().Attributes.ShardId));
                match.Data.Attributes.Duration = match.Data.Attributes.Duration / 60;
                AddStatsFromMatch(match, playerModel.Data.First().Id);
                model.Add(match);
            }

            return model;
        }

        private void AddStatsFromMatch(MatchObject match, string playerId)
        {
            foreach (var item in match.Included)
            {
                if (item.Type == "participant")
                {
                    if (item.RosterAttributes.Stats.PlayerId == playerId)
                    {
                        match.Win = item.RosterAttributes.Stats.WinPlace == 1 ? true : false;
                        match.Stats = item.RosterAttributes.Stats;
                        match.Stats.TimeSurvived = match.Stats.TimeSurvived / 60;
                        break;
                    }

                }
            }
        }

        internal async Task<string> GetSeasonDataFromPlayer(string playerId, string region, string season)
        {
            var client = GetClient();
            Url url = new Url($"{region}/players/{playerId}/seasons/{season}");
            var responce = await client.GetStringAsync(url);
            return responce;
        }



        //internal List<Stats> GetPlyerStatsFromMatch(List<MatchObject> matches, string playerId)
        //{
        //    List<Stats> stats = new List<Stats>();
        //    foreach (var match in matches)
        //    {

        //        foreach (var item in match.Included)
        //        {
        //            if(item.Type == "participant")
        //            {
        //                if(item.RosterAttributes.Stats.PlayerId == playerId)
        //                {
        //                    stats.Add(item.RosterAttributes.Stats);
        //                    break;
        //                }

        //            }
        //        }
        //    }

        //    return stats;
        //}

        private async Task<string> GetMatchInfoFromApi(string id, string region)
        {
            var client = GetClient();
            Url url = new Url($"{region}/matches/{id}");
            var responce = await client.GetStringAsync(url);
            return responce;
        }

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(baseUrl) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }


        public async Task<string> GetPlayerAsync(string server, string playerName)
        {
            var client = GetClient();
            Url url = new Url($"{server}/players");
            url.SetQueryParam("filter[playerNames]", playerName);
            var responce = await client.GetStringAsync(url);
            return responce;
        }

        public async Task<Seasons> GetSeasonsAsync(string server)
        {
            var client = GetClient();
            Url url = new Url($"{server}/seasons");
            var response = await client.GetStringAsync(url);
            Seasons seasons = JsonConvert.DeserializeObject<Seasons>(response);
            foreach (var item in seasons.SeasonsData)
            {
                item.Name = GetSeasonNameFromId(item.Id);
            }
            return seasons;
        }

        //public async Task<Seasons> GetSeasonByIdAsync(string id, string server)
        //{
        //    var client = GetClient();
        //    Url url = new Url($"{server}/seasons");
        //    var response = await client.GetStringAsync(url);
        //    Seasons seasons = JsonConvert.DeserializeObject<Seasons>(response);
        //    foreach (var item in seasons.SeasonsData)
        //    {
        //        item.Name = GetSeasonNameFromId(item.Id);
        //    }
        //    return seasons;
        //}

        private string GetSeasonNameFromId(string id)
        {
            var array = id.Split(".");
            return array.Last();
        }
    }
}
