
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models.Entities;
using System.Reflection;


namespace Persistence
{
    public class PersonalBankAccountManagerDBContext : IdentityDbContext<User, Role, Guid>
    {
        public PersonalBankAccountManagerDBContext()
        {

        }
        public PersonalBankAccountManagerDBContext(
            DbContextOptions<PersonalBankAccountManagerDBContext> dbContext) :
            base(dbContext)
        {

        }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionPlan> TransactionPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Picture> Pictures   { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bank>  Banks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BankAccountManager;TrustServerCertificate=True;Integrated Security=SSPI");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

