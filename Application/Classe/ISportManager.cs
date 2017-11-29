using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //interface regroupant toutes les méthodes qui vont pouvoir être appliqué aux Sport.
  
    public interface ISportManager 
    {
        
        ObservableCollection<Sport> LesSports { get; }

        void Add(Sport sport);

        void Add(Sport sport, Championnat championnat);

        void Add(Sport sport, Championnat championnat, Equipe equipe);

        void Remove(Sport sport);

        void Remove(Sport sport, Actualite actualite);

        void Remove(Sport sport, Championnat championnat, Equipe equipe);

        void Remove(Sport sport, Championnat championnat);

        void Update(Sport sport, Championnat C1);

        void Update(Sport sport, Actualite A1);

        void Update(Sport sport);

        void Update(Sport S1, Championnat c1, Equipe e1, Utilisateur u1, string description);

        void Update(Sport S1, Championnat c1, Journee j1, Equipe e1, Equipe e2, int ScoreE1 , int scoreE2);

    }
}
