using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    public class Actualité
    {
        public string Titre { get; private set; }
        private DateTime DateArticle;
        public string Descritpion { get; private set; }
        public string Img { get; private set; }

        public Actualité (string titre , string descri, string Source_Img)
        {
            this.Titre = titre;
            DateArticle = DateTime.Now;
            this.Descritpion = descri;
            this.Img = Source_Img;
            
        }

        public override string ToString()
        {
            return $"{Titre} \n \t {Descritpion} \n \t\t\t\t {DateArticle} ";
        }

    }
}
