using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Classe
{
    //Sérialisaion de la classe Championnat. La classe championnat possède un dictionnaire de classmeent dans lequel on on ajoute un classement avec la méthode "CléeClassement"
    [DataContract]
    public class Championnat : INotifyPropertyChanged
    {
        private string CNom { get; set; }
        [DataMember]
        public string Nom
        {
            get
            {
                return CNom;
            }
            set
            {
                CNom = value;
                OnPropertyChanged("Nom");
            }
        }
        [DataMember]
        public Dictionary<Journee, Classement> DictionnaireClassement { get; set; }

        [DataMember]
        public ObservableCollection<Equipe> LiEquipe { get; private set; }

        public Championnat(string nom)
        {
            this.Nom = nom;
            DictionnaireClassement = new Dictionary<Journee, Classement>();
            LiEquipe = new ObservableCollection<Equipe>();
        }

        public void AjouteEquipe(Equipe e1)
        {
            if (LiEquipe.Contains(e1))
            {

                throw new Exception("Erreur équipe déja existante");
            }
            else
            {
                LiEquipe.Add(e1);


            }
        }

        public void CréeClassement(Journee J1)
        {
            if (DictionnaireClassement.ContainsKey(J1))
            {
                throw new Exception("Journée deja existante pour ce championnat");
            }

            else
            {
                DictionnaireClassement.Add(J1, new Classement(LiEquipe));

            }
        }
        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Championnat other = (Championnat)obj;

            if (this.Nom == other.Nom) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return LiEquipe.Count%31;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}