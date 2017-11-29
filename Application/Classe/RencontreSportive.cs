using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{ //Sérialisation d'une rencontre sportive. On ajoute les points aux équipes dans le constructeur de rencontreSportive en fonction de leur Nom.
    [DataContract]
    public class RencontreSportive
    {
        [DataMember]
        public DateTime DateRencontre { get; private set; }
        [DataMember]
        public int ScoreE1 { get; private set; }
        [DataMember]
        public int ScoreE2 { get; private set; }
        [DataMember]
        public Equipe Equipe1 { get; private set; }
        [DataMember]
        public Equipe Equipe2 { get; private set; }

        public RencontreSportive(Sport sport, Championnat C1 ,Equipe e1, Equipe e2, int ScoreE1, int ScoreE2)
        {
            
            if(e1==null || e2 == null)
            {
                throw new Exception("Erreur avec une équipe pendant la rencontre");
            }


            if (C1.LiEquipe.Contains(e1) && C1.LiEquipe.Contains(e2))
            {
                this.DateRencontre = DateTime.Now;
                this.Equipe1 = e1;
                this.Equipe2 = e2;
                this.ScoreE1 = ScoreE1;
                this.ScoreE2 = ScoreE2;

              
                if (ScoreE1 == ScoreE2)
                {
                    e1.nbPoints += 1;
                    e2.nbPoints += 1;
                }

                if ( ScoreE1 > ScoreE2)
                {
                    e1.nbPoints += 3;
                }

                if (ScoreE1 < ScoreE2)
                {
                    e2.nbPoints += 3;
                }
            }

            else
            {
                throw new Exception("Les équipes ne font pas partis du méme championnat");
            }
        }
        public override string ToString()
        {
            return $"{Equipe1.Nom} : {ScoreE1} - {ScoreE2} : {Equipe2.Nom} \n";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            RencontreSportive other = (RencontreSportive)obj;

            if (this.Equipe1==other.Equipe1 && this.Equipe2==other.Equipe2) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
