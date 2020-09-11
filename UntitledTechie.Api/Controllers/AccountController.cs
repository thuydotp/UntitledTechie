using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Api.Data;
using UntitledTechie.Api.DTOs;
using UntitledTechie.Api.Entities;

namespace UntitledTechie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TechieContext _context;

        public AccountController(TechieContext context)
        {
            _context = context;
        }

        // GET: api/AccountControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            return await _context.Accounts.Select(x => AccountDTO(x)).ToListAsync();
        }

        // GET: api/AccountControler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccountDTO(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return AccountDTO(account);
        }

        // PUT: api/AccountControler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountDTO(Guid id, AccountDTO AccountDTO)
        {
            if (id != AccountDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(AccountDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDTOExists(id))
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

        // POST: api/AccountControler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> PostAccountDTO(AccountDTO accountDTO)
        {
            AccountEntity account = new AccountEntity {
                Id = accountDTO.Id,
                Username = accountDTO.Username,
                AvatarImageId = accountDTO.AvatarImageId
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccountDTO), new { id = accountDTO.Id }, accountDTO);
        }

        // DELETE: api/AccountControler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDTO>> DeleteAccountDTO(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return AccountDTO(account);
        }

        private bool AccountDTOExists(Guid id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        private static AccountDTO AccountDTO(AccountEntity account)
        {
            return new AccountDTO {
                Id = account.Id,
                Username = account.Username,
                AvatarImageId = account.AvatarImageId,
            };
        }
    }
}
