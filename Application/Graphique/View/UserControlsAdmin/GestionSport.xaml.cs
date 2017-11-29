using Classe;
using Graphique.View.UserControlsAdmin.GestionSport_UsersControls;
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
    /// Logique d'interaction pour GestionSport.xaml
    /// </summary>
    public partial class GestionSport : UserControl

    {
        internal Championnat c1;
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public GestionSport()
        {
            InitializeComponent();
            this.DataContext = Manager;
        }

        private void suppresion_Click(object sender, RoutedEventArgs e)
        {
            Manager.Remove((Sport)ListeSport.SelectedItem);
        }


        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
           Championnat c1= (sender as ListBox).SelectedItem as Championnat;
           
            ModifChampionnat mc = new ModifChampionnat(c1);
            mc.ShowDialog();
        }

        private void ListBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {

            Actualite a1 = (sender as ListBox).SelectedItem as Actualite;

            ModifActualite ma = new ModifActualite(a1);
            ma.ShowDialog();
        }

        private void AjouterChampionnat_Click(object sender, RoutedEventArgs e)
        {
            Sport s1 = ListeSport.SelectedItem as Sport;
            if (s1.LiChampionnat.Count < 2)
            {
                AjoutChampionnat Ac = new AjoutChampionnat((Sport)ListeSport.SelectedItem);
                Ac.ShowDialog();
            }

            else
            {
                MessageBox.Show("Vous ne pouvez posséder que 2 championnats pour 1 sport", "Erreur création championnat", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
