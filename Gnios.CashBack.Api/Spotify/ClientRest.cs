using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Gnios.CashBack.Api.Spotify
{
    public class ClientRest
    {
        private SpotifyToken Token { get; set; }
        private RestClient Client { get; set; }
        public MemoryCacheService CacheService { get; }

        private string cacheGroup = "SpotifyApi";

        private string apiURL = "https://api.spotify.com/v1/";

        public ClientRest(MemoryCacheService cacheService)
        {
            Client = new RestClient(apiURL);
            CacheService = cacheService;
            Token = cacheService.Cache(cacheGroup, KeysCache.TokenSpotify, LoginSpotify);
        }

        private SpotifyToken LoginSpotify()
        {
            string clientID = "6c8ff00b9bd04be69996781e06d7bdaf";
            string clientSecret = "9f75120461e94f95a9041bd59deccdf4";
            var clientAuth = new RestClient("https://accounts.spotify.com/");
            clientAuth.Authenticator = new HttpBasicAuthenticator(clientID, clientSecret);

            var request = new RestRequest("api/token", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");

            IRestResponse response = clientAuth.Execute(request);
            return JsonConvert.DeserializeObject<SpotifyToken>(response.Content);
        }

        public IList<SpotifyAlbum> GetAlbums()
        {
            var teste = this.GetGenres()?.Genres;
            var genres = new List<string> { "pop", "mpb", "classical", "rock" };// this.GetGenres()?.Genres;
            var albums = new List<SpotifyAlbum>();

            foreach (var genre in genres)
            {
                var request = new RestRequest("recommendations", Method.GET);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("Authorization", $"Bearer {Token.access_token}");
                request.AddQueryParameter("seed_genres", genre);
                request.AddQueryParameter("limit", "50");
                request.AddQueryParameter("market", "US");
                IRestResponse response = Client.Execute(request);
                var output = JsonConvert.DeserializeObject<RecomendationsOutPut>(response.Content);
                output?.tracks?.ForEach(x => x.album.genre = genre);
                albums.AddRange(output?.tracks?.Select(x => x.album).ToList());
            }

            return albums;
        }

        public GetGenresOutput GetGenres()
        {
            var request = new RestRequest("recommendations/available-genre-seeds", Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", $"Bearer {Token.access_token}");

            IRestResponse response = Client.Execute(request);

            return JsonConvert.DeserializeObject<GetGenresOutput>(response.Content);
        }
    }
}
