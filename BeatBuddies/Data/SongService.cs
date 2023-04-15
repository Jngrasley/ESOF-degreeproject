using System.Data;
using System.Data.SqlClient;

namespace MusicRecommendationSystem.Data
{
    public class SongService
    {
        //gets all songs from the db
        public List<Song> GetAllSongs()
        {
            List<Song> SongList = new List<Song>();
            Song song;
            //retrieve connection string
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();

            string connStr = configuration.GetConnectionString("DefaultConn");

            //connect to database
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("AllSongsListGet", con))
                {
                    //execute stored procedure with listed parameters
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    //read song attributes for each row in db
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            song = new Song();
                            song.TrackID = sdr["track_id"].ToString();
                            song.SongTitle = sdr["track_name"].ToString();
                            song.Album = sdr["track_album"].ToString();
                            song.PreviewURL = sdr["preview_URL"].ToString();
                            song.Artist = sdr["artist_name"].ToString();
                            song.Genre = sdr["track_genre"].ToString();
                            song.Duration = Convert.ToDouble(sdr["duration"]);
                            song.Danceability = Convert.ToDouble(sdr["danceability"]);
                            song.Energy = Convert.ToDouble(sdr["energy"]);
                            song.Key = Convert.ToInt32(sdr["track_key"]);
                            song.Loudness = Convert.ToDouble(sdr["loudness"]);
                            song.Speechiness = Convert.ToDouble(sdr["speechiness"]);
                            song.Acousticness = Convert.ToDouble(sdr["acousticness"]);
                            song.Instrumentalness = Convert.ToDouble(sdr["instrumentalness"]);
                            song.Liveness = Convert.ToDouble(sdr["liveness"]);
                            song.Valence = Convert.ToDouble(sdr["valence"]);
                            song.Tempo = Convert.ToDouble(sdr["tempo"]);
                            song.TimeSignature = Convert.ToInt32(sdr["time_signature"]);
                            song.ZeroCrossing = Convert.ToDouble(sdr["zero_crossing"]);
                            song.MFCCSMax = Convert.ToDouble(sdr["mfccs_max"]);
                            song.MFCCSMin = Convert.ToDouble(sdr["mfccs_min"]);
                            song.MFCCSMean = Convert.ToDouble(sdr["mfccs_mean"]);
                            song.MFCCSMedian = Convert.ToDouble(sdr["mfccs_median"]);
                            song.RMS = Convert.ToDouble(sdr["RMS"]);
                            song.BPM = Convert.ToDouble(sdr["BPM"]);
                            song.RolloffMin = Convert.ToDouble(sdr["rolloff_min"]);
                            song.RolloffMax = Convert.ToDouble(sdr["rolloff_max"]);
                            song.ChromaMedian = Convert.ToDouble(sdr["chroma_median"]);
                            song.ChromaMean = Convert.ToDouble(sdr["chroma_mean"]);
                            song.ChromaMin = Convert.ToDouble(sdr["chroma_min"]);
                            song.ChromaMax = Convert.ToDouble(sdr["chroma_max"]);
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);
                            song.SubCluster = Convert.ToInt32(sdr["subcluster_labels"]);
                            song.a = Convert.ToDouble(sdr["a"]);
                            song.b = Convert.ToDouble(sdr["b"]);
                            song.c = Convert.ToDouble(sdr["c"]);
                            song.d = Convert.ToDouble(sdr["d"]);
                            song.e = Convert.ToDouble(sdr["e"]);
                            song.f = Convert.ToDouble(sdr["f"]);
                            song.g = Convert.ToDouble(sdr["g"]);
                            song.h = Convert.ToDouble(sdr["h"]);
                            song.i = Convert.ToDouble(sdr["i"]);
                            song.j = Convert.ToDouble(sdr["j"]);
                            song.k = Convert.ToDouble(sdr["k"]);
                            song.l = Convert.ToDouble(sdr["l"]);
                            song.m = Convert.ToDouble(sdr["m"]);
                            song.n = Convert.ToDouble(sdr["n"]);
                            song.o = Convert.ToDouble(sdr["o"]);
                            song.p = Convert.ToDouble(sdr["p"]);
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);
                            song.SubCluster = Convert.ToInt32(sdr["subcluster_labels"]);

