using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using upd8_webApi.Models;

namespace upd8_webApi.Data
{
    public class upd8_webApiContext : DbContext
    {
        public upd8_webApiContext (DbContextOptions<upd8_webApiContext> options)
            : base(options)
        {
        }

        public DbSet<upd8_webApi.Models.Cidade> Cidade { get; set; } = default!;

        public DbSet<upd8_webApi.Models.Estado> Estado { get; set; }

        public DbSet<upd8_webApi.Models.Cliente> Cliente { get; set; }
    }
}
