using Classe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Données
{
    public class DataManager
    {
        //Data Manager permet le chargement des données dans le Stub() ou dans XML()
        public static SportManager loadData_Sport()
        {
           
            Data d1 = new XML();
            foreach (Sport s1 in d1.loadSport())
            {
                d1.LesSports.Add(s1);
            }
            SportManager Manager = new SportManager(d1);
       
            return Manager;

        }
        public static ManagerUtilisateur loadData_Utilisateur()
        {
            Directory.SetCurrentDirectory("../../../Données/XML");
            Data d1 = new XML();

            foreach (Utilisateur u1 in d1.loadUtilisateur())
            {
                d1.LesUtilisateur.Add(u1);
            }
            ManagerUtilisateur Manager = new ManagerUtilisateur(d1);
            return Manager;

        }
    }


}
