namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants;

    public class Commit
    {
        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatorId { get; set; }
        public User Creator { get; set; }
        public String RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
