﻿using System.Collections.Generic;

namespace Gnios.CashBack.Api.Spotify
{
    public class SpotifyToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }

    public class ExternalUrls
    {
        public string spotify { get; set; }
    }

    public class Artist
    {
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ExternalUrls2
    {
        public string spotify { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Album
    {
        public string album_type { get; set; }
        public List<Artist> artists { get; set; }
        public ExternalUrls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ExternalUrls3
    {
        public string spotify { get; set; }
    }

    public class Artist2
    {
        public ExternalUrls3 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ExternalIds
    {
        public string isrc { get; set; }
    }

    public class ExternalUrls4
    {
        public string spotify { get; set; }
    }

    public class ExternalUrls5
    {
        public string spotify { get; set; }
    }

    public class LinkedFrom
    {
        public ExternalUrls5 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Track
    {
        public Album album { get; set; }
        public List<Artist2> artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool @explicit { get; set; }
        public ExternalIds external_ids { get; set; }
        public ExternalUrls4 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public LinkedFrom linked_from { get; set; }
    }

    public class Seed
    {
        public int initialPoolSize { get; set; }
        public int afterFilteringSize { get; set; }
        public int afterRelinkingSize { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public object href { get; set; }
    }

    public class RecomendationsOutPut
    {
        public List<Track> tracks { get; set; }
        public List<Seed> seeds { get; set; }
    }
}
