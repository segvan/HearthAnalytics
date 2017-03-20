using System;
using System.ComponentModel.DataAnnotations;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class MatchDto : BaseDto<Guid>
    {
        [Required]
        public Guid DeckId { get; set; }

        public int? EnemyClassId { get; set; }

        public int? EnemyArchyTypeId { get; set; }

        public bool Coin { get; set; }

        [Required]
        public int ResultId { get; set; }

        public int Rank { get; set; }

        public string Notes { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
