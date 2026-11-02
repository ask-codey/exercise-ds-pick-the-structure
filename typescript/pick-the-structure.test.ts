// The tests for your five functions. You don't need to change this file.
// Each problem has a test with a big input that is only fast with the right
// structure. If one of them runs for a long time, that's the test telling you
// to choose another structure: stop it with Ctrl+C.
import assert from "node:assert/strict";
import { test } from "node:test";
import { blockedMessages, bracketsBalanced, countTaken, fewestStops, mostPlayed } from "./pick-the-structure.ts";

const TRACKS: [string, string][] = [["Elm", "Oak"], ["Oak", "Pine"], ["Pine", "Harbor"], ["Elm", "Maple"], ["Maple", "Cedar"], ["Cedar", "Pine"], ["Ferry", "Island"]];
const MESSAGES: [string, number][] = [["Kai", 1], ["Kai", 2], ["Mia", 2], ["Kai", 3], ["Kai", 4], ["Kai", 9], ["Kai", 14]];

function assertFast(started: number, what: string): void {
  const seconds = (performance.now() - started) / 1000;
  assert.ok(seconds < 2, `Not yet: ${what} took ${seconds.toFixed(1)} seconds. With the right structure it takes well under one.`);
}

test("countTaken counts the names already used", () => {
  assert.equal(countTaken(["river_fox", "neon_owl"], ["neon_owl", "lemon_bee"]), 1, "Not yet: neon_owl is taken and lemon_bee is free, so 1.");
  assert.equal(countTaken(["river_fox", "neon_owl"], ["neon_owl", "river_fox", "slow_cat"]), 2, "Not yet: neon_owl and river_fox are both taken.");
  assert.equal(countTaken([], ["river_fox"]), 0, "Not yet: with nothing taken, no name is taken.");
});

test("countTaken is fast for 100,000 names", () => {
  const taken: string[] = [];
  const wanted: string[] = [];
  for (let i = 0; i < 100000; i++) {
    taken.push(`user${i}`);
    wanted.push(`user${i * 2}`);
  }
  const started = performance.now();
  const count = countTaken(taken, wanted);
  assert.equal(count, 50000, "Not yet: half of the 100,000 wanted names are taken.");
  assertFast(started, "checking 100,000 names");
});

test("mostPlayed finds the top song", () => {
  assert.equal(mostPlayed(["Slow Rain", "Lemon Skies", "Slow Rain"]), "Slow Rain", "Not yet: Slow Rain was played twice.");
  assert.equal(mostPlayed(["Midnight Bus", "Lemon Skies"]), "Lemon Skies", "Not yet: a tie goes to the title first from A to Z.");
  assert.equal(mostPlayed([]), "", "Not yet: with no plays, return an empty string.");
});

test("mostPlayed is fast for 200,000 plays", () => {
  const plays: string[] = [];
  for (let i = 0; i < 200000; i++) {
    plays.push(`Song ${i % 50000}`);
  }
  plays.push("Song 777", "Song 777", "Song 777");
  const started = performance.now();
  const top = mostPlayed(plays);
  assert.equal(top, "Song 777", "Not yet: every song was played 4 times except Song 777, played 7.");
  assertFast(started, "counting 200,000 plays");
});

test("fewestStops counts the shortest ride", () => {
  assert.equal(fewestStops(TRACKS, "Elm", "Harbor"), 3, "Not yet: Elm, Oak, Pine, Harbor is 3 stops.");
  assert.equal(fewestStops(TRACKS, "Elm", "Cedar"), 2, "Not yet: Elm, Maple, Cedar is 2 stops.");
  assert.equal(fewestStops(TRACKS, "Elm", "Elm"), 0, "Not yet: a station is 0 stops from itself.");
  assert.equal(fewestStops(TRACKS, "Elm", "Island"), -1, "Not yet: no tracks join Elm and Island.");
  assert.equal(fewestStops(TRACKS, "Elm", "Airport"), -1, "Not yet: Airport isn't on the map.");
});

test("fewestStops is fast on a big map", () => {
  const grid: [string, string][] = [];
  for (let row = 0; row < 150; row++) {
    for (let column = 0; column < 150; column++) {
      if (column < 149) grid.push([`S${row}-${column}`, `S${row}-${column + 1}`]);
      if (row < 149) grid.push([`S${row}-${column}`, `S${row + 1}-${column}`]);
    }
  }
  const started = performance.now();
  const stops = fewestStops(grid, "S0-0", "S149-149");
  assert.equal(stops, 298, "Not yet: corner to corner of a 150 by 150 grid of stations is 298 stops.");
  assertFast(started, "a map of 22,500 stations");
});

test("bracketsBalanced checks every kind", () => {
  assert.ok(bracketsBalanced("(1 + [2 * 3])"), "Not yet: every bracket here is closed by its own kind, in order.");
  assert.ok(bracketsBalanced("total = (price * [1 + tax]) - {discount}"), "Not yet: (, [ and { are each closed in the right order.");
  assert.ok(bracketsBalanced("no brackets"), "Not yet: a line with no brackets is balanced.");
  assert.ok(!bracketsBalanced("(1 + 2]"), "Not yet: ( is closed by ], the wrong kind.");
  assert.ok(!bracketsBalanced("(("), "Not yet: two brackets are never closed.");
  assert.ok(!bracketsBalanced(")("), "Not yet: ) comes before anything it could close.");
});

test("bracketsBalanced is fast for deep nesting", () => {
  const deep = "(".repeat(100000) + ")".repeat(100000);
  const started = performance.now();
  const balanced = bracketsBalanced(deep);
  const missingOne = bracketsBalanced(deep.slice(1));
  assert.ok(balanced, "Not yet: 100,000 ( then 100,000 ) is balanced.");
  assert.ok(!missingOne, "Not yet: with one ( missing, the last ) has nothing to close.");
  assertFast(started, "checking 200,000 brackets");
});

test("blockedMessages counts each sender's last 10 seconds", () => {
  assert.equal(blockedMessages([["Kai", 1], ["Kai", 2], ["Kai", 3], ["Kai", 4]]), 1, "Not yet: Kai's 4th message comes after 3 in the 10 seconds before it, so it's blocked.");
  assert.equal(blockedMessages([["Kai", 1], ["Kai", 2], ["Kai", 3], ["Kai", 11]]), 0, "Not yet: at second 11, the message from second 1 is 10 seconds back and no longer counts, so only 2 do.");
  assert.equal(blockedMessages([["Kai", 1], ["Mia", 1], ["Kai", 2], ["Mia", 2], ["Kai", 3], ["Mia", 3]]), 0, "Not yet: each sender counts only their own messages: 3 each, none blocked.");
  assert.equal(blockedMessages(MESSAGES), 2, "Not yet: Kai's messages at seconds 4 and 9 are blocked.");
  assert.equal(blockedMessages([]), 0, "Not yet: no messages, nothing blocked.");
});

test("blockedMessages is fast for a spam wave", () => {
  // 20 bots each send a message every 3 seconds, 40,000 times: 800,000 messages.
  const messages: [string, number][] = [];
  for (let i = 0; i < 800000; i++) {
    messages.push([`bot${i % 20}`, Math.floor(i / 20) * 3]);
  }
  const started = performance.now();
  const blocked = blockedMessages(messages);
  assert.equal(blocked, 799940, "Not yet: from each bot's 4th message on, 3 earlier ones sit in the 10 seconds before it, blocked or not: 799,940 blocked.");
  assertFast(started, "checking 800,000 messages");
});
