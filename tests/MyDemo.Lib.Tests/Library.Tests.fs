module Tests

open VerifyXunit
open Xunit

open MyDemo.Lib.Api

[<Fact>]
let ``Adding 2 numbers with a lib works`` () =
    let result = add 1 2
    Assert.Equal(3, result)

[<Fact>]
let ``Working with Verify 0: (native calls)`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    let newMap = Map.add 3 "c" simpleMap
    Verifier.Verify(newMap).ToTask() |> Async.AwaitTask
    
[<Fact>]
let ``Working with Verify 1: (native calls)`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    let newMap = Map.add 3 "c" simpleMap
    // which part of the Verify API don't I understand?
    let verify value = Verifier.Verify(value).ToTask()
    verify(newMap) |> Async.AwaitTask
    