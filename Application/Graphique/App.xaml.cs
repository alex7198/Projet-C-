using Classe;
using Données;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        internal ManagerUtilisateur ManagerUtilisateur { get; } = DataManager.loadData_Utilisateur();

        internal SportManager Manager { get; } = DataManager.loadData_Sport();




        //public App()
        //{
        //    ManagerUtilisateur.DataUtilisateur = new XML();
        //    foreach (var n in ManagerUtilisateur.LesUtilisateur)
        //    {
        //        ManagerUtilisateur.DataUtilisateur.Add(n);

        //    }
        //    Manager.DataManager = new XML();
        //    foreach (var n in Manager.LesSports)
        //    {
        //        Manager.DataManager.Add(n);

        //    }


        //}
    }
}
