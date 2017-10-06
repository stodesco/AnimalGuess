using System;
using System.Collections.Generic;

namespace AnimalGuess.Persistence
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public List<Hint> Hints { get; set; }
    }
}
