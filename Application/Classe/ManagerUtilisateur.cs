using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    //Serialisation du managerUtilisateur. Il comporte une liste d'utilsiateurs.
    [DataContract]
    public class ManagerUtilisateur : INotifyPropertyChanged

    {
        [DataMember]
        public ObservableCollection<Utilisateur> LesUtilisateur
        {
            get
            {
                return lesUtilisateur;
            }

        }
        [DataMember]
        private ObservableCollection<Utilisateur> lesUtilisateur = new ObservableCollection<Utilisateur>();

        [DataMember]
        public IUtilisateur DataUtilisateur { get; set; }

        public ManagerUtilisateur(IUtilisateur dataManager)
        {

            DataUtilisateur = dataManager;
            foreach (Utilisateur n in dataManager.LesUtilisateur)
            {
                lesUtilisateur.Add(n);
                n.PropertyChanged += UtilisateurPropertyChanged;
            }

            //lesUtilisateur.AddRange(dataManager.LesUtilisateur);
        }

        private void UtilisateurPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Utilisateur users = sender as Utilisateur;
            if (users == null) return;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Add(Utilisateur utilisateur)
        {
            if (lesUtilisateur.Contains(utilisateur)) return;
            lesUtilisateur.Add(utilisateur);
            utilisateur.PropertyChanged += UtilisateurPropertyChanged;
            DataUtilisateur.Add(utilisateur);
        }

        public void Remove(Utilisateur utilisateur)
        {
            lesUtilisateur.Remove(utilisateur);
            utilisateur.PropertyChanged -=UtilisateurPropertyChanged;
            DataUtilisateur.Remove(utilisateur);
        }
         public void Update(Utilisateur users)
        {
            DataUtilisateur.Update(users);
        }

       
    }
}
