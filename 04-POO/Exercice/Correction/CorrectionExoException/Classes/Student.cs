using CorrectionExoException.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoException.Classes
{
    internal class Student
    {
        public string Nom {  get; set; }
        private int _age;
        public int Age { 
            get => _age; 
            set {
                if (value <= 0) throw new InvalideAgeException("Age invalide pour notre student");
                _age = value;
            } 
        }

        public Student(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }
    }
}
