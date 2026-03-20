using System.Collections.ObjectModel;
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

namespace databaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// using System.Collections.ObjectModel;

    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    namespace EvidenceFilmu
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<Film> Filmy { get; set; }

            public MainWindow()
            {
                InitializeComponent();
                Filmy = new ObservableCollection<Film>()
            {
                new Film { Id = 1, Nazev = "Mean Girls", Reziser = "Mark Waters", RokVydani = 2004, Zanr = "Komedie", Hodnoceni = 8, VidelaJsem = true },
                new Film { Id = 2, Nazev = "Clueless", Reziser = "Amy Heckerling", RokVydani = 1995, Zanr = "Romantika", Hodnoceni = 7, VidelaJsem = true }
            };
                dgFilmy.ItemsSource = Filmy;
            }

            private void BtnPridat_Click(object sender, RoutedEventArgs e)
            {
                if (!Validace()) return;

                Film novy = new Film()
                {
                    Id = Filmy.Count + 1,
                    Nazev = txtNazev.Text,
                    Reziser = txtReziser.Text,
                    RokVydani = int.Parse(txtRok.Text),
                    Zanr = txtZanr.Text,
                    Hodnoceni = int.Parse(txtHodnoceni.Text),
                    VidelaJsem = chkVidela.IsChecked == true
                };

                Filmy.Add(novy);
                VymazFormular();
            }

            private void BtnNacist_Click(object sender, RoutedEventArgs e)
            {
                if (dgFilmy.SelectedItem is Film f)
                {
                    txtNazev.Text = f.Nazev;
                    txtReziser.Text = f.Reziser;
                    txtRok.Text = f.RokVydani.ToString();
                    txtZanr.Text = f.Zanr;
                    txtHodnoceni.Text = f.Hodnoceni.ToString();
                    chkVidela.IsChecked = f.VidelaJsem;
                }
            }

            private void BtnUpravit_Click(object sender, RoutedEventArgs e)
            {
                if (dgFilmy.SelectedItem is Film f)
                {
                    if (!Validace()) return;

                    f.Nazev = txtNazev.Text;
                    f.Reziser = txtReziser.Text;
                    f.RokVydani = int.Parse(txtRok.Text);
                    f.Zanr = txtZanr.Text;
                    f.Hodnoceni = int.Parse(txtHodnoceni.Text);
                    f.VidelaJsem = chkVidela.IsChecked == true;

                    dgFilmy.Items.Refresh();
                    VymazFormular();
                }
            }

            private void BtnSmazat_Click(object sender, RoutedEventArgs e)
            {
                if (dgFilmy.SelectedItem is Film f)
                {
                    if (MessageBox.Show("Opravdu smazat?", "Potvrzení", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Filmy.Remove(f);
                    }
                }
            }

            private void BtnVymaz_Click(object sender, RoutedEventArgs e)
            {
                VymazFormular();
            }

            private void VymazFormular()
            {
                txtNazev.Text = "";
                txtReziser.Text = "";
                txtRok.Text = "";
                txtZanr.Text = "";
                txtHodnoceni.Text = "";
                chkVidela.IsChecked = false;
            }

            private bool Validace()
            {
                if (string.IsNullOrWhiteSpace(txtNazev.Text))
                {
                    MessageBox.Show("Zadej název filmu");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtReziser.Text))
                {
                    MessageBox.Show("Zadej režiséra");
                    return false;
                }

                if (!int.TryParse(txtRok.Text, out int rok) || rok < 1900 || rok > DateTime.Now.Year)
                {
                    MessageBox.Show("Neplatný rok");
                    return false;
                }

                if (!int.TryParse(txtHodnoceni.Text, out int hodnoceni) || hodnoceni < 1 || hodnoceni > 10)
                {
                    MessageBox.Show("Hodnocení 1–10");
                    return false;
                }

                return true;
            }

            private void TxtHledat_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
            {
                string text = txtHledat.Text.ToLower();
                dgFilmy.ItemsSource = Filmy.Where(f => f.Nazev.ToLower().Contains(text));
            }
        }
    }
}
