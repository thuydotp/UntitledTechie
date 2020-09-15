using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Data;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly TechieContext _context;

        public CommentController(TechieContext context)
        {
            _context = context;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentEntity>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentEntity>> GetCommentEntity(Guid id)
        {
            var commentEntity = await _context.Comments.FindAsync(id);

            if (commentEntity == null)
            {
                return NotFound();
            }

            return commentEntity;
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentEntity(Guid id, CommentEntity commentEntity)
        {
            if (id != commentEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommentEntity>> PostCommentEntity(CommentEntity commentEntity)
        {
            _context.Comments.Add(commentEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentEntity", new { id = commentEntity.Id }, commentEntity);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentEntity>> DeleteCommentEntity(Guid id)
        {
            var commentEntity = await _context.Comments.FindAsync(id);
            if (commentEntity == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(commentEntity);
            await _context.SaveChangesAsync();

            return commentEntity;
        }

        private bool CommentEntityExists(Guid id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
