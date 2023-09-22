using System.ComponentModel.DataAnnotations;

namespace EStore.DataAccess.DTOs
{
    public class MemberDTO
    {
        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Password { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
