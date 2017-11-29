using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Sérialisation de la classe.
    [DataContract]
    public  class Actualite : INotifyPropertyChanged
    {
        private string ATitre { get; set; }
        private DateTime ADateArticle { get; set; }
        private string ADescritpion { get;set; }


        [DataMember]
        public string Titre
        {
            get
            {
                return ATitre;
            }
            set
            {
                ATitre = value;
                OnPropertyChanged("Titre");
            }
        }
        [DataMember]
        public DateTime DateArticle
        {
            get
            {
                return ADateArticle;
            }
            set
            {
                ADateArticle = value;
                OnPropertyChanged("DateArticle");
            }
        }
        [DataMember]
        public string Descritpion
        {
            get
            {
                return ADescritpion;
            }
            set
            {
                ADescritpion = value;
                OnPropertyChanged("Descritpion");
            }
        }
    

        public Actualite(string titre, string descri)
        {
            this.Titre = titre;
            DateArticle = DateTime.Now;
            this.Descritpion = descri;
      

        }
        public override string ToString()
        {
            return $"{Titre} \n \t {Descritpion} \n \t\t\t\t {DateArticle} ";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Actualite other = (Actualite)obj;

            if (this.Titre==other.Titre) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
