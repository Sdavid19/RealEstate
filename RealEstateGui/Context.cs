using Jedlik.EntityFramework.Helper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateGui
{
    public class Context: JedlikDbContext
    {
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<Ad> RealEstates { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			string connstring = "Server=localhost;database=ingatlan;uid=root;pwd=;";
			optionsBuilder.UseMySql(connstring, ServerVersion.AutoDetect(connstring));
		}

	}
}
