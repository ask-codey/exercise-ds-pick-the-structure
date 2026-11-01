using System.Diagnostics;
using PickTheStructure;

namespace PickTheStructure.Tests;

// The tests for your four methods. You don't need to change this file.
// Each problem has a test with a big input that is only fast with the right
// structure. If one of them runs for a long time, that's the test telling you
// to choose another structure: stop it with Ctrl+C.

[TestClass]
public class ProblemsTests
{
    private static readonly List<(string, string)> Tracks = new List<(string, string)> { ("Elm", "Oak"), ("Oak", "Pine"), ("Pine", "Harbor"), ("Elm", "Maple"), ("Maple", "Cedar"), ("Cedar", "Pine"), ("Ferry", "Island") };

    private static void AssertFast(Stopwatch watch, string what)
    {
        Assert.IsTrue(watch.Elapsed.TotalSeconds < 2, "Not yet: " + what + " took " + watch.Elapsed.TotalSeconds.ToString("0.0") + " seconds. With the right structure it takes well under one.");
    }

    [TestMethod]
    public void CountTakenCountsTheNamesAlreadyUsed()
    {
        Assert.AreEqual(1, Problems.CountTaken(new List<string> { "river_fox", "neon_owl" }, new List<string> { "neon_owl", "lemon_bee" }), "Not yet: neon_owl is taken and lemon_bee is free, so 1.");
        Assert.AreEqual(2, Problems.CountTaken(new List<string> { "river_fox", "neon_owl" }, new List<string> { "neon_owl", "river_fox", "slow_cat" }), "Not yet: neon_owl and river_fox are both taken.");
        Assert.AreEqual(0, Problems.CountTaken(new List<string>(), new List<string> { "river_fox" }), "Not yet: with nothing taken, no name is taken.");
    }

    [TestMethod]
    public void CountTakenIsFastFor100000Names()
    {
        List<string> taken = new List<string>();
        List<string> wanted = new List<string>();
        for (int i = 0; i < 100000; i++)
        {
            taken.Add("user" + i);
            wanted.Add("user" + (i * 2));
        }
        Stopwatch watch = Stopwatch.StartNew();
        int count = Problems.CountTaken(taken, wanted);
        watch.Stop();
        Assert.AreEqual(50000, count, "Not yet: half of the 100,000 wanted names are taken.");
        AssertFast(watch, "checking 100,000 names");
    }

    [TestMethod]
    public void MostPlayedFindsTheTopSong()
    {
        Assert.AreEqual("Slow Rain", Problems.MostPlayed(new List<string> { "Slow Rain", "Lemon Skies", "Slow Rain" }), "Not yet: Slow Rain was played twice.");
        Assert.AreEqual("Lemon Skies", Problems.MostPlayed(new List<string> { "Midnight Bus", "Lemon Skies" }), "Not yet: a tie goes to the title first from A to Z.");
        Assert.AreEqual("", Problems.MostPlayed(new List<string>()), "Not yet: with no plays, return an empty string.");
    }

    [TestMethod]
    public void MostPlayedIsFastFor200000Plays()
    {
        List<string> plays = new List<string>();
        for (int i = 0; i < 200000; i++)
        {
            plays.Add("Song " + (i % 50000));
        }
        plays.AddRange(new List<string> { "Song 777", "Song 777", "Song 777" });
        Stopwatch watch = Stopwatch.StartNew();
        string top = Problems.MostPlayed(plays);
        watch.Stop();
        Assert.AreEqual("Song 777", top, "Not yet: every song was played 4 times except Song 777, played 7.");
        AssertFast(watch, "counting 200,000 plays");
    }

    [TestMethod]
    public void FewestStopsCountsTheShortestRide()
    {
        Assert.AreEqual(3, Problems.FewestStops(Tracks, "Elm", "Harbor"), "Not yet: Elm, Oak, Pine, Harbor is 3 stops.");
        Assert.AreEqual(2, Problems.FewestStops(Tracks, "Elm", "Cedar"), "Not yet: Elm, Maple, Cedar is 2 stops.");
        Assert.AreEqual(0, Problems.FewestStops(Tracks, "Elm", "Elm"), "Not yet: a station is 0 stops from itself.");
        Assert.AreEqual(-1, Problems.FewestStops(Tracks, "Elm", "Island"), "Not yet: no tracks join Elm and Island.");
        Assert.AreEqual(-1, Problems.FewestStops(Tracks, "Elm", "Airport"), "Not yet: Airport isn't on the map.");
    }

    [TestMethod]
    public void FewestStopsIsFastOnABigMap()
    {
        List<(string, string)> grid = new List<(string, string)>();
        for (int row = 0; row < 150; row++)
        {
            for (int column = 0; column < 150; column++)
            {
                if (column < 149) grid.Add(("S" + row + "-" + column, "S" + row + "-" + (column + 1)));
                if (row < 149) grid.Add(("S" + row + "-" + column, "S" + (row + 1) + "-" + column));
            }
        }
        Stopwatch watch = Stopwatch.StartNew();
        int stops = Problems.FewestStops(grid, "S0-0", "S149-149");
        watch.Stop();
        Assert.AreEqual(298, stops, "Not yet: corner to corner of a 150 by 150 grid of stations is 298 stops.");
        AssertFast(watch, "a map of 22,500 stations");
    }

    [TestMethod]
    public void BracketsBalancedChecksEveryKind()
    {
        Assert.IsTrue(Problems.BracketsBalanced("(1 + [2 * 3])"), "Not yet: every bracket here is closed by its own kind, in order.");
        Assert.IsTrue(Problems.BracketsBalanced("total = (price * [1 + tax]) - {discount}"), "Not yet: (, [ and { are each closed in the right order.");
        Assert.IsTrue(Problems.BracketsBalanced("no brackets"), "Not yet: a line with no brackets is balanced.");
        Assert.IsFalse(Problems.BracketsBalanced("(1 + 2]"), "Not yet: ( is closed by ], the wrong kind.");
        Assert.IsFalse(Problems.BracketsBalanced("(("), "Not yet: two brackets are never closed.");
        Assert.IsFalse(Problems.BracketsBalanced(")("), "Not yet: ) comes before anything it could close.");
    }

    [TestMethod]
    public void BracketsBalancedIsFastForDeepNesting()
    {
        string deep = new string('(', 100000) + new string(')', 100000);
        Stopwatch watch = Stopwatch.StartNew();
        bool balanced = Problems.BracketsBalanced(deep);
        bool missingOne = Problems.BracketsBalanced(deep.Substring(1));
        watch.Stop();
        Assert.IsTrue(balanced, "Not yet: 100,000 ( then 100,000 ) is balanced.");
        Assert.IsFalse(missingOne, "Not yet: with one ( missing, the last ) has nothing to close.");
        AssertFast(watch, "checking 200,000 brackets");
    }
}
