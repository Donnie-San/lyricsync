namespace LyricSync.DTOs
{
    public class SongDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Album { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
