using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Interface regroupant toutes les méthodes qui vont pouvoir être appliqué aux utilsiateurs.
    public interface IUtilisateur
    {
        ObservableCollection<Utilisateur> LesUtilisateur { get; }

        void Add(Utilisateur utilisateur);

        void Remove(Utilisateur utilisateur);

        void Update(Utilisateur utilisateur);
    }
}
