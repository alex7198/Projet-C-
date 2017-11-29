using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{

    //Sérialsiation des Sports. Un sport possède une lsite de championnat, d'actualité.
    [DataContract]
    public class Sport : INotifyPropertyChanged 
    {
        private string nom;

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged(nameof(Nom)); }
        }
        [DataMember]
        public ObservableCollection<Championnat> LiChampionnat { get;set; }

        [DataMember]
        public ObservableCollection<Actualite> LiActualite { get;set; }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public void AjouterActualite(Actualite A1)
        {
            if (A1 == null)
            {
                throw new Exception("Probléme actualite \n");
            }

                LiActualite.Add(A1);
            
        }

        public void AjouterChampionnat(Championnat C1)
        {
            if (C1 == null)
            {
                throw new Exception("Probléme championnat \n");
            }

            if (LiChampionnat.Contains(C1))
            {
                throw new Exception("Championnat déja presente pour ce sport");
            }

            else
            {
                LiChampionnat.Add(C1);
            }
        }

        public override string ToString()
        {
            string Actualite="-------Article(s)------ \n";
            string Championnat = "------Championnat--- \n";
            string Ensemble = "";

            if (LiActualite==null)
            {
                Actualite = $"{Actualite} \n pas d'actualite";
            }
            else
            {
                for (int i = 0; i < LiActualite.Count; i++)
                {
                    Actualite = Actualite + LiActualite[i].ToString() + "\n";
                }
            }

            if (LiChampionnat==null)
            {
                Championnat = $"{Championnat} \n pas d'actualite";
            }
            else
            {
                for (int i = 0; i < LiChampionnat.Count; i++)
                {
                    Championnat = Championnat + LiChampionnat[i].ToString();
                }
            }

            Ensemble = Actualite + Championnat;
            return Ensemble;
        }

        public override int GetHashCode()
        {
            int hash = Nom.GetHashCode() * 31; 
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Sport other = (Sport)obj;

            if (Nom == other.Nom){ return true; }
            return false;

        }
    }

}