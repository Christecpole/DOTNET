using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorrectionEFcore.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom {  get; set; }
        public DateTime DateNaissance {  get; set; }
        //[Range(0,int.MaxValue)]
        public int Age {  get; set; }
        public string Genre {  get; set; }
        public string Telephone {  get; set; }
        public string Email {  get; set; }

        public Contact(string nom, string prenom, DateTime dateNaissance, int age, string genre, string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Age = age;
            Genre = genre;
            Telephone = telephone;
            Email = email;
        }

        public Contact()
        {
        }

        public override string? ToString()
        {
            return $"Contact N°{Id} : {Nom} {Prenom}, Age : {Age}, Genre : {Genre}, Telephone : {Telephone}, Email : {Email},Date de naissance : {DateNaissance}";
        }
    }
}
