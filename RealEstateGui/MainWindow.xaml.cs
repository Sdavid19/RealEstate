using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using RealEstate.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateGui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		Context ctx = new Context();

		public MainWindow()
		{
			InitializeComponent();
			ctx.Sellers.Load();
			ctx.RealEstates.Load();
			Seller.ItemsSource = ctx.Sellers.Local.ToObservableCollection();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var ads = ctx.RealEstates.Local.ToObservableCollection();
			int AdCount = ads.Where(x=>x.Seller.Id == (Seller.SelectedItem as Seller).Id).Count();
			AdCountLbl.Content = AdCount.ToString();
		}
	}
}
