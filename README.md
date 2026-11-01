# Exercise: Pick the Structure

Exercise code for the lesson **Exercise: Pick the Structure** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

Four small problems from apps you use. Each one is quick to get right on a small input, and only fast on a big one with the right structure. For each, choose the structure, write the function, and name your choice and its Big-O on the function's **Structure:** line:

- `countTaken` (`CountTaken` in C#, `count_taken` in Python): a sign-up form, counting how many wanted usernames are already taken
- `mostPlayed` (`MostPlayed`, `most_played`): a music app's "most played" badge
- `fewestStops` (`FewestStops`, `fewest_stops`): a subway app's fewest stops between two stations
- `bracketsBalanced` (`BracketsBalanced`, `brackets_balanced`): a code editor checking that every bracket is closed by the right kind

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

Each problem also has a test with a big input, such as 100,000 usernames, that has to finish in under 2 seconds. With the right structure it takes a small fraction of that. If a test seems stuck, that's the test telling you to choose another structure: stop it with **Ctrl+C**.

## Tips

- **Start from the job each function does most,** as in *Choosing the Right Structure*: checking a name, counting a title, finding the next station, closing the newest bracket.
- **Each problem has a structure from the course that makes its main step O(1),** or makes the whole job O(n) or O(V + E). The cost cards in *Choosing the Right Structure* are a good place to look.
- **A correct answer that's too slow is a "not yet", not a failure.** Keep the small tests passing and change the structure.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
