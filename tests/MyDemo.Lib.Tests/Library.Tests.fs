[<VerifyXunit.UsesVerify>]
module Tests

open Xunit
    
[<Fact>]
let ``Working with Verify - Example 1`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    let newMap = Map.add 3 "c" simpleMap
    Verifier.verify(newMap)
