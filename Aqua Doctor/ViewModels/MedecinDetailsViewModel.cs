using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Aqua_Doctor.TableModel;
using System.Collections.ObjectModel;
using Aqua_Doctor;
using System.Windows.Data;
using System.ComponentModel;
using Prism.Mvvm;
using System.Configuration;

namespace Aqua_Doctor.ViewModels
{
    class MedecinDetailsViewModel : BindableBase ,IMedecinDetailsViewModel
    {
        public MedecinDetailsViewModel()
        {
            using (var sQLiteOperation = new SQLiteOperation(".\\AquaDB.db"))
            {
                sQLiteOperation.Get<Medecin>().ForEach(med =>
                {
                    var medecin = new MedecinModel
                    {
                        IdMedecin = med.IdMedecin,
                        Nom = med.Nom,
                        Prenom = med.Prenom,
                        Date_Naiss = med.Date_Naiss.ToShortDateString(),
                        Adresse = med.Adresse,
                        Num_Tel = med.Num_Tel,
                        Email = med.Email,
                        Specialite = med.Specialite,
                        Date_Inscr = med.Date_Inscr.ToShortDateString(),
                        IsSelected = false
                    };

                    

                    LstMedecin.Add(medecin);
                });

            }

            

        }

        private ObservableCollection<MedecinModel> _lstmedecin = new ObservableCollection<MedecinModel>();

        public ObservableCollection<MedecinModel> LstMedecin
        {
            get { return _lstmedecin; }
            set { SetProperty(ref _lstmedecin, value); }
        }
    }
}
