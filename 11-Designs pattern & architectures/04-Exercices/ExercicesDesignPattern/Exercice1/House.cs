using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice1
{
    internal class House
    {

        public int Floors { get; }
        public bool Haspool { get; }
        public string RoofType { get; }
        public string Color  { get; }

        private House(Builder builder) { 
            Floors = builder.Floors;
            Haspool = builder.Haspool;
            RoofType = builder.RoofType ?? "";
            Color = builder.Color ?? "";
        }

        public override string ToString()
        {
            return $"House : etages : {Floors} piscine :{Haspool} toiture : {RoofType}  couleur : {Color}";
        }

        public sealed class Builder
        {
            public int Floors { get; private set; }
            public bool Haspool { get; private set; }
            public string? RoofType { get; private set; }
            public string? Color { get; private set; }

            public Builder FloorsValue(int floors)
            {
                if(floors > 0)
                {
                    Floors = floors;
                    return this;
                }
                else
                {
                    return this;
                }
                
            }

            public Builder HasPoolValue(bool hasPool)
            {
                Haspool = hasPool;
                return this;
            }

            public Builder RoofTypeValue(string roofType)
            {
                RoofType = roofType;
                return this;
            }

            public Builder ColorValue(string color)
            {
                Color = color;
                return this;
            }

            public House Build() => new House(this);

        }
    }
}
