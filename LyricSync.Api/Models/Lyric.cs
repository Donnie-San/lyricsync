namespace LyricSync.Models
{
    public class Lyric
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }

        public TimeSpan? Timestamp { get; set; }
        public string Language { get; set; }
        public bool IsPrimary { get; set; }
    }
}
