using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model
{
    public class Hour
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Permatnent:
        /// Zadavatel Trener - Id kdo je na hodině
        /// Zadavatel Zak - Ke komu na hodinu
        /// Onetime:
        /// Id kdo je na hodině, pokud volna hodina tak nikdo
        /// </summary>
        [Required]
        [DisplayName("Kdo je na hodinw/ U koho hodina")]
        public string Person { get; set; }
        /// <summary>
        /// Zacatek hodiny
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Začátek hodiny")]
        public DateTime Start { get; set; }
        /// <summary>
        /// Konec hodiny
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Konec hodiny")]
        public DateTime End { get; set; }
        /// <summary>
        /// Kdo zadal hodinu
        /// Permanent:
        /// Trener - opakujici s hodina v rozvrhu
        /// Zak - preferovana hodina, kdy by chtel mit trenink
        /// Onetime:
        /// Trener - volna hodina
        /// Zak - individualni hodina
        /// </summary>
        [Required]
        [DisplayName("Zadavatel hodiny")]
        public string Requester { get; set; }
        [Required]
        public bool isOnetime { get; set; }
    }
}
