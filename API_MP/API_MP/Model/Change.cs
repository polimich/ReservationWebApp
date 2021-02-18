using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model
{
    public class Change
    {
        [Key]
        public int id { get; set; }
        [Required]
        public ChangeType ChangeType { get; set; }
        [Required]
        public string Description { get; set; }
    }
    public enum ChangeType
    {
        isSick, 
        CanceledInTime,
        CanceledLate,
    }
}
