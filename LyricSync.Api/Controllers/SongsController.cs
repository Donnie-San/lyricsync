using LyricSync.Data;
using LyricSync.Models;
using LyricSync.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LyricSync.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SongsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.Include(s => s.Lyrics).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.Include(s => s.Lyrics).FirstOrDefaultAsync(s => s.Id == id);
            if (song == null) return NotFound();
            return song;
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(SongDto dto)
        {
            var song = new Song {
                Title = dto.Title,
                Artist = dto.Artist,
                Genre = dto.Genre,
                Duration = dto.Duration,
                ReleaseDate = dto.ReleaseDate,
                Album = dto.Album,
                CoverImageUrl = dto.CoverImageUrl
            };

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, SongDto dto)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null) return NotFound();

            song.Title = dto.Title;
            song.Artist = dto.Artist;
            song.Genre = dto.Genre;
            song.Duration = dto.Duration;
            song.ReleaseDate = dto.ReleaseDate;
            song.Album = dto.Album;
            song.CoverImageUrl = dto.CoverImageUrl;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null) return NotFound();

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
