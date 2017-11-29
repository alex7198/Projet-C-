using Classe;
using Graphique.View;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphique.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour LesEquipes.xaml
    /// </summary>
    public partial class LesEquipes : UserControl
    {
        internal Equipe E1;
        Championnat championnatselection;
        public static readonly DependencyProperty Championnat1Property = DependencyProperty.Register("Championnat1", typeof(Championnat), typeof(LesEquipes));

        public Championnat Championnat1
        {
            get
            {
                return GetValue(Championnat1Property) as Championnat;
            }

            set
            {
                SetValue(LesEquipes.Championnat1Property, value);
            }
        }

        public static readonly DependencyProperty UtilisateurProperty = DependencyProperty.Register("Users", typeof(Utilisateur), typeof(LesEquipes));
        public Utilisateur Users
        {
            get
            {
                return GetValue(UtilisateurProperty) as Utilisateur;

            }

            set
            {
                SetValue(LesEquipes.UtilisateurProperty, value);
            }
        }


        internal bool connexion = false;


        public LesEquipes()
        {
            InitializeComponent();
           

        }

        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        private void PosterCommentaire(object sender, RoutedEventArgs e)
        {
            if (Users != null)
            {
                connexion = true;



                Sport leSport = new Sport { Nom = "ss" };
                foreach (Sport s1 in Manager.LesSports)
                {
                    foreach (Championnat championnat in s1.LiChampionnat)
                    {
                        if (championnat.Equals(Championnat1))
                        {
                            leSport = s1;
                        }
                    }
                }
                Manager.Update(leSport, Championnat1, E1, Users, TextCommentaire.Text);
            }

            else
            {
                connexion = false;

            }

            if (connexion != true)
            {
                MessageBox.Show("Vous devez etre connecté pour posté un commentaire", "Erreur connexion", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
        }

        private void ChoixChampionnat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            championnatselection = ChoixChampionnat.SelectedItem as Championnat;
            LiEquipe.DataContext = championnatselection;
        }

        private void LiEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E1 = LiEquipe.SelectedItem as Equipe;
        }
    }
}
