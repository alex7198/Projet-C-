using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Classe
{
    //Sérialisation de la classe Equipe. Une equipe possède un dictionnaire de commentaire avec comme clé un Utilisateur et comme valeur le commentaire. Elle possède aussi une liste de joueur.
    [DataContract]
    public class Equipe : IComparable<Equipe> 
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public int nbPoints { get; set; }
        [DataMember]
        public List<Joueur> LiJoueur { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        
        [DataMember]

        public Dictionary<Utilisateur, ObservableCollection<Commentaire>> DictionnaireCommentaire { get; private set; }

      


        public Equipe(string nom, string Description)
        {

            if (nom == null)
            {
                throw new Exception("Erreur création équipe");
            }
            this.Nom = nom;
            nbPoints = 0;
            this.Description = Description;
            LiJoueur = new List<Joueur>();
            DictionnaireCommentaire = new Dictionary<Utilisateur, ObservableCollection<Commentaire>>();
        }
        public override int GetHashCode()
        {
            int hash = nbPoints * 31 + Nom.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (obj == null) { return false; }
            if (GetType() != obj.GetType()) { return false; }

            Equipe other = (Equipe)obj;

            if (Nom == other.Nom) { return true; }
            return false;

        }

        public override string ToString()
        {
            string message = "";
            string joueur = "";
            string equipe = "";
            foreach (Utilisateur u in DictionnaireCommentaire.Keys)
            {
                ObservableCollection<Commentaire> liCommentaire = new ObservableCollection<Commentaire>();
                DictionnaireCommentaire.TryGetValue(u, out liCommentaire);
                Console.WriteLine(u.ToString());
                message = message + u.ToString();
                foreach (Commentaire c in liCommentaire)
                {

                   message=message+ "\t \t" +c.ToString() + "\n";
                }
               
            }

            for(int i = 0; i < LiJoueur.Count; i++)
            {
                joueur = joueur + LiJoueur[i].ToString() +"\n";
            }

            equipe = $" { Nom }" + joueur + message;
            return equipe;
        }

        public void AjouterCommentaire(Utilisateur U1, string commentaire)
        {
            if (DictionnaireCommentaire.ContainsKey(U1))
            {
                foreach (Utilisateur u in DictionnaireCommentaire.Keys)
                {
                    if (u.Equals(U1))
                    {
                        ObservableCollection<Commentaire> liCommentaire = new ObservableCollection<Commentaire>();
                        DictionnaireCommentaire.TryGetValue(u, out liCommentaire);
                        liCommentaire.Add(new Commentaire(commentaire));
                    }
                }
            }
            else
            {
                ObservableCollection<Commentaire> liCommentaire = new ObservableCollection<Commentaire>();
                liCommentaire.Add(new Commentaire(commentaire));
                DictionnaireCommentaire.Add(U1, liCommentaire);
            }
        }

          public void ajouterJoueur(Joueur j)
        {
            if (LiJoueur.Contains(j))
            {

                throw new Exception("Joueur déjà existant");
            }
            else
            {
                LiJoueur.Add(j);


            }
        }
        public int CompareTo(Equipe other)
        {
            int compt = other.nbPoints.CompareTo(nbPoints);
            if (compt != 0){return compt;}

            return other.Nom.CompareTo(Nom);
        }

      
    }
}
