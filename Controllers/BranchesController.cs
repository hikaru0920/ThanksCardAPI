using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BranchesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {

            return await _context.Branches
                                    .Include(Branch => Branch.Department)
                                    .ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(long id)
        {
            var branch = await _context.Branches.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return branch;
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(long id, Branch branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Branch>> PostDepartment(Branch branch)
        {
            // Parent Department には既に存在している部署が入るため、更新の対象から外す。
            

            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = branch.Id }, branch);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteBranch(long id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        private bool BranchExists(long id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
