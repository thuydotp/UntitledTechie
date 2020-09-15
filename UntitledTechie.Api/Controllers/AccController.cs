using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Data;
using UntitledTechie.Api.DTOs;
using UntitledTechie.Infrastructure.Entities;
using UntitledTechie.Infrastructure.Repositories.Contract;

namespace UntitledTechie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccController : ControllerBase
    {

        private readonly IRepository<AccountEntity> _accRepository;
        public AccController(IRepository<AccountEntity> accRepository)
        {
            _accRepository = accRepository;
        }

        // GET: api/AccountControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            return Ok(await _accRepository.GetAllListAsync());
        }

    }
}
