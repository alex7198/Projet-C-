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
    //Sérialisation de SportManager qui comporte la liste des sports.
    [DataContract]
    public class SportManager : INotifyPropertyChanged
        
    {
        [DataMember]
        public ObservableCollection <Sport> LesSports
        {
            get
            {
                return lesSports;
            }

        }
        [DataMember]
        private ObservableCollection<Sport> lesSports = new ObservableCollection<Sport>();
        [DataMember]
        public ISportManager DataManager { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       

        public SportManager(ISportManager dataManager)
        {
            DataManager = dataManager;

            foreach (Sport n in dataManager.LesSports)
            {

                lesSports.Add(n);
                n.PropertyChanged += SportPropertyChanged;


            }
        }

       

        private void SportPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Sport sport = sender as Sport;
            if (sport == null) return;
                Update(sport);
        }

        public void Add(Sport sport, Championnat championnat, Equipe equipe)
        {
            DataManager.Add(sport, championnat, equipe);
        }

        private void Update(Sport sport)
        {
            DataManager.Update(sport);
        }

        public void Add (Sport sport)
        {
            lesSports.Add(sport);
            sport.PropertyChanged += SportPropertyChanged;
            DataManager.Add(sport);
        }

        public void Remove(Sport Sport)
        {
            lesSports.Remove(Sport);
            Sport.PropertyChanged -= SportPropertyChanged;
            DataManager.Remove(Sport);
        }

        public void Update(Sport S1, Championnat c1, Equipe e1, Utilisateur u1, string description)
        {
            DataManager.Update(S1,c1,e1,u1,description);
        }

        public void Update(Sport S1,Actualite a1)
        {
            DataManager.Update(S1,a1);
        }

        public void Update(Sport S1, Championnat c1)
        {
            DataManager.Update(S1, c1);
        }



        public void Update(Sport S1, Championnat c1, Journee j1, Equipe e1, Equipe e2, int ScoreE1, int scoreE2)
        {
            DataManager.Update(S1, c1,  j1, e1, e2, ScoreE1, scoreE2);
        }

        public void Remove(Sport sport , Actualite actualite)
        {
            DataManager.Remove(sport, actualite);
        }

        public void Remove(Sport sport, Championnat championnat, Equipe equipe)
        {
            DataManager.Remove(sport, championnat, equipe);
        }


        public void Remove(Sport sport, Championnat championnat)
        {
            DataManager.Remove(sport, championnat);
        }
       public void Add(Sport sport, Championnat championnat)
        {
            DataManager.Add(sport, championnat);
        }

    }
}
