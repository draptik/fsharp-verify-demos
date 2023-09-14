[<VerifyXunit.UsesVerify>]
module Tests

open Xunit
    
[<Fact(Skip = "Ignore, because the verified file is placed next to the code")>]
let ``Example 1`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    Verifier.verify simpleMap

[<Fact>]
let ``Example 2 using a custom output folder`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    Verifier.verify' Verifier.verifySettings simpleMap

let verify value =
    Verifier.verify' Verifier.verifySettings value

[<Fact>]
let ``Example 3 another wrapper`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    verify simpleMap

[<Fact>]
let ``Example 4 diff tool`` () =
    Verifier.initializeDiffTool ()
    let simpleMap = Map [1, "a"; 2, "b1"]
    verify simpleMap
