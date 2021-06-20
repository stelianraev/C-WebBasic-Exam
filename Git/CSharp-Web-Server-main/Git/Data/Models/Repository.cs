namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants;

    public class Repository
    {
        [Required]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLenght)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
