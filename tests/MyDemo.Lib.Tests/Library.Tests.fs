[<VerifyXunit.UsesVerify>]
module Tests

open Xunit
open MyDemo.Lib

[<Fact(Skip = "Ignore, because the verified file is placed next to the code")>]
let ``Example 1`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    Verifier.verify_internal simpleMap

[<Fact>]
let ``Example 2 using a custom output folder`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    Verifier.verify_internal_with_settings Verifier.verifySettings simpleMap

[<Fact>]
let ``Example 3 another wrapper`` () =
    let simpleMap = Map [1, "a"; 2, "b"]
    Verifier.verify simpleMap

[<Fact>]
let ``Example 4 diff tool`` () =
    Verifier.initializeDiffTool ()
    let simpleMap = Map [1, "a"; 2, "b1"]
    Verifier.verify simpleMap

[<Fact>]
let ``SimpleName works`` () =
    let sut = { FirstName = "Homer"; LastName = "Simpson" }
    Verifier.verify sut
