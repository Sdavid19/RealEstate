using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RealEstate.Classes
{
	public class Ad
	{
		public int Area { get; set; }
		public Category Category { get; set; }
		public DateTime CreateAt { get; set; }
		public string Description { get; set; }
		public int Floors { get; set; }
		public bool FreeOfCharge { get; set; }
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public string LatLong { get; set; }
		public int Rooms { get; set; }
		public Seller Seller { get; set; }

		public Ad(string row)
		{
			//id;rooms;latlong;floors;area;description;freeOfCharge;imageUrl;createAt;sellerId;sellerName;sellerPhone;categoryId;categoryName
			string[] data = row.Split(';');
			Id = int.Parse(data[0]);
			Rooms = int.Parse(data[1]);
			LatLong = data[2];
			Floors= int.Parse(data[3]);
			Area = int.Parse(data[4]);
			Description = data[5];
			FreeOfCharge = data[6] == "1";
			ImageUrl = data[7];
			CreateAt = Convert.ToDateTime(data[8]);
			Seller = new Seller() { Id = int.Parse(data[9]), Name = data[10], Phone = data[11] };
			Category = new Category() {Id = int.Parse(data[12]), Name= data[13] };
		}

		public Ad()
		{

		}

		public double DistanceTo(double x, double y)
		{
			double dx = Math.Abs(Convert.ToDouble(this.LatLong.Split(',')[0].Replace('.', ',')) - x);
			double dy = Math.Abs(Convert.ToDouble(this.LatLong.Split(',')[1].Replace('.', ',')) - y);

			return Math.Sqrt(Math.Pow(dx,2) + Math.Pow(dy,2));
		}

		public static IEnumerable<Ad> LoadFromCsv(string fileName)
		{
			List<Ad> data = new List<Ad>();
			foreach (var i in File.ReadLines(fileName).Skip(1))
			{
				yield return new Ad(i);
			}
			
		}
	}
}
