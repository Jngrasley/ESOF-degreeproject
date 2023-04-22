USE [ESOF4969DegreeProject]
GO

/****** Object:  Table [dbo].[track]    Script Date: 2023-04-21 9:53:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[track](
	[track_id] [nvarchar](32) NULL,
	[track_name] [nvarchar](60) NULL,
	[track_album] [nvarchar](50) NULL,
	[preview_URL] [nvarchar](100) NULL,
	[artist_name] [nvarchar](40) NULL,
	[track_genre] [nvarchar](25) NULL,
	[duration] [float] NULL,
	[danceability] [float] NULL,
	[energy] [float] NULL,
	[track_key] [int] NULL,
	[loudness] [float] NULL,
	[speechiness] [float] NULL,
	[acousticness] [float] NULL,
	[instrumentalness] [float] NULL,
	[liveness] [float] NULL,
	[valence] [float] NULL,
	[tempo] [float] NULL,
	[time_signature] [int] NULL,
	[zero_crossing] [float] NULL,
	[mfccs_Max] [float] NULL,
	[mfccs_Min] [float] NULL,
	[mfccs_Mean] [float] NULL,
	[mfccs_Median] [float] NULL,
	[RMS] [float] NULL,
	[BPM] [float] NULL,
	[rolloff_min] [float] NULL,
	[rolloff_max] [float] NULL,
	[chroma_Median] [float] NULL,
	[chroma_Mean] [float] NULL,
	[chroma_Min] [float] NULL,
	[chroma_Max] [float] NULL,
	[cluster_labels] [int] NULL,
	[subcluster_labels] [int] NULL,
	[a] [float] NULL,
	[b] [float] NULL,
	[c] [float] NULL,
	[d] [float] NULL,
	[e] [float] NULL,
	[f] [float] NULL,
	[g] [float] NULL,
	[h] [float] NULL,
	[i] [float] NULL,
	[j] [float] NULL,
	[k] [float] NULL,
	[l] [float] NULL,
	[m] [float] NULL,
	[n] [float] NULL,
	[o] [float] NULL,
	[p] [float] NULL
) ON [PRIMARY]
GO


