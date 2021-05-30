using System;
using System.Collections.Generic;
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

namespace Binaris_Jatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        int ossz;
        int szam;

        public MainWindow()
        {
            InitializeComponent();
            javit.IsEnabled = false;
        }

        private void JatekKezdes(object sender, RoutedEventArgs e)
        {
            szam = r.Next(0, 511);

            kerdes.Content = "Hogyan írjuk fel " + szam + "-t binárisan?";
            javit.IsEnabled = true;

            valasz.Content = "";

            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                x.Text = "0";
            }
        }

        private void Segtseg(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Nyomd meg a Kezdés gombot a játék elindításához" + Environment.NewLine +
                "Írj 0-kat vagy 1-eseket a nyégyzetekbe" + Environment.NewLine +
                "Ha 1-est írsz a négyzetbe, az azt az értéket jelöli ami a mező felett van" + Environment.NewLine +
                "Ha 0-t írsz a négyzetbe, akkor a fent lévő érték nem lesz beleszámolva a végeredménybe" + Environment.NewLine +
                "Akárhányszor próbálkozhatsz" + Environment.NewLine +
                "Jó szórakozást és gyakorlást!", "Segítség a játékhoz"
                );
        }

        private void ValaszJavit(object sender, RoutedEventArgs e)
        {
            ossz = 0;

            valasz.Content = "";

            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                if (x.Text == "1")
                {
                    ossz += Convert.ToInt32(x.Tag);
                }

                valasz.Content += x.Text;
            }

            if (ossz == szam)
            {
                javit.IsEnabled = false;
                valasz.Content += " helyes";
                
            }
            else
            {
                valasz.Content += " helytelen";
            }
        }
    }
}   
