using CorrectionEFcore.Models;
using CorrectionEFcore.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CorrectionEFcore.Ihm
{
    internal class Ihm
    {

        private ContactRepository _repository = new ContactRepository();

        public void Start()
        {

            while (true)
            {
                Console.WriteLine("""
                === Liste de contacts ===
                1/ Crée un contact
                2/ Afficher tout les contact
                3/ Afficher un contact par son Id
                4/ Mettre a jour un contact
                5/ Supprimer un contact
                Entrer votre choix :
                """);

                string? entry = Console.ReadLine();

                switch (entry)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ShowAll();
                        break;
                    case "3":
                        ShowById();
                        break;
                    case "4":
                        Update();
                        break;
                    case "5":
                        Delete();
                        break;
                    default:
                        return;
                }
            }
            
        }


        public void AddContact()
        {
            Console.WriteLine("--- Ajout d'un contact ---");
            Console.WriteLine("Nom :");
            var nom = Console.ReadLine();
            Console.WriteLine("Prenom :");
            var prenom = Console.ReadLine();
            Console.WriteLine("Age :");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Genre :");
            var genre = Console.ReadLine();
            Console.WriteLine("Numeros de telephone :");
            var telephone = Console.ReadLine();
            Console.WriteLine("adress Email :");
            var email = Console.ReadLine();
            Console.WriteLine("Date de Naissance (dd-MM-yyyy):");
            var dateNaissanceStr = Console.ReadLine();

            DateTime dateNaissance = DateTime.ParseExact(dateNaissanceStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Contact contact = new Contact(nom, prenom, dateNaissance, age, genre,telephone,email);

            contact = _repository.Add(contact);

            if(contact == null)
            {
                Console.WriteLine("Erreure lors de l'ajout");
            }
            else
            {
                Console.WriteLine("Contact Enregistré : "+contact);
            }
        }

        public void ShowAll()
        {
            Console.WriteLine("--- Affichage de tout les contact ---");
            foreach (var contact in _repository.Get())
            {
                Console.WriteLine(contact);
            }
        }

        public void ShowById()
        {
            Console.WriteLine("--- Affichage d'un contact par son Id ---");
            Console.WriteLine("Id : ");
            int id = int.Parse(Console.ReadLine());

            Contact contact = _repository.Get(id);
            if (contact == null) 
            {
                Console.WriteLine("Aucun contact trouvé");
                return;
            }
          
                Console.WriteLine(contact);
        }

        public void Update()
        {
            Console.WriteLine("--- Mise a jour d'un contact ---");
            Console.WriteLine("Id : ");
            int id = int.Parse(Console.ReadLine());

            Contact contact = _repository.Get(id);
            if (contact == null)
            {
                Console.WriteLine("Aucun contact trouvé");
                return;
            }

            Console.WriteLine($"Nom ({contact.Nom}):");
            var nom = Console.ReadLine();
            Console.WriteLine($"Prenom ({contact.Prenom}):");
            var prenom = Console.ReadLine();
            Console.WriteLine($"Age ({contact.Age}):");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine($"Genre ({contact.Genre}):");
            var genre = Console.ReadLine();
            Console.WriteLine($"Numeros de telephone ({contact.Telephone}):");
            var telephone = Console.ReadLine();
            Console.WriteLine($"adress Email ({contact.Email}):");
            var email = Console.ReadLine();
            Console.WriteLine($"Date de Naissance (dd-MM-yyyy) ({contact.DateNaissance}):");
            var dateNaissanceStr = Console.ReadLine();

            DateTime dateNaissance = DateTime.ParseExact(dateNaissanceStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Contact contactUpdated = new Contact(nom, prenom, dateNaissance, age, genre, telephone, email);

            if(_repository.Update(id, contactUpdated))
            {
                Console.WriteLine("Contact mis a jour");
            }
            else
            {
                Console.WriteLine("Erreure lors de la mise a jour");
            }
        }


        public void Delete()
        {
            Console.WriteLine("--- Suppresion d'un contact ---");
            Console.WriteLine("Id : ");
            int id = int.Parse(Console.ReadLine());

            if (_repository.Delete(id))
            {
                Console.WriteLine("Contact supprimé");
            }
            else
            {
                Console.WriteLine("Erreure lors de la suppresion");
            }
        }

    }
}
