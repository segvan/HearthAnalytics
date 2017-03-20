using HearthAnalytics.Infrastructure;
using HearthAnalytics.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HearthAnalytics.Model
{
    [Table("MatchResults")]
    public class MatchResult : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public MatchResultEnum MatchResultEnum { get; set; }
    }
}
