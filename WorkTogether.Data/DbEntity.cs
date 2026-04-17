using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTogether.Data
{
    public abstract class DbEntity
    {
        public bool IsValid()
        {
            return Validator.TryValidateObject(
                this,
                new ValidationContext(this),
                new List<ValidationResult>(),
                validateAllProperties: true
            );
        }

        public abstract bool IsDeleteable();
    }
}
