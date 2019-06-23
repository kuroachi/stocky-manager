using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockManager.Models.DBModels
{
    public partial class StockyManagerContext : DbContext
    {
        public StockyManagerContext()
        {
        }

        public StockyManagerContext(DbContextOptions<StockyManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyShareType> CompanyShareType { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Shareholder> Shareholder { get; set; }
        public virtual DbSet<ShareholderType> ShareholderType { get; set; }
        public virtual DbSet<ShareType> ShareType { get; set; }
        public virtual DbSet<StockAccount> StockAccount { get; set; }
        public virtual DbSet<StockAccountTransaction> StockAccountTransaction { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=stocky.database.windows.net;Database=StockyManager;Trusted_Connection=False;user Id=tranghht;password=Nagatoyuki7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentSeries)
                    .HasColumnName("Current_Series")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IconImage)
                    .HasColumnName("Icon_Image")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShareValue).HasColumnName("Share_Value");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyShareType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CompanyId, e.ShareTypeId });

                entity.ToTable("Company_ShareType");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShareTypeId)
                    .HasColumnName("Share_TypeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyShareType)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCompany_Sh401975");

                entity.HasOne(d => d.ShareType)
                    .WithMany(p => p.CompanyShareType)
                    .HasForeignKey(d => d.ShareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCompany_Sh176713");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CloseTime).HasColumnType("date");

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("CompanyID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OpenTime).HasColumnType("date");

                entity.Property(e => e.PostMoney).HasColumnName("Post_Money");

                entity.Property(e => e.PreMoney).HasColumnName("Pre_Money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSeries318895");
            });

            modelBuilder.Entity<Shareholder>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("CompanyID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShareholderTypeId)
                    .IsRequired()
                    .HasColumnName("Shareholder_TypeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalShares).HasColumnName("Total_Shares");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Shareholder)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKShareholde957170");

                entity.HasOne(d => d.ShareholderType)
                    .WithMany(p => p.Shareholder)
                    .HasForeignKey(d => d.ShareholderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKShareholde376676");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shareholder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKShareholde190336");
            });

            modelBuilder.Entity<ShareholderType>(entity =>
            {
                entity.ToTable("Shareholder_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShareType>(entity =>
            {
                entity.ToTable("Share_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockAccount>(entity =>
            {
                entity.ToTable("Stock_Account");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentAmount).HasColumnName("Current_Amount");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnName("Expired_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ShareTypeId)
                    .IsRequired()
                    .HasColumnName("Share_TypeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShareholderId)
                    .IsRequired()
                    .HasColumnName("ShareholderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SharesType)
                    .HasColumnName("Shares_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ShareType)
                    .WithMany(p => p.StockAccount)
                    .HasForeignKey(d => d.ShareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStock_Acco982700");

                entity.HasOne(d => d.Shareholder)
                    .WithMany(p => p.StockAccount)
                    .HasForeignKey(d => d.ShareholderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStock_Acco321656");
            });

            modelBuilder.Entity<StockAccountTransaction>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.StockAccountId, e.TransactionId });

                entity.ToTable("StockAccount_Transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StockAccountId)
                    .HasColumnName("StockAccountID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.StockAccount)
                    .WithMany(p => p.StockAccountTransaction)
                    .HasForeignKey(d => d.StockAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStockAccou986030");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.StockAccountTransaction)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStockAccou981930");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SeriesId)
                    .IsRequired()
                    .HasColumnName("SeriesID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SharesQuantity).HasColumnName("Shares_Quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeApprove)
                    .HasColumnName("Time_Approve")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionTime)
                    .HasColumnName("Transaction_Time")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionTypeId)
                    .IsRequired()
                    .HasColumnName("Transaction_TypeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTransactio79882");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTransactio555221");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("Transaction_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("User_Account");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdentifyCardNumber)
                    .HasColumnName("Identify_Card_Number")
                    .HasColumnType("text");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
