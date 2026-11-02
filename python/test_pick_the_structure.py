# The tests for your five functions. You don't need to change this file.
# Each problem has a test with a big input that is only fast with the right
# structure. If one of them runs for a long time, that's the test telling you
# to choose another structure: stop it with Ctrl+C.
import time

from pick_the_structure import blocked_messages, brackets_balanced, count_taken, fewest_stops, most_played

TRACKS = [("Elm", "Oak"), ("Oak", "Pine"), ("Pine", "Harbor"), ("Elm", "Maple"), ("Maple", "Cedar"), ("Cedar", "Pine"), ("Ferry", "Island")]
MESSAGES = [("Kai", 1), ("Kai", 2), ("Mia", 2), ("Kai", 3), ("Kai", 4), ("Kai", 9), ("Kai", 14)]


def assert_fast(started, what):
    seconds = time.perf_counter() - started
    assert seconds < 2, f"Not yet: {what} took {seconds:.1f} seconds. With the right structure it takes well under one."


def test_count_taken_counts_the_names_already_used():
    assert count_taken(["river_fox", "neon_owl"], ["neon_owl", "lemon_bee"]) == 1, "Not yet: neon_owl is taken and lemon_bee is free, so 1."
    assert count_taken(["river_fox", "neon_owl"], ["neon_owl", "river_fox", "slow_cat"]) == 2, "Not yet: neon_owl and river_fox are both taken."
    assert count_taken([], ["river_fox"]) == 0, "Not yet: with nothing taken, no name is taken."


def test_count_taken_is_fast_for_100000_names():
    taken = [f"user{i}" for i in range(100000)]
    wanted = [f"user{i * 2}" for i in range(100000)]
    started = time.perf_counter()
    count = count_taken(taken, wanted)
    assert count == 50000, "Not yet: half of the 100,000 wanted names are taken."
    assert_fast(started, "checking 100,000 names")


def test_most_played_finds_the_top_song():
    assert most_played(["Slow Rain", "Lemon Skies", "Slow Rain"]) == "Slow Rain", "Not yet: Slow Rain was played twice."
    assert most_played(["Midnight Bus", "Lemon Skies"]) == "Lemon Skies", "Not yet: a tie goes to the title first from A to Z."
    assert most_played([]) == "", "Not yet: with no plays, return an empty string."


def test_most_played_is_fast_for_200000_plays():
    plays = [f"Song {i % 50000}" for i in range(200000)] + ["Song 777", "Song 777", "Song 777"]
    started = time.perf_counter()
    top = most_played(plays)
    assert top == "Song 777", "Not yet: every song was played 4 times except Song 777, played 7."
    assert_fast(started, "counting 200,000 plays")


def test_fewest_stops_counts_the_shortest_ride():
    assert fewest_stops(TRACKS, "Elm", "Harbor") == 3, "Not yet: Elm, Oak, Pine, Harbor is 3 stops."
    assert fewest_stops(TRACKS, "Elm", "Cedar") == 2, "Not yet: Elm, Maple, Cedar is 2 stops."
    assert fewest_stops(TRACKS, "Elm", "Elm") == 0, "Not yet: a station is 0 stops from itself."
    assert fewest_stops(TRACKS, "Elm", "Island") == -1, "Not yet: no tracks join Elm and Island."
    assert fewest_stops(TRACKS, "Elm", "Airport") == -1, "Not yet: Airport isn't on the map."


def test_fewest_stops_is_fast_on_a_big_map():
    grid = []
    for row in range(150):
        for column in range(150):
            if column < 149:
                grid.append((f"S{row}-{column}", f"S{row}-{column + 1}"))
            if row < 149:
                grid.append((f"S{row}-{column}", f"S{row + 1}-{column}"))
    started = time.perf_counter()
    stops = fewest_stops(grid, "S0-0", "S149-149")
    assert stops == 298, "Not yet: corner to corner of a 150 by 150 grid of stations is 298 stops."
    assert_fast(started, "a map of 22,500 stations")


def test_brackets_balanced_checks_every_kind():
    assert brackets_balanced("(1 + [2 * 3])"), "Not yet: every bracket here is closed by its own kind, in order."
    assert brackets_balanced("total = (price * [1 + tax]) - {discount}"), "Not yet: (, [ and { are each closed in the right order."
    assert brackets_balanced("no brackets"), "Not yet: a line with no brackets is balanced."
    assert not brackets_balanced("(1 + 2]"), "Not yet: ( is closed by ], the wrong kind."
    assert not brackets_balanced("(("), "Not yet: two brackets are never closed."
    assert not brackets_balanced(")("), "Not yet: ) comes before anything it could close."


def test_brackets_balanced_is_fast_for_deep_nesting():
    deep = "(" * 100000 + ")" * 100000
    started = time.perf_counter()
    balanced = brackets_balanced(deep)
    missing_one = brackets_balanced(deep[1:])
    assert balanced, "Not yet: 100,000 ( then 100,000 ) is balanced."
    assert not missing_one, "Not yet: with one ( missing, the last ) has nothing to close."
    assert_fast(started, "checking 200,000 brackets")


def test_blocked_messages_counts_each_senders_last_10_seconds():
    assert blocked_messages([("Kai", 1), ("Kai", 2), ("Kai", 3), ("Kai", 4)]) == 1, "Not yet: Kai's 4th message comes after 3 in the 10 seconds before it, so it's blocked."
    assert blocked_messages([("Kai", 1), ("Kai", 2), ("Kai", 3), ("Kai", 11)]) == 0, "Not yet: at second 11, the message from second 1 is 10 seconds back and no longer counts, so only 2 do."
    assert blocked_messages([("Kai", 1), ("Mia", 1), ("Kai", 2), ("Mia", 2), ("Kai", 3), ("Mia", 3)]) == 0, "Not yet: each sender counts only their own messages: 3 each, none blocked."
    assert blocked_messages(MESSAGES) == 2, "Not yet: Kai's messages at seconds 4 and 9 are blocked."
    assert blocked_messages([]) == 0, "Not yet: no messages, nothing blocked."


def test_blocked_messages_is_fast_for_a_spam_wave():
    # 20 bots each send a message every 3 seconds, 10,000 times: 200,000 messages.
    messages = [(f"bot{i % 20}", (i // 20) * 3) for i in range(200000)]
    started = time.perf_counter()
    blocked = blocked_messages(messages)
    assert blocked == 199940, "Not yet: from each bot's 4th message on, 3 earlier ones sit in the 10 seconds before it, blocked or not: 199,940 blocked."
    assert_fast(started, "checking 200,000 messages")
