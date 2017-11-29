using Classe;
using Graphique.View.UserControlsAdmin;
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
using System.Windows.Shapes;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Window
    {
        internal ManagerUtilisateur Manager
        {
            get
            {
                return (App.Current as App).ManagerUtilisateur;
            }
        }


        internal SportManager ManagerSport
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }


        public PageAdmin()
        {
            InitializeComponent();

            SelectionOption.SelectedIndex = SelectionOption.Items.Add("Supprimer/modifier un sport");
            SelectionOption.Items.Add("Ajouter un sport/Supprimer un utilisateur");
            

            this.DataContext = Manager;
        }

        private void SelectionOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(SelectionOption.SelectedIndex)
            {
                case 0:
                    this.StackOption.Children.Clear();
                    this.StackOption.Children.Add(new GestionSport());
                    this.StackOption.Children.Add(new Aide());
                    break;
                case 1:
                    this.StackOption.Children.Clear();
                    this.StackOption.Children.Add(new AjoutSport());
                    this.StackOption.Children.Add(new SuppUtilisateur());
                    break;
            }
        }
    }
}
