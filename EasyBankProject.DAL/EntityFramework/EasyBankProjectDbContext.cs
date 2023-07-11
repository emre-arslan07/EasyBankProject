using EasyBankProject.ENTITY.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DAL.EntityFramework
{
    public class EasyBankProjectDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-1F0RU5E; Database = EasyBankDb; uid = admin; pwd = ea01031994;");
        }

        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer)
                .WithMany(y => y.CustomerSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CustomerAccountProcess>()
                .HasOne(x=>x.ReceiverCustomer)
                .WithMany(y=>y.CustomerReceiver)
                .HasForeignKey(z=>z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }

    }
}
