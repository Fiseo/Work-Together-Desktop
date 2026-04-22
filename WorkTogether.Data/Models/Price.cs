using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTogether.Data.Models
{
    public partial class Price: DbEntity
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
