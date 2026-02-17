using CorrectionExoCompteBancaire.Classes.Compte;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes
{
    internal class Ihm
    {

        private Client client;

        public Ihm()
        {
            client = new Client("Toto", "Tata", "1235-1234-1234-1234", "123456789");
            
        }

        //methode de demarage de notre IHM
        public void Start()
        {
           
            while (true)
            {
                Console.WriteLine("=== Menu Principale ===");
                Console.WriteLine("1- Lister les comptes");
                Console.WriteLine("2- Créer un compte bancaire");
                Console.WriteLine("3- Effectuer un dépot");
                Console.WriteLine("4- Effectuer un retrait");
                Console.WriteLine("5- Afficher les operation et le solde");
                Console.WriteLine("Votre choix :");
                string entry = Console.ReadLine();

                switch (entry)
                {
                    case "1":
                        ShowAccount();
                        break;
                    case "2":
                        CreateCompteBancaire();
                        break;
                    case "3":
                        MakeDeposit();
                        break;
                    case "4":
                        MakeWithdraw();
                        break;
                    case "5":
                        ShowOperationAndBalance();
                        break;
                    default:
                        return;

                }
            }
        }


        private void ShowAccount()
        {
            int cpt = 1;
            //on recupere la liste des compte de notre client et on la parcour pour afficher chacun de ses comptes
            foreach (CompteBancaire cb in client.CompteBancaires)
            {
                Console.WriteLine($"compte n° {cpt++} {cb}");
            }
           
        }

        private void CreateCompteBancaire()
        {
            string accountType;

            Console.WriteLine("=== Création de compte ===");
            Console.WriteLine("1- Créer un compte courant");
            Console.WriteLine("2- Créer un compte épargne");
            Console.WriteLine("3- Créer un compte payant");
            string entry = Console.ReadLine();

            switch (entry)
            {
                case "1":
                    accountType = "courant";
                    break;
                case "2":
                    accountType = "epargne";
                    break;
                case "3":
                    accountType = "payant";
                    break;
                default:
                    return;
            }

            Console.WriteLine("Entrer le solde de votre compte :");
            double solde = Double.Parse(Console.ReadLine());

            CompteBancaire compteBancaire;

            //si l'utilisateur shouaite cree un compte epargne
            if (accountType == "epargne")
            {
                Console.WriteLine("Taux d'epargne de votre compte :");
                double tauxEpargne = Double.Parse(Console.ReadLine());
                compteBancaire = new CompteEpargne(solde, client, tauxEpargne);
            }
            //si l'utilisateur shouaite cree un compte payant
            else if (accountType == "payant")
            {
                Console.WriteLine("cout d'operation de votre compte :");
                double coutOperation = Double.Parse(Console.ReadLine());
                compteBancaire = new ComptePayant(solde, client, coutOperation);
            }
            //si l'utilisateur shouaite cree un compte courant
            else
            {
                compteBancaire = new CompteCourant(solde, client);
            }

            client.AddCompteBancaire(compteBancaire);
        }

        private void MakeDeposit()
        {
            //on demande a l'utilisateur quel compte il shouaite utiliser
            Console.WriteLine("Sur quelle compte voulez vous faire un depot :");
            //on fait -1 pour transformer le compte n°1 en index 0 de notre tableau
            int index = int.Parse(Console.ReadLine()) -1;

            Console.WriteLine("Quelle est le montant du depot :");
            double montant = Double.Parse(Console.ReadLine());

            //CompteBancaire  cb= client.CompteBancaires[index];
            //cb.Depot(montant);

            //une fois le compte choisi et le montant indiquer on recupere le compte dans la liste des compte de notre client et on appel ca methode depot pour realiser le depot
            client.CompteBancaires[index].Depot(montant);
        }

        private void MakeWithdraw()
        {
            Console.WriteLine("Sur quelle compte voulez vous faire un retrait :");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Quelle est le montant du retrait :");
            double montant = Double.Parse(Console.ReadLine());

            client.CompteBancaires[index].Retrait(montant);
        }

        private void ShowOperationAndBalance()
        {

            //on parcour la liste de tout les compte de notre client
            foreach (CompteBancaire cb in client.CompteBancaires)
            {
                //pour chacun des compte on affiche sont solde
                Console.WriteLine("Solde : "+ cb.Solde);
                //pour chaque compte on recupere la liste des operation et on parcour la liste pour les afficher
                foreach(Operation operation in cb.Operations)
                {
                    Console.WriteLine(operation);
                }
            }
        }















    }
}
