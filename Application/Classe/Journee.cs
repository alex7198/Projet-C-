using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Sérialisation d'une journée. Une journée possède une liste de rencontreSportive.
    [DataContract]
    public class Journee
    {
        [DataMember]
        int numéro;
        [DataMember]
        public List<RencontreSportive> LiRencontreSportive { get; set; }

        public Journee (int numéro)
        {
            LiRencontreSportive = new List<RencontreSportive>();
            this.numéro = numéro;
        }

        public void AjouterRencontreSportive(RencontreSportive rs)
        {
            if (rs == null)
            {
                throw new Exception("Rencontre Sportive fausse");
            }

            if (LiRencontreSportive.Contains(rs))
            {
                throw new Exception("Rencontre déja effectué");
            }

            else
            {
                LiRencontreSportive.Add(rs);
            }
        }

      

        public override string ToString()
        {
            return "Journée n°" + numéro;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Journee other = (Journee)obj;

            if (this.numéro==other.numéro) { return true;}
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
