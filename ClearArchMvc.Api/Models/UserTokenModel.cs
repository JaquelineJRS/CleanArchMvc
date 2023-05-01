using System;

namespace CleanArchMvc.Api.Models
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
