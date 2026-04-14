using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Repositoryy
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<MyVolunteer> Volunteers { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}