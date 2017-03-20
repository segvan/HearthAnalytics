using HearthAnalytics.Infrastructure;
using HearthAnalytics.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HearthAnalytics.Model
{
    [Table("ClassTypes")]
    public class ClassType : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public ClassTypeEnum ClassTypeEnum { get; set; }
    }
}
