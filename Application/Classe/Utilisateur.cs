using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Classe
{ //Sérialisation d'un utilisateur.
    [DataContract]
    public class Utilisateur : INotifyPropertyChanged

    {
        private string PNom { get; set; }
        private string PPrenom { get; set; }
        private string PAdresse { get; set; }

        private bool PAdmin { get; set; } = false;
        [DataMember]
        public bool Admin
        {
            get
            {
                return PAdmin;
            }
            set
            {
                PAdmin = value;
                OnPropertyChanged("Admin");
            }
        }
        [DataMember]
        public string Nom
        {
            get
            {
                return PNom;
            }
            set
            {
                PNom = value;
                OnPropertyChanged("Nom");
            }
        }
        [DataMember]
        public string Prenom
        {
            get
            {
                return PPrenom;
            }
            set
            {
                PPrenom = value;
                OnPropertyChanged("Prenom");
            }
        }
        [DataMember]
        public string Adresse
        {
            get
            {
                return PAdresse;
            }
            set
            {
                PAdresse = value;
                OnPropertyChanged("Adresse");
            }
        }
        [DataMember]
        public string Mdp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       


        public override string ToString()
        {
            return $"{Nom} {Prenom} {Adresse} \n ";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Utilisateur other = (Utilisateur)obj;

            if (Nom == other.Nom && Mdp == other.Mdp) { return true; }
            return false;

        }


    }
}
