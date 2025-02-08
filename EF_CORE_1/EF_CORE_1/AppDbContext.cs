using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_CORE_1
{
    internal class AppDbContext : DbContext
	{
		public DbSet<Wallet> wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var constr = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);

        }


    }
}





