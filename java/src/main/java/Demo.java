import java.util.List;

// Tries your methods on small examples. Run it with: java src/main/java/Demo.java
public class Demo {
    public static void main(String[] args) {
        List<String> taken = List.of("river_fox", "neon_owl", "paper_kite");
        List<String> wanted = List.of("neon_owl", "lemon_bee", "river_fox", "slow_cat");
        List<String> plays = List.of("Slow Rain", "Lemon Skies", "Slow Rain", "Midnight Bus", "Lemon Skies", "Slow Rain");
        List<List<String>> tracks = List.of(List.of("Elm", "Oak"), List.of("Oak", "Pine"), List.of("Pine", "Harbor"), List.of("Elm", "Maple"), List.of("Maple", "Cedar"), List.of("Cedar", "Pine"), List.of("Ferry", "Island"));
        List<Problems.Message> messages = List.of(new Problems.Message("Kai", 1), new Problems.Message("Kai", 2), new Problems.Message("Mia", 2), new Problems.Message("Kai", 3), new Problems.Message("Kai", 4), new Problems.Message("Kai", 9), new Problems.Message("Kai", 14));

        System.out.println("Taken: " + Problems.countTaken(taken, wanted) + " of " + wanted.size() + " wanted names");
        System.out.println("Most played: " + Problems.mostPlayed(plays));
        System.out.println("Fewest stops from Elm to Harbor: " + Problems.fewestStops(tracks, "Elm", "Harbor"));
        for (String line : new String[] {"total = (price * [1 + tax]) - {discount}", "(1 + 2]"}) {
            System.out.println(line + ": " + (Problems.bracketsBalanced(line) ? "balanced" : "not balanced"));
        }
        System.out.println("Blocked: " + Problems.blockedMessages(messages) + " of " + messages.size() + " messages");
    }
}
