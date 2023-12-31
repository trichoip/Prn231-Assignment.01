﻿using System.ComponentModel.DataAnnotations;

namespace EStore.Share.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
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
