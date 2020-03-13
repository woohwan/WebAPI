using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class work_apsContext : DbContext
    {

        public work_apsContext(DbContextOptions<work_apsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VCoviGwUser> VCoviGwUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VCoviGwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_covi_gw_user");

                entity.Property(e => e.BirthDay)
                    .HasColumnName("birth_day")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BirthType)
                    .HasColumnName("birth_type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepName).HasColumnName("dep_name");

                entity.Property(e => e.DnCode)
                    .IsRequired()
                    .HasColumnName("dn_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DnName)
                    .HasColumnName("dn_name")
                    .HasMaxLength(200);

                entity.Property(e => e.EMail)
                    .HasColumnName("e_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("emp_name")
                    .HasMaxLength(100);

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnterDate)
                    .HasColumnName("enter_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GrCode)
                    .IsRequired()
                    .HasColumnName("gr_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrName)
                    .HasColumnName("gr_name")
                    .HasMaxLength(200);

                entity.Property(e => e.GrSort)
                    .HasColumnName("gr_sort")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LevelCode)
                    .HasColumnName("level_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelName)
                    .HasColumnName("level_name")
                    .HasMaxLength(200);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobile_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentCode)
                    .HasColumnName("parent_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentName)
                    .HasColumnName("parent_name")
                    .HasMaxLength(200);

                entity.Property(e => e.PositionCode)
                    .HasColumnName("position_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionName)
                    .HasColumnName("position_name")
                    .HasMaxLength(200);

                entity.Property(e => e.RetireDate)
                    .HasColumnName("retire_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasColumnName("tel_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TitleCode)
                    .HasColumnName("title_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TitleName)
                    .HasColumnName("title_name")
                    .HasMaxLength(200);

                entity.Property(e => e.UrCode)
                    .IsRequired()
                    .HasColumnName("ur_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UseYn)
                    .IsRequired()
                    .HasColumnName("use_yn")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
