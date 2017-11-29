using Classe;
using Données;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stub : Data, ISportManager, IUtilisateur
{
    //Le Stub est implémenté par Data, ISportManager et IUtilisateur. On retrouve donc toutes les méthodes présentes dans Data.
    public Stub()
    {
    }

    public override ObservableCollection<Sport> loadSport()
    {
        ObservableCollection<Sport> lesSports = new ObservableCollection<Sport>();

        //***********************************************RUGBY*******************************************************************

        Actualite actu = new Actualite("ASM en final ", "En réitérant l'exploit d 'il y a 7 ans, les jaune et bleu ont offert à leurs fidèles supporters le plus beau des cadeaux : la victoire.Une liesse populaire s'est répandue dans les rues de Clermont-Ferrand où même ceux qui avaient choisi de regarder le match chez eux ont rejoint la foule pour célébrer cette victoire tant espérée.Même si la nuit de sommeil risque d'être courte pour beaucoup, il leur faudra conserver quelques forces pour acclamer dimanche après-midi les héros d'un soir.Les dieux du stade sont, en effet, attendus, sur cette même place, dès 17H00 lundi 5 juin, pour recevoir les remerciements et la reconnaissance de ces dizaines de milliers de supporters qui rêvaient de voir enfin revenir le bouclier de Brennus en terre auvergnate.");
        Sport Rugby = new Sport { Nom = "Rugby", LiActualite = new ObservableCollection<Actualite>(), LiChampionnat = new ObservableCollection<Championnat>() };
        lesSports.Add(Rugby);

        Rugby.AjouterActualite(actu);

        //*********************************************TOP14********************************************************************

        Championnat Top14 = new Championnat("Top 14");
        Rugby.AjouterChampionnat(Top14);

        Utilisateur U1 = new Utilisateur { Nom = "Supp1", Prenom = "Tata", Adresse = "Tata@gmail.com", Mdp = "tata" };


        Equipe Clermont = new Equipe("Clermont-Ferrand", "L'ASM Clermont Auvergne, anciennement AS Montferrand, est un club de rugby à XV français basé à Clermont-Ferrand et actuellement présidé par Éric de Cromières3. L'équipe première est entraînée par le Français Franck Azéma à partir de 2014 après huit saisons sous la houlette du Néo-Zélandais Vern Cotter, et évolue dans le Top 14 et dispute la Coupe d'Europe.");
        Equipe Toulon = new Equipe("Toulon", "Equipe null");
        Equipe Lyon = new Equipe("Lyon", "Retraite de l'asm");
        Equipe Toulouse = new Equipe("Toulouse", "Superbe équipe");
        Equipe Montpellier = new Equipe("Montpellier", "Equipe null");
        Equipe LaRochelle = new Equipe("La Rochelle", "Retraite de l'asm");
        Equipe Castres = new Equipe("Castres", "Superbe équipe");
        Equipe Racing = new Equipe("Racing-92", "Equipe null");
        Equipe StadeFrançais = new Equipe("Stade Français", "Retraite de l'asm");
        Equipe Brive = new Equipe("Brive", "Superbe équipe");
        Equipe Pau = new Equipe("Pau", "Equipe null");
        Equipe Bordeaux = new Equipe("Bordeaux-Bègles", "Retraite de l'asm");
        Equipe Grenoble = new Equipe("Grenoble", "Equipe null");
        Equipe Bayonne = new Equipe("Bayonne", "Retraite de l'asm");

        Top14.AjouteEquipe(Clermont);
        Top14.AjouteEquipe(Toulon);
        Top14.AjouteEquipe(Lyon);
        Top14.AjouteEquipe(Toulouse);
        Top14.AjouteEquipe(Montpellier);
        Top14.AjouteEquipe(LaRochelle);
        Top14.AjouteEquipe(Castres);
        Top14.AjouteEquipe(Racing);
        Top14.AjouteEquipe(StadeFrançais);
        Top14.AjouteEquipe(Brive);
        Top14.AjouteEquipe(Pau);
        Top14.AjouteEquipe(Bordeaux);
        Top14.AjouteEquipe(Grenoble);
        Top14.AjouteEquipe(Bayonne);


        Journee Journee1_Top14 = new Journee(1);
        Journee Journee2_Top14 = new Journee(2);
        Journee Journee3_Top14 = new Journee(3);

        Clermont.AjouterCommentaire(U1, "salakakakaakakakakak");

        RencontreSportive R1J1_Top14 = new RencontreSportive(Rugby, Top14, Lyon, Brive, 15, 15);
        RencontreSportive R2J1_Top14 = new RencontreSportive(Rugby, Top14, StadeFrançais, Grenoble, 54, 20);
        RencontreSportive R3J1_Top14 = new RencontreSportive(Rugby, Top14, LaRochelle, Clermont, 30, 30);
        RencontreSportive R4J1_Top14 = new RencontreSportive(Rugby, Top14, Castres, Pau, 28, 11);
        RencontreSportive R5J1_Top14 = new RencontreSportive(Rugby, Top14, Bordeaux, Racing, 15, 9);
        RencontreSportive R6J1_Top14 = new RencontreSportive(Rugby, Top14, Toulouse, Montpellier, 20, 12);
        RencontreSportive R7J1_Top14 = new RencontreSportive(Rugby, Top14, Bayonne, Toulon, 15, 0);

        Journee1_Top14.AjouterRencontreSportive(R1J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R2J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R3J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R4J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R5J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R6J1_Top14);
        Journee1_Top14.AjouterRencontreSportive(R7J1_Top14);

        Top14.CréeClassement(Journee1_Top14);

        RencontreSportive R1J2_Top14 = new RencontreSportive(Rugby, Top14, Pau, Toulon, 18, 20);
        RencontreSportive R2J2_Top14 = new RencontreSportive(Rugby, Top14, Bayonne, Castres, 12, 12);
        RencontreSportive R3J2_Top14 = new RencontreSportive(Rugby, Top14, Grenoble, LaRochelle, 19, 22);
        RencontreSportive R4J2_Top14 = new RencontreSportive(Rugby, Top14, Brive, StadeFrançais, 28, 20);
        RencontreSportive R5J2_Top14 = new RencontreSportive(Rugby, Top14, Racing, Lyon, 29, 16);
        RencontreSportive R6J2_Top14 = new RencontreSportive(Rugby, Top14, Toulouse, Bordeaux, 22, 17);
        RencontreSportive R7J2_Top14 = new RencontreSportive(Rugby, Top14, Montpellier, Clermont, 22, 26);

        Journee2_Top14.AjouterRencontreSportive(R1J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R2J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R3J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R4J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R5J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R6J2_Top14);
        Journee2_Top14.AjouterRencontreSportive(R7J2_Top14);

        Top14.CréeClassement(Journee2_Top14);

        RencontreSportive R1J3_Top14 = new RencontreSportive(Rugby, Top14, StadeFrançais, Clermont, 30, 30);
        RencontreSportive R2J3_Top14 = new RencontreSportive(Rugby, Top14, Lyon, Grenoble, 32, 13);
        RencontreSportive R3J3_Top14 = new RencontreSportive(Rugby, Top14, Castres, LaRochelle, 18, 26);
        RencontreSportive R4J3_Top14 = new RencontreSportive(Rugby, Top14, Pau, Bayonne, 25, 9);
        RencontreSportive R5J3_Top14 = new RencontreSportive(Rugby, Top14, Toulon, Brive, 21, 25);
        RencontreSportive R6J3_Top14 = new RencontreSportive(Rugby, Top14, Bordeaux, Montpellier, 15, 32);
        RencontreSportive R7J3_Top14 = new RencontreSportive(Rugby, Top14, Racing, Toulouse, 28, 14);





        Journee3_Top14.AjouterRencontreSportive(R1J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R2J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R3J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R4J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R5J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R6J3_Top14);
        Journee3_Top14.AjouterRencontreSportive(R7J3_Top14);



        Top14.CréeClassement(Journee3_Top14);


        Joueur J1 = new Joueur("Julien", "Bardy", "2éme ligne");
        Joueur J2 = new Joueur("Piere", "Ezac", "3éme ligne");

        Clermont.ajouterJoueur(J1);
        Clermont.ajouterJoueur(J2);






        //********************************************ProD2**********************************************************************

        Championnat Prod2 = new Championnat("Pro D2");
        Rugby.AjouterChampionnat(Prod2);

    
        Equipe Montmarsan = new Equipe("Montmarsan", "Retraite de l'asm");

        Prod2.AjouteEquipe(Brive);
        Prod2.AjouteEquipe(Bayonne);
        Prod2.AjouteEquipe(Montmarsan);


        //Journee Journee1_ProD2 = new Journee(1);
        Journee Journee2_ProD2 = new Journee(2);

        RencontreSportive R1_ProD2 = new RencontreSportive(Rugby, Prod2, Brive, Bayonne, 150, 0);
        RencontreSportive R2_ProD2 = new RencontreSportive(Rugby, Prod2, Brive, Montmarsan, 15, 0);

        RencontreSportive R3_ProD2 = new RencontreSportive(Rugby, Prod2, Montmarsan, Bayonne, 15, 0);
        //RencontreSportive R4_ProD2 = new RencontreSportive(Rugby, Prod2, Brive, Bayonne, 15, 0);

        Journee2_ProD2.AjouterRencontreSportive(R1_ProD2);
        Journee2_ProD2.AjouterRencontreSportive(R2_ProD2);
        Journee2_ProD2.AjouterRencontreSportive(R3_ProD2);
        //Journee1_ProD2.AjouterRencontreSportive(R4_ProD2);

        //Prod2.CréeClassement(Journee1_ProD2);
        Prod2.CréeClassement(Journee2_ProD2);

        //*************************************FOOT***************************************************




        Actualite actu_Foot = new Actualite("ASSE", "null");
        Sport Foot = new Sport { Nom = "Foot", LiActualite = new ObservableCollection<Actualite>(), LiChampionnat = new ObservableCollection<Championnat>() };
        Championnat Ligue1 = new Championnat("Ligue 1");
        Foot.AjouterChampionnat(Ligue1);


        Championnat Ligue2 = new Championnat("Ligue 2");
        Foot.AjouterChampionnat(Ligue2);
        Equipe ClermontF = new Equipe("Clermont-Ferrand", "Superbe équipe");
        Equipe ToulonF = new Equipe("Toulon", "Equipe null");
        Equipe LyonF = new Equipe("Lyon", "Retraite de l'asm");
        Equipe ToulouseF = new Equipe("Toulouse", "Superbe équipe");
        Equipe MontpellierF = new Equipe("Montpellier", "Equipe null");
        Equipe LaRochelleF = new Equipe("La Rochelle", "Retraite de l'asm");

        Ligue1.AjouteEquipe(ClermontF);
        Ligue1.AjouteEquipe(ToulonF);
        Ligue1.AjouteEquipe(LyonF);
        Ligue1.AjouteEquipe(ToulouseF);
        Ligue1.AjouteEquipe(MontpellierF);
        Ligue1.AjouteEquipe(LaRochelleF);


        Journee Journee1_Ligue1 = new Journee(1);
        Journee Journee2_Ligue1 = new Journee(2);
        Journee Journee3_Ligue1 = new Journee(3);

        Clermont.AjouterCommentaire(U1, "Vraiment une belle équipe , un beau centre de formation");


        RencontreSportive R3J1_Ligue1 = new RencontreSportive(Foot, Ligue1, LaRochelleF, ClermontF, 0, 3);
        RencontreSportive R6J1_Ligue1 = new RencontreSportive(Foot, Ligue1, ToulouseF, MontpellierF, 0, 1);

        Journee1_Ligue1.AjouterRencontreSportive(R3J1_Ligue1);
        Journee1_Ligue1.AjouterRencontreSportive(R6J1_Ligue1);


        Ligue1.CréeClassement(Journee1_Ligue1);


        lesSports.Add(Foot);
        Foot.AjouterActualite(actu_Foot);
        //Rugby.AjouterActualite(actu_Foot);

        return lesSports;
    }

    public override ObservableCollection<Utilisateur> loadUtilisateur()
    {
        ObservableCollection<Utilisateur> lesUtilisateur = new ObservableCollection<Utilisateur>();

        lesUtilisateur.Add(new Utilisateur { Nom = "Supp1", Prenom = "Tata", Adresse = "Tata@gmail.com", Mdp = "tata" });
        lesUtilisateur.Add(new Utilisateur { Nom = "Tata", Prenom = "Tata", Adresse = "Tata@gmail.com", Mdp = "tata", Admin = true });
        return lesUtilisateur;
    }

    public override ObservableCollection<Sport> LesSports
    {
        get
        {
            return lesSports;
        }
    }

    private ObservableCollection<Sport> lesSports = new ObservableCollection<Sport>();


    public override ObservableCollection<Utilisateur> LesUtilisateur
    {
        get
        {
            return lesUtilisateur;

        }
    }
    private ObservableCollection<Utilisateur> lesUtilisateur = new ObservableCollection<Utilisateur>();

    public override void Add(Sport sport)
    {
        lesSports.Add(sport);

    }


    public override void Remove(Utilisateur utilisateur)
    {
        if (utilisateur == null)
        {
            throw new Exception("utilisateur vide");
        }
        else
        {
            lesUtilisateur.Remove(utilisateur);

        }

    }

    public override void Remove(Sport sport)
    {
        if (sport == null)
        {
            throw new Exception("Sport vide");
        }
        else
        {
            lesSports.Remove(sport);

        }
    }

    public override void Remove(Sport sport, Championnat championnat)
    {
        foreach (Sport s1 in lesSports)
        {
            if (s1.Equals(sport))
            {
                for (int i = 0; i < s1.LiChampionnat.Count; i++)
                {
                    if (s1.LiChampionnat[i].Equals(championnat))
                    {
                        s1.LiChampionnat.Remove(s1.LiChampionnat[i]);

                    }
                    i++;
                }
            }
        }
    }

    public override void Remove(Sport sport, Actualite actualite)
    {
        foreach (Sport s1 in lesSports)
        {
            if (s1.Equals(sport))
            {
                for (int i = 0; i < s1.LiActualite.Count; i++)
                {
                    if (s1.LiActualite[i].Equals(actualite))
                    {
                        s1.LiActualite.Remove(s1.LiActualite[i]);

                    }
                    i++;
                }
            }
        }
    }

    public override void Remove(Sport sport, Championnat championnat, Equipe equipe)
    {
        foreach (Sport s1 in lesSports)
        {
            if (s1.Equals(sport))
            {
                for (int i = 0; i < s1.LiChampionnat.Count; i++)
                {
                    if (s1.LiChampionnat[i].Equals(championnat))
                    {
                        for (int j = 0; j < s1.LiChampionnat[i].LiEquipe.Count; j++)
                        {
                            if (s1.LiChampionnat[i].LiEquipe[j].Equals(equipe))
                            {
                                s1.LiChampionnat[i].LiEquipe.Remove(s1.LiChampionnat[i].LiEquipe[j]);

                            }

                        }

                    }
                }
            }
        }
    }

    public override void Update(Utilisateur utilisateur)
    {
        for (int i = 0; i < lesUtilisateur.Count; i++)
        {
            if (lesUtilisateur[i].Equals(utilisateur))
            {
                lesUtilisateur[i] = utilisateur;

            }
        }
    }

    public override void Update(Sport sport)
    {
        for (int i = 0; i < lesSports.Count; i++)
        {
            if (lesSports[i].Equals(sport))
            {
                lesSports[i] = sport;

            }
        }
    }

    public override void Update(Sport sport, Championnat C1)
    {
        for (int i = 0; i < sport.LiChampionnat.Count; i++)
        {
            if (sport.LiChampionnat[i].Equals(C1))
            {
                sport.LiChampionnat[i] = C1;

            }
        }
    }

    public override void Update(Sport sport, Actualite A1)
    {
        for (int i = 0; i < sport.LiActualite.Count; i++)
        {
            if (sport.LiActualite[i].Equals(A1))
            {
                sport.LiActualite[i] = A1;

            }
        }
    }



    public override void Update(Sport S1, Championnat c1, Equipe e1, Utilisateur u1, string description)
    {
        foreach (Sport sport in lesSports)
        {
            if (sport.Equals(S1))
            {
                foreach (Championnat championnat in sport.LiChampionnat)
                {
                    if (championnat.Equals(c1))
                    {
                        foreach (Equipe equipe in c1.LiEquipe)
                        {
                            if (equipe.Equals(e1))
                            {
                                equipe.AjouterCommentaire(u1, description);

                            }
                        }
                    }
                }
            }
        }
    }

    public override void Update(Sport S1, Championnat c1, Journee j1, Equipe e1, Equipe e2, int ScoreE1, int scoreE2)
    {
        foreach (Sport sport in lesSports)
        {
            if (sport.Equals(S1))
            {
                foreach (Championnat championnat in sport.LiChampionnat)
                {
                    if (championnat.Equals(c1))
                    {

                        foreach (Journee journee in championnat.DictionnaireClassement.Keys)
                        {
                            if (journee.Equals(j1))
                            {
                                j1.AjouterRencontreSportive(new RencontreSportive(S1, c1, e1, e2, ScoreE1, scoreE2));

                            }
                        }
                    }
                }
            }
        }
    }

    public override void Add(Sport sport, Championnat championnat, Equipe equipe)
    {
        foreach (Sport s1 in lesSports)
        {
            if (s1.Equals(sport))
            {
                for (int i = 0; i < s1.LiChampionnat.Count; i++)
                {
                    if (s1.LiChampionnat[i].Equals(championnat))
                    {
                        s1.LiChampionnat[i].AjouteEquipe(equipe);
                        
                    }
                }
            }
        }
    }

    public override void Add(Utilisateur utilisateur)
    {
        if (lesUtilisateur.Contains(utilisateur)) return;
        lesUtilisateur.Add(utilisateur);
    }

    public override void Add(Sport sport, Championnat championnat)
    {
        foreach (Sport s1 in lesSports)
        {
            if (s1.Equals(sport))
            {
                s1.AjouterChampionnat(championnat);
                
            }
        }
    }
}

















    /*public Stub()
     {
         try
         {

             Sport Rugby = new Sport("Rugby");

             Actualite Article_Rugby1 = new Actualite("L'asm en final", "Bla bla bla", "/img/asm");
             Championnat Top14 = new Championnat("Top 14");

             Rugby.AjouterActualite(Article_Rugby1);
             Rugby.AjouterChampionnat(Top14);

             Console.Write(Rugby.ToString());


             Equipe ASM = new Equipe("ASM", "Superbe équipe", "/Image/fond.jpg");
             Equipe Toulon = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
             Equipe LOU = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");
             Journee Journe1 = new Journee();

             Top14.AjouteEquipe(Toulon);
             Top14.AjouteEquipe(ASM);
             Top14.AjouteEquipe(LOU);

             //RencontreSportive R1 = new RencontreSportive(Top14, ASM, Toulon, 150, 0);
             //RencontreSportive R2 = new RencontreSportive(Top14, ASM, LOU, 15, 0);

            // RencontreSportive R3 = new RencontreSportive(Top14, LOU, ASM, 15, 0);
            // RencontreSportive R4 = new RencontreSportive(Top14, Toulon, ASM, 15, 0);



            // Journe1.AjouterRencontreSportive(R1);
             //Journe1.AjouterRencontreSportive(R2);
            // Journe1.AjouterRencontreSportive(R3);
            // Journe1.AjouterRencontreSportive(R4);

             Top14.CréeClassement(Journe1);

             Console.WriteLine(Top14.ToString());


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
         catch (Exception e)
         {
             Console.WriteLine(e);
         }
     }

     public override List<Equipe> ListEquipe()
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

     public Ensemble loadSports()

     {

     Ensemble e = new Ensemble();

     Sport Rugby = new Sport("Rugby");
     Sport Football = new Sport("Football");

     e.AjouterSport(Rugby);
     e.AjouterSport(Football);
     Championnat Top14 = new Championnat("Top14");
     Championnat Ligue1 = new Championnat("Ligue1");


     Rugby.AjouterChampionnat(Top14);
     Football.AjouterChampionnat(Ligue1);



         Equipe ASM = new Equipe("ASM", "Superbe équipe", "/Image/fond.jpg");
         Equipe Toulon = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
         Equipe LOU = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");

     Equipe Asse = new Equipe("Asse", "Superbe équipe", "/Image/fond.jpg");
     Equipe Psg = new Equipe("Psg", "Equipe null", "/Image/fond.jpg");

     Ligue1.AjouteEquipe(Asse);
     Ligue1.AjouteEquipe(Psg);


     Actualite Article_Rugby1 = new Actualite("L'asm en final", "Bla bla bla", "/img/asm");
     Actualite Article_Rugby2 = new Actualite("L'asm perd en final", "Bla bla bla", "/img/asm");
     Actualite Article_Foot1 = new Actualite("L'assse en final", "Bla bla bla", "/img/asm");
     Rugby.AjouterActualite(Article_Rugby1);
     Rugby.AjouterActualite(Article_Rugby2);
     //Problème ça affiche pas les actu de foot et les actu de rugby restent quand on sélectionne rugby, bizarre, je pense qu'il y a un pb dans le code.
     Football.AjouterActualite(Article_Foot1);

     Top14.AjouteEquipe(Toulon);
         Top14.AjouteEquipe(ASM);
         Top14.AjouteEquipe(LOU);



         RencontreSportive R1 = new RencontreSportive(Rugby,Top14, ASM, Toulon, 150, 0);
         RencontreSportive R2 = new RencontreSportive(Rugby,Top14, ASM, LOU, 15, 0);

         RencontreSportive R3 = new RencontreSportive(Rugby,Top14, LOU, ASM, 15, 0);
         RencontreSportive R4 = new RencontreSportive(Rugby,Top14, Toulon, ASM, 15, 0);
         Journee Journe1 = new Journee();
         Journee Journe2 = new Journee();

         Journe1.AjouterRencontreSportive(R1);
         Journe1.AjouterRencontreSportive(R2);
         Journe1.AjouterRencontreSportive(R3);
         Journe1.AjouterRencontreSportive(R4);

         Journe2.AjouterRencontreSportive(R1);
         Journe2.AjouterRencontreSportive(R2);


         Top14.CréeClassement(Journe1);
         Top14.CréeClassement(Journe2);


     return e;
     }

    public  Championnat loadChampionnat2()
    {
     Championnat ProD2 = new Championnat("Top14");


     Equipe Toulouse = new Equipe("ASM", "Superbe équipe", "/Image/fond.jpg");
     Equipe Paris = new Equipe("Toulon", "Equipe null", "/Image/fond.jpg");
     Equipe Aurillac = new Equipe("Lou", "Retraite de l'asm", "/Image/fond.jpg");



     ProD2.AjouteEquipe(Toulouse);
     ProD2.AjouteEquipe(Paris);
     ProD2.AjouteEquipe(Aurillac);



     //RencontreSportive R1 = new RencontreSportive(ProD2, Paris, Toulouse, 150, 0);
    // RencontreSportive R2 = new RencontreSportive(ProD2, Paris, Aurillac, 15, 0);

     //RencontreSportive R3 = new RencontreSportive(ProD2, Aurillac, Paris, 15, 0);
    // RencontreSportive R4 = new RencontreSportive(ProD2, Toulouse, Paris, 15, 0);
    // Journee Journe1 = new Journee();
    // Journee Journe2 = new Journee();

     //Journe1.AjouterRencontreSportive(R1);
     //Journe1.AjouterRencontreSportive(R2);
    // Journe1.AjouterRencontreSportive(R3);
    // Journe1.AjouterRencontreSportive(R4);

     //Journe2.AjouterRencontreSportive(R1);
     //Journe2.AjouterRencontreSportive(R2);


     //ProD2.CréeClassement(Journe1);
     //ProD2.CréeClassement(Journe2);



     return ProD2;
    }



     public List<Utilisateur> loadUtilisateur()
     {
     List<Utilisateur> liUtilisateur = new List<Utilisateur>();
     Utilisateur u1 = new Utilisateur("Champiat", "Gabriel", "14 ddd", "lala");
     Utilisateur u2 = new Utilisateur("Cmpiat", "Giel", "16 ddd", "toto");
     liUtilisateur.Add(u1);
     liUtilisateur.Add(u2);

     return liUtilisateur;*/

   