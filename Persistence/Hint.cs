using System;
namespace AnimalGuess.Persistence
{
    public class Hint
    {
		public int HintId { get; set; }
		public string Description { get; set; }
        public Animal Animal { get; set; }
    }
}
