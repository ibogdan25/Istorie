using Istorie.Utils;
using Istorie.Windows;
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
using System.Data.OleDb;
using System.Configuration;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            SystemDeOperare.GetOS();
            //MessageBox.Show(Environment.OSVersion.ToString());
        }

        private void connect_bttn_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["IstorieAccesDB"].ConnectionString.ToString());
            try
            {
                conn.Open();
                OleDbCommand comanda = new OleDbCommand("select count(*) from Utilizatori where Nume_user=@nume and Pass_user=@parola ",conn);
                comanda.Parameters.AddWithValue("@nume", numeUtilizator.Text);
                comanda.Parameters.AddWithValue("@parola", parolaUtilizator.Text);
                int exista= int.Parse(comanda.ExecuteScalar().ToString());
                if (exista > 0)
                {
                    MeniuPrincipal form = new MeniuPrincipal();
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else {
                    MessageBox.Show("Parola sau nume gresit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}
