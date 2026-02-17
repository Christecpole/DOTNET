using GestionFacture.Calcul;
using GestionFacture.Models;
using GestionFacture.Notification;
using GestionFacture.Persistance;
using GestionFacture.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Services
{
    //Il ne va plus faire le travail lui même, il coordonne et délègue.
    internal class ServiceFacture
    {
        //champs privés: on reçoit chaque dépendance par le constructeur
        private readonly ValidateurFacture _validateur;
        private readonly CalculateurTva _calculateur;
        private readonly DepotFactureFichier _depot;
        private readonly NotificationConsole _notification;

        //Constructeur : on reçoit toutes les classes. ON ne les crée pas nous même.
        public ServiceFacture(ValidateurFacture validateurFacture, CalculateurTva calculateur, DepotFactureFichier depot, NotificationConsole notification)
        {
            _validateur = validateurFacture;
            _calculateur = calculateur;
            _depot = depot;
            _notification = notification;
        }

        public void Enregistrer(Facture facture)
        {
            _validateur.Valider(facture); // validation
            facture.Montant = _calculateur.CalculerAvecTva(facture.Montant); // Calcul de la tva
            _depot.Sauvegarder(facture); // sauvegarde
            _notification.Notifier(facture.Client, "Facture enregistrée avec succès"); // Notification
        }

        //public void Enregistrer(Facture facture)
        //{
            // validation (1ère responsabilité) - si montant invalide on lève une exception
            //if(facture.Montant <= 0)
            //{
            //    throw new ArgumentException("Le montant doit être positif.");
            //}

            // Calcul de la tva (2ème responsabilité) - on modifie le montant
            //facture.Montant = facture.Montant * 1.20m;

            // Sauvegarder (3ème responsabilité) - on écrit dans un fichier
            //string contenu = $"Facture {facture.Id} - Client: {facture.Client} - Montant: {facture.Montant}";
            //File.WriteAllText($"facture_{facture.Id}.txt", contenu);

            //Notification (4ème responsabilité) - on affiche un message
            //Console.WriteLine($"[Notification pour {facture.Client}] Facture enregistrée avec succès.");

            // Problème : 4 responsabilités dans une seule classe. Si on change la TVA, le format de fichier, ou le canal de notification on modifie la même classe. Risque de régression. 
        //}
    }
}
