﻿using System;
using Istorie.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
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
    /// Interaction logic for ListaIntrebari.xaml
    /// </summary>
    public partial class ListaIntrebari : Window
    {
        public ListaIntrebari()
        {
            InitializeComponent();
            fill();
        }
        List<IntrebareGrila> intrebariGrila = new List<IntrebareGrila>();
        public void fill()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["IstorieAccesDB"].ConnectionString.ToString());
            bool faraProbleme = true;
            try
            {
                conn.Open();
                OleDbCommand comanda = new OleDbCommand("select * from Intrebari", conn);
                OleDbDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    int id =int.Parse( dr[0].ToString());
                    string intrebare = dr[1].ToString();
                    string raspunsuriT = dr[2].ToString();
                    string[] raspunsuri = raspunsuriT.Split(new string[] { "[spatiu]" }, StringSplitOptions.RemoveEmptyEntries);
                    string varianteCorecteT_1 = dr[3].ToString();
                    string[] varianteCorect_1=varianteCorecteT_1.Split(new string[] { "[spatiu]" }, StringSplitOptions.RemoveEmptyEntries);
                    intrebariGrila.Add(new IntrebareGrila(id,intrebare, raspunsuri, varianteCorect_1));
                }
            }
            catch(Exception ex)
            {
                faraProbleme = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            if (faraProbleme)
            {
                //intrebare
                int contor = 0;
                panel_Intrebari.Children.Clear();
                foreach(var grila in intrebariGrila)
                {
                    //INTREBARE
                    Label intrebareTextBox = new Label();
                    intrebareTextBox.Name = "intrebareTextBox_" + contor;
                    intrebareTextBox.IsEnabled = true;
                    intrebareTextBox.BorderThickness = new Thickness(0);
                    intrebareTextBox.Content = grila.Intrebare;
                    intrebareTextBox.Margin = new Thickness(0, 10, 0, 3);
                    intrebareTextBox.Tag = grila;
                    intrebareTextBox.MouseDoubleClick += new MouseButtonEventHandler(intrebare_DoubleClick);
                    panel_Intrebari.Children.Add(intrebareTextBox);

                    //RASPUNSURI
                    int contorRaspunsuri = 0;
                    foreach(var raspuns in grila.getRaspunsuri())
                    {
                        TextBox raspunsuTextBox = new TextBox();
                        raspunsuTextBox.Name = "intrebareTextBox_" + contor+"_"+contorRaspunsuri;
                        raspunsuTextBox.IsEnabled = false;
                        raspunsuTextBox.BorderThickness = new Thickness(0);
                        raspunsuTextBox.Text = raspuns;
                        raspunsuTextBox.Foreground= (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        if (grila.returnECorect(contorRaspunsuri) == true)
                        {
                            raspunsuTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#d2ffc8"));
                        }
                        else
                        {
                            raspunsuTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffd3d3"));
                        }
                        raspunsuTextBox.TextWrapping = TextWrapping.Wrap;
                        raspunsuTextBox.Margin = new Thickness(0, 0, 0, 3);
                        panel_Intrebari.Children.Add(raspunsuTextBox);
                        contorRaspunsuri++;
                    }

                    contor++;
                }
            }
        }
        public void intrebare_DoubleClick(object sender,MouseEventArgs e)
        {
            Label actual = (Label)sender;
            IntrebareGrila grila = (IntrebareGrila)actual.Tag;
            Hide();
            AddEditCerintaGrila form=new AddEditCerintaGrila(grila);
            form.ShowDialog();
            fill();
            ShowDialog();
        }
    }
}
