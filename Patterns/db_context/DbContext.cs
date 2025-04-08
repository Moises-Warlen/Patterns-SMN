using Microsoft.EntityFrameworkCore;
using Patterns.Models;

namespace Patterns.db_context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Sub_Iten> Sub_Iten { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(e => e.cod_usuario);
                entity.Property(e => e.nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ind_admin);
            });

            modelBuilder.Entity<Assunto>(entity =>
            {
                entity.ToTable("Assunto");
                entity.HasKey(e => e.cod_assunto);
                entity.Property(e => e.nome).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Sub_Iten>(entity =>
            {
                entity.ToTable("Sub_Iten");
                entity.HasKey(e => e.cod_sub);
                entity.Property(e => e.nome).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Postagem>(entity =>
            {
                entity.ToTable("Postagem");
                entity.HasKey(e => e.cod_post);

                entity.Property(e => e.conteudo).IsRequired().HasMaxLength(20000);
                entity.Property(e => e.data_post).HasColumnType("date");

                entity.HasOne(e => e.Assunto)
                    .WithMany()
                    .HasForeignKey(e => e.cod_assunto)
                    .HasConstraintName("fk_postagem_assunto");

                entity.HasOne(e => e.sub_iten)
                    .WithMany(s => s.Postagens)
                    .HasForeignKey(e => e.cod_sub)
                    .HasConstraintName("fk_postagem_subiten");

                entity.HasOne(e => e.autor)
                    .WithMany(u => u.Postagens)
                    .HasForeignKey(e => e.cod_usuario)
                    .HasConstraintName("fk_postagem_usuario");
            });
        }
    }
}
