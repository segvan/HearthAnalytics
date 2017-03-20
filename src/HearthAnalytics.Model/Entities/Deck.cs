using HearthAnalytics.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HearthAnalytics.Model
{
    [Table("Decks")]
    public class Deck : BaseEntity<Guid>, IDateTracking, IHasOwner<Guid>
    {
        [Required]
        [Column("UserId")]
        public Guid OwnerUserId { get; set; }

        [ForeignKey(nameof(OwnerUserId))]
        public User Owner { get; set; }

        [Required]
        public int ArchyTypeId { get; set; }

        [ForeignKey(nameof(ArchyTypeId))]
        public ArchyType ArchyType { get; set; }

        [Required]
        public string Title { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public double Version { get; set; }

        public ICollection<Match> Matches { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public Deck()
        {
            this.Matches = new List<Match>();
        }
    }
}
