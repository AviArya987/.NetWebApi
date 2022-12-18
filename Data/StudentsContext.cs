using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student.Models;

namespace student.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options): base(options){}

        public DbSet<Students> Students {get; set;} = null!;
        public DbSet<Teachers> Teachers {get; set;} = null!;
    }
}