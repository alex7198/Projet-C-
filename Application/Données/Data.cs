using Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Données
{
    //Data contiet toutes les méthode de IUtilisateur et ISportManager + loadSport + loadUtilisateur. 
   public abstract class Data : IUtilisateur , ISportManager
    {
        public abstract ObservableCollection<Sport> LesSports { get; }
        public abstract ObservableCollection<Utilisateur> LesUtilisateur { get; }

        public abstract void Add(Sport sport);
        public abstract void Add(Sport sport, Championnat championnat, Equipe equipe);
        public abstract void Add(Utilisateur utilisateur);
        public abstract ObservableCollection<Sport> loadSport();
        public abstract ObservableCollection<Utilisateur> loadUtilisateur();
        public abstract void Remove(Sport sport);
        public abstract void Remove(Utilisateur utilisateur);
        public abstract void Remove(Sport sport, Championnat championnat, Equipe equipe);
        public abstract void Update(Sport sport);
        public abstract void Update(Utilisateur utilisateur);
        public abstract void Update(Sport S1, Championnat c1, Equipe e1, Utilisateur u1, string description);
        public abstract void Update(Sport sport, Actualite A1);
        public abstract void Update(Sport sport, Championnat C1);

        public abstract void Update(Sport S1, Championnat c1, Journee j1, Equipe e1, Equipe e2, int ScoreE1, int scoreE2);

        public abstract void Remove(Sport sport, Actualite actualite);

       public abstract void Remove(Sport sport, Championnat championnat);
        public abstract void Add(Sport sport, Championnat championnat);
    }
}
