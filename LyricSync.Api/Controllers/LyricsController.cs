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
    public class LyricsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LyricsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{songId}")]
        public async Task<ActionResult<IEnumerable<Lyric>>> GetLyrics(int songId)
        {
            var lyrics = await _context.Lyrics.Where(l => l.SongId == songId).ToListAsync();
            return lyrics;
        }

        [HttpPost]
        public async Task<ActionResult<Lyric>> CreateLyric(LyricDto dto)
        {
            var lyric = new Lyric {
                Content = dto.Content,
                SongId = dto.SongId,
                Timestamp = dto.Timestamp,
                Language = dto.Language,
                IsPrimary = dto.IsPrimary
            };

            _context.Lyrics.Add(lyric);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLyrics), new { songId = lyric.SongId }, lyric);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLyric(int id, LyricDto dto)
        {
            var lyric = await _context.Lyrics.FindAsync(id);
            if (lyric == null) return NotFound();

            lyric.Content = dto.Content;
            lyric.Timestamp = dto.Timestamp;
            lyric.Language = dto.Language;
            lyric.IsPrimary = dto.IsPrimary;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLyric(int id)
        {
            var lyric = await _context.Lyrics.FindAsync(id);
            if (lyric == null) return NotFound();

            _context.Lyrics.Remove(lyric);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
