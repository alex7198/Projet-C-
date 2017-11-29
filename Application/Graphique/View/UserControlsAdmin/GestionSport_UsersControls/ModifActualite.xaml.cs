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
    /// Logique d'interaction pour ModifActualite.xaml
    /// </summary>
    public partial class ModifActualite : Window
    {
        internal Actualite Actualite;
        internal Sport leSport;
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public ModifActualite(Actualite actualite)
        {
            InitializeComponent();
            Actualite = actualite;
            this.DataContext = actualite;

            foreach (Sport s1 in Manager.LesSports)
            {
                for (int i = 0; i < s1.LiActualite.Count; i++)
                {
                    if (s1.LiActualite[i].Equals(Actualite))
                    {
                        leSport = s1;
                    }
                }
            }
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sauvegarde_Click(object sender, RoutedEventArgs e)
        {
            Manager.Update(leSport, Actualite);
            System.Windows.Forms.MessageBox.Show("Vos modification(s) ont bien été pris en compte", "Sauvegarde effectué",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            this.Close();
        }

        private void supprimer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult var = System.Windows.Forms.MessageBox.Show("Vous allez supprimer une actualité , êtes vous certains ? ", "Supprimer une actualite",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (var == System.Windows.Forms.DialogResult.OK)
            {
                Manager.Remove(leSport, Actualite);
                System.Windows.Forms.MessageBox.Show($"Vous venez de supprimer {Actualite.Titre}", "Suppression actualité", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
