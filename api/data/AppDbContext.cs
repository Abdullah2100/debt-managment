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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne<User>(us => us.User)
                .WithOne()
                .HasForeignKey<Employee>(us => us.UserId)
                .HasPrincipalKey<User>(us => us.Id);

            entity.HasMany<Store>(us => us.Stores)
                .WithMany(us => us.Employees);

            entity.HasMany<Debt>(us => us.Debts)
                .WithOne()
                .HasForeignKey(d => d.AddedBy)
                .HasPrincipalKey(e => e.Id);

            entity.HasMany<RePayment>(us => us.RePayments)
                .WithOne()
                .HasForeignKey(d => d.AddedBy)
                .HasPrincipalKey(e => e.Id);
            ;
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasOne<User>(s => s.User)
                .WithOne()
                .HasForeignKey<Store>(s => s.OwnerUesrId)
                .HasPrincipalKey<User>(u => u.Id);
        });


        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasOne<Employee>(us => us.EditByEmployee)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.EditBy)
                .HasPrincipalKey<Employee>(e=> e.Id);

            entity.HasOne<Store>(us => us.Store)
                .WithMany()
                .HasForeignKey(us => us.StoreId);
        });


        base.OnModelCreating(modelBuilder);
    }
}