using System;
using System.Collections.Generic;
using AnimalGuess.Models;

namespace AnimalGuess.Persistence
{
    public class GameRepository
    {
        List<GameModel> Games { get; set; } = new List<GameModel>();
    }
}
