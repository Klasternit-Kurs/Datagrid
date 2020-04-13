using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datagrid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> lArt = new ObservableCollection<Artikal>();


		public MainWindow()
		{
			InitializeComponent();

			/*Artikal a = new Artikal();
			a.Naziv = "Nesto";
			a.Cena = 5;
			lArt.Add(a);


			a = new Artikal();
			a.Naziv = "Nesto drugo";
			a.Cena = 20;
			lArt.Add(a);*/

			dg.ItemsSource = lArt;

			lArt.Add(new Artikal("Nesto", 5));
			lArt.Add(new Artikal("Nesto drugo", 20));
			lArt.Add(new Artikal("Plazam", 200));
		}

		private void Cekirano(object sender, RoutedEventArgs e)
		{
			lArt.Remove((sender as Button).DataContext as Artikal);
		}
	}

	public class Artikal
	{
		public string Naziv { get; set; }
		public decimal Cena { get; set; }
		public bool Selektovan { get; set; }
		
		public Artikal(string n, decimal c)
		{
			Naziv = n;
			Cena = c;
		}

		public Artikal() { }
	}

}
