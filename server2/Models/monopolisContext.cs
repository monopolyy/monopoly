using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server2.Proxy;

namespace server2.Models
{
    public partial class monopolisContext : DbContext
    {
        //TaxProxy taxproxy = new TaxProxy()
        public monopolisContext()
        {
        }

        public monopolisContext(DbContextOptions<monopolisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NeighbourhoodType> NeighbourhoodType { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<TaxProxy> Tax { get; set; }
        public virtual DbSet<Tile> Tile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:monopolyyy.database.windows.net,1433;Initial Catalog=game;Persist Security Info=False;User ID=monopoly;Password=game123456-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NeighbourhoodType>(entity =>
            {
                entity.HasKey(e => e.IdNeighbourhoodType);

                entity.Property(e => e.IdNeighbourhoodType)
                    .HasColumnName("id_NeighbourhoodType")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer);

                entity.Property(e => e.IdPlayer).HasColumnName("id_Player");

                entity.Property(e => e.CurrentPosition).HasColumnName("currentPosition");

                entity.Property(e => e.IndexP).HasColumnName("indexP");

                entity.Property(e => e.State).HasColumnName("state");


                entity.Property(e => e.Turn).HasColumnName("turn");

                entity.Property(e => e.MoneyP).HasColumnName("moneyP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.IdStreets);

                entity.Property(e => e.IdStreets).HasColumnName("id_Streets");

                entity.Property(e => e.FkPlayeridPlayer).HasColumnName("fk_Playerid_Player");

                entity.Property(e => e.NeighbourHood).HasColumnName("neighbourHood");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rent).HasColumnName("rent");

                entity.Property(e => e.Level).HasColumnName("levell");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.HasOne(d => d.FkPlayeridPlayerNavigation)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.FkPlayeridPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Streets__fk_Play__52593CB8");

                entity.HasOne(d => d.NeighbourHoodNavigation)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.NeighbourHood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Streets__neighbo__5165187F");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.IdTax);

                entity.Property(e => e.IdTax).HasColumnName("id_Tax");

                entity.Property(e => e.TaxAmount).HasColumnName("taxAmount");

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<Tile>(entity =>
            {
                entity.HasKey(e => e.IdTile);

                entity.Property(e => e.IdTile)
                    .HasColumnName("id_Tile")
                    .ValueGeneratedNever();

                entity.Property(e => e.IndexT).HasColumnName("indexT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.DrawOut).HasColumnName("drawOut");
                entity.Property(e => e.Amaunt).HasColumnName("amaunt");
            });
        }
    }
}
