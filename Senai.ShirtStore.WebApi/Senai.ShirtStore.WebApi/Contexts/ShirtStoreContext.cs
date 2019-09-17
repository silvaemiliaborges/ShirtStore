using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class ShirtStoreContext : DbContext
    {
        public ShirtStoreContext()
        {
        }

        public ShirtStoreContext(DbContextOptions<ShirtStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camiseta> Camiseta { get; set; }
        public virtual DbSet<Cor> Cor { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Tamanho> Tamanho { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_ShirtStore;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camiseta>(entity =>
            {
                entity.HasKey(e => e.IdCamiseta);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCorNavigation)
                    .WithMany(p => p.Camiseta)
                    .HasForeignKey(d => d.IdCor)
                    .HasConstraintName("FK__Camiseta__IdCor__628FA481");

                entity.HasOne(d => d.IdEstoqueNavigation)
                    .WithMany(p => p.Camiseta)
                    .HasForeignKey(d => d.IdEstoque)
                    .HasConstraintName("FK__Camiseta__IdEsto__656C112C");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Camiseta)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Camiseta__IdMarc__6477ECF3");

                entity.HasOne(d => d.IdTamanhoNavigation)
                    .WithMany(p => p.Camiseta)
                    .HasForeignKey(d => d.IdTamanho)
                    .HasConstraintName("FK__Camiseta__IdTama__6383C8BA");
            });

            modelBuilder.Entity<Cor>(entity =>
            {
                entity.HasKey(e => e.IdCor);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Marca__7D8FE3B223408A78")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Perfil__7D8FE3B26824B936")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tamanho>(entity =>
            {
                entity.HasKey(e => e.IdTamanho);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105349DA48A09")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuario__7D8FE3B2C9A2E52E")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
