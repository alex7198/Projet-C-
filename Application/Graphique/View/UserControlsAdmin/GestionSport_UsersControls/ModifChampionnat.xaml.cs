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

namespace Graphique.View.UserControlsAdmin.GestionSport_UsersControls
{
    /// <summary>
    /// Logique d'interaction pour ModifChampionnat.xaml
    /// </summary>
    public partial class ModifChampionnat : Window
    {
        internal Sport leSport;
        internal Championnat championnat;
        internal Journee j1;
        internal Equipe Equipe1;
        internal Equipe Equipe2; 
        public ModifChampionnat(Championnat c1)
        {
            InitializeComponent();
            championnat = c1;
            this.DataContext = c1;
            Equipe2_nom.DataContext = Equipe1;

            foreach (Sport s1 in Manager.LesSports)
            {
                foreach (Championnat champ in s1.LiChampionnat)
                {
                    if (championnat.Equals(champ))
                    {
                        leSport = s1;
                    }
                }
            }

        }
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        private void SuppressionEquipe_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult result = System.Windows.Forms.MessageBox.Show("Vous allez supprimer une équipe , êtes vous sure ?", "Suppresion utilisateur", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Manager.Remove(leSport, championnat, Equipe1);
                Equipe1 = null;
            }
            
        }

        private void ListEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (Equipe1 == null)
            {
                Equipe1 = ListEquipe.SelectedItem as Equipe;
                Equipe1_nom.DataContext = Equipe1;
            }

            else
            {
                Equipe2 = ListEquipe.SelectedItem as Equipe;
                Equipe2_nom.DataContext = Equipe2;
            }

         
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Boolean verifie = true;
            string etat = "";

            if(Equipe1==null || Equipe2 == null)
            {
                etat = $"Vous n'avez pas choisit d'équipe , veuillez choisir 2 équipes pour créer une rencontre sportive";
                verifie = false;
            }

            if (j1 == null)
            {
                etat = $"{etat} ,Vous n'avez pas séléctionné une journée pour votre renconstre sportive";
                verifie = false;

            }

            if(Recup_Equipe1.Text=="" || Recup_Equipe2.Text == "")
            {
                etat=$"{etat} Veuillez rentrer un score valide pour les deux equipes";
                verifie = false;
            }

            if (verifie)
            {
                RencontreSportive r1 = new RencontreSportive(leSport, championnat, Equipe1, Equipe2, int.Parse(Recup_Equipe1.Text), int.Parse(Recup_Equipe2.Text));
                if (j1.LiRencontreSportive.Contains(r1))
                {
                    etat = $"Erreur lors  de la création de la  rencontre sportive car  {r1.ToString()} existe déja";
                }
                else
                {
                    j1.AjouterRencontreSportive(r1);
                    Manager.Update(leSport, championnat);
                    etat = $"Création de la rencontre sportive \n {r1.ToString()}";
                }
                
            }

            System.Windows.Forms.MessageBox.Show(etat, "Creation rencontre sportive suivante :", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ajoutJournées_Click(object sender, RoutedEventArgs e)
        {
            championnat.CréeClassement(new Journee(championnat.DictionnaireClassement.Keys.Count + 1));
            Manager.Update(leSport, championnat);
        }

        private void ajout_Click(object sender, RoutedEventArgs e)
        {
            string etat = "";

            if(recup_description.Text=="" || recup_nomEq.Text== "")
            {
                etat = $"Veuillez vérifier les informations saisie s'il vous plait";
            }

            else
            {
                Manager.Add(leSport, championnat, new Equipe(recup_nomEq.Text, recup_description.Text));
                recup_description.Text = "";
                recup_nomEq.Text = "";
                etat = $"Bravo vous venez d'ajouter une équipe dans le championnat{championnat.Nom}";
            }

            System.Windows.MessageBox.Show(etat, "Ajout équipe", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            j1 = comboBox.SelectedItem as Journee;
        }

     
    }
}
