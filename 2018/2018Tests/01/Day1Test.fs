module Day1Test

open Xunit

let testPart2 input expected =
    Assert.Equal(Day1.part2 input, expected)

[<Fact>]
let ``Case1`` () =
    testPart2 (List.toSeq [1; -1]) 0

[<Fact>]
let ``Case2`` () =
    testPart2 (List.toSeq [3; 3; 4; -2; -4]) 10

[<Fact>]
let ``Case3`` () =
    testPart2 (List.toSeq [-6; 3; 8; 5; -6]) 5

[<Fact>]
let ``Case4`` () =
    testPart2 (List.toSeq [7; 7; -2; -7; -4]) 14