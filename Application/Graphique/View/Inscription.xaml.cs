using Classe;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Graphique.View
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        internal ManagerUtilisateur ManagerUtilisateur
        {
            get
            {
                return (App.Current as App).ManagerUtilisateur;
            }
        }
        public Inscription()
        {
            InitializeComponent();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {

            DialogResult result = System.Windows.Forms.MessageBox.Show("Vous allez quitté l'inscription", "Annulé",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {

            if (Recup_Identifiant.Text == "" || Recup_Email.Text == "" || Recup_Mdp.Text == "")
            {


                Recup_Identifiant.BorderBrush = Brushes.Red;
                Recup_Email.BorderBrush = Brushes.Red;
                Recup_Mdp.BorderBrush = Brushes.Red;
                System.Windows.MessageBox.Show("Vous n'avez pas remplie les information importante pour pourvoir valider l'inscription , s'il vous plait veuillez remplir les champ(s) obligatoire(s)", "erreur inscription", MessageBoxButton.OK,MessageBoxImage.Error);
            }

            else
            {

                ManagerUtilisateur.Add(new Utilisateur { Nom = Recup_Identifiant.Text, Prenom = Recup_Prènom.Text, Adresse = Recup_Email.Text, Mdp = Recup_Mdp.Text });
                System.Windows.Forms.MessageBox.Show("Bravo vous vous êtes créer un compte sur notre application , vous pouvez des maintenant poste des commentaire", "Creation réussi", MessageBoxButtons.OK);
                this.Close();
            }

        }
    }
}
