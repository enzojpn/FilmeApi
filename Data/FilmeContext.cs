using FilmeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>().
            HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            builder.Entity<Cinema>()
            .HasOne(cinema => cinema.Gerente)
            .WithMany(gerente => gerente.Cinemas)
            .HasForeignKey(cinema => cinema.Id);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }

    }
}