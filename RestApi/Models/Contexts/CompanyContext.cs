using Microsoft.EntityFrameworkCore;

namespace RestApi.Models.Contexts
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dostawcy> Dostawcy { get; set; } = null!;
        public virtual DbSet<Dostawy> Dostawy { get; set; } = null!;
        public virtual DbSet<Kategorie> Kategorie { get; set; } = null!;
        public virtual DbSet<Klienci> Klienci { get; set; } = null!;
        public virtual DbSet<ProduktDostawy> ProduktDostawy { get; set; } = null!;
        public virtual DbSet<Produkty> Produkty { get; set; } = null!;
        public virtual DbSet<Zamowienia> Zamowienia { get; set; } = null!;
        public virtual DbSet<ZamowioneProdukty> ZamowioneProdukty { get; set; } = null!;
        public virtual DbSet<Uzytkownik> Uzytkownicy { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dostawcy>(entity =>
            {
                entity.HasKey(e => e.DostawcaId)
                    .HasName("PK__Dostawcy__62ECC779AE897194");
            });

            modelBuilder.Entity<Dostawy>(entity =>
            {
                entity.HasKey(e => e.DostawaId)
                    .HasName("PK__Dostawy__527104C5C2EF144C");

                entity.Property(e => e.DataDostawy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Dostawca)
                    .WithMany(p => p.Dostawy)
                    .HasForeignKey(d => d.DostawcaId)
                    .HasConstraintName("FK__Dostawy__Dostawc__49C3F6B7");
            });

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.HasKey(e => e.KategoriaId)
                    .HasName("PK__Kategori__37D210EC39FF8D68");
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.KlientId)
                    .HasName("PK__Klienci__EA31B8934A99865F");
            });

            modelBuilder.Entity<ProduktDostawy>(entity =>
            {
                entity.HasKey(e => new { e.DostawaId, e.ProduktId })
                    .HasName("PK__ProduktD__6D6EF7C7204FF0E0");

                entity.HasOne(d => d.Dostawa)
                    .WithMany(p => p.ProduktDostawy)
                    .HasForeignKey(d => d.DostawaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProduktDo__Dosta__4CA06362");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.ProduktDostawy)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProduktDo__Produ__4D94879B");
            });

            modelBuilder.Entity<Produkty>(entity =>
            {
                entity.HasKey(e => e.ProduktId)
                    .HasName("PK__Produkty__F1FF30226D55E572");

                entity.HasOne(d => d.Kategorie)
                    .WithMany(p => p.Produkty)
                    .HasForeignKey(d => d.KategoriaId)
                    .HasConstraintName("FK__Produkty__Katego__398D8EEE");
            });

            modelBuilder.Entity<Zamowienia>(entity =>
            {
                entity.HasKey(e => e.ZamowienieId)
                    .HasName("PK__Zamowien__7BB9EB6028853FD1");

                entity.Property(e => e.DataZamowienia).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Zamowienia)
                    .HasForeignKey(d => d.KlientId)
                    .HasConstraintName("FK__Zamowieni__Klien__403A8C7D");
            });

            modelBuilder.Entity<ZamowioneProdukty>(entity =>
            {
                entity.HasKey(e => new { e.ZamowienieId, e.ProduktId })
                    .HasName("PK__Zamowion__44A61862512B7FD7");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.ZamowioneProdukty)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zamowione__Produ__440B1D61");

                entity.HasOne(d => d.Zamowienie)
                    .WithMany(p => p.ZamowioneProdukty)
                    .HasForeignKey(d => d.ZamowienieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zamowione__Zamow__4316F928");
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HasloHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Rola)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("User");

                entity.ToTable("Uzytkownicy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
