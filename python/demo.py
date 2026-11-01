# Tries your functions on small examples. Run it with: python demo.py
from pick_the_structure import brackets_balanced, count_taken, fewest_stops, most_played

taken = ["river_fox", "neon_owl", "paper_kite"]
wanted = ["neon_owl", "lemon_bee", "river_fox", "slow_cat"]
plays = ["Slow Rain", "Lemon Skies", "Slow Rain", "Midnight Bus", "Lemon Skies", "Slow Rain"]
tracks = [("Elm", "Oak"), ("Oak", "Pine"), ("Pine", "Harbor"), ("Elm", "Maple"), ("Maple", "Cedar"), ("Cedar", "Pine"), ("Ferry", "Island")]

print(f"Taken: {count_taken(taken, wanted)} of {len(wanted)} wanted names")
print(f"Most played: {most_played(plays)}")
print(f"Fewest stops from Elm to Harbor: {fewest_stops(tracks, 'Elm', 'Harbor')}")
for line in ["total = (price * [1 + tax]) - {discount}", "(1 + 2]"]:
    print(line + ": " + ("balanced" if brackets_balanced(line) else "not balanced"))
