
using System.Collections.ObjectModel;
using Aqua_Doctor.TableModel;

namespace Aqua_Doctor.ViewModels
{
    interface IMedecinDetailsViewModel
    {
        ObservableCollection<MedecinModel> LstMedecin { get; set; }
    }
}
