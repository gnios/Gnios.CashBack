using System.Collections.Generic;

namespace Gnios.CashBack.Api.Spotify
{
    public class RecomendationsOutPut
    {
        public List<Track> tracks { get; set; }
        public List<Seed> seeds { get; set; }
    }
}
