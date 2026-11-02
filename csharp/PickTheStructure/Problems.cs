namespace PickTheStructure;

// Five small problems from apps you use. The comment above each method says
// what it should return, with examples. Replace each return line with your
// own code, and write the structure you chose on its Structure: line.
public static class Problems
{
    /*
     * A sign-up form: how many of the wanted usernames are already taken?
     * The site has up to 100,000 taken names, and checks a name on every
     * visit, so this has to stay fast.
     *
     * CountTaken(["river_fox", "neon_owl"], ["neon_owl", "lemon_bee"]) -> 1
     * CountTaken([], ["river_fox"]) -> 0
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static int CountTaken(List<string> taken, List<string> wanted)
    {
        return 0;
    }

    /*
     * A music app's "most played" badge. Each item in plays is one play of
     * a song. Return the title played the most times. A tie goes to the
     * title that comes first from A to Z. No plays at all: return "".
     *
     * MostPlayed(["Slow Rain", "Lemon Skies", "Slow Rain"]) -> "Slow Rain"
     * MostPlayed(["Midnight Bus", "Lemon Skies"]) -> "Lemon Skies"
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static string MostPlayed(List<string> plays)
    {
        return "";
    }

    /*
     * A subway app: the fewest stops from one station to another. Each
     * track joins two neighboring stations, and trains run both ways.
     * A station is 0 stops from itself. Return -1 when no tracks join
     * them, or when either station isn't on the map.
     *
     * On the demo's map:
     * FewestStops(tracks, "Elm", "Harbor") -> 3
     * FewestStops(tracks, "Elm", "Island") -> -1
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static int FewestStops(List<(string, string)> tracks, string from, string to)
    {
        return 0;
    }

    /*
     * A code editor checks the brackets in a line: every (, [ and { must be
     * closed by the same kind, ), ] or }, in the right order. Every other
     * character is ignored. A line with no brackets is balanced.
     *
     * BracketsBalanced("(1 + [2 * 3])") -> true
     * BracketsBalanced("(1 + 2]") -> false
     * BracketsBalanced("((") -> false
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static bool BracketsBalanced(string text)
    {
        return false;
    }

    /*
     * A chat room's spam guard. Each message is a sender's name and the
     * second it was sent, and the messages come in time order. A message
     * is blocked when its sender already sent 3 or more messages in the 10
     * seconds before it: at a second greater than this one's minus 10.
     * Every message counts toward the limit, blocked or not. Return how
     * many messages are blocked. A busy room sends 200,000 messages an
     * hour, so this has to stay fast.
     *
     * BlockedMessages([("Kai", 1), ("Kai", 2), ("Kai", 3), ("Kai", 4)]) -> 1
     * BlockedMessages([("Kai", 1), ("Kai", 2), ("Kai", 3), ("Kai", 11)]) -> 0
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static int BlockedMessages(List<(string Sender, int Second)> messages)
    {
        return 0;
    }
}