                            SongList.Add(song);
                        }
                    }
                }
            }
            //return song list
            return SongList;
        
        }

        //gets all songs in the given cluster
        public List<Song> GetSimilarSongs(int clusterLabel, int subClusterLabel)
        {
            List<Song> SongList = new List<Song>();
            Song song;
            //retrieve connection string
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();

            string connStr = configuration.GetConnectionString("DefaultConn");

            //connect to database
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetSimilarTracks", con))
                {
                    //execute stored procedure with listed parameters
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@label", clusterLabel);
                    cmd.Parameters.AddWithValue("@sublabel", subClusterLabel);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //read song attributes in each row of the db
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            song = new Song();
                            song.TrackID = sdr["track_id"].ToString();
                            song.SongTitle = sdr["track_name"].ToString();
                            song.Album = sdr["track_album"].ToString();
                            song.PreviewURL = sdr["preview_URL"].ToString();
                            song.Artist = sdr["artist_name"].ToString();
                            song.Genre = sdr["track_genre"].ToString();
                            song.Duration = Convert.ToDouble(sdr["duration"]);
                            song.Danceability = Convert.ToDouble(sdr["danceability"]);
                            song.Energy = Convert.ToDouble(sdr["energy"]);
                            song.Key = Convert.ToInt32(sdr["track_key"]);
                            song.Loudness = Convert.ToDouble(sdr["loudness"]);
                            song.Speechiness = Convert.ToDouble(sdr["speechiness"]);
                            song.Acousticness = Convert.ToDouble(sdr["acousticness"]);
                            song.Instrumentalness = Convert.ToDouble(sdr["instrumentalness"]);
                            song.Liveness = Convert.ToDouble(sdr["liveness"]);
                            song.Valence = Convert.ToDouble(sdr["valence"]);
                            song.Tempo = Convert.ToDouble(sdr["tempo"]);
                            song.TimeSignature = Convert.ToInt32(sdr["time_signature"]);
                            song.ZeroCrossing = Convert.ToDouble(sdr["zero_crossing"]);
                            song.MFCCSMax = Convert.ToDouble(sdr["mfccs_max"]);
                            song.MFCCSMin = Convert.ToDouble(sdr["mfccs_min"]);
                            song.MFCCSMean = Convert.ToDouble(sdr["mfccs_mean"]);
                            song.MFCCSMedian = Convert.ToDouble(sdr["mfccs_median"]);
                            song.RMS = Convert.ToDouble(sdr["RMS"]);
                            song.BPM = Convert.ToDouble(sdr["BPM"]);
                            song.RolloffMin = Convert.ToDouble(sdr["rolloff_min"]);
                            song.RolloffMax = Convert.ToDouble(sdr["rolloff_max"]);
                            song.ChromaMedian = Convert.ToDouble(sdr["chroma_median"]);
                            song.ChromaMean = Convert.ToDouble(sdr["chroma_mean"]);
                            song.ChromaMin = Convert.ToDouble(sdr["chroma_min"]);
                            song.ChromaMax = Convert.ToDouble(sdr["chroma_max"]);
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);
                            song.SubCluster = Convert.ToInt32(sdr["subcluster_labels"]);
                            song.a = Convert.ToDouble(sdr["a"]);
                            song.b = Convert.ToDouble(sdr["b"]);
                            song.c = Convert.ToDouble(sdr["c"]);
                            song.d = Convert.ToDouble(sdr["d"]);
                            song.e = Convert.ToDouble(sdr["e"]);
                            song.f = Convert.ToDouble(sdr["f"]);
                            song.g = Convert.ToDouble(sdr["g"]);
                            song.h = Convert.ToDouble(sdr["h"]);
                            song.i = Convert.ToDouble(sdr["i"]);
                            song.j = Convert.ToDouble(sdr["j"]);
                            song.k = Convert.ToDouble(sdr["k"]);
                            song.l = Convert.ToDouble(sdr["l"]);
                            song.m = Convert.ToDouble(sdr["m"]);
                            song.n = Convert.ToDouble(sdr["n"]);
                            song.o = Convert.ToDouble(sdr["o"]);
                            song.p = Convert.ToDouble(sdr["p"]);

                            SongList.Add(song);
                        }
                    }
                }
            }
            //return song list
            return SongList;

        }
    }
}
