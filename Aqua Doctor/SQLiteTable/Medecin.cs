using SQLite;
using System;

namespace Aqua_Doctor
{
    [Table("Medecin")]
    class Medecin  
    {
        

        [PrimaryKey, AutoIncrement]
        public int IdMedecin
        {
            get;
            set;
        }

        [NotNull, MaxLength(30)]
        public string Nom
        {
            get;
            set;
        }

        [NotNull, MaxLength(30)]
        public string Prenom
        {
            get;
            set;
        }

        public DateTime Date_Naiss
        {
            get;
            set;
        }

      

        [MaxLength(12)]
        public string Num_Tel
        {
            get;
            set;
        }

        [MaxLength(30)]
        public string Email
        {
            get;
            set;
        }


        [MaxLength(100)]
        public string Adresse
        {
            get;
            set;
        }

        public string Specialite
        {
            get;
            set;
        }


        public DateTime Date_Inscr
        {
            get;
            set;
        }


        public Medecin()
        {

        }

    }


}
