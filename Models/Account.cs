using System;
using System.Collections.Generic;

namespace allspice.Models
{
    public class Account : Profile
    {
        public string Email { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        
    }
}