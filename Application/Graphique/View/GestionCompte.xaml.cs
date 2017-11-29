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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphique.View
{
    /// <summary>
    /// Logique d'interaction pour GestionCompte.xaml
    /// </summary>
    public partial class GestionCompte : Window
    {
        internal ManagerUtilisateur ManagerUtilisateur
        {
            get
            {
                return (App.Current as App).ManagerUtilisateur;
            }
        }
        internal Utilisateur utilisateur;
        Boolean modification = false;
        public GestionCompte(Utilisateur U1)
        {
            
            InitializeComponent();
            utilisateur = U1;
            this.DataContext = U1;
            Recup_Email.Visibility = Visibility.Hidden;
        
            Recup_Mdp.Visibility = Visibility.Hidden;
            Recup_Nom.Visibility = Visibility.Hidden;
            Recup_Prènom.Visibility = Visibility.Hidden;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            string etat = "";
            if (modification)
            {
                etat = "Vous avez efféctué des modifications, êtes vous sûre de vos nouvelles information ?";
            }
       
        else {
                etat = "Vous allez quitté la gestion de compte ";
            }

            DialogResult result = System.Windows.Forms.MessageBox.Show(etat, "Confirmation modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
              
                this.Close();
            }
        }


        private void Modifie_Click(object sender, RoutedEventArgs e)
        {
            Recup_Email.Visibility = Visibility.Visible;
            Recup_Mdp.Visibility = Visibility.Visible;
            Recup_Nom.Visibility = Visibility.Visible;
            Recup_Prènom.Visibility = Visibility.Visible;

            modification = true;
        }
        private void Supprimé_Click(object sender, RoutedEventArgs e)
        {
        
                DialogResult result = System.Windows.Forms.MessageBox.Show("Vous allez supprimé votre compte , êtes vous sûre", "Confirmation modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                ManagerUtilisateur.Remove(utilisateur);
                this.Close();
                }
            }
        }
    }
