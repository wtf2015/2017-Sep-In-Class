﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class WeightedMark
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        // adding a ? to a value type allows it to store a null value
        public double? _EarnedMark; // a field as the "backing store"
        public double? EarnedMark // Explicitly implment the get/set
        {
            get { return _EarnedMark; }
            set
            {
                // The number being assigned is in a keyword called value
                if (value < 0 || value > Weight)
                    throw new ArgumentException($"Earned marks must be from zero to {Weight}");
                _EarnedMark = value;
            }
        }

        public WeightedMark(string name, double weight)
        {
            // Validate the info coming in
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Weighted marks require a name");
            if (weight <= 0 || weight > 100)
                throw new ArgumentException("Weighted marks must be greater than zero and lesss than or equal to 100", nameof(weight));

            // Store the "sanitized" input
            Name = name.Trim(); // "sanitize" by removing leading/trailing white space
            Weight = weight;
        }
    }
}
