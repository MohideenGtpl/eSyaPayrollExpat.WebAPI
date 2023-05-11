﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaPayrollExpat.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcbsln> GtEcbsln { get; set; }
        public virtual DbSet<GtEcbssg> GtEcbssg { get; set; }
        public virtual DbSet<GtEccncd> GtEccncd { get; set; }
        public virtual DbSet<GtEccuco> GtEccuco { get; set; }
        public virtual DbSet<GtIfcrer> GtIfcrer { get; set; }
        public virtual DbSet<GtPyexar> GtPyexar { get; set; }
        public virtual DbSet<GtPyexbc> GtPyexbc { get; set; }
        public virtual DbSet<GtPyexbd> GtPyexbd { get; set; }
        public virtual DbSet<GtPyexbm> GtPyexbm { get; set; }
        public virtual DbSet<GtPyexce> GtPyexce { get; set; }
        public virtual DbSet<GtPyexcj> GtPyexcj { get; set; }
        public virtual DbSet<GtPyexem> GtPyexem { get; set; }
        public virtual DbSet<GtPyexfd> GtPyexfd { get; set; }
        public virtual DbSet<GtPyexpb> GtPyexpb { get; set; }
        public virtual DbSet<GtPyexpi> GtPyexpi { get; set; }
        public virtual DbSet<GtPyexpp> GtPyexpp { get; set; }
        public virtual DbSet<GtPyexps> GtPyexps { get; set; }
        public virtual DbSet<GtPyexsb> GtPyexsb { get; set; }
        public virtual DbSet<GtPyexsi> GtPyexsi { get; set; }
        public virtual DbSet<GtPyexta> GtPyexta { get; set; }
        public virtual DbSet<GtPyexva> GtPyexva { get; set; }
        public virtual DbSet<GtPyexvi> GtPyexvi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);
            });

            modelBuilder.Entity<GtEcbsln>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId, e.LocationId });

                entity.ToTable("GT_ECBSLN");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_GT_ECBSLN")
                    .IsUnique();

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EActiveUsers)
                    .IsRequired()
                    .HasColumnName("eActiveUsers");

                entity.Property(e => e.EBusinessKey)
                    .IsRequired()
                    .HasColumnName("eBusinessKey");

                entity.Property(e => e.ESyaLicenseType)
                    .IsRequired()
                    .HasColumnName("eSyaLicenseType")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EUserLicenses)
                    .IsRequired()
                    .HasColumnName("eUserLicenses");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TocurrConversion).HasColumnName("TOCurrConversion");

                entity.Property(e => e.TolocalCurrency)
                    .IsRequired()
                    .HasColumnName("TOLocalCurrency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TorealCurrency).HasColumnName("TORealCurrency");

                entity.HasOne(d => d.GtEcbssg)
                    .WithMany(p => p.GtEcbsln)
                    .HasForeignKey(d => new { d.BusinessId, d.SegmentId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECBSLN_GT_ECBSSG");
            });

            modelBuilder.Entity<GtEcbssg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId });

                entity.ToTable("GT_ECBSSG");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OrgnDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegmentDesc)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<GtEccncd>(entity =>
            {
                entity.HasKey(e => e.Isdcode);

                entity.ToTable("GT_ECCNCD");

                entity.Property(e => e.Isdcode)
                    .HasColumnName("ISDCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CountryFlag)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsPinapplicable).HasColumnName("IsPINApplicable");

                entity.Property(e => e.IsPoboxApplicable).HasColumnName("IsPOBoxApplicable");

                entity.Property(e => e.MobileNumberPattern)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.PincodePattern)
                    .HasColumnName("PINcodePattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PoboxPattern)
                    .HasColumnName("POBoxPattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Uidlabel)
                    .HasColumnName("UIDLabel")
                    .HasMaxLength(50);

                entity.Property(e => e.Uidpattern)
                    .HasColumnName("UIDPattern")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GtEccuco>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.ToTable("GT_ECCUCO");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DecimalPlaces).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.DecimalPortionWord).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GtIfcrer>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.CurrencyCode, e.DateOfExchangeRate });

                entity.ToTable("GT_IFCRER");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfExchangeRate).HasColumnType("datetime");

                entity.Property(e => e.BuyingLastVoucherDate).HasColumnType("datetime");

                entity.Property(e => e.BuyingRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SellingLastVoucherDate).HasColumnType("datetime");

                entity.Property(e => e.SellingRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StandardRate).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<GtPyexar>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod, e.PaidPeriod });

                entity.ToTable("GT_PYEXAR");

                entity.Property(e => e.PaidPeriod).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ArrearDays).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexbc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BankCode, e.BankCurrency });

                entity.ToTable("GT_PYEXBC");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankCurrency).HasMaxLength(4);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexbd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.SerialNumber });

                entity.ToTable("GT_PYEXBD");

                entity.Property(e => e.AccountHolderName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankAddress).HasMaxLength(150);

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankCurrency)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BankRemittance)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryAddress).HasMaxLength(150);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName).HasMaxLength(100);

                entity.Property(e => e.CorrespondingBankAccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorrespondingBankAddress).HasMaxLength(150);

                entity.Property(e => e.CorrespondingBankName).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Swiftcode)
                    .HasColumnName("SWIFTCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexbm>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BankCode });

                entity.ToTable("GT_PYEXBM");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankCharges).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.BranchAddress).HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexce>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.PayPeriod, e.CurrencyCode });

                entity.ToTable("GT_PYEXCE");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexcj>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.FromDate });

                entity.ToTable("GT_PYEXCJ");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.AdministrativeReportingTo).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionalReportingTo).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtPyexem>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber });

                entity.ToTable("GT_PYEXEM");

                entity.Property(e => e.BiometricId)
                    .HasColumnName("BiometricID")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfConfirmation).HasColumnType("date");

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.DateOfRelieving).HasColumnType("date");

                entity.Property(e => e.DateOfResignation).HasColumnType("date");

                entity.Property(e => e.DateOfTermination).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(15);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.EmployeeStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.TerminationReason).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexfd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.FixedDeductionId });

                entity.ToTable("GT_PYEXFD");

                entity.Property(e => e.FixedDeductionId).HasColumnName("FixedDeductionID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeductionDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FixedDeductionType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NoOfinstallment).HasColumnName("NoOFInstallment");

                entity.Property(e => e.PaidAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ReferenceDetail).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexpb>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod, e.SerialNumber });

                entity.ToTable("GT_PYEXPB");

                entity.Property(e => e.AccountHolderName).HasMaxLength(100);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankAddress).HasMaxLength(150);

                entity.Property(e => e.BankCharges).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankCurrency)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BankRemittance)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryAddress).HasMaxLength(150);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName).HasMaxLength(100);

                entity.Property(e => e.CorrespondingBankAccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorrespondingBankAddress).HasMaxLength(150);

                entity.Property(e => e.CorrespondingBankName).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalCurrencyAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OrgBankCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrgBankDate).HasColumnType("datetime");

                entity.Property(e => e.SalaryCurrencyAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Swiftcode)
                    .HasColumnName("SWIFTCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexpi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PermanentOrCurrent });

                entity.ToTable("GT_PYEXPI");

                entity.Property(e => e.PermanentOrCurrent)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LandLineNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexpp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.PayPeriod });

                entity.ToTable("GT_PYEXPP");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexps>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod });

                entity.ToTable("GT_PYEXPS");

                entity.Property(e => e.AdvanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AmountInLocalCurrency).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AttendanceFactor).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.BankCharges).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Bcdebit).HasColumnName("BCDebit");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NetSalaryAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Nhifamount)
                    .HasColumnName("NHIFAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Nssfamount)
                    .HasColumnName("NSSFAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ProcessedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.SalaryAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryCurrency)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.VariableIncentiveAmount).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtPyexsb>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.SerialNumber });

                entity.ToTable("GT_PYEXSB");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PaymentAmountBySalaryCurrency).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PaymentByCurrency)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.TransferTo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtPyexsi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber });

                entity.ToTable("GT_PYEXSI");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsNhifapplicable).HasColumnName("IsNHIFApplicable");

                entity.Property(e => e.IsNssfapplicable).HasColumnName("IsNSSFApplicable");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Nhifamount)
                    .HasColumnName("NHIFAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Nssfamount)
                    .HasColumnName("NSSFAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryCurrency)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GtPyexta>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod });

                entity.ToTable("GT_PYEXTA");

                entity.Property(e => e.ArrearDays).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AttendanceFactor).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.AttendedDays).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lopdays)
                    .HasColumnName("LOPDays")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.VacationDays).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VacationPayPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VaccationPayDays).HasColumnType("decimal(9, 6)");
            });

            modelBuilder.Entity<GtPyexva>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod });

                entity.ToTable("GT_PYEXVA");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SalaryAdvance).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtPyexvi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.EmployeeNumber, e.PayPeriod });

                entity.ToTable("GT_PYEXVI");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.VariableIncentiveAmount).HasColumnType("decimal(18, 6)");
            });
        }
    }
}
