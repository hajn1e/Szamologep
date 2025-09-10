using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double elsoSzam = 0;
        public string muvelet = "";
        private bool ujBevitel;
        public bool ujBetivel = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Szam_Click(object sender, RoutedEventArgs e)
        {
            var gomb = (Button)sender;
            var szam = gomb.Content.ToString();

            if (Kijelzo.Text == "0" || ujBetivel)
            {
                Kijelzo.Text = szam;
                ujBetivel = false;
            }
            else
            {
                Kijelzo.Text += szam;
            }
        }

        private void Muvelet_Click(object sender, RoutedEventArgs e)
        {
            var gomb = (Button)sender;
            elsoSzam = double.Parse(Kijelzo.Text);
            muvelet = gomb.Content.ToString();
            ujBevitel = true;
        }

        private void Egyenlo_Click(object sender, RoutedEventArgs e)
        {
            var masodikSzam = double.Parse(Kijelzo.Text);
            double eredmeny = 0;

            switch (muvelet)
            {
                case "+":
                    eredmeny = elsoSzam + masodikSzam;
                    break;
                case "-":
                    eredmeny = elsoSzam - masodikSzam;
                    break;
                case "*":
                    eredmeny = elsoSzam * masodikSzam;
                    break;
                case "/":
                    if (masodikSzam != 0)
                    {
                        eredmeny = elsoSzam / masodikSzam;
                    }
                    else
                    {
                        MessageBox.Show("Nullával nem lehet osztani");
                        return;
                    }
                    break;
            }
            Kijelzo.Text = eredmeny.ToString();
            ujBevitel = true;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Kijelzo.Text = "0";
            elsoSzam = 0;
            muvelet = "";
            ujBevitel = false;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Kijelzo.Text = "0";
            ujBevitel = true;
        }

        private void BackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (ujBevitel) return;
            if (Kijelzo.Text.Length > 1)
                Kijelzo.Text = Kijelzo.Text[..^1];
            else
                Kijelzo.Text = "0";
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Kijelzo.Text.StartsWith("-"))
                Kijelzo.Text = Kijelzo.Text[1..];
            else if (Kijelzo.Text != "0")
                Kijelzo.Text = "-" + Kijelzo.Text;
        }

        private void Pont_Click(object sender, RoutedEventArgs e)
        {
            var sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (ujBevitel)
            {
                Kijelzo.Text = "0" + sep;
                ujBevitel = false;
            }
            else if (!Kijelzo.Text.Contains(sep))
            {
                Kijelzo.Text += sep;
            }
        }
    }
}