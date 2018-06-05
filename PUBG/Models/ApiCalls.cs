using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PUBG.Models
{
    public class ApiCalls
    {
        private const string baseUrl = "https://api.playbattlegrounds.com/shards/";
        HttpClient client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        private const string ApiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5YjU3YWY1MC00YTA1LTAxMzYtNDE4My0yNTE1Y2RhMTQzMzYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNTI4MTAzNjY4LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InB1YmdzdGF0aXN0aWNzIn0.Teep9hWwlVG8kunMj6VWU6ShDLEI8C_oV3XfRTpjmpE";

        public async void GetPlayerAsync(string server, string playerName)
        {
            Url url = new Url($"{server}/players");
            url.SetQueryParam("filter[playerNames]", playerName);
            url.SetQueryParam("Authorization: Bearer ", ApiKey);
            //url.SetQueryParam("accept: application/vnd.api+json", "");
            var responce = await client.GetStringAsync(url); 
        }
    }
}
