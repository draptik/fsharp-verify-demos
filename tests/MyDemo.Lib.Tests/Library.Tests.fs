[<VerifyXunit.UsesVerify>]
module Tests

open System
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

/// Verify shouldn't be used for checking the internal data structure anyway.
/// The whole point of Verify (and similar Golden-Master testing tools) is to
/// test the result at the boundary of the application (i.e. the public API).
/// 
/// So testing F# specific types is not a good idea.
[<VerifyXunit.UsesVerify>]
module DontDoThis =

    [<Fact>]
    let ``SimpleName is verifiable`` () =
        let sut = { SimpleName.FirstName = "Homer"; LastName = "Simpson" }
        Verifier.verify sut

    [<Fact(Skip = "This fails: An F# option type isn't serialized correctly by default")>]
    let ``SimpleNameOption is verifiable when value is present`` () =
        let sut = { SimpleNameOption.FirstName = Some "Homer"; LastName = "Simpson" }
        Verifier.verify sut

    [<Fact(Skip = "This fails: An F# option type isn't serialized correctly by default")>]
    let ``SimpleNameOption is verifiable when value is missing`` () =
        let sut = { SimpleNameOption.FirstName = None; LastName = "Simpson" }
        Verifier.verify sut


    [<Fact(Skip = "This fails: An F# discriminated union isn't serialized correctly by default")>]
    let ``PaymentMethod is verifiable when value is CreditCard`` () =
        let sut = CreditCard { CardNumber = "123"; ExpiryDate = new DateTime(2019, 1, 1) }
        Verifier.verify sut
