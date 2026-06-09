using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController(AppDbContext context): BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>>GetMembers()
        {
            var members = await context.Members.ToListAsync();
            return members;
        }

        [Authorize]
        [HttpGet("{id}")] // localhost:5001/api/members/bob-id
        public async Task<ActionResult<Member>> GetMember(string id)
        {
            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();
            return member;
        }

    }
}