using System;
using Istorie.Utils;
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
#pragma warning disable CS0105 // Using directive appeared previously in this namespace
using System.Linq;
#pragma warning restore CS0105 // Using directive appeared previously in this namespace
namespace Istorie.Windows
{
    /// <summary>
    /// Interaction logic for AddEditCerintaGrila.xaml
    /// </summary>
    public partial class AddEditCerintaGrila : Window
    {
        public int raspunsuri = 4;
        public AddEditCerintaGrila()
        {
            InitializeComponent();
        }
        public AddEditCerintaGrila(IntrebareGrila grila)
        {
            InitializeComponent();
            intrebare.Text = grila.Intrebare;


        }
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (raspunsuri == 20)
            {
                MessageBox.Show("Numarul maxim de intrebari este 20.");
                return;
            }
            raspunsuri++;
            //Grid
            Grid newGrid = new Grid();
            newGrid.Margin = new Thickness(0, 10, 0, 1);
            newGrid.Name = "grid_intrebarea_" + raspunsuri;
            //Label
            Label newLabel = new Label();
            newLabel.Name = "label_intrebarea_" + raspunsuri;
            newLabel.Margin = new Thickness(0, 0, 20, 0);
            newLabel.Content = "#" + raspunsuri;
            newGrid.Children.Add(newLabel);
            //TextBox
            TextBox newTextBox = new TextBox();
            newTextBox.Name = "intrebarea_" + raspunsuri;
            newTextBox.Margin = new Thickness(30, 0, 0, 0);
            newTextBox.Width = 280;
            newTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            newGrid.Children.Add(newTextBox);
            //CheckBox
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = "checkBox_" + raspunsuri;
            newCheckBox.Margin = new Thickness(330, 0, 0, 0);
            newCheckBox.VerticalAlignment = VerticalAlignment.Center;
            newCheckBox.Content = "Raspuns corect";
            newGrid.Children.Add(newCheckBox);

            stack_raspunsuri.Children.Add(newGrid);

        }

        private void detele_button_Click(object sender, RoutedEventArgs e)
        {
            if (raspunsuri == 4)
            {
                MessageBox.Show("Numarul minim de raspunsuri este 4.");
                return;
            }
            else
            {
                //De perfectionat 
                foreach (var children in stack_raspunsuri.Children.OfType<Grid>())
                {
                    if (children.Name == "grid_intrebarea_" + raspunsuri)
                    {
                        stack_raspunsuri.Children.Remove(children);
                        break;
                    }
                }
                raspunsuri--;
            }
        }

    }
}
