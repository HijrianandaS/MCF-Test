using Microsoft.EntityFrameworkCore;

namespace BackendMCF.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
        public DbSet<MsUser> MsUsers { get; set; }
        public DbSet<TrBpkb> TrBpkbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Pemetaan tabel
            modelBuilder.Entity<MsUser>().ToTable("ms_user");
            modelBuilder.Entity<MsStorageLocation>().ToTable("ms_storage_location");
            modelBuilder.Entity<TrBpkb>().ToTable("tr_bpkb");

            modelBuilder.Entity<MsUser>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.UserName).HasColumnName("user_name");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
            });

            modelBuilder.Entity<MsStorageLocation>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.LocationName).HasColumnName("location_name");
            });

            modelBuilder.Entity<TrBpkb>(entity =>
            {
                entity.Property(e => e.AgreementNumber).HasColumnName("agreement_number");
                entity.Property(e => e.BpkbNo).HasColumnName("bpkb_no");
                entity.Property(e => e.BranchId).HasColumnName("branch_id");
                entity.Property(e => e.BpkbDate).HasColumnName("bpkb_date");
                entity.Property(e => e.FakturNo).HasColumnName("faktur_no");
                entity.Property(e => e.FakturDate).HasColumnName("faktur_date");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.PoliceNo).HasColumnName("police_no");
                entity.Property(e => e.BpkbDateIn).HasColumnName("bpkb_date_in");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.CreatedOn).HasColumnName("created_on");
                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");
                entity.Property(e => e.LastUpdatedOn).HasColumnName("last_updated_on");
            });
        }
    }
}
