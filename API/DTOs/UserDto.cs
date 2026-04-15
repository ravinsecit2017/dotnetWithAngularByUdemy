using System;

namespace API.DTOs
{
    public class UserDto
    {
        public string? Id { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public required string Token { get; set; }
    }
}