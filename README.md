# Exercise: Pick the Structure

Exercise code for the lesson **Exercise: Pick the Structure** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

## The tickets

Five tickets from apps you use. Each one is quick to get right on a small input, and only fast on a big one with the right choice. For each, choose the structure, write the function, and name your choice and its Big-O on the function's **Structure:** line.

> 1. **Sign-up:** "How many of these wanted usernames are already taken? We have 100,000 taken names, and check on every visit."
> 2. **Music app:** "Show a 'most played' badge: the title played the most times, ties going to the title first from A to Z. A busy day is 200,000 plays."
> 3. **Subway app:** "Show the fewest stops between two stations. Each track joins two neighboring stations, and the new map has 22,500 stations."
> 4. **Code editor:** "Warn when the brackets in a line don't match: every `(`, `[` and `{` closed by the same kind, in the right order. Some generated files nest 100,000 deep."
> 5. **Chat room:** "Block spam. A message is blocked when its sender already sent 3 or more messages in the 10 seconds before it, and every message counts, blocked or not. Count the blocked ones. A spam wave is 200,000 messages."

The functions, one per ticket:

- `countTaken` (`CountTaken` in C#, `count_taken` in Python): the sign-up form
- `mostPlayed` (`MostPlayed`, `most_played`): the "most played" badge
- `fewestStops` (`FewestStops`, `fewest_stops`): the subway app
- `bracketsBalanced` (`BracketsBalanced`, `brackets_balanced`): the code editor
- `blockedMessages` (`BlockedMessages`, `blocked_messages`): the chat room's spam guard

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `PickTheStructure/Problems.cs` | `PickTheStructure.Tests/ProblemsTests.cs` |
| `java/` | `src/main/java/Problems.java` | `src/test/java/ProblemsTest.java` |
| `python/` | `pick_the_structure.py` | `test_pick_the_structure.py` |
| `javascript/` | `pick-the-structure.js` | `pick-the-structure.test.js` |
| `typescript/` | `pick-the-structure.ts` | `pick-the-structure.test.ts` |

Each function returns `0`, an empty string or `false` for now. The comment above it says what it should return, with examples. Replace the `return` line with your own code, and write the structure you chose, with its Big-O, on the function's **Structure:** line.

Every folder also has a small demo program that tries your functions on small examples. You don't need to change the tests or the demo.

## Run it and check your work

Open your language's folder in VS Code (**File > Open Folder**), then open its terminal (**Terminal > New Terminal**) and run these commands there.

**C#**

```bash
dotnet run --project PickTheStructure
dotnet test
```

**Java** (the Maven Wrapper downloads Maven the first time, so the first run takes a minute)

```bash
java src/main/java/Demo.java
./mvnw test
```

On Windows in PowerShell, write `.\mvnw test` instead of `./mvnw test`.

**Python** (once: make a virtual environment and install pytest into it)

```bash
python -m venv .venv
```

Then turn it on: `.venv\Scripts\Activate.ps1` in PowerShell on Windows, or `source .venv/bin/activate` on macOS (where the command is `python3`, not `python`). Then:

```bash
pip install -r requirements.txt
python demo.py
python -m pytest
```

**JavaScript**

```bash
node demo.js
npm test
```

**TypeScript** (once: `npm install`, which installs TypeScript)

```bash
node demo.ts
npm test
```

At first every test fails: that is expected. Each function you finish turns its tests green. A failing test's message starts with **Not yet:** and says what it expected.

Each ticket also has a test with its big input, such as 100,000 usernames, that has to finish in under 2 seconds. With the right structure it takes a small fraction of that. If a test seems stuck, that's the test telling you to choose another structure: stop it with **Ctrl+C**.

<details>
<summary>Stuck?</summary>

Try each ticket on your own first; these name the structures.

- **Start from the job each function does most,** as in the lesson *The Feature Is Slow: Which Structure Fixes It?*: checking a name, counting a title, finding the next station, closing the newest bracket, forgetting messages more than 10 seconds old.
- **Taken names:** a **set** answers "is this name in there?" in O(1) on average.
- **Most played:** a **dictionary** from each title to its count.
- **Fewest stops:** an **adjacency list** of the stations and **breadth-first search** with a queue.
- **Brackets:** a **stack** of the brackets still open. A recursive answer may run out of call stack on the deep test; a stack of your own won't.
- **Spam guard:** a **dictionary** from each sender to a **queue** of their recent seconds. New seconds join at the back; seconds 10 or more back leave from the front.
- **A correct answer that's too slow is a "not yet", not a failure.** Keep the small tests passing and change the structure.

</details>

<details>
<summary>Why Should I Choose This?</summary>

Open this once your tests are green.

- **Taken names:** a list makes each check read up to 100,000 names: 100,000 checks is up to 10 billion comparisons. A set makes each check one lookup, so the whole job is O(t + w).
- **Most played:** sorting the 200,000 plays first works in O(n log n); a dictionary of counts does it in one pass, O(n). Scanning a list of titles for each play is O(n × titles), 10 billion steps with 50,000 titles.
- **Fewest stops:** trying every route is exponential, and a depth-first walk finds *a* route, not the fewest. Breadth-first search visits each of the 22,500 stations once, O(V + E).
- **Brackets:** counting brackets can't tell `(]` from `()`. A stack checks each bracket once, O(n), and never runs out of call stack.
- **Spam guard:** checking every earlier message for each new one is O(n²): with 200,000 messages it took 94 seconds in C#, and ran more than 4 minutes in Python before we stopped it. Keeping each sender's whole history and counting it every time is better, but still slow when a sender has thousands of messages: 27 seconds in Python, 1.7 in C#. A queue per sender holds only the last 10 seconds, and each second joins and leaves it once, O(n): under a tenth of a second in both.

</details>

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
