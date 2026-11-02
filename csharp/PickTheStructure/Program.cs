using PickTheStructure;

// Tries your methods on small examples. Run it with: dotnet run --project PickTheStructure
List<string> taken = new List<string> { "river_fox", "neon_owl", "paper_kite" };
List<string> wanted = new List<string> { "neon_owl", "lemon_bee", "river_fox", "slow_cat" };
List<string> plays = new List<string> { "Slow Rain", "Lemon Skies", "Slow Rain", "Midnight Bus", "Lemon Skies", "Slow Rain" };
List<(string, string)> tracks = new List<(string, string)> { ("Elm", "Oak"), ("Oak", "Pine"), ("Pine", "Harbor"), ("Elm", "Maple"), ("Maple", "Cedar"), ("Cedar", "Pine"), ("Ferry", "Island") };
List<(string, int)> messages = new List<(string, int)> { ("Kai", 1), ("Kai", 2), ("Mia", 2), ("Kai", 3), ("Kai", 4), ("Kai", 9), ("Kai", 14) };

Console.WriteLine("Taken: " + Problems.CountTaken(taken, wanted) + " of " + wanted.Count + " wanted names");
Console.WriteLine("Most played: " + Problems.MostPlayed(plays));
Console.WriteLine("Fewest stops from Elm to Harbor: " + Problems.FewestStops(tracks, "Elm", "Harbor"));
foreach (string line in new string[] { "total = (price * [1 + tax]) - {discount}", "(1 + 2]" })
{
    Console.WriteLine(line + ": " + (Problems.BracketsBalanced(line) ? "balanced" : "not balanced"));
}
Console.WriteLine("Blocked: " + Problems.BlockedMessages(messages) + " of " + messages.Count + " messages");
