using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMovies.Models
{
    public class ApplicationUserClass : DbContext
    {
        public ApplicationUserClass(DbContextOptions<ApplicationUserClass> options) : base (options)
        {

        }
    }
}
