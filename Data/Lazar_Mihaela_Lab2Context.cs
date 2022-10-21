using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lazar_Mihaela_Lab2.Models;

namespace Lazar_Mihaela_Lab2.Data
{
    public class Lazar_Mihaela_Lab2Context : DbContext
    {
        public Lazar_Mihaela_Lab2Context (DbContextOptions<Lazar_Mihaela_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lazar_Mihaela_Lab2.Models.Book> Book { get; set; } = default!;
    }
}
