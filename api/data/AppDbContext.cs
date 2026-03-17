using System.Reflection.Emit;
using data.Entity;
using Microsoft.EntityFrameworkCore;

namespace data;

public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<RePayment> RePayments { get; set; }
    public DbSet<BlockedStoreEmployeeUser> StoreBlockedEmployee { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasOne(us => us.Employee)
                .WithOne(us => us.User)
                .HasForeignKey<Employee>(em => em.UserId);

            user.HasOne(us => us.StoreEmployeeUser)
                .WithOne(seu => seu.User)
                .HasForeignKey<StoreEmployeeUser>(seu => seu.UserId);

            user.HasMany(us => us.MyRepayment)
                .WithOne(rp => rp.RePaymentBy)
                .HasForeignKey(rp => rp.RePaymentUserId);

            user.HasMany(us => us.MyDebts)
                .WithOne(d => d.DebtBy)
                .HasForeignKey(d => d.DebtUserId);
        });

        modelBuilder.Entity<Debt>(debt =>
        {
            debt.HasOne(d => d.DebtBy)
                .WithMany(u => u.MyDebts)
                .HasForeignKey(d => d.DebtUserId);

            debt.HasOne(d => d.StoreEmployeeUser)
                .WithMany(seu => seu.StoreDebt)
                .HasForeignKey(d => d.OperatedByStoreEmployeeUserId);

            debt.HasOne(d => d.Store)
                .WithMany(s => s.StoreDebt)
                .HasForeignKey(d => d.StoreId);
        });

        modelBuilder.Entity<RePayment>(repayment =>
        {
            repayment.HasOne(rp => rp.RePaymentBy)
                .WithMany(u => u.MyRepayment)
                .HasForeignKey(rp => rp.RePaymentUserId);

            repayment.HasOne(rp => rp.StoreEmployeeUser)
                .WithMany(seu => seu.StoreRepayment)
                .HasForeignKey(rp => rp.OperatedByStoreEmployeeUserId);

            repayment.HasOne(rp => rp.Store)
                .WithMany(s => s.StoreRepayment)
                .HasForeignKey(rp => rp.StoreId);
        });

        modelBuilder.Entity<Store>(store =>
        {
            store.HasMany(st => st.EmployeeUsersStore)
                .WithOne(seu => seu.Store)
                .HasForeignKey(seu => seu.StoreId);

            store.HasMany(st => st.BlockedEmployeeUsersStore)
                .WithOne(bse => bse.Store)
                .HasForeignKey(bse => bse.StoreId);
        });

        modelBuilder.Entity<StoreEmployeeUser>(storeEmployeeUser =>
        {
            storeEmployeeUser.HasMany(seu => seu.StoreRepayment)
                .WithOne(rp => rp.StoreEmployeeUser)
                .HasForeignKey(rp => rp.OperatedByStoreEmployeeUserId);
        });

        modelBuilder.Entity<BlockedStoreEmployeeUser>(blocked =>
        {
            blocked.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            blocked.HasOne(b => b.Store)
                .WithMany(s => s.BlockedEmployeeUsersStore)
                .HasForeignKey(b => b.StoreId);
        });

        modelBuilder.Entity<Transaction>(transaction =>
        {
            transaction.HasOne(t => t.StoreEmployeeUser)
                .WithMany(seu => seu.StoreOperationTransactions)
                .HasForeignKey(t => t.CreatedById);

            transaction.HasOne(t => t.Store)
                .WithMany(s => s.StoreTransactions)
                .HasForeignKey(t => t.StoreId);
        });

        base.OnModelCreating(modelBuilder);
    }
}