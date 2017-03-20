using System.ComponentModel.DataAnnotations;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class MatchResultDto : BaseDto<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int MatchResultEnum { get; set; }
    }
}
