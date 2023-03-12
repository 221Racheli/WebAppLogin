using System.ComponentModel.DataAnnotations;

namespace entities
{
    public class User 
    {
        public int userId { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "too long password")]
        public string password { get; set; }

        [EmailAddress(ErrorMessage = "Email not valid")]
        public string email { get; set; }
    }
}