using RealEstate.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Ad> hirdetesek = Ad.LoadFromCsv("realestates.csv").ToList();
			Console.WriteLine($"1. Földszintes ingatlanok átlahos alapterülete: {hirdetesek.Where(x=> x.Floors == 0).Average(x => x.Area):F2} m2");

			var adat = hirdetesek.Where(x => x.FreeOfCharge).OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).First();
			Console.WriteLine("2. Mesevár óvodához legközelebbi tehermentes ingatlan adatai:");
			Console.WriteLine($"\tEladó neve\t: {adat.Seller.Name}");
			Console.WriteLine($"\tEladó telefonja\t: {adat.Seller.Phone}");
			Console.WriteLine($"\tAlapterület\t: {adat.Area}");
			Console.WriteLine($"\tSzobák száma\t: {adat.Rooms}");

			Console.ReadLine();
		}
	}
}
