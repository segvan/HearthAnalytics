using System.ComponentModel.DataAnnotations;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class ClassTypeDto : BaseDto<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int ClassTypeEnum { get; set; }
    }
}
