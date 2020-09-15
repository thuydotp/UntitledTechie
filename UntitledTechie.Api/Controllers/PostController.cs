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
    public class PostController : ControllerBase
    {
        private readonly TechieContext _context;

        public PostController(TechieContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostEntity>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostEntity>> GetPostEntity(Guid id)
        {
            var postEntity = await _context.Posts.FindAsync(id);

            if (postEntity == null)
            {
                return NotFound();
            }

            return postEntity;
        }

        // PUT: api/Post/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostEntity(Guid id, PostEntity postEntity)
        {
            if (id != postEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(postEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostEntityExists(id))
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

        // POST: api/Post
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostEntity>> PostPostEntity(PostEntity postEntity)
        {
            _context.Posts.Add(postEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostEntity", new { id = postEntity.Id }, postEntity);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostEntity>> DeletePostEntity(Guid id)
        {
            var postEntity = await _context.Posts.FindAsync(id);
            if (postEntity == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(postEntity);
            await _context.SaveChangesAsync();

            return postEntity;
        }

        private bool PostEntityExists(Guid id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
