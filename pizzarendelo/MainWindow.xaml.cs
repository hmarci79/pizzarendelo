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

namespace pizzarendelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizza = new List<string>() { "Margherita", "Sonkás", "Hawaii", "Gombás", "Négy sajtos", "Magyaros" };
        Dictionary<string, string> rendeles = new Dictionary<string, string>();
        List<string> folyamatban = new List<string>() {"", "" };

        public MainWindow()
        {
            InitializeComponent();
            lbox_pizzak.ItemsSource = pizza;
            lbox_meretek.ItemsSource = new List<string> { "kicsi", "közepes", "nagy" };
            
        }

        private void lbox_pizzak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pizza = ""+lbox_pizzak.SelectedItem;
            folyamatban[0] = pizza;
            Szovegdoboz();
        }

        private void lbox_meretek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string meret = "" + lbox_meretek.SelectedItem;
            folyamatban[1] = meret;
            Szovegdoboz();
        }

        private void Szovegdoboz()
        {
            if (folyamatban[0] == "")
            {
                tb_rendeles.Text = folyamatban[1];
            }
            else if (folyamatban[1] == "")
            {
                tb_rendeles.Text = folyamatban[0];
            }
            else
            {
                tb_rendeles.Text = folyamatban[0] + " - " + folyamatban[1];
            }
        }

        private void btn_hozzaad_Click(object sender, RoutedEventArgs e)
        {
            rendeles.Add(folyamatban[0], folyamatban[1]);
            tb_rendeles.Text = "";
            Listazas();
        }

        private void Listazas()
        {
            int szamlalo = 0;
            foreach (var item in rendeles)
            {
                grid_rendeles.RowDefinitions.Add(new RowDefinition());
                TextBlock tb = new TextBlock 
                { 
                    Text = item.Key + " - " + item.Value,
                    Margin = new Thickness(0,25,70,0),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 160,
                    TextAlignment = TextAlignment.Center,
                };
                Button btn = new Button
                {
                    Content = "X",
                    Margin = new Thickness(0, 10, 10, 0),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 50,
                    Height = 50,
                };
                grid_rendeles.Children.Add(tb);
                grid_rendeles.Children.Add(btn);
            }
        }
    }
}