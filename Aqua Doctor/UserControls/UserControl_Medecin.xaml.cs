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
using System.Data.SQLite;
using System.Data;
using Aqua_Doctor.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Aqua_Doctor.TableModel;




namespace Aqua_Doctor.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl_Medecin.xaml
    /// </summary>
    public partial class UserControl_Medecin : UserControl
    {
        MedecinDetailsViewModel viewModel;
        public UserControl_Medecin()
        {
            InitializeComponent();
            viewModel = new MedecinDetailsViewModel();
            DataContext = viewModel;
            
            
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._obj.MainGrid.Children.Clear();
            MainWindow._obj.MainGrid.Children.Add(new UserControl_Ajouter_Medecin());
            MainWindow._obj.ButtonGoBack.Visibility = Visibility.Visible;
            MainWindow._obj.MenuTextBlock.Text = "Ajouter Patient";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;


            foreach(MedecinModel medecin in viewModel.LstMedecin)
            {
                if (medecin.IsSelected)
                {
                    i++;
                }
            }

            if(i==0)
            {
                MessageBox.Show("Veuillez selectionner les medecins a supprimer");
            } else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure? you want to delete " + i + " Rows ?", "Delete Confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {

                    using (SQLiteOperation sQLiteOperation = new SQLiteOperation(".\\AquaDB.db"))
                    {
                        foreach (MedecinModel medecin in viewModel.LstMedecin)
                        {
                            if (medecin.IsSelected)
                            {
                                Medecin medecinRow = new Medecin
                                {
                                    IdMedecin = medecin.IdMedecin
                                };

                                sQLiteOperation.Delete<Medecin>(medecinRow);
                                DataContext = new MedecinDetailsViewModel();
                            }
                        }
                    }

                }
            }

            
        }
    }
}
