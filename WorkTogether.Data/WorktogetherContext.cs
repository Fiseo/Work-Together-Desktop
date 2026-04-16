using Microsoft.EntityFrameworkCore;
using WorkTogether.Data.Models;

namespace WorkTogether.Data;

public partial class WorkTogetherContext : DbContext
{
    public WorkTogetherContext()
    {
    }

    public WorkTogetherContext(DbContextOptions<WorkTogetherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bay> BaySet { get; set; }

    public virtual DbSet<Booking> BookingSet { get; set; }

    public virtual DbSet<BookingUnit> BookingUnitSet { get; set; }

    public virtual DbSet<Civility> CivilitySet { get; set; }

    public virtual DbSet<Offer> OfferSet { get; set; }

    public virtual DbSet<ServiceCall> ServiceCallSet { get; set; }

    public virtual DbSet<ServiceCallType> ServiceCallTypeSet { get; set; }

    public virtual DbSet<Unit> UnitSet { get; set; }

    public virtual DbSet<User> UserSet { get; set; }

    public virtual DbSet<User> AdminSet { get; set; }

    public virtual DbSet<Individual> IndividualSet { get; set; }

    public virtual DbSet<Company> CompanySet { get; set; }

    public virtual DbSet<Technician> TechnicianSet { get; set; }

    public virtual DbSet<Accountant> AccountantSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=worktogether;User=root;Password=root;Port=3306");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bay");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("booking");

            entity.HasIndex(e => e.OfferId, "IDX_E00CEDDE53C674EE");

            entity.HasIndex(e => e.CompanyId, "IDX_E00CEDDE979B1AD6");

            entity.HasIndex(e => e.IndividualId, "IDX_E00CEDDEAE271C0D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.End)
                .HasColumnType("date")
                .HasColumnName("end");
            entity.Property(e => e.IndividualId).HasColumnName("individual_id");
            entity.Property(e => e.IsMonthly).HasColumnName("is_monthly");
            entity.Property(e => e.IsPayed).HasColumnName("is_payed");
            entity.Property(e => e.IsRenewable).HasColumnName("is_renewable");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.Start)
                .HasColumnType("date")
                .HasColumnName("start");

            entity.HasOne(d => d.Company).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_E00CEDDE979B1AD6");

            entity.HasOne(d => d.Individual).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK_E00CEDDEAE271C0D");

            entity.HasOne(d => d.Offer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E00CEDDE53C674EE");
        });

        modelBuilder.Entity<BookingUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("booking_unit");

            entity.HasIndex(e => e.BookingId, "IDX_C42A2E1D3301C60");

            entity.HasIndex(e => e.UnitId, "IDX_C42A2E1DF8BD700D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.End)
                .HasColumnType("date")
                .HasColumnName("end");
            entity.Property(e => e.Start)
                .HasColumnType("date")
                .HasColumnName("start");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingUnits)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C42A2E1D3301C60");

            entity.HasOne(d => d.Unit).WithMany(p => p.BookingUnits)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C42A2E1DF8BD700D");
        });

        modelBuilder.Entity<Civility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("civility");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
            entity.Property(e => e.UnitProvided).HasColumnName("unit_provided");
        });

        modelBuilder.Entity<ServiceCall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_call");

            entity.HasIndex(e => e.TypeId, "IDX_2CD9BD2C54C8C93");

            entity.HasIndex(e => e.TechnicianId, "IDX_2CD9BD2E6C5D496");

            entity.HasIndex(e => e.UnitId, "IDX_2CD9BD2F8BD700D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.TechnicianId).HasColumnName("technician_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Technician).WithMany(p => p.ServiceCalls)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_2CD9BD2E6C5D496");

            entity.HasOne(d => d.Type).WithMany(p => p.ServiceCalls)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_2CD9BD2C54C8C93");

            entity.HasOne(d => d.Unit).WithMany(p => p.ServiceCalls)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_2CD9BD2F8BD700D");
        });

        modelBuilder.Entity<ServiceCallType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_call_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("unit");

            entity.HasIndex(e => e.BayId, "IDX_DCBB0C53DF9BA23B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BayId).HasColumnName("bay_id");
            entity.Property(e => e.HaveProblem).HasColumnName("have_problem");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");

            entity.HasOne(d => d.Bay).WithMany(p => p.Units)
                .HasForeignKey(d => d.BayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCBB0C53DF9BA23B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UNIQ_IDENTIFIER_EMAIL").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Roles)
                .HasColumnType("json")
                .HasColumnName("roles");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasDiscriminator<string>("Type")
                .HasValue<Individual>("individual")
                .HasValue<Company>("company")
                .HasValue<Technician>("technician")
                .HasValue<Accountant>("accountant")
                .HasValue<User>("admin");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasIndex(e => e.CivilityId, "IDX_8D93D64923D6A298");

            entity.Property(e => e.CivilityId).HasColumnName("civility_id");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.HasOne(d => d.Civility).WithMany(p => p.Staffs)
                .HasForeignKey(d => d.CivilityId);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");

        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CompanyRegister)
                .HasMaxLength(14)
                .HasColumnName("company_register");
            entity.Property(e => e.Creation)
                .HasColumnType("date")
                .HasColumnName("creation");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

        });

        modelBuilder.Entity<Individual>(entity =>
        {
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.CivilityId).HasColumnName("civility_id");
            entity.HasOne(d => d.Civility).WithMany(p => p.Individuals)
                .HasForeignKey(d => d.CivilityId)
                .HasConstraintName("FK_8D93D64923D6A298");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
