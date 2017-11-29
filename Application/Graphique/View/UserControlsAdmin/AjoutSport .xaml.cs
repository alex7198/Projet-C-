using Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour AjoutSport.xaml
    /// </summary>
    public partial class AjoutSport : UserControl
    {
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public List<Actualite> lesActualites { get; set; } 
        public AjoutSport()
        {
           
            InitializeComponent();
            lesActualites = new List<Actualite>();
            lesActualites.Add(new Actualite("lll", "ddd"));
            root.DataContext = this;

        
        


        }
       

        private void ajoutsport_Click(object sender, RoutedEventArgs e)
        {
            if (sport_nom.Text == "")
            {
                MessageBox.Show("Veiller verifer les informations sur le sport","erreur ajout sport",MessageBoxButton.OKCancel,MessageBoxImage.Error);
            }
            else
            {

                Manager.Add(new Sport { Nom = sport_nom.Text });
                MessageBox.Show("Bravo vous avez ajouté un nouveau sport ,vous pourrez le modifie dans l'onglet Modifier/Supprimier un sport", "Création de sport", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               
              
            }
        }
        
    }
}
