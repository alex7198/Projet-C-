using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Sérialisation des joueurs.
    [DataContract]
    public class Joueur
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Poste { get; set; }
       
        public Joueur(string Nom, string Prenom, string Poste)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Poste = Poste;
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom} {Poste}";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Joueur other = (Joueur)obj;

            if (this.Nom==other.Nom && this.Prenom==other.Prenom) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
