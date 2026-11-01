import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

import java.util.ArrayList;
import java.util.List;
import org.junit.jupiter.api.Test;

// The tests for your four methods. You don't need to change this file.
// Each problem has a test with a big input that is only fast with the right
// structure. If one of them runs for a long time, that's the test telling you
// to choose another structure: stop it with Ctrl+C.
class ProblemsTest {
    private static final List<List<String>> TRACKS = List.of(List.of("Elm", "Oak"), List.of("Oak", "Pine"), List.of("Pine", "Harbor"), List.of("Elm", "Maple"), List.of("Maple", "Cedar"), List.of("Cedar", "Pine"), List.of("Ferry", "Island"));

    private static void assertFast(long started, String what) {
        double seconds = (System.nanoTime() - started) / 1e9;
        assertTrue(seconds < 2, "Not yet: " + what + " took " + String.format("%.1f", seconds) + " seconds. With the right structure it takes well under one.");
    }

    @Test
    void countTakenCountsTheNamesAlreadyUsed() {
        assertEquals(1, Problems.countTaken(List.of("river_fox", "neon_owl"), List.of("neon_owl", "lemon_bee")), "Not yet: neon_owl is taken and lemon_bee is free, so 1.");
        assertEquals(2, Problems.countTaken(List.of("river_fox", "neon_owl"), List.of("neon_owl", "river_fox", "slow_cat")), "Not yet: neon_owl and river_fox are both taken.");
        assertEquals(0, Problems.countTaken(List.of(), List.of("river_fox")), "Not yet: with nothing taken, no name is taken.");
    }

    @Test
    void countTakenIsFastFor100000Names() {
        List<String> taken = new ArrayList<>();
        List<String> wanted = new ArrayList<>();
        for (int i = 0; i < 100000; i++) {
            taken.add("user" + i);
            wanted.add("user" + (i * 2));
        }
        long started = System.nanoTime();
        int count = Problems.countTaken(taken, wanted);
        assertEquals(50000, count, "Not yet: half of the 100,000 wanted names are taken.");
        assertFast(started, "checking 100,000 names");
    }

    @Test
    void mostPlayedFindsTheTopSong() {
        assertEquals("Slow Rain", Problems.mostPlayed(List.of("Slow Rain", "Lemon Skies", "Slow Rain")), "Not yet: Slow Rain was played twice.");
        assertEquals("Lemon Skies", Problems.mostPlayed(List.of("Midnight Bus", "Lemon Skies")), "Not yet: a tie goes to the title first from A to Z.");
        assertEquals("", Problems.mostPlayed(List.of()), "Not yet: with no plays, return an empty string.");
    }

    @Test
    void mostPlayedIsFastFor200000Plays() {
        List<String> plays = new ArrayList<>();
        for (int i = 0; i < 200000; i++) {
            plays.add("Song " + (i % 50000));
        }
        plays.addAll(List.of("Song 777", "Song 777", "Song 777"));
        long started = System.nanoTime();
        String top = Problems.mostPlayed(plays);
        assertEquals("Song 777", top, "Not yet: every song was played 4 times except Song 777, played 7.");
        assertFast(started, "counting 200,000 plays");
    }

    @Test
    void fewestStopsCountsTheShortestRide() {
        assertEquals(3, Problems.fewestStops(TRACKS, "Elm", "Harbor"), "Not yet: Elm, Oak, Pine, Harbor is 3 stops.");
        assertEquals(2, Problems.fewestStops(TRACKS, "Elm", "Cedar"), "Not yet: Elm, Maple, Cedar is 2 stops.");
        assertEquals(0, Problems.fewestStops(TRACKS, "Elm", "Elm"), "Not yet: a station is 0 stops from itself.");
        assertEquals(-1, Problems.fewestStops(TRACKS, "Elm", "Island"), "Not yet: no tracks join Elm and Island.");
        assertEquals(-1, Problems.fewestStops(TRACKS, "Elm", "Airport"), "Not yet: Airport isn't on the map.");
    }

    @Test
    void fewestStopsIsFastOnABigMap() {
        List<List<String>> grid = new ArrayList<>();
        for (int row = 0; row < 150; row++) {
            for (int column = 0; column < 150; column++) {
                if (column < 149) grid.add(List.of("S" + row + "-" + column, "S" + row + "-" + (column + 1)));
                if (row < 149) grid.add(List.of("S" + row + "-" + column, "S" + (row + 1) + "-" + column));
            }
        }
        long started = System.nanoTime();
        int stops = Problems.fewestStops(grid, "S0-0", "S149-149");
        assertEquals(298, stops, "Not yet: corner to corner of a 150 by 150 grid of stations is 298 stops.");
        assertFast(started, "a map of 22,500 stations");
    }

    @Test
    void bracketsBalancedChecksEveryKind() {
        assertTrue(Problems.bracketsBalanced("(1 + [2 * 3])"), "Not yet: every bracket here is closed by its own kind, in order.");
        assertTrue(Problems.bracketsBalanced("total = (price * [1 + tax]) - {discount}"), "Not yet: (, [ and { are each closed in the right order.");
        assertTrue(Problems.bracketsBalanced("no brackets"), "Not yet: a line with no brackets is balanced.");
        assertFalse(Problems.bracketsBalanced("(1 + 2]"), "Not yet: ( is closed by ], the wrong kind.");
        assertFalse(Problems.bracketsBalanced("(("), "Not yet: two brackets are never closed.");
        assertFalse(Problems.bracketsBalanced(")("), "Not yet: ) comes before anything it could close.");
    }

    @Test
    void bracketsBalancedIsFastForDeepNesting() {
        String deep = "(".repeat(100000) + ")".repeat(100000);
        long started = System.nanoTime();
        boolean balanced = Problems.bracketsBalanced(deep);
        boolean missingOne = Problems.bracketsBalanced(deep.substring(1));
        assertTrue(balanced, "Not yet: 100,000 ( then 100,000 ) is balanced.");
        assertFalse(missingOne, "Not yet: with one ( missing, the last ) has nothing to close.");
        assertFast(started, "checking 200,000 brackets");
    }
}
