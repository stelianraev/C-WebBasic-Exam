namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using static Data.Constants;
    public class User
    {
        [Required]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();
        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
