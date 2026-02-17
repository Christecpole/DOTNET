using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Builder
{
    internal class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        private Person(Builder builder) {
            FirstName = builder.FirstName ?? "";
            LastName = builder.LastName ?? "";
            Age = builder.Age;
        }

        public override string ToString()
        {
            return $"Person : fistname : {FirstName} lastname : {LastName} age : {Age}";
        }

        public sealed class Builder
        {
            public string? FirstName { get; private set; }
            public string? LastName { get; private set; }
            public int Age { get; private set; }

            public Builder FirstNameValue(string firstname)
            {
                FirstName = firstname;
                return this;
            }

            public Builder LastNameValue(string lastname)
            {
                LastName = lastname;
                return this;
            }

            public Builder AgeValue(int age)
            {
                Age = age;
                return this;
            }

            public Person Build() => new Person(this);

        }
    }
}
