using System.Security.Claims;
using API.Data;
using API.DTOs;
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

        // [HttpPut]
        // public async Task<ActionResult> UpdateMember(MemberUpdateDto memberUpdateDto)
        // {
        //     var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //     if (memberId == null) return BadRequest("Oops - No id found in token");
        //     var member = await await MemberRepository.GetMemberByIdAsync(memberId);
        //     if (member == null) return BadRequest("Could not get member");

        //     member.DisplayName = memberUpdateDto.DisplayName ?? member.DisplayName;
        //     member.Description = memberUpdateDto.Description ?? member.Description;
        //     member.City = memberUpdateDto.City ?? member.City;
        //     member.Country = memberUpdateDto.Country ?? member.Country;

        //     context.Entry(member).State = EntityState.Modified;

        //     if (await context.SaveChangesAsync() > 0) return NoContent();

        //     return BadRequest("Failed to update the user");
        // }

    }
}