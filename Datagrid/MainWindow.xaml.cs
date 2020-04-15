using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

		private decimal txtCena;
		public decimal TxtCena 
		{
			get => txtCena; 
			set
			{
				txtCena = value;
				PromenaC?.Invoke(this, new PromeniCenuArgs(txtCena));
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
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

		private void Brisanje(object sender, RoutedEventArgs e)
		{
			if (!lArt.Remove((sender as Button).DataContext as Artikal))
				MessageBox.Show("Brisanje nije moguce!");
		}

		private void ToggleKlik(object sender, RoutedEventArgs e)
		{
			ToggleButton tb = sender as ToggleButton;

			if (tb.IsChecked == true)
			{
				PromenaC += (tb.DataContext as Artikal).PromeniCenu;
			} else
			{
				PromenaC -= (tb.DataContext as Artikal).PromeniCenu;
			}
		}

		public delegate void PromeniCenuHandler(object posiljaoc, PromeniCenuArgs pca);
		public event PromeniCenuHandler PromenaC; 
	}

	public class PromeniCenuArgs
	{
		public decimal Cena;
		public PromeniCenuArgs(decimal d)
		{
			Cena = d;
		}
	}

	public class Artikal : INotifyPropertyChanged
	{
		public string Naziv { get; set; }

		private decimal cena;
		public decimal Cena 
		{
			get => cena;
			set
			{
				cena = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cena"));
			}
		}
		public bool Selektovan { get; set; }
		
		public Artikal(string n, decimal c)
		{
			Naziv = n;
			Cena = c;
		}

		public Artikal() { }

		public event PropertyChangedEventHandler PropertyChanged;

		public void PromeniCenu(object koSalje, PromeniCenuArgs argumenti)
		{
			Cena = argumenti.Cena;
		}
	}

}
