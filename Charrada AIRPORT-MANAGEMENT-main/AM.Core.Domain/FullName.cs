using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class FullName
    {

        [MaxLength(30, ErrorMessage = "MaxLength 30")]

        public string FirstName { get; set; }

        [Key]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string LastName { get; set; }

    }
}
