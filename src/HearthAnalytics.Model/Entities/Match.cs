using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HearthAnalytics.Infrastructure;

namespace HearthAnalytics.Model
{
    [Table("Matches")]
    public class Match : BaseEntity<Guid>, IDateTracking, IHasOwner<Guid>
    {
        [Required]
        [Column("UserId")]
        public Guid OwnerUserId { get; set; }

        [ForeignKey(nameof(OwnerUserId))]
        public User Owner { get; set; }

        [Required]
        public Guid DeckId { get; set; }

        [ForeignKey(nameof(DeckId))]
        public Deck Deck { get; set; }

        public int? EnemyClassId { get; set; }

        [ForeignKey(nameof(EnemyClassId))]
        public ClassType EnemyClass { get; set; }

        public int? EnemyArchyTypeId { get; set; }

        [ForeignKey(nameof(EnemyArchyTypeId))]
        public ArchyType EnemyArchyType { get; set; }

        public bool Coin { get; set; }

        [Required]
        public int ResultId { get; set; }

        [ForeignKey(nameof(ResultId))]
        public MatchResult Result { get; set; }

        public int Rank { get; set; }

        public string Notes { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
