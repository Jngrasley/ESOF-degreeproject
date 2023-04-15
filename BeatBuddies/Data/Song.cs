namespace MusicRecommendationSystem.Data
{
    [Serializable]
    public class Song
    {
        public string TrackID { get; set; }
        public string SongTitle { get; set; }
        public string Album { get; set; }
        public string PreviewURL { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public double Duration { get; set; }
        public double Danceability { get; set; }
        public double Energy { get; set; }
        public int Key { get; set; }
        public double Loudness { get; set; }
        public double Speechiness { get; set; }
        public double Acousticness { get; set; }
        public double Instrumentalness { get; set; }
        public double Liveness { get; set; }
        public double Valence { get; set; }
        public double Tempo { get; set; }
        public int TimeSignature { get; set; }
        public double ZeroCrossing { get; set; }
        public double MFCCSMax { get; set; }
        public double MFCCSMin { get; set; }
        public double MFCCSMean { get; set; }
        public double MFCCSMedian { get; set; }
        public double RMS { get; set; }
        public double BPM { get; set; }
        public double RolloffMin { get; set; }
        public double RolloffMax { get; set; }
        public double ChromaMedian { get; set; }
        public double ChromaMean { get; set; }
        public double ChromaMin { get; set; }
        public double ChromaMax { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }
        public double e { get; set; }
        public double f { get; set; }
        public double g { get; set; }
        public double h { get; set; }
        public double i { get; set; }
        public double j { get; set; }
        public double k { get; set; }
        public double l { get; set; }
        public double m { get; set; }
        public double n { get; set; }
        public double o { get; set; }
        public double p { get; set; }
        public int Cluster { get; set; }
        public int SubCluster { get; set; }
        public string SongAndArtist { get; set; }
        public double? Distance { get; set; }
    }
}
