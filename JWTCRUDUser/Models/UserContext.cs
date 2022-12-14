using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JWTCRUDUser.Models;

namespace JWTCRUDUser.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User>? users { get; set; }

        public UserContext(DbContextOptions options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}