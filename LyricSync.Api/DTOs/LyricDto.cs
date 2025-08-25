namespace LyricSync.DTOs
{
    public class LyricDto
    {
        public string Content { get; set; }
        public int SongId { get; set; }
        public TimeSpan? Timestamp { get; set; }
        public string Language { get; set; }
        public bool IsPrimary { get; set; }
    }
}
