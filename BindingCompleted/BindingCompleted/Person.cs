﻿namespace BindingCompleted
{
    internal class Person
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Person(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}