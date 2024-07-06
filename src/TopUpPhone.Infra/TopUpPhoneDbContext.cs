using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TopUpPhone.Core.Domain;
using TopUpPhone.Core.Domain.Entities;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Infrastructure;

public class TopUpPhoneDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<TopUpItemEntity> TopUpItems { get; set; }
    public DbSet<BeneficiaryEntity> Beneficiaries { get; set; }

    public TopUpPhoneDbContext(DbContextOptions<TopUpPhoneDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Base>().Property(b => b.Id).IsRequired();
        modelBuilder.Entity<Base>().Property(b => b.CreatedAt);
        modelBuilder.Entity<Base>().Property(b => b.UpdatedAt);

        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.Beneficiaries)
            .WithOne(b => b.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BeneficiaryEntity>()
            .HasOne(b => b.User)
            .WithMany(u => u.Beneficiaries)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TransactionEntity>()
            .HasOne(t => t.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransactionEntity>()
            .HasOne(t => t.Beneficiary)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransactionEntity>()
            .HasOne(t => t.TopUpItem)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data for TopUpItemEntity
        modelBuilder.Entity<TopUpItemEntity>().HasData(
            new TopUpItemEntity { Id = 1, Description = "AED 5", Amount = 5, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 2, Description = "AED 10", Amount = 10, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 3, Description = "AED 20", Amount = 20, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 4, Description = "AED 30", Amount = 30, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 5, Description = "AED 50", Amount = 50, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 6, Description = "AED 75", Amount = 75, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow },
            new TopUpItemEntity { Id = 7, Description = "AED 100", Amount = 100, TransactionFee = 1, Status = Status.Active, CreatedAt = DateTime.UtcNow }
        );
    }
}
