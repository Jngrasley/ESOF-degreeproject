using System.Data;
using System.Data.SqlClient;

namespace MusicRecommendationSystem.Data
{
    public class SongService
    {
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

                    //read value to determine if user is authenticated or not
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            song = new Song();
                            song.SongTitle = sdr["track_name"].ToString();
                            song.Artist = sdr["artist_name"].ToString();
                            song.Album = sdr["track_album"].ToString();
                            song.Genre = sdr["track_genre"].ToString();
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);

                            SongList.Add(song);
                        }
                    }
                }
            }
            //return authentication status
            return SongList;
        
        }

        public List<Song> GetSimilarSongs(int clusterLabel, string title)
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
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@label", clusterLabel);              
                    cmd.CommandType = CommandType.StoredProcedure;

                    //read value to determine if user is authenticated or not
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            song = new Song();
                            song.SongTitle = sdr["track_name"].ToString();
                            song.Artist = sdr["artist_name"].ToString();
                            song.Album = sdr["track_album"].ToString();
                            song.Genre = sdr["track_genre"].ToString();
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);

                            SongList.Add(song);
                        }
                    }
                }
            }
            //return authentication status
            return SongList;

        }


        public Song GetSong(string title)
        {
            Song song = new Song();
            //retrieve connection string
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();

            string connStr = configuration.GetConnectionString("DefaultConn");

            //connect to database
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetSong", con))
                {
                    //execute stored procedure with listed parameters
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //read value to determine if user is authenticated or not
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            song.SongTitle = sdr["track_name"].ToString();
                            song.Artist = sdr["artist_name"].ToString();
                            song.Album = sdr["track_album"].ToString();
                            song.Genre = sdr["track_genre"].ToString();
                            song.Cluster = Convert.ToInt32(sdr["cluster_labels"]);
                        }
                    }
                }
            }
            //return authentication status
            return song;

        }
    }
}
