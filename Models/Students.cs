using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student.Models
{
    public class Students
    {
        [Key]
        public int Id {get; set;}

        public string? name {get; set;}

        public int cls {get; set;}

        [Display(Name ="Teachers")]
        public virtual int TeacherId {get; set;}

        [ForeignKey("TeacherId")]
        public virtual Teachers? Teacher {get; set;}
    }
}