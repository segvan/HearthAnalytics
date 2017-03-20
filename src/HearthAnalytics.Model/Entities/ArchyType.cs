using HearthAnalytics.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HearthAnalytics.Model
{
    [Table("ArchyTypes")]
    public class ArchyType : BaseEntity<int>, IDateTracking, IHasOwner<Guid>
    {
        [Required]
        public int ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public ClassType Class { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Deck> Decks { get; set; }

        [Required]
        [Column("UserId")]
        public Guid OwnerUserId { get; set; }

        [ForeignKey(nameof(OwnerUserId))]
        public User Owner { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public ArchyType()
        {
            this.Decks = new List<Deck>();
        }
    }
}
