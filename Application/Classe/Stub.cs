using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
   public class Stub
    {
        public Stub()
        {
            try {

              Console.WriteLine("----------SPORT---------\n \n");
                Sport Rugby = new Sport("Rugby");

                Actualite Article_Rugby1 = new Actualite("L'asm en final", "Bla bla bla", "/img/asm");
                Championnat Top14 = new Championnat("Top 14");

                Rugby.AjouterActualite(Article_Rugby1);
                Rugby.AjouterChampionnat(Top14);

                Console.Write(Rugby.ToString());

                Console.WriteLine("\n \n ----------CHAMPIONNAT---------");

                Equipe ASM = new Equipe("ASM","Superbe équipe","/Image/fond.jpg");
                Equipe Toulon = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
                Equipe LOU = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");
                Journée Journe1 = new Journée();

                Top14.AjouteEquipe(Toulon);
                Top14.AjouteEquipe(ASM);
                Top14.AjouteEquipe(LOU);

                RenconstreSportive R1 = new RenconstreSportive(Top14, ASM, Toulon, 150, 0);
                RenconstreSportive R2 = new RenconstreSportive(Top14,ASM, LOU, 15, 0);

                RenconstreSportive R3 = new RenconstreSportive(Top14, LOU, ASM, 15, 0);
                RenconstreSportive R4 = new RenconstreSportive(Top14, Toulon, ASM, 15, 0);



                Journe1.AjouterRencontreSportive(R1);
                Journe1.AjouterRencontreSportive(R2);
                Journe1.AjouterRencontreSportive(R3);
                Journe1.AjouterRencontreSportive(R4);

                Top14.CréeClassement(Journe1);

                Console.WriteLine(Top14.ToString());

                Console.WriteLine("\n \n ----------EQUIPE---------");

                Joueur J1 = new Joueur("Julien", "Bardy", "2éme ligne");
                Joueur J2 = new Joueur("Piere", "Ezac", "3éme ligne");

                Utilisateur Yiakon = new Utilisateur("Champiat", "Gabriel", "14 ddd", "lala");
                Utilisateur IpYiakon = new Utilisateur("Cmpiat", "Giel", "16 ddd", "toto");

                ASM.AjouterCommentaire(Yiakon, "Super équipe , vraiment , espérons qu'il gagne \n");
                ASM.AjouterCommentaire(Yiakon, "il gagne \n");
                ASM.AjouterCommentaire(IpYiakon, "Super équipe \n");

                ASM.ajouterJoueur(J1);
                ASM.ajouterJoueur(J2);

                Console.WriteLine(ASM.ToString());

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Equipe> ListEquipe()
        {
            List<Equipe> LiEquipe = new List<Equipe>();
            Equipe ASM = new Equipe("ASM", "Superbe équipe", "/Image/fond.jpg");
            Equipe Toulon = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
            Equipe LOU = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");

            LiEquipe.Add(ASM);
            LiEquipe.Add(Toulon);
            LiEquipe.Add(LOU);

            return LiEquipe;
        }

        public Championnat loadChampionnat()
        {
            Championnat Top14 = new Championnat("Top14");
            

            Equipe ASM = new Equipe("ASM", "Superbe équipe", "/Image/fond.jpg");
            Equipe Toulon = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
            Equipe LOU = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");

            

            Top14.AjouteEquipe(Toulon);
            Top14.AjouteEquipe(ASM);
            Top14.AjouteEquipe(LOU);

            

            RenconstreSportive R1 = new RenconstreSportive(Top14, ASM, Toulon, 150, 0);
            RenconstreSportive R2 = new RenconstreSportive(Top14, ASM, LOU, 15, 0);

            RenconstreSportive R3 = new RenconstreSportive(Top14, LOU, ASM, 15, 0);
            RenconstreSportive R4 = new RenconstreSportive(Top14, Toulon, ASM, 15, 0);
            Journée Journe1 = new Journée();
            Journée Journe2 = new Journée();

            Journe1.AjouterRencontreSportive(R1);
            Journe1.AjouterRencontreSportive(R2);
            Journe1.AjouterRencontreSportive(R3);
            Journe1.AjouterRencontreSportive(R4);

            Journe2.AjouterRencontreSportive(R1);
            Journe2.AjouterRencontreSportive(R2);

            Console.WriteLine(Journe1);

            Top14.CréeClassement(Journe1);
            Top14.CréeClassement(Journe2);

            Console.WriteLine(Top14.DictionnaireClassement.Keys);
            
            return Top14;
        }

        public Championnat loadChampionnat2()
        {
            Championnat proD2 = new Championnat("ProD2");

            Equipe Biarritz = new Equipe("Biarritz", "Bel avenir !", "/Image/fond.jpg");
            Equipe Agen = new Equipe("Agen", "Super !", "/Image/fond.jpg");
            Equipe Dax = new Equipe("Dax", "Début difficile", "/Image/fond.jpg");

            proD2.AjouteEquipe(Biarritz);
            proD2.AjouteEquipe(Agen);
            proD2.AjouteEquipe(Dax);

            RenconstreSportive R1 = new RenconstreSportive(proD2, Biarritz, Agen, 18, 15);
            RenconstreSportive R2 = new RenconstreSportive(proD2, Biarritz, Dax, 21, 25);
            RenconstreSportive R3 = new RenconstreSportive(proD2, Dax, Agen, 12, 18);

            Journée Journe1 = new Journée();
            Journée Journe2 = new Journée();

            Journe1.AjouterRencontreSportive(R1);
            Journe1.AjouterRencontreSportive(R2);

            Journe2.AjouterRencontreSportive(R3);

            proD2.CréeClassement(Journe1);
            proD2.CréeClassement(Journe2);

            return proD2;




        }

        public Sport loadSport()
        {
           
            Sport Rugby = new Sport("Rugby");

            Actualite Article_Rugby1 = new Actualite("L'asm en final", "Bla bla bla", "/Image/Icone.jpg");
            Actualite Article_Rugby2 = new Actualite("L'asm en demi", "Bla bla bla", "/Image/fond.jpg");


            Rugby.AjouterActualite(Article_Rugby1);
            Rugby.AjouterActualite(Article_Rugby2);

            return Rugby;
        }
    }
}
