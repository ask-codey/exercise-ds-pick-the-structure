// Tries your functions on small examples. Run it with: node demo.js
import { blockedMessages, bracketsBalanced, countTaken, fewestStops, mostPlayed } from "./pick-the-structure.js";

const taken = ["river_fox", "neon_owl", "paper_kite"];
const wanted = ["neon_owl", "lemon_bee", "river_fox", "slow_cat"];
const plays = ["Slow Rain", "Lemon Skies", "Slow Rain", "Midnight Bus", "Lemon Skies", "Slow Rain"];
const tracks = [["Elm", "Oak"], ["Oak", "Pine"], ["Pine", "Harbor"], ["Elm", "Maple"], ["Maple", "Cedar"], ["Cedar", "Pine"], ["Ferry", "Island"]];
const messages = [["Kai", 1], ["Kai", 2], ["Mia", 2], ["Kai", 3], ["Kai", 4], ["Kai", 9], ["Kai", 14]];

console.log(`Taken: ${countTaken(taken, wanted)} of ${wanted.length} wanted names`);
console.log(`Most played: ${mostPlayed(plays)}`);
console.log(`Fewest stops from Elm to Harbor: ${fewestStops(tracks, "Elm", "Harbor")}`);
for (const line of ["total = (price * [1 + tax]) - {discount}", "(1 + 2]"]) {
  console.log(`${line}: ${bracketsBalanced(line) ? "balanced" : "not balanced"}`);
}
console.log(`Blocked: ${blockedMessages(messages)} of ${messages.length} messages`);
