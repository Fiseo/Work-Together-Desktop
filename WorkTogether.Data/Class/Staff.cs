using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models
{
    abstract public class Staff: User
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string? LastName { get; set; }

        public int? CivilityId { get; set; }
        [Required]
        
        public Civility? Civility { get; set; }

        public override string Label => FirstName + " " + LastName;
    }
}