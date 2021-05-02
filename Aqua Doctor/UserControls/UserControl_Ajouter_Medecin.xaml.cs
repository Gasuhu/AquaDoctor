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
using Aqua_Doctor.TableModel;

namespace Aqua_Doctor.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl_Ajouter_Medecin.xaml
    /// </summary>
    public partial class UserControl_Ajouter_Medecin : UserControl
    {

        public static UserControl_Ajouter_Medecin ajouterMed_Control;

        public UserControl_Ajouter_Medecin()
        {
            InitializeComponent();
            ajouterMed_Control = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteOperation ajouterMedecin = new SQLiteOperation(".\\AquaDB.db"))
            {
                Medecin medecin = new Medecin
                {
                    Nom = NomTextBox.Text,
                    Prenom = PrenomTextBox.Text,
                    Date_Naiss = (DateTime)DateNaissPicker.SelectedDate,
                    Adresse = AdresseTextBox.Text,
                    Num_Tel = PhoneTextBox.Text,
                    Email = MailTextBox.Text,
                    Specialite = SpecialiteCombo.Text,
                    Date_Inscr = DateTime.Now
                };

               
                ajouterMedecin.Insert<Medecin>(medecin);

            }

            



        }

        
    }
}
