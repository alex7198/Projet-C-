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
    //Sérialsiation de la classe Classement. On effectue un tri sur la liste d'équipe en fonction du nb de points de chaque équipes pour faire le classement.
    [DataContract]
    public class Classement 
    {
        [DataMember]
        private ObservableCollection<Equipe> _liEquipe;
        [DataMember]
        public ObservableCollection<Equipe> LiEquipe { 
            get
            {
                List<Equipe> liequipe= _liEquipe.ToList();
                liequipe.Sort();
                return new ObservableCollection<Equipe>(liequipe);                
            }

            set
            {
                _liEquipe = value;
            }
       }
        public Classement()
        {
              LiEquipe = new ObservableCollection<Equipe>();
             _liEquipe = new ObservableCollection<Equipe>();
        }
        public Classement(ObservableCollection<Equipe> liEquipe)
        {
           if (liEquipe == null)
            {
                throw new Exception("Erreur lors de l'ajout de la liste d'équipe");
            }
            _liEquipe = liEquipe;
        }

        public override string ToString()
        {
            string message = "";
            for (int i=0; i < LiEquipe.Count; i++){
                message = message + LiEquipe[i].ToString();
            }
            return message;
        }
    }
}
