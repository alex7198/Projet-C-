using Classe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Actualité.xaml
    /// </summary>
    public partial class ActuRugby : UserControl
    {

        public static readonly DependencyProperty LiActualiteActuRugbyProperty = DependencyProperty.Register("LiActualiteActuRugby", typeof(ObservableCollection<Actualite>), typeof(ActuRugby));
        internal SportManager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public ActuRugby()
        {
            InitializeComponent();
        

        }

        public ObservableCollection<Actualite> LiActualiteActuRugby
        {
            get
            {
                return GetValue(LiActualiteActuRugbyProperty) as ObservableCollection<Actualite>;
            }

            set
            {
                SetValue(ActuRugby.LiActualiteActuRugbyProperty, value);
            }
        }
    }
}
