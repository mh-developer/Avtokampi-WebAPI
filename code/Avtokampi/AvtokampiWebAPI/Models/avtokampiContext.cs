using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvtokampiWebAPI.Models
{
    public partial class avtokampiContext : DbContext
    {
        public avtokampiContext()
        {
        }

        public avtokampiContext(DbContextOptions<avtokampiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kampi> Kampi { get; set; }
        public virtual DbSet<Mnenja> Mnenja { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID =postgres;Password=postgres;Server=resources.kampiraj.ga;Port=5432;Database=avtokampi;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kampi>(entity =>
            {
                entity.ToTable("kampi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Kraj)
                    .IsRequired()
                    .HasColumnName("kraj")
                    .HasMaxLength(100);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(25);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis");

                entity.Property(e => e.Slika)
                    .IsRequired()
                    .HasColumnName("slika");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Kampi)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id_kampi");
            });

            modelBuilder.Entity<Mnenja>(entity =>
            {
                entity.ToTable("mnenja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KampId).HasColumnName("kamp_id");

                entity.Property(e => e.Mnenje)
                    .IsRequired()
                    .HasColumnName("mnenje")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Kamp)
                    .WithMany(p => p.Mnenja)
                    .HasForeignKey(d => d.KampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kamp_id_mnenja");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mnenja)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id_mnenja");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.ToTable("rezervacije");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Do)
                    .IsRequired()
                    .HasColumnName("do")
                    .HasMaxLength(100);

                entity.Property(e => e.KampId).HasColumnName("kamp_id");

                entity.Property(e => e.Od)
                    .IsRequired()
                    .HasColumnName("od")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Kamp)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kamp_id_rezervacije");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id_rezervacije");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
