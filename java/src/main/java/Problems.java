import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// Four small problems from apps you use. The comment above each method says
// what it should return, with examples. Replace each return line with your
// own code, and write the structure you chose on its Structure: line.
// Each track is a list of two stations: List.of("Elm", "Oak").
public class Problems {
    /*
     * A sign-up form: how many of the wanted usernames are already taken?
     * The site has up to 100,000 taken names, and checks a name on every
     * visit, so this has to stay fast.
     *
     * countTaken(["river_fox", "neon_owl"], ["neon_owl", "lemon_bee"]) -> 1
     * countTaken([], ["river_fox"]) -> 0
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static int countTaken(List<String> taken, List<String> wanted) {
        return 0;
    }

    /*
     * A music app's "most played" badge. Each item in plays is one play of
     * a song. Return the title played the most times. A tie goes to the
     * title that comes first from A to Z. No plays at all: return "".
     *
     * mostPlayed(["Slow Rain", "Lemon Skies", "Slow Rain"]) -> "Slow Rain"
     * mostPlayed(["Midnight Bus", "Lemon Skies"]) -> "Lemon Skies"
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static String mostPlayed(List<String> plays) {
        return "";
    }

    /*
     * A subway app: the fewest stops from one station to another. Each
     * track joins two neighboring stations, and trains run both ways.
     * A station is 0 stops from itself. Return -1 when no tracks join
     * them, or when either station isn't on the map.
     *
     * On the demo's map:
     * fewestStops(tracks, "Elm", "Harbor") -> 3
     * fewestStops(tracks, "Elm", "Island") -> -1
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static int fewestStops(List<List<String>> tracks, String from, String to) {
        return 0;
    }

    /*
     * A code editor checks the brackets in a line: every (, [ and { must be
     * closed by the same kind, ), ] or }, in the right order. Every other
     * character is ignored. A line with no brackets is balanced.
     *
     * bracketsBalanced("(1 + [2 * 3])") -> true
     * bracketsBalanced("(1 + 2]") -> false
     * bracketsBalanced("((") -> false
     *
     * Structure: (write the structure you used, and this function's Big-O)
     */
    public static boolean bracketsBalanced(String text) {
        return false;
    }
}
