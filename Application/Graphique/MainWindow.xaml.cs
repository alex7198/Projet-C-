using Classe;
using Graphique.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool connexion = false;



        public Sport sportSelected;
        //Envoie une liste d'actualite en fonction du sport choisit a ActuRugby pour ont utilise les DP afins d'envoiés les données en fonction du choix
        public static readonly DependencyProperty LiActualiteProperty = DependencyProperty.Register("LiActualite", typeof(ObservableCollection<Actualite>), typeof(MainWindow));
        //il faut déclarer la DP et une variable avec le nom apres Register
        public ObservableCollection<Actualite> LiActualite
        {
            get
            {
                return GetValue(LiActualiteProperty) as ObservableCollection<Actualite>;

            }

            private set
            {
                SetValue(MainWindow.LiActualiteProperty, value);
            }
        }
        //Envoie un Championnat en fonction du sport choisit a Top14 pour ont utilise les DP afins d'envoiés les données en fonction du choix
        public static readonly DependencyProperty Championnat1Property = DependencyProperty.Register("Championnat1", typeof(Championnat), typeof(MainWindow));
        //il faut déclarer la DP et une variable avec le nom apres Register
        public Championnat Championnat1
        {
            get
            {
                return GetValue(Championnat1Property) as Championnat;
            }

            set
            {
                SetValue(MainWindow.Championnat1Property, value);
            }
        }
        //Envoie un Dictionnaire contenant en key:des Journées et en Value : un classement  en fonction du sport choisit a Top14 pour ont utilise les DP afins d'envoiés les données en fonction du choix
        public static readonly DependencyProperty DicoJCProperty = DependencyProperty.Register("DicoJC", typeof(Dictionary<Journee, Classement>), typeof(MainWindow));
        //il faut déclarer la DP et une variable avec le nom apres Register
        public Dictionary<Journee, Classement> DicoJC
        {
            get
            {
                return GetValue(DicoJCProperty) as Dictionary<Journee, Classement>;

            }

            set
            {
                SetValue(MainWindow.DicoJCProperty, value);
            }


        }


        public static readonly DependencyProperty UtilisateurProperty = DependencyProperty.Register("Users", typeof(Utilisateur), typeof(MainWindow));
        public Utilisateur Users
        {
            get
            {
                return GetValue(UtilisateurProperty) as Utilisateur;

            }

            private set
            {
                SetValue(MainWindow.UtilisateurProperty, value);
            }
        }

        //Permet de faire appel a la variable instacié dans App.xaml.cs et de l'utilisé
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }
        //Permet de faire appel a la variable instacie dans App.xaml.cs et de l'utilisé
        internal ManagerUtilisateur ManagerUtilisateur
        {
            get
            {
                return (App.Current as App).ManagerUtilisateur;
            }
        }
        public MainWindow()
        { 
            InitializeComponent();

            //DataContext est obligatoire pour le binding , cela lui indique sur qu'elle élements , il doit allé cherche les infos.
            liSports.DataContext = Manager;
            GestionCompte.Visibility = Visibility.Hidden;
            deconnexion.Visibility = Visibility.Hidden;
            GestionAdmin.Visibility = Visibility.Hidden;
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {

            if (Recup_Nom.Text == "" && Recup_Mdp.Password == "")
            {
                Recup_Nom.BorderBrush = Brushes.Red;
                Recup_Mdp.BorderBrush = Brushes.Red;
                System.Windows.MessageBox.Show("Erreur avec le remplissage des identifiants/mot de passe", "Erreur connexion", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
            else
            {
                Recup_Nom.BorderBrush = Brushes.Gray;
                Recup_Mdp.BorderBrush = Brushes.Gray;
                Utilisateur u1 = new Utilisateur { Nom = Recup_Nom.Text, Mdp = Recup_Mdp.Password };
                if (ManagerUtilisateur.LesUtilisateur.Contains(u1))
                {
                    foreach (Utilisateur U2 in ManagerUtilisateur.LesUtilisateur)
                    {
                        if (U2.Equals(u1))
                        {
                            u1 = U2;
                        }

                    }
                    Users = u1;
                    connexion = true;
                    Identifiant.Content = $"Bienvenue sur votre page sportive favorite {u1.Nom}";

                    MotDePasse.Visibility = Visibility.Hidden;
                    Recup_Nom.Visibility = Visibility.Hidden;
                    Recup_Mdp.Visibility = Visibility.Hidden;
                    Inscription.Visibility = Visibility.Hidden;
                    Connexion.Visibility = Visibility.Hidden;
                    GestionCompte.Visibility = Visibility.Visible;
                    deconnexion.Visibility = Visibility.Visible;

                    if (Users.Admin)
                    {
                        GestionAdmin.Visibility = Visibility.Visible;
                    }

                    else
                    {
                        GestionAdmin.Visibility = Visibility.Hidden;
                    }

                }

                else
                {
                    System.Windows.MessageBox.Show("Erreur identifiants ou Mot de passe", "Erreur connexion", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }

            }

        }
        //Page admin qui sert a l'utilisateur avec l'option d'admin de pouvoir gérer une grosse partie de l'application.
        private void Admin(object sender, RoutedEventArgs e)
        {
            PageAdmin P1 = new PageAdmin();
            P1.ShowDialog();
        }
        //Appel l'ouverture de la page d'inscription lorsqu'on double-clique sur le label.
        // ps: objet sender est l'objet qui envoie l'evenement , dans se cas , ça sera le label
        private void Inscription_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Inscription I1 = new View.Inscription();
            I1.ShowDialog();
        }
        //Si l'utilisateur n'est pas connécter alors il ne pourras pas accéder à la page gestion de compte , si il l'est alors il pourra modifié ses informations
        private void GestionCompte_Click(object sender, RoutedEventArgs e)
        {
            if (Users == null)
            {
                System.Windows.MessageBox.Show("Probléme avec l'utilisateur , vérifiez que l'utilisateur soit bien connecté", "Erreur utilisateur", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else
            {
                View.GestionCompte G1 = new View.GestionCompte(Users);
                G1.ShowDialog();
            }


        }
        //permet de lire la valeur choisit dans la combobox liSports et de les attribués a differentes variables
        private void liSports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sport s1 = (Sport)liSports.SelectedItem;

            if (s1 != null)
            {
                LiActualite = s1.LiActualite;

                this.DataContext = s1;
                if (s1.LiActualite == null)
                {
                    s1.LiActualite = new ObservableCollection<Actualite>();
                    s1.LiActualite.Add(new Actualite("Par défaut", "Par defaut"));
                }

                if (s1.LiChampionnat == null)
                {
                    s1.LiChampionnat = new ObservableCollection<Championnat>();
                    s1.LiChampionnat.Add(new Championnat("Par défaut"));
                }
                else
                {
                    Championnat1 = s1.LiChampionnat[0];
                }

                DicoJC = s1.LiChampionnat[0].DictionnaireClassement;
            }

        }



        private void deconnexion_Click(object sender, RoutedEventArgs e)
        {
            Users = null;
            Identifiant.Content = "Identifiant : ";
            MotDePasse.Visibility = Visibility.Visible;
            Recup_Nom.Visibility = Visibility.Visible;
            Recup_Mdp.Visibility = Visibility.Visible;
            Recup_Nom.Text = "";
            Recup_Mdp.Password = "";
            Inscription.Visibility = Visibility.Visible;
            Connexion.Visibility = Visibility.Visible;
            GestionCompte.Visibility = Visibility.Hidden;
            deconnexion.Visibility = Visibility.Hidden;
            GestionAdmin.Visibility = Visibility.Hidden;
        }       
    }
}
