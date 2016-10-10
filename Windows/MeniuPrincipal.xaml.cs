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
using System.Windows.Shapes;

namespace Istorie.Windows
{
    /// <summary>
    /// Interaction logic for MeniuPrincipal.xaml
    /// </summary>
    public partial class MeniuPrincipal : Window
    {
        public MeniuPrincipal()
        {
            InitializeComponent();
        }

        private void listaIntrebariBttn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ListaIntrebari form = new ListaIntrebari();
            form.ShowDialog();
            Show();
        }
    }
}
