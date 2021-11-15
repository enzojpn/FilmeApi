using FilmeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas {get; set;}
        public DbSet<Endereco> Endereco {get; set;}
        
    }
}