using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TMSDBContext : DbContext
    {
        public TMSDBContext()
        {
        }

        public TMSDBContext(DbContextOptions<TMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OffenceDetail> OffenceDetails { get; set; }
        public virtual DbSet<TmOffence> TmOffences { get; set; }
        public virtual DbSet<TmOwnerdetail> TmOwnerdetails { get; set; }
        public virtual DbSet<TmRegdetail> TmRegdetails { get; set; }
        public virtual DbSet<TmUsermaster> TmUsermasters { get; set; }
        public virtual DbSet<TmVehicledetail> TmVehicledetails { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=TMSDB;Integrated Security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<OffenceDetail>(entity =>
            {
                entity.HasKey(e => e.OffenceNo)
                    .HasName("PK__OFFENCE___261CF930FF8C2ABD");

                entity.ToTable("OFFENCE_DETAILS");

                entity.Property(e => e.OffenceNo).HasColumnName("OFFENCE_NO");

                entity.Property(e => e.OffenceId).HasColumnName("OFFENCE_ID");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PLACE");

                entity.Property(e => e.ReportedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REPORTED_BY");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME");

                entity.Property(e => e.VehNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VEH_NO");

                entity.HasOne(d => d.Offence)
                    .WithMany(p => p.OffenceDetails)
                    .HasForeignKey(d => d.OffenceId)
                    .HasConstraintName("FK__OFFENCE_D__OFFEN__300424B4");

                entity.HasOne(d => d.VehNoNavigation)
                    .WithMany(p => p.OffenceDetails)
                    .HasPrincipalKey(p => p.VehNo)
                    .HasForeignKey(d => d.VehNo)
                    .HasConstraintName("FK__OFFENCE_D__VEH_N__2F10007B");
            });

            modelBuilder.Entity<TmOffence>(entity =>
            {
                entity.HasKey(e => e.OffenceId)
                    .HasName("PK__TM_OFFEN__261F1663525960A8");

                entity.ToTable("TM_OFFENCE");

                entity.Property(e => e.OffenceId).HasColumnName("OFFENCE_ID");

                entity.Property(e => e.OffenceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OFFENCE_TYPE");

                entity.Property(e => e.Penalty).HasColumnName("PENALTY");

                entity.Property(e => e.VehType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEH_TYPE");
            });

            modelBuilder.Entity<TmOwnerdetail>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__TM_OWNER__7C4E08F30873F6FF");

                entity.ToTable("TM_OWNERDETAILS");

                entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");

                entity.Property(e => e.AddProofName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADD_PROOF_NAME");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.LandlineNo).HasColumnName("LANDLINE_NO");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.MobileNo).HasColumnName("MOBILE_NO");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION");

                entity.Property(e => e.PancardNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PANCARD_NO");

                entity.Property(e => e.PermAddr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERM_ADDR");

                entity.Property(e => e.Pincode).HasColumnName("PINCODE");

                entity.Property(e => e.TempAddr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEMP_ADDR");
            });

            modelBuilder.Entity<TmRegdetail>(entity =>
            {
                entity.HasKey(e => e.AppNo)
                    .HasName("PK__TM_REGDE__F00E81B79A238737");

                entity.ToTable("TM_REGDETAILS");

                entity.HasIndex(e => e.VehNo, "UQ__TM_REGDE__77FD7610FCBAF6B1")
                    .IsUnique();

                entity.Property(e => e.AppNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APP_NO");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_PURCHASE");

                entity.Property(e => e.DistrubuterName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISTRUBUTER_NAME");

                entity.Property(e => e.OldOwnerId).HasColumnName("OLD_OWNER_ID");

                entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");

                entity.Property(e => e.VehId).HasColumnName("VEH_ID");

                entity.Property(e => e.VehNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VEH_NO");

                entity.HasOne(d => d.OldOwner)
                    .WithMany(p => p.TmRegdetailOldOwners)
                    .HasForeignKey(d => d.OldOwnerId)
                    .HasConstraintName("FK__TM_REGDET__OLD_O__2B3F6F97");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TmRegdetailOwners)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__TM_REGDET__OWNER__2A4B4B5E");

                entity.HasOne(d => d.Veh)
                    .WithMany(p => p.TmRegdetails)
                    .HasForeignKey(d => d.VehId)
                    .HasConstraintName("FK__TM_REGDET__VEH_I__29572725");
            });

            modelBuilder.Entity<TmUsermaster>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__TM_USERM__B15BE12FCE2A07E3");

                entity.ToTable("TM_USERMASTER");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<TmVehicledetail>(entity =>
            {
                entity.HasKey(e => e.VehId)
                    .HasName("PK__TM_VEHIC__77FCDCC543992B8D");

                entity.ToTable("TM_VEHICLEDETAILS");

                entity.HasIndex(e => e.EngineNo, "UQ__TM_VEHIC__173AC9E3819A11DC")
                    .IsUnique();

                entity.Property(e => e.VehId).HasColumnName("VEH_ID");

                entity.Property(e => e.CuibicCapacity).HasColumnName("CUIBIC_CAPACITY");

                entity.Property(e => e.DateOfManufacture)
                    .HasColumnType("date")
                    .HasColumnName("DATE_OF_MANUFACTURE");

                entity.Property(e => e.EngineNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENGINE_NO");

                entity.Property(e => e.FuelUsed)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FUEL_USED");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MANUFACTURER_NAME");

                entity.Property(e => e.ModelNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MODEL_NO");

                entity.Property(e => e.NoOfCyclinders).HasColumnName("NO_OF_CYCLINDERS");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.VehColor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VEH_COLOR");

                entity.Property(e => e.VehName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VEH_NAME");

                entity.Property(e => e.VehType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VEH_TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
