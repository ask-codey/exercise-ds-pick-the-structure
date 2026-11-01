# Four small problems from apps you use. The comment under each function says
# what it should return, with examples. Replace each return line with your
# own code, and write the structure you chose on its Structure: line.
from collections import deque


def count_taken(taken, wanted):
    """
    A sign-up form: how many of the wanted usernames are already taken?
    The site has up to 100,000 taken names, and checks a name on every
    visit, so this has to stay fast.

    count_taken(["river_fox", "neon_owl"], ["neon_owl", "lemon_bee"]) -> 1
    count_taken([], ["river_fox"]) -> 0

    Structure: (write the structure you used, and this function's Big-O)
    """
    return 0


def most_played(plays):
    """
    A music app's "most played" badge. Each item in plays is one play of
    a song. Return the title played the most times. A tie goes to the
    title that comes first from A to Z. No plays at all: return "".

    most_played(["Slow Rain", "Lemon Skies", "Slow Rain"]) -> "Slow Rain"
    most_played(["Midnight Bus", "Lemon Skies"]) -> "Lemon Skies"

    Structure: (write the structure you used, and this function's Big-O)
    """
    return ""


def fewest_stops(tracks, start, end):
    """
    A subway app: the fewest stops from start to end. Each
    track joins two neighboring stations, and trains run both ways.
    A station is 0 stops from itself. Return -1 when no tracks join
    them, or when either station isn't on the map.

    On the demo's map:
    fewest_stops(tracks, "Elm", "Harbor") -> 3
    fewest_stops(tracks, "Elm", "Island") -> -1

    Structure: (write the structure you used, and this function's Big-O)
    """
    return 0


def brackets_balanced(text):
    """
    A code editor checks the brackets in a line: every (, [ and { must be
    closed by the same kind, ), ] or }, in the right order. Every other
    character is ignored. A line with no brackets is balanced.

    brackets_balanced("(1 + [2 * 3])") -> True
    brackets_balanced("(1 + 2]") -> False
    brackets_balanced("((") -> False

    Structure: (write the structure you used, and this function's Big-O)
    """
    return False
