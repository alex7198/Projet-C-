using Classe;
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

namespace Graphique.View.UserControlsAdmin
{
    /// <summary>
    /// Logique d'interaction pour SuppUtilisateur.xaml
    /// </summary>
    public partial class SuppUtilisateur : UserControl
    {
        Utilisateur users; 
        internal ManagerUtilisateur  Manager
        {
            get
            {
                return (App.Current as App).ManagerUtilisateur;
            }
        }

        public SuppUtilisateur()
        {
            InitializeComponent();
            users = new Utilisateur();
            ListeUsers.DataContext = Manager;

          


        }

        private void ListeUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            users = ListeUsers.SelectedItem as Utilisateur;
            textBlock_Nom.DataContext = users;
            textBlock_Prenom.DataContext = users;
            textBlock_Adresse.DataContext = users;
            textBlock_Mdp.DataContext = users;
            

        }

        private void suppresion_Click(object sender, RoutedEventArgs e)
        {
            if (users.Nom == null)
            {
                MessageBox.Show("Erreur lors de la selection d'un utilisateur", "Erreur suppression", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            else
            {
                Manager.Remove(users);
            }
        }

        private void Passer_admin_Click(object sender, RoutedEventArgs e)
        {
            if (users.Admin)
            {
                MessageBox.Show("Personne déja admin", "Admin error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                users.Admin = true;
                Manager.Update(users);
                MessageBox.Show($"Vous venez de mettre {users.Nom} admin", "Admin ajouté", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
