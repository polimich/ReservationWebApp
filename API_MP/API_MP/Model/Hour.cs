using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model
{
    /// <summary>
    /// Model pro ukládání informací o hodinách
    /// </summary>
    public class Hour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Kdo je na hodinw/ U koho hodina")]
        public string Person { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Začátek hodiny")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Konec hodiny")]
        public DateTime End { get; set; }

        [Required]
        [DisplayName("Zadavatel hodiny")]
        public string Requester { get; set; }
        [Required]
        public bool isOnetime { get; set; }
    }
}
