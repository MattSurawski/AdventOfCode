module Day1

open System.Collections.Generic
open System.IO

let part1 inseq =
    inseq
    |> Seq.fold (+) 0

let part2 inseq =
    let infiniteInput = seq { while true do yield! inseq }
    let frequencies = new HashSet<int>()
    // Not very functional, but even the F# source code cheats sometimes https://github.com/fsharp/fsharp/blob/master/src/fsharp/FSharp.Core/seq.fs#L658
    use e = infiniteInput.GetEnumerator()
    let mutable frequency = 0
    while (not (frequencies.Contains(frequency)) && e.MoveNext()) do
        printfn "Initial frequency: %d current: %d seen: %s" frequency e.Current (System.String.Join(", ", frequencies))
        frequencies.Add(frequency) |> ignore
        frequency <- frequency + e.Current
        printfn "Next    frequency: %d current: %d seen: %s" frequency e.Current (System.String.Join(", ", frequencies))
    frequency
    

let main() =
    use instream = new StreamReader("../../../01/input.txt")
    let inseq = seq { while not instream.EndOfStream do yield instream.ReadLine() |> int }
    printfn "Day 1 Part 1's solution is: %d" (part1 inseq)
    printfn "Day 1 Part 2's solution is: %d" (part2 inseq)
    ()