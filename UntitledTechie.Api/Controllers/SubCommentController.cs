using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Api.Data;
using UntitledTechie.Api.Entities;

namespace UntitledTechie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCommentController : ControllerBase
    {
        private readonly TechieContext _context;

        public SubCommentController(TechieContext context)
        {
            _context = context;
        }

        // GET: api/SubComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCommentEntity>>> GetSubComments()
        {
            return await _context.SubComments.ToListAsync();
        }

        // GET: api/SubComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCommentEntity>> GetSubCommentEntity(Guid id)
        {
            var subCommentEntity = await _context.SubComments.FindAsync(id);

            if (subCommentEntity == null)
            {
                return NotFound();
            }

            return subCommentEntity;
        }

        // PUT: api/SubComment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCommentEntity(Guid id, SubCommentEntity subCommentEntity)
        {
            if (id != subCommentEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCommentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCommentEntityExists(id))
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

        // POST: api/SubComment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubCommentEntity>> PostSubCommentEntity(SubCommentEntity subCommentEntity)
        {
            _context.SubComments.Add(subCommentEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCommentEntity", new { id = subCommentEntity.Id }, subCommentEntity);
        }

        // DELETE: api/SubComment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCommentEntity>> DeleteSubCommentEntity(Guid id)
        {
            var subCommentEntity = await _context.SubComments.FindAsync(id);
            if (subCommentEntity == null)
            {
                return NotFound();
            }

            _context.SubComments.Remove(subCommentEntity);
            await _context.SaveChangesAsync();

            return subCommentEntity;
        }

        private bool SubCommentEntityExists(Guid id)
        {
            return _context.SubComments.Any(e => e.Id == id);
        }
    }
}
