using Microsoft.EntityFrameworkCore;
using Spliit.Core.Entities;

namespace Spliit.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Participant> Participants => Set<Participant>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ExpenseDocument> ExpenseDocuments => Set<ExpenseDocument>();
    public DbSet<ExpensePaidFor> ExpensePaidFor => Set<ExpensePaidFor>();
    public DbSet<RecurringExpenseLink> RecurringExpenseLinks => Set<RecurringExpenseLink>();
    public DbSet<Activity> Activities => Set<Activity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.CurrencyCode).HasMaxLength(10);
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.HasOne(e => e.Group).WithMany(g => g.Participants).HasForeignKey(e => e.GroupId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Grouping).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.HasOne(e => e.Group).WithMany(g => g.Expenses).HasForeignKey(e => e.GroupId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.PaidBy).WithMany(p => p.ExpensesPaidBy).HasForeignKey(e => e.PaidById).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Category).WithMany(c => c.Expenses).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ExpenseDocument>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Url).IsRequired().HasMaxLength(500);
            entity.HasOne(e => e.Expense).WithMany(ex => ex.Documents).HasForeignKey(e => e.ExpenseId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExpensePaidFor>(entity =>
        {
            entity.HasKey(e => new { e.ExpenseId, e.ParticipantId });
            entity.HasOne(e => e.Expense).WithMany(ex => ex.PaidFor).HasForeignKey(e => e.ExpenseId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Participant).WithMany(p => p.ExpensesPaidFor).HasForeignKey(e => e.ParticipantId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RecurringExpenseLink>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.CurrentFrameExpense).WithOne(ex => ex.RecurringExpenseLink).HasForeignKey<RecurringExpenseLink>(e => e.CurrentFrameExpenseId).OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(e => e.GroupId);
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Group).WithMany(g => g.Activities).HasForeignKey(e => e.GroupId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
