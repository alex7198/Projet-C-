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
    /// Logique d'interaction pour Championnat.xaml
    /// </summary>
    public partial class Top14 : UserControl
    {

       public static readonly DependencyProperty DicoJCTop14Property = DependencyProperty.Register("DicoJCTop14", typeof(Dictionary<Journee,Classement>), typeof(Top14));

        public Dictionary<Journee,Classement> DicoJCTop14
        {
            get
            {
                return GetValue(DicoJCTop14Property) as Dictionary<Journee, Classement> ;

            }

            set
            {
                SetValue(Top14.DicoJCTop14Property, value);
            }


        }

        public Top14()
        {
           InitializeComponent();
           
        }

        /* public static readonly DependencyProperty LiRencontreSportiveProperty = DependencyProperty.Register("LiRencontreSportive", typeof(List<Classe.RencontreSportive>), typeof(Top14));

        public List<Classe.RencontreSportive> LiRencontreSportive
        {
            get
            {
                return GetValue(LiRencontreSportiveProperty) as List<Classe.RencontreSportive>;

            }

            private set
            {
                SetValue(Top14.LiRencontreSportiveProperty, value);
            }
        } */
    }
}
