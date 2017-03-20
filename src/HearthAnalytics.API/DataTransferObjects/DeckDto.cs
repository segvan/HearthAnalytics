using System;
using System.ComponentModel.DataAnnotations;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class DeckDto : BaseDto<Guid>
    {
        [Required]
        public int ArchyTypeId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public double Version { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
