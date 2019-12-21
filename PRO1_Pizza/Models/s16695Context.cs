using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO1_Pizza.Models
{
    public partial class s16695Context : DbContext
    {
        public s16695Context()
        {
        }

        public s16695Context(DbContextOptions<s16695Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Ciasto> Ciasto { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaWZamowieniu> PizzaWZamowieniu { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<SkladnikiNaPizzy> SkladnikiNaPizzy { get; set; }
        public virtual DbSet<StatusOplacenia> StatusOplacenia { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16695;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("Administrator_pk");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasColumnName("haslo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciasto>(entity =>
            {
                entity.HasKey(e => e.IdCiasta)
                    .HasName("Ciasto_pk");

                entity.Property(e => e.IdCiasta)
                    .HasColumnName("idCiasta")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaCiasta).HasColumnName("Cena_ciasta");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawcy)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.IdDostawcy)
                    .HasColumnName("idDostawcy")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaPizzy).HasColumnName("Cena_pizzy");

                entity.Property(e => e.CenaPromocyjna).HasColumnName("Cena_promocyjna");

                entity.Property(e => e.IdCiasta).HasColumnName("idCiasta");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiastaNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdCiasta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto");
            });

            modelBuilder.Entity<PizzaWZamowieniu>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdZamowienia })
                    .HasName("Pizza_w_zamowieniu_pk");

                entity.ToTable("Pizza_w_zamowieniu");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaWZamowieniu)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_13_Pizza");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.PizzaWZamowieniu)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_13_Zamowienie");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladniku)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladniku)
                    .HasColumnName("idSkladniku")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaSkladniku).HasColumnName("Cena_skladniku");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkladnikiNaPizzy>(entity =>
            {
                entity.HasKey(e => new { e.IdSkladniku, e.IdPizza })
                    .HasName("Skladniki_na_pizzy_pk");

                entity.ToTable("Skladniki_na_pizzy");

                entity.Property(e => e.IdSkladniku).HasColumnName("idSkladniku");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.SkladnikiNaPizzy)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladniki_na_pizzy_Pizza");

                entity.HasOne(d => d.IdSkladnikuNavigation)
                    .WithMany(p => p.SkladnikiNaPizzy)
                    .HasForeignKey(d => d.IdSkladniku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladniki_na_pizzy_Skladnik");
            });

            modelBuilder.Entity<StatusOplacenia>(entity =>
            {
                entity.HasKey(e => e.IdOplacenia)
                    .HasName("Status_oplacenia_pk");

                entity.ToTable("Status_oplacenia");

                entity.Property(e => e.IdOplacenia)
                    .HasColumnName("idOplacenia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdDostawcy).HasColumnName("idDostawcy");

                entity.Property(e => e.KodPocztowy).HasColumnName("Kod_pocztowy");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrzewidywanyCzasDostawy)
                    .HasColumnName("Przewidywany_czas_dostawy")
                    .HasColumnType("time(4)");

                entity.Property(e => e.StatusOplacenia).HasColumnName("Status_oplacenia");

                entity.Property(e => e.SumaCen).HasColumnName("Suma_cen");

                entity.HasOne(d => d.IdDostawcyNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdDostawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dostawca");

                entity.HasOne(d => d.StatusOplaceniaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.StatusOplacenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Status_oplacenia");
            });
        }
    }
}
