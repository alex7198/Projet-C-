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

namespace Graphique.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Résultat.xaml
    /// </summary>
    public partial class Résultat : UserControl
    {
        public Résultat()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty LiRencontreSportiveProperty = DependencyProperty.Register("LiRencontreSportive", typeof(List<Classe.RencontreSportive>), typeof(Résultat));

        public List<Classe.RencontreSportive> LiRencontreSportive
        {
            get
            {
                return GetValue(LiRencontreSportiveProperty) as List<Classe.RencontreSportive>;

            }

            set
            {
                SetValue(LiRencontreSportiveProperty, value);
            }
        }
    }

   
}
