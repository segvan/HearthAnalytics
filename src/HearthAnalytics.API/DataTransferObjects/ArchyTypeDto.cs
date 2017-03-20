using System;
using System.ComponentModel.DataAnnotations;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class ArchyTypeDto : BaseDto<int>
    {
        [Required]
        public int ClassId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public bool IsActive { get; set; }
    }
}
