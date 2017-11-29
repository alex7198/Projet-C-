using Classe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphique.View.UserControlsAdmin.GestionSport_UsersControls
{
    /// <summary>
    /// Logique d'interaction pour AjoutChampionnat.xaml
    /// </summary>
    public partial class AjoutChampionnat : Window
    {
        internal Sport sportReçu;
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public ObservableCollection<Joueur> lesJoueurs { get; private set; }
        public ObservableCollection<Equipe> lesEquipes { get; private set; }

        public AjoutChampionnat(Sport sport)
        {
            InitializeComponent();
            lesJoueurs = new ObservableCollection<Joueur>();
            lesEquipes = new ObservableCollection<Equipe>();
            liJoueur.DataContext = this;
            ContainslesEquipes.DataContext = this;
            sportReçu = sport;




        }

        private void AjouterJoueur_Click(object sender, RoutedEventArgs e)
        {
            if (Recup_NomJoueur.Text =="" || Recup_PosteJoueur.Text == "" || Recup_PrenomJoueur.Text == "")
            {
                Recup_NomJoueur.BorderBrush = Brushes.Red;
                Recup_PosteJoueur.BorderBrush = Brushes.Red;
                Recup_PrenomJoueur.BorderBrush = Brushes.Red;
                MessageBox.Show("Vous avez pas remplis tout les champs pour la création d'un joueur", "Erreur création joueur", MessageBoxButton.OK, MessageBoxImage.Error);

          }
            else
            {
                Joueur j1 = new Joueur(Recup_NomJoueur.Text, Recup_PrenomJoueur.Text, Recup_PosteJoueur.Text);
                lesJoueurs.Add(j1);

                Recup_NomJoueur.BorderBrush = Brushes.Gray;
                Recup_PosteJoueur.BorderBrush = Brushes.Gray;
                Recup_PrenomJoueur.BorderBrush = Brushes.Gray;
                Recup_NomJoueur.Text = "";
                Recup_PosteJoueur.Text = "";
                Recup_PrenomJoueur.Text = "";
            } 
                
        }

        private void AjouterEquipe_Click(object sender, RoutedEventArgs e)
        {
            if(lesJoueurs.Count<2 ||Recup_NomEq.Text== "")
            {
                MessageBox.Show($"Erreur lors de creation de l'équipe {Recup_NomEq.Text} , vous devez posséder aux moins 2 joueurs , pour 1 équipe!", "Erreur création équipe", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            else
            {
                Equipe e1 = new Equipe(Recup_NomEq.Text, recup_description.Text);
                foreach(Joueur j1 in lesJoueurs)
                {
                    if (j1 != null)
                    {
                        e1.ajouterJoueur(j1);
                    }
                }

                lesEquipes.Add(e1);
               

                lesJoueurs.Clear();
                Recup_NomEq.Text = "";
                recup_description.Text = "";

            }
        }

        private void creeChampionnat_Click(object sender, RoutedEventArgs e)
        {
            if (lesEquipes.Count < 2 || Recup_NomChamp.Text == "")
            {
                MessageBox.Show($"Erreur lors de creation de l'équipe {Recup_NomChamp.Text} , vous devez posséder aux moins 2 équipes", "Erreur création équipe", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            else
            {
                Championnat c1 = new Championnat(Recup_NomChamp.Text);
                foreach (Equipe e1 in lesEquipes)
                {
                    if (e1 != null)
                    {
                        c1.AjouteEquipe(e1);
                    }
                }

                Manager.Add(sportReçu, c1);

                lesEquipes.Clear();
                lesJoueurs.Clear();
                Recup_NomChamp.Text = "";
                Recup_NomEq.Text = "";
                recup_description.Text = "";
                this.Close();

            }
        }
    }
}

