using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KanbanAPI.Models;
using KanbanAPI.Data;

namespace KanbanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/boards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Board>>> GetBoards()
        {
            return await _context.Boards.Include(b => b.Cards).ToListAsync();
        }

        // GET: api/boards/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetBoard(int id)
        {
            var board = await _context.Boards.Include(b => b.Cards).FirstOrDefaultAsync(b => b.Id == id);
            if (board == null)
            {
                return NotFound();
            }
            return board;
        }

        // POST: api/boards
        [HttpPost]
        public async Task<ActionResult<Board>> CreateBoard(Board board)
        {
            board.CreatedAt = DateTime.UtcNow;
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoard), new { id = board.Id }, board);
        }

        // PUT: api/boards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, Board updatedBoard)
        {
            if (id != updatedBoard.Id)
                return BadRequest();

            var board = await _context.Boards.FindAsync(id);
            if (board == null)
                return NotFound();

            board.Name = updatedBoard.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/boards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
                return NotFound();

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
