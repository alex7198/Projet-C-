using Classe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Données
{
    //Le XML est implémenté par Data, ISportManager et IUtilisateur. On retrouve donc toutes les méthodes présentes dans Data.
    public class XML : Data, ISportManager, IUtilisateur
    {
        string xmlFile = "LesSports.xml";

        string xmlFileUtilisateur = "LesUtilisateurs.xml";

        public XML()
        {
        }
        public override ObservableCollection<Sport> LesSports
        {
            get
            {
                return lesSports;
            }
        }

        private ObservableCollection<Sport> lesSports = new ObservableCollection<Sport>();

        private ObservableCollection<Utilisateur> lesUtilisateurs = new ObservableCollection<Utilisateur>();

        public override ObservableCollection<Utilisateur> LesUtilisateur
        {
            get
            {
               return lesUtilisateurs;
            }
        }





        private void SaveChangesSport()
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var Serializer = new DataContractSerializer(typeof(ObservableCollection<Sport>));

            using (XmlWriter s = XmlWriter.Create(xmlFile))
            {
                Serializer.WriteObject(s, lesSports);
            }
        }

        private void SavesChangesUtilisateur()
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var Serializer = new DataContractSerializer(typeof(ObservableCollection<Utilisateur>));

            using (XmlWriter s = XmlWriter.Create(xmlFileUtilisateur))
            {
                Serializer.WriteObject(s, lesUtilisateurs);
            }
        }



        public override void Add(Sport sport, Championnat championnat, Equipe equipe)
        {
            foreach (Sport s1 in lesSports)
            {
                if (s1.Equals(sport))
                {
                  for(int i = 0; i < s1.LiChampionnat.Count; i++)
                    {
                        if (s1.LiChampionnat[i].Equals(championnat))
                        {
                            s1.LiChampionnat[i].AjouteEquipe(equipe);
                            SaveChangesSport();
                        }
                    }
                }
            }
        }

        public override void Add(Utilisateur utilisateur)
        {
            if (lesUtilisateurs.Contains(utilisateur)) return;
            lesUtilisateurs.Add(utilisateur);
            SavesChangesUtilisateur();
        }

        public override void Add(Sport sport)
        {
            if (lesSports.Contains(sport)) return;
            lesSports.Add(sport);
            SaveChangesSport();
        }
       

        public override void Add(Sport sport, Championnat championnat)
        {
            foreach (Sport s1 in lesSports)
            {
                if (s1.Equals(sport))
                {
                    s1.AjouterChampionnat(championnat);
                    SaveChangesSport();
                }
            }
        }

        public override ObservableCollection<Sport> loadSport()
        {
           
            var Serializer = new DataContractSerializer(typeof(ObservableCollection<Sport>));
            ObservableCollection<Sport> listeSport;
            using (Stream s = File.OpenRead(xmlFile)) 
            {
                listeSport = Serializer.ReadObject(s) as ObservableCollection<Sport>;
            }

            return listeSport;
        }

        public override ObservableCollection<Utilisateur> loadUtilisateur()
        {
            var Serializer = new DataContractSerializer(typeof(ObservableCollection<Utilisateur>));
            ObservableCollection<Utilisateur> liUtilisateur;
            using (Stream s = File.OpenRead(xmlFileUtilisateur))
            {
                liUtilisateur = Serializer.ReadObject(s) as ObservableCollection<Utilisateur>;
            }

            return liUtilisateur;
        }





        public override void Remove(Utilisateur utilisateur)
        {
            if (utilisateur == null)
            {
                throw new Exception("utilisateur vide");
            }
            else
            {
                lesUtilisateurs.Remove(utilisateur);
                SavesChangesUtilisateur();
            }
          
        }

        public override void Remove(Sport sport)
        {
            if (sport == null)
            {
                throw new Exception("Sport vide");
            }
            else
            {
                lesSports.Remove(sport);
                SaveChangesSport();
            }
        }

        public override void Remove(Sport sport, Championnat championnat)
        {
            foreach (Sport s1 in lesSports)
            {
                if (s1.Equals(sport))
                {
                    for (int i = 0; i < s1.LiChampionnat.Count; i++)
                    {
                        if (s1.LiChampionnat[i].Equals(championnat))
                        {
                            s1.LiChampionnat.Remove(s1.LiChampionnat[i]);
                            SaveChangesSport();
                        }
                        i++;
                    }
                }
            }
        }

        public override void Remove(Sport sport, Actualite actualite)
        {
            foreach (Sport s1 in lesSports)
            {
                if (s1.Equals(sport))
                {
                    for (int i = 0; i < s1.LiActualite.Count; i++)
                    {
                        if (s1.LiActualite[i].Equals(actualite))
                        {
                            s1.LiActualite.Remove(s1.LiActualite[i]);
                            SaveChangesSport();
                        }
                        i++;
                    }
                }
            }
        }

        public override void Remove(Sport sport, Championnat championnat, Equipe equipe)
        {
            foreach (Sport s1 in lesSports)
            {
                if (s1.Equals(sport))
                {
                    for (int i = 0; i < s1.LiChampionnat.Count; i++)
                    {
                        if (s1.LiChampionnat[i].Equals(championnat))
                        {
                            for (int j = 0; j < s1.LiChampionnat[i].LiEquipe.Count; j++)
                            {
                                if (s1.LiChampionnat[i].LiEquipe[j].Equals(equipe))
                                {
                                    s1.LiChampionnat[i].LiEquipe.Remove(s1.LiChampionnat[i].LiEquipe[j]);
                                    SaveChangesSport();
                                }

                            }

                        }
                    }
                }
            }
        }

        public override void Update(Utilisateur utilisateur)
        {
            for (int i = 0; i < lesUtilisateurs.Count; i++)
            {
                if (lesUtilisateurs[i].Equals(utilisateur))
                {
                    lesUtilisateurs[i] = utilisateur;
                    SavesChangesUtilisateur();
                }
            } 
        }

        public override void Update(Sport sport)
        {
           for(int i = 0; i < lesSports.Count; i++)
            {
                if (lesSports[i].Equals(sport))
                {
                    lesSports[i] = sport;
                    SaveChangesSport();
                }
            }
        }

        public override void Update(Sport sport, Championnat C1)
        {
            for (int i = 0; i < sport.LiChampionnat.Count; i++)
            {
                if (sport.LiChampionnat[i].Equals(C1))
                {
                    sport.LiChampionnat[i] = C1;
                    SaveChangesSport();
                }
            }
        }

        public override void Update(Sport sport, Actualite A1)
        {
            for (int i = 0; i < sport.LiActualite.Count; i++)
            {
                if (sport.LiActualite[i].Equals(A1))
                {
                    sport.LiActualite[i] = A1;
                    SaveChangesSport();
                }
            }
        }



        public override void Update(Sport S1, Championnat c1, Equipe e1, Utilisateur u1, string description)
        {
            foreach (Sport sport in lesSports)
            {
                if (sport.Equals(S1))
                {
                    foreach (Championnat championnat in sport.LiChampionnat)
                    {
                        if (championnat.Equals(c1))
                        {
                            foreach (Equipe equipe in c1.LiEquipe)
                            {
                                if (equipe.Equals(e1))
                                {
                                    equipe.AjouterCommentaire(u1, description);
                                    SaveChangesSport();
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void Update(Sport S1, Championnat c1, Journee j1, Equipe e1, Equipe e2, int ScoreE1, int scoreE2)
        {
            foreach (Sport sport in lesSports)
            {
                if (sport.Equals(S1))
                {
                    foreach (Championnat championnat in sport.LiChampionnat)
                    {
                        if (championnat.Equals(c1))
                        {

                            foreach (Journee journee in championnat.DictionnaireClassement.Keys)
                            {
                                if (journee.Equals(j1))
                                {
                                    j1.AjouterRencontreSportive(new RencontreSportive(S1, c1, e1, e2, ScoreE1, scoreE2));
                                    SaveChangesSport();
                                }
                            }
                        }
                    }
                }
            }
        }

      
    }
}
