using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Models;

namespace MtecDevs.Data;

    public class AppDbContext : IdentityDbContext
    {
       public AppContext(DbContextOptions opcoes) : base(opcoes)
       {
       }

       public DbSet<Usuario> Usuarios {get; set;}
       public DbSet<TipoDev> TipoDevs {get; set;}

    }