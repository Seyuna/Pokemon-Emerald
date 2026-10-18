using PokemonEmerald.Core.Game;
using PokemonEmerald.Core.Rng;
using PokemonEmerald.Core.Species;

Console.WriteLine("Hello, World!");

var rng = new EmeraldRng(12345);
var originalTrainerId = rng.Random32();
var factory = new PokemonFactory(rng);
var pokemon = factory.CreateNew(SpeciesId.Bulbasaur, 5, originalTrainerId);

Console.ReadKey();