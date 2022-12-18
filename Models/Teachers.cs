using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student.Models
{
    public class Teachers
    {
        [Key]
        public int Id {get; set;}

        public string? name {get; set;}
    }
}