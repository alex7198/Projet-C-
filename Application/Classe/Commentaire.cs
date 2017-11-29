using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Sérailisation de la classe Commentaire. Le contenu d'un commentaire est contenu dans un String.
    [DataContract]
    public class Commentaire
    {
        [DataMember (Name = "contenuDuCommentaire")]
        public string Contenu { get; private set; }
        [DataMember]
        public DateTime DateCommentaire { get; set; }
        
        public Commentaire (string Contenu)
        {
            this.Contenu = Contenu;
            DateCommentaire = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Contenu} \n \t Commentaire fais le : {DateCommentaire}";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Commentaire other = (Commentaire)obj;

            if (this.DateCommentaire==other.DateCommentaire && this.Contenu==other.Contenu){ return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
