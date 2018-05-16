using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HearthAnalytics.Model
{
    [Table("Users")]
    public class User: IdentityUser<Guid>
    {
        [Required]
        public override string UserName { get; set; }

        public override string Email { get; set; }

        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        public ICollection<Deck> Decks { get; set; }
        public ICollection<Match> Matches { get; set; }

        public ICollection<ArchyType> ArhcyTypes { get; set; }

        public User()
        {
            this.Decks = new List<Deck>();
            this.Matches = new List<Match>();
            this.ArhcyTypes = new List<ArchyType>();
        }
    }
}
