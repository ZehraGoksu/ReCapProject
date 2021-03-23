using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class CarContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Slq kullanıcam ve nasıl bağlanmam gerektiğine belirticem
			//Normalde içerisine id adresi verilir ama biz developmetn adresini veriyoruz kendi sqlimizin ismi
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCap;Trusted_Connection=true");
			//Trusted_connection = kullanıcı adı şifre gerektirmeden bağlanma
		}


		//hangi tablo neye karşılık gelicek nerde diye bildirdik çünlü artık veritabanına bağlandı (Entities'dekiler )
		public DbSet<Car> Cars { get; set; }

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Color> Colors { get; set; }
	}
}
