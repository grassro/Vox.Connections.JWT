using VoxConnections.JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.JWT.Context
{
    public class VoxContext : DbContext
    {
        public VoxContext(DbContextOptions<VoxContext> options) : base(options) { }

        public VoxContext() { }

        //Adiciona os modelos das classes no contexto
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Headhunter> Headhunter { get; set; }

    }
}
