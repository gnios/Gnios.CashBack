using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gnios.CashBack.Api.Spotify
{
    public class GetGenresOutput
    {
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }
    }
}
