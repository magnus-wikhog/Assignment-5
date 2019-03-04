﻿///<summary>
/// Namn:       Magnus Wikhög
/// Projekt:    _projekt_namn__
/// Inlämnad:   _inlämnad_datum_
///</summary>
using Assignment.ListManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Recipe {

    /// <summary>
    /// A class representing a Recipe.
    /// </summary>
    [Serializable]
    public class Recipe {
        List<string> mIngredients;

        public string Name;
        public List<string> Ingredients { get => mIngredients; }


        /// <summary>
        /// A constructor for creating a Recipe instance.
        /// </summary>
        public Recipe() {
            mIngredients = new List<string>();
        }


        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        override
        public string ToString() {
            return Name + ", " + Ingredients.Aggregate( (a, b) => a.ToString()+", "+b.ToString() );
        }
    }
}
